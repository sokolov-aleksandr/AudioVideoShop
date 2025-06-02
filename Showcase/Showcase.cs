using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AudioVideoShop.Login;
using AudioVideoShop.Services;

namespace AudioVideoShop
{
    public partial class Showcase : Form, IRoleConfigurable
    {
        #region Constants

        public GroupBox AdminPanel => AdminGroupBox;
        public TabControl MainTabControl => tabControl1;
        public TabPage AdminTabPage => tabPage2;

        private ProductCatalogManager _catalogManager;
        private ProductsDataSource _productsData;
        private AccountDataSource _accountsData;
        private AccessTableSynchronizer _tableSynchronizer;
        private SearchHelper _searchHelper;

        #endregion

        #region Start

        public Showcase()
        {
            InitializeComponent();
        }

        private void Showcase_Load(object sender, EventArgs e)
        {
            // Обрабатываем интерфейс под роль пользователя
            RoleConfigurator.Apply(Session.CurrentUser.Role, this);

            usernameLabel.Text = Session.CurrentUser.Username;

            // Инициализация источников данных
            _accountsData = new AccountDataSource();
            _productsData = new ProductsDataSource();
            _catalogManager = new ProductCatalogManager(_productsData, flowLayoutPanelProductCatalog);
            _searchHelper = new SearchHelper();
            _tableSynchronizer = new AccessTableSynchronizer("Products");

            // Подгружаем все карточки из базы и рендерим
            _catalogManager.UpdateCatalogFromDatabase();
            comboBoxCategoryFilter.SelectedIndex = 0; // По умолчанию показывать все

            // При открытии делаем фокус на эту форму
            this.BringToFront();
            this.Activate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Создание карточки товара с информацией о продукте
        /// </summary>
        /// <param name="product">Информация о продукте</param>
        public void CreateProductCard(Product product)
        {
            _catalogManager.CreateProductCard(product);
        }

        /// <summary>
        /// Обновление продукта в базе данных
        /// </summary>
        /// <param name="product">Новая информация о продукте</param>
        public void UpdateProduct(Product product)
        {
            _catalogManager.UpdateProduct(product);
        }

        /// <summary>
        /// Полное удаление карточки товара
        /// </summary>
        /// <param name="id">id товара в базе данных</param>
        public void DeleteProductCard(int id)
        {
            _catalogManager.DeleteProduct(id);
        }

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="product">Товар для добавления</param>
        public void AddToCart(Product product)
        {
            Session.CurrentUser.Cart.AddItem(product);
        }

        #endregion

        #region Private Event Handlers
        private void button1_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProductForm(this);
            addProductForm.ShowDialog();
        }

        private void Showcase_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Выйти из программы?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Отмена закрытия формы
            }
            else
            {
                // Освобождаем ресурсы от БД
                _catalogManager.Dispose();
                Form1.Instance.Show();
            }
        }

        private void comboBoxCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxCategoryFilter.SelectedItem.ToString();
            _catalogManager.FilterByCategory(selectedCategory);
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            var createAccount = new CreateAccount(_accountsData, Session.CurrentUser.Role);
            createAccount.ShowDialog();
        }

        private void buttonOpenCart_Click(object sender, EventArgs e)
        {
            var cartForm = new CartForm(Session.CurrentUser.Cart);
            cartForm.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                _tableSynchronizer.LoadToGrid(dataGridView1);

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    ChangeTable(comboBox1.Text);
                    _tableSynchronizer.RefreshGrid(dataGridView1, _tableSynchronizer.tableName);
                }
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                _catalogManager.UpdateCatalogFromDatabase();
            }
        }

        private void buttonDeleteChanges_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы действительно хотите отменить все изменения и обновить таблицу из базы данных?",
                "Подтверждение действия",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _tableSynchronizer.RefreshGrid(dataGridView1, _tableSynchronizer.tableName);
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            _tableSynchronizer.SaveChanges();

            // Сбрасываем фон всех ячеек в белый после сохранения
            DataGridViewStyler.ResetAllCellsBackground(dataGridView1);

            MessageBox.Show("Изменения успешно сохранены");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeTable(comboBox1.Text);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewStyler.HighlightModifiedCell(cell);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string column = comboBox2.SelectedItem?.ToString();
            string searchText = textBoxSearch.Text.Trim();
            _searchHelper.ApplySearchFilter(dataGridView1, column, searchText);
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            _searchHelper.ClearSearchFilter(dataGridView1);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Меняет таблицу в админке и обновляет колонки для поиска
        /// </summary>
        private void ChangeTable(string nameTable)
        {
            _tableSynchronizer.tableName = nameTable;
            _tableSynchronizer.RefreshGrid(dataGridView1, nameTable);

            // Настраиваем колонки (авторазмер, выравнивание)
            DataGridViewStyler.AdjustColumns(dataGridView1);

            // Обновление списка колонок для поиска
            var columns = _tableSynchronizer.GetColumnNames();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(columns.ToArray());
        }

        #endregion
    }
}
