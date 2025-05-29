using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using AudioVideoShop.Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AudioVideoShop
{
    public partial class Showcase : Form
    {
        ProductsDataSource productsData; // Класс для работы с БД
        AccountDataSource accountsData;
        AccessTableSynchronizer tableSynchronizer;

        public Showcase()
        {
            InitializeComponent();
        }

        private void Showcase_Load(object sender, EventArgs e)
        {
            // Обрабатываем интерфейс под роль пользователя
            HandlingAccountRole(Session.CurrentUser.Role);
            usernameLabel.Text = Session.CurrentUser.Username;

            accountsData = new AccountDataSource();
            productsData = new ProductsDataSource(); // Объявляем тут, чтобы вызвать конструктор создающий соединение с БД
            tableSynchronizer = new AccessTableSynchronizer("Products");
            UpdateCatalog();
            comboBoxCategoryFilter.SelectedIndex = 0; // По умолчанию — показывать все

            // При открытии делаем фокус на эту форму
            this.BringToFront(); // TODO фикси это, всё равно главной становится главная форма
            this.Activate();
        }

        public void CreateProductCard(Product product)
        {
            productsData.AddProductToDB(product); // Добавляем товар в базу данных

            // Добавляем товар на форму (визуально)
            flowLayoutPanelProductCatalog.Controls.Add(CreateCard(product));
        }

        private ProductCard CreateCard(Product p)
        {
            var card = new ProductCard(this, p);
            card.SetProduct(p);
            return card;
        }


        public void UpdateProduct(Product product)
        {
            productsData.UpdateProductInDB(product);
            UpdateCatalog();
        }

        private void UpdateCatalog()
        {
            List<Product> products = productsData.LoadProducts();
            UpdateCatalogUI(products);
        }

        private void UpdateCatalogUI(List<Product> products)
        {
            flowLayoutPanelProductCatalog.Controls.Clear(); // Очистим панель перед добавлением новых карточек

            foreach (var product in products)
            {
                flowLayoutPanelProductCatalog.Controls.Add(CreateCard(product));
            }
        }


        // Добавление нового товара
        private void button1_Click(object sender, EventArgs e) 
        {
            AddProductForm addProductForm = new AddProductForm(this);
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
                productsData.Dispose();
                Form1.Instance.Show();
            }
        }
        
        public void DeleteProductCard(int id)
        {
            productsData.DeleteProductById(id); // Удаляем из БД

            // Поиск и удаление визуальной карточки
            foreach (Control control in flowLayoutPanelProductCatalog.Controls)
            {
                if (control is ProductCard card && card.Product.Id == id)
                {
                    flowLayoutPanelProductCatalog.Controls.Remove(card);
                    card.Dispose(); // Освобождаем ресурсы
                    break;
                }
            }
        }

        public void AddToCart(Product product)
        {
            Session.CurrentUser.Cart.AddItem(product);
        }

        private void comboBoxCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxCategoryFilter.SelectedItem.ToString();
            List<Product> allProducts = productsData.LoadProducts();

            if (selectedCategory != "Все")
            {
                allProducts = allProducts.Where(p => p.Category == selectedCategory).ToList();
            }

            UpdateCatalogUI(allProducts);
        }

        private void HandlingAccountRole(AccountRole role)
        {
            var roleActions = new Dictionary<AccountRole, Action>
            {
                // Роль Админа
                [AccountRole.admin] = () =>
                {
                    // Действия:
                    AdminGroupBox.Visible = true;
                    tabControl1.TabPages[1].Text = "База данных";
                    tabControl1.TabPages[1].Enabled = true;
                },

                // Роль обычного пользователя (Покупателя)
                [AccountRole.user] = () =>
                {
                    // Действия:
                    AdminGroupBox.Visible = false;
                    tabControl1.TabPages.Remove(tabPage2);
                }
            };

            if (roleActions.TryGetValue(role, out var action))
            {
                action.Invoke();
            }
            else
            {
                MessageBox.Show("Неизвестная роль. \nУкажите роль и её действия!");
            }
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount(accountsData, Session.CurrentUser.Role);
            createAccount.ShowDialog();
        }

        private void buttonOpenCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(Session.CurrentUser.Cart);
            cartForm.ShowDialog();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                tableSynchronizer.LoadToGrid(dataGridView1);
                
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    ChangeTable(comboBox1.Text);
                    tableSynchronizer.RefreshGrid(dataGridView1, tableSynchronizer.tableName);
                }
            }

            if (tabControl1.SelectedIndex == 0)
            {
                UpdateCatalog();
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
                tableSynchronizer.RefreshGrid(dataGridView1, tableSynchronizer.tableName);
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            tableSynchronizer.SaveChanges();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            MessageBox.Show("Изменения успешно сохранены");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeTable(comboBox1.Text);
        }

        private void ChangeTable(string nameTable)
        {
            tableSynchronizer.tableName = nameTable;
            tableSynchronizer.RefreshGrid(dataGridView1, nameTable);
            AdjustDataGridViewColumns(dataGridView1);

            // Обновление колонок для поиска
            List<string> columns = tableSynchronizer.GetColumnNames();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(columns.ToArray()); // Каждое имя на новой строке

        }

        private void AdjustDataGridViewColumns(DataGridView dgv)
        {
            // Настройка авторазмера столбцов — растянуть на всю ширину
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Пройтись по всем столбцам и задать выравнивание
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                // Если это первый столбец, выравниваем по правому краю
                if (column.Index == 0)
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                else
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Остальные по левому краю
            }
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Style.BackColor = Color.LightBlue; // Цвет для подсветки
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Фильтрует строки в dataGridView1 по выбранной колонке и тексту поиска.
        /// Работает для любых типов столбцов за счёт конвертации в строку.
        /// </summary>
        private void ApplySearchFilter()
        {
            // Проверяем выбор колонки
            string column = comboBox2.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(column))
            {
                MessageBox.Show("Пожалуйста, выберите колонку для поиска.");
                return;
            }

            // Текст для поиска
            string searchText = textBoxSearch.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Пожалуйста, введите текст для поиска.");
                return;
            }

            // Получаем DataTable из грида
            if (!(dataGridView1.DataSource is DataTable dt))
                return;

            try
            {
                // Конвертируем содержимое ANY-столбца в строку и применяем LIKE
                string filter = $"Convert([{column}], 'System.String') LIKE '%{searchText}%'";
                dt.DefaultView.RowFilter = filter;
            }
            catch (EvaluateException ex)
            {
                // На случай, если Convert не сработает — просто сбрасываем фильтр и ругаемся
                dt.DefaultView.RowFilter = string.Empty;
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}");
            }
        }


        /// <summary>
        /// Сбрасывает фильтр и возвращает таблицу к исходному (полностью загруженному) виду.
        /// </summary>
        private void ClearSearchFilter()
        {
            // Очищаем текст и фильтр
            textBoxSearch.Clear();

            if (dataGridView1.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            ClearSearchFilter();
        }
    }
}
