using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public class ProductsDataSource : AccessDataSource
    {
        public ProductsDataSource() : base() { }

        public void AddProductToDB(Product product)
        {
            try
            {
                // SQL-запрос на добавление
                string query = "INSERT INTO Products (productName, category, price, inStock, description, imagePath) " +
                               "VALUES (@name, @category, @price, @inStock, @description, @imagePath)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@category", product.Category);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@inStock", product.InStock);
                    command.Parameters.AddWithValue("@description", product.Decription);
                    command.Parameters.AddWithValue("@imagePath", product.ImagePath);

                    command.ExecuteNonQuery(); // Выполняем SQL-запрос
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара в базу данных:\n" + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Product> LoadProducts()
        {
            var products = new List<Product>();

            string query = "SELECT * FROM Products"; // SQL-запрос для получения ВСЕХ значений из таблицы Products
            OleDbCommand command = new OleDbCommand(query, connection); // Создаём команду на выполнение запроса с открытым соединением

            using (OleDbDataReader reader = command.ExecuteReader()) // Создаём читатель
            {
                while (reader.Read()) // Читаем по строкам
                {
                    string productName = reader["productName"].ToString();             // Название товара
                    decimal productPrice = decimal.Parse(reader["price"].ToString(),   // Цена товара
                        System.Globalization.CultureInfo.InvariantCulture);            //           (Принудительно меняем культуру,
                                                                                       //           чтобы разделителем была точка, а не запятая)
                    string pathToImage = reader["imagePath"].ToString();               // Путь к картинке товара
                    bool inStock = (bool)reader["inStock"];                            // Товар в наличии или нет 
                    string productCategory = reader["category"].ToString();            // Категория товара
                    string productDescription = reader["description"].ToString();      // Текстовое описание товара

                    Product product = new Product(productName, productPrice, pathToImage, inStock, productCategory, productDescription);
                    products.Add(product);
                }
            }

            return products;
        }


    }
}
