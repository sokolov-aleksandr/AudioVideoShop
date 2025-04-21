using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Account account;
            if (!_accountDataSource.TryLogin(username, password, out account)) // Пытаемся залогиниться
            {
                // Если логин неудачный:
                MessageBox.Show("Данного аккаунта не существует");
                return;
            }

            Session.CreateSession(account); // Создаём сессию для данного пользователя

            // Открываем магазин
            Showcase showcase = new Showcase();
            showcase.Show();
            this.Close();
        }

    }
}
