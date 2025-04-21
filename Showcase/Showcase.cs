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

namespace AudioVideoShop
{
    public partial class Showcase : Form
    {
        ProductsDataSource productsData; // Класс для работы с БД

        public Showcase()
        {
            InitializeComponent();
        }

        private void Showcase_Load(object sender, EventArgs e)
        {
            // Обрабатываем интерфейс под роль пользователя
            HandlingAccountRole(Session.CurrentUser.Role);
            
            productsData = new ProductsDataSource(); // Объявляем тут, чтобы вызвать конструктор создающий соединение с БД
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
            ProductCard productCard = new ProductCard(this, product);
            productCard.SetProduct(product);
            flowLayoutPanelProductCatalog.Controls.Add(productCard);
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
                ProductCard productCard = new ProductCard(this, product);
                productCard.SetProduct(product);
                flowLayoutPanelProductCatalog.Controls.Add(productCard);
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
                    buttonAddProduct.Visible = true;
                },

                // Роль обычного пользователя (Покупателя)
                [AccountRole.user] = () =>
                {
                    // Действия:
                    buttonAddProduct.Visible = false;
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
    }
}
