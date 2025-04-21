using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AudioVideoShop
{
    public class AccountDataSource : AccessDataSource
    {
        public AccountDataSource() : base() { }
        
        /// <summary>
        /// Попытка логина пользователя и возвращение информации об аккаунте
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль пользователя (НЕ ХЭШ)</param>
        /// <param name="account">Заполняется экземпляр класса Аккаунта</param>
        /// <returns>Результат поиска пользователя в БД (есть он там или нет)</returns>
        public bool TryLogin(string username, string password, out Account account)
        {
            account = null;

            string query = "SELECT Username, Password, Role FROM Accounts WHERE Username = ?";

            using (var command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string passwordFromDB = reader["Password"].ToString();

                        if (password == passwordFromDB) // TODO: Добавь хэширование
                        {
                            account = new Account
                            {
                                Username = username,
                                Role = (AccountRole)Enum.Parse(typeof(AccountRole), reader["Role"].ToString(), ignoreCase: true)
                            };

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void CreateAccountInDB(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
