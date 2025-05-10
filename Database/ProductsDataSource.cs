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
                // Найти ID категории по названию
                int categoryId = GetCategoryIdByName(product.Category);
                if (categoryId == -1)
                {
                    MessageBox.Show("Категория '" + product.Category + "' не найдена в базе данных.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL-запрос на добавление
                string query = "INSERT INTO Products (productName, categoryID, price, quantity, description, imagePath) " +
                               "VALUES (@name, @categoryID, @price, @quantity, @description, @imagePath)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@categoryID", categoryId);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@description", product.Decription);
                    command.Parameters.AddWithValue("@imagePath", product.ImagePath);

                    command.ExecuteNonQuery();
                }

                // Получаем ID последней вставленной записи
                using (OleDbCommand idCommand = new OleDbCommand("SELECT @@IDENTITY", connection))
                {
                    object result = idCommand.ExecuteScalar();
                    if (result != null)
                    {
                        product.Id = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара в базу данных:\n" + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCategoryIdByName(string categoryName)
        {
            string query = "SELECT ID FROM Categories WHERE categoryName = @name";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", categoryName);

                object result = command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return -1; // Категория не найдена
            }
        }


        public List<Product> LoadProducts()
        {
            var products = new List<Product>();

            string query = "SELECT Products.Код, Products.productName, Products.price, Products.imagePath, " +
               "Products.quantity, Products.description, Categories.categoryName " +
               "FROM Products " +
               "INNER JOIN Categories ON Products.categoryID = Categories.ID"; // SQL-запрос для получения ВСЕХ значений из таблицы Products
            OleDbCommand command = new OleDbCommand(query, connection); // Создаём команду на выполнение запроса с открытым соединением

            using (OleDbDataReader reader = command.ExecuteReader()) // Создаём читатель
            {
                while (reader.Read()) // Читаем по строкам
                {
                    int id = Convert.ToInt32(reader["Код"]); // Получаем ID из Access
                    string productName = reader["productName"].ToString();             // Название товара
                    decimal productPrice = decimal.Parse(reader["price"].ToString(),   // Цена товара
                        System.Globalization.CultureInfo.InvariantCulture);            //           (Принудительно меняем культуру,
                                                                                       //           чтобы разделителем была точка, а не запятая)
                    string pathToImage = reader["imagePath"].ToString();               // Путь к картинке товара
                    int quantity = (int)reader["quantity"];                            // Товар в наличии или нет 
                    string productCategory = reader["categoryName"].ToString();            // Категория товара
                    string productDescription = reader["description"].ToString();      // Текстовое описание товара

                    Product product = new Product(productName, productPrice, pathToImage, quantity, productCategory, productDescription);
                    product.Id = id;
                    products.Add(product);
                }
            }

            return products;
        }

        public void UpdateProductInDB(Product product)
        {
            try
            {
                // Найти ID категории по названию
                int categoryId = GetCategoryIdByName(product.Category);
                if (categoryId == -1)
                {
                    MessageBox.Show("Категория '" + product.Category + "' не найдена в базе данных.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL-запрос на обновление
                string query = "UPDATE Products SET " +
                               "productName = @name, " +
                               "categoryID = @categoryID, " +
                               "price = @price, " +
                               "quantity = @quantity, " +
                               "description = @description, " +
                               "imagePath = @imagePath " +
                               "WHERE Код = @id";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@categoryID", categoryId);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@description", product.Decription);
                    command.Parameters.AddWithValue("@imagePath", product.ImagePath);
                    command.Parameters.AddWithValue("@id", product.Id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Обновление не выполнено. Возможно, товар с ID = " + product.Id + " не найден.",
                            "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении товара в базе данных:\n" + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteProductById(int id)
        {
            try
            {
                string query = "DELETE FROM Products WHERE Код = @id";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Продукт с указанным ID не найден.",
                            "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении товара из базы данных:\n" + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
