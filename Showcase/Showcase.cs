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
            productsData = new ProductsDataSource(); // Объявляем тут, чтобы вызвать конструктор создающий соединение с БД
            UpdateCatalog();
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
    }
}
