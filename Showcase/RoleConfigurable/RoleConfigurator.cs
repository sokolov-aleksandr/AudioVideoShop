using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public static class RoleConfigurator
    {
        public static void Apply(AccountRole role, Showcase form)
        {
            HandlingAccountRole(role, form);
        }

        private static void HandlingAccountRole(AccountRole role, IRoleConfigurable form)
        {
            var roleActions = new Dictionary<AccountRole, Action>
            {
                // Роль Админа
                [AccountRole.admin] = () =>
                {
                    // Действия:
                    form.AdminPanel.Visible = true;
                    form.MainTabControl.TabPages[1].Text = "База данных";
                    form.MainTabControl.TabPages[1].Enabled = true;
                },

                // Роль обычного пользователя (Покупателя)
                [AccountRole.user] = () =>
                {
                    // Действия:
                    form.AdminPanel.Visible = false;
                    form.MainTabControl.TabPages.Remove(form.AdminTabPage);
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
