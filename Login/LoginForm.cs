using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioVideoShop.Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AudioVideoShop
{
    public partial class LoginForm : Form
    {
        private AccountDataSource _accountDataSource;
        
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            _accountDataSource = new AccountDataSource(); // Также вызываем конструктор, который соеденяется с БД
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string username = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (Login(username, password))
            {
                // Открываем магазин
                Showcase showcase = new Showcase();
                showcase.Show();
                this.Close();
            }

            
        }

        private bool Login(string username, string password)
        {
            Account account;
            if (!_accountDataSource.TryLogin(username, password, out account)) // Пытаемся залогиниться
            {
                // Если логин неудачный:
                MessageBox.Show("Данного аккаунта не существует");
                return false;
            }

            Session.CreateSession(account); // Создаём сессию для данного пользователя
            return true;
        }

        /// <summary>
        /// Автологин когда уже извне известен логин и пароль (например при создании нового аккаунта)
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        public void AutoLogin(string username, string password)
        {
            if (Login(username, password))
            {
                // Открываем магазин
                Showcase showcase = new Showcase();
                showcase.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данного аккаунта не существует!");
            }
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            // Создаём окно регистрации с действием автологина
            var createAccount = new CreateAccount(
                _accountDataSource,                             // передаём текущее подключение
                (u, p) => this.AutoLogin(u, p)                  // и колбэк на автологин
            );

            createAccount.ShowDialog();
        }
    }
}
