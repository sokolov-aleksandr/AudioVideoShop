///<summary>
/// Для работы необходимы драйвера Access
/// https://www.microsoft.com/en-us/download/details.aspx?id=54920
/// </summary>

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
        private OleDbConnection connection = null; // Соединение для работы с БД

        public Showcase()
        {
            InitializeComponent();
        }

        private void Showcase_Load(object sender, EventArgs e)
        {
            ConnectDatabase();
            UpdateCatalog(connection);
        }

        public void CreateProduct(string productName, string productCategory,
            decimal productPrice, bool inStock,
            string productDescription, string pathToImage)
        {
            try
            {
                // SQL-запрос на добавление
                string query = "INSERT INTO Products (productName, category, price, inStock, description, imagePath) " +
                               "VALUES (@name, @category, @price, @inStock, @description, @imagePath)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", productName);
                    command.Parameters.AddWithValue("@category", productCategory);
                    command.Parameters.AddWithValue("@price", productPrice);
                    command.Parameters.AddWithValue("@inStock", inStock);
                    command.Parameters.AddWithValue("@description", productDescription);
                    command.Parameters.AddWithValue("@imagePath", pathToImage);

                    command.ExecuteNonQuery(); // Выполняем SQL-запрос
                }

                // Добавляем товар на форму (визуально)
                ProductCard productCard = new ProductCard();
                productCard.SetProduct(productName, productPrice, pathToImage, inStock);
                flowLayoutPanelProductCatalog.Controls.Add(productCard);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара в базу данных:\n" + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectDatabase()
        {
            string dbRelativePath = Path.Combine("Data", "Shop.accdb");             // Получаем относительный путь базы данных
            string dbFullPath = Path.Combine(Application.StartupPath, dbRelativePath);  // Делаем из него абсолютный путь
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFullPath};"; // Полный путь соединения до базы данных
            connection = new OleDbConnection(connectionString); // Создаём соединение с базой данных
            connection.Open(); // Открываем соединение с базой данных

        }

        private void UpdateCatalog(OleDbConnection connection)
        {
            string query = "SELECT * FROM Products"; // SQL-запрос для получения ВСЕХ значений из таблицы Products
            OleDbCommand command = new OleDbCommand(query, connection); // Создаём команду на выполнение запроса с открытым соединением
            OleDbDataReader reader = command.ExecuteReader(); // Выполняем запрос и получаем читатель построчный

            while (reader.Read()) // Читаем по строкам
            {
                string name = reader["productName"].ToString();             // Название товара
                decimal price = decimal.Parse(reader["price"].ToString(),   // Цена товара
                    System.Globalization.CultureInfo.InvariantCulture);     //             (Принудительно меняем культуру, чтобы разделителем была точка, а не запятая)
                string imagePath = reader["imagePath"].ToString();          // Путь к картинке товара
                bool inStock = (bool)reader["inStock"];

                ProductCard productCard = new ProductCard(); // Экземпляр карточки товара 
                productCard.SetProduct(name, price, imagePath, inStock); // Заполняем информацию
                flowLayoutPanelProductCatalog.Controls.Add(productCard); // Добавляем карточку на панель в форме
            }
            reader.Close(); // Закрываем читатель
        }

        private void Showcase_FormClosing(object sender, FormClosingEventArgs e) // При закрытии формы
        {
            var result = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close(); // Закрываем соединение с базой данных
                }
            }
            else
            {
                e.Cancel = true; // Отменяем закрытие
            }
        }

        // Добавление нового товара
        private void button1_Click(object sender, EventArgs e) 
        {
            AddProductForm addProductForm = new AddProductForm(this);
            addProductForm.ShowDialog();
        }
    }
}
