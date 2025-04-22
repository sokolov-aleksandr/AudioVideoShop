using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop.Login
{
    public partial class CreateAccount : Form
    {
        private AccountRole _currentAccountRole;
        private readonly AccountDataSource _dataSource;
        private readonly Action<string, string> _onAccountCreated;

        // Для ComboBox выбора роли
        private readonly Dictionary<string, AccountRole> roleMap = new Dictionary<string, AccountRole>
        {
            ["Администратор"] = AccountRole.admin,
            ["Обычный пользователь"] = AccountRole.user
        };


        public CreateAccount(AccountDataSource dataSource, AccountRole currentAccountRole)
        {
            InitializeComponent();
            _dataSource = dataSource;
            _currentAccountRole = currentAccountRole;
        }

        // Конструктор с автологином
        public CreateAccount(AccountDataSource dataSource, Action<string, string> onAccountCreated)
        {
            InitializeComponent();
            _dataSource = dataSource; // Передаём подключение из прошлой формы
            _onAccountCreated = onAccountCreated;
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            HandlingAccountRole(_currentAccountRole);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox2.Text;
            AccountRole role;

            if (RoleComboBox.Visible)
            {
                if (!roleMap.TryGetValue(RoleComboBox.Text, out role))
                {
                    MessageBox.Show("Неизвестная роль. Выберите корректную роль из списка.");
                    return;
                }
            }
            else
                role = AccountRole.user; // Если поле роли пустое (не дают выбрать), значит это пользователь

            _dataSource.CreateAccountInDB(username, password, role);

            _onAccountCreated?.Invoke(username, password); // Вызов действия после закрытия этой формы

            this.Close();
        }

        private void HandlingAccountRole(AccountRole role)
        {
            var roleActions = new Dictionary<AccountRole, Action>
            {
                // Роль Админа
                [AccountRole.admin] = () =>
                {
                    // Действия:
                    RoleComboBox.Visible = true;
                    RoleComboBox.SelectedIndex = 0;
                    label3.Visible = true;
                },

                // Роль обычного/нового пользователя
                [AccountRole.user] = () =>
                {
                    // Действия:
                    RoleComboBox.Visible = false;
                    label3.Visible = false;
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
