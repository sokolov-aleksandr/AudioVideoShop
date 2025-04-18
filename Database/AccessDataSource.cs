///<summary>
/// Для работы необходимы драйвера Access
/// https://www.microsoft.com/en-us/download/details.aspx?id=54920
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AudioVideoShop
{
    public class AccessDataSource : IDisposable
    {
        protected OleDbConnection connection = null; // Соединение для работы с БД

        public AccessDataSource()
        {
            ConnectDatabase();
        }

        private void ConnectDatabase()
        {
            string dbRelativePath = Path.Combine("Data", "Shop.accdb");             // Получаем относительный путь базы данных
            string dbFullPath = Path.Combine(Application.StartupPath, dbRelativePath);  // Делаем из него абсолютный путь
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFullPath};"; // Полный путь соединения до базы данных
            connection = new OleDbConnection(connectionString); // Создаём соединение с базой данных
            connection.Open(); // Открываем соединение с базой данных
        }

        // Закрытие соеднинения с помощью IDisposable (вызывается гарантированно, а не автосборщиком)
        public void Dispose()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Dispose();
                connection = null;
            }
        }
    }
}
