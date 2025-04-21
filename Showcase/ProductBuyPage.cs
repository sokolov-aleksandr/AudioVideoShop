using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public partial class ProductBuyPage : Form
    {
        private Showcase _showcase;
        private Product _product;
        
        public ProductBuyPage(Showcase showcase, Product product, string fullImagePath)
        {
            InitializeComponent();
            _showcase = showcase;
            _product = product;

            // Заполняем данные из карточки
            labelNameProduct.Text = product.Name;
            labelPrice.Text = $"{product.Price.ToString()} ₽";
            textBoxDecription.Text = product.Decription;
            pictureBoxProduct.Image = Image.FromFile(fullImagePath);
            labelCategory.Text = product.Category;
            buttonBuy.Enabled = product.InStock;
            labelID.Text += product.Id.ToString();
        }

        private void ProductBuyPage_Load(object sender, EventArgs e)
        {
            HandlingAccountRole(Session.CurrentUser.Role);
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Удалить товар?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                _showcase.DeleteProductCard(_product.Id);
                this.Close();
            }

        }

        private void HandlingAccountRole(AccountRole role)
        {
            var roleActions = new Dictionary<AccountRole, Action>
            {
                // Роль Админа
                [AccountRole.admin] = () =>
                {
                    // Действия:
                    buttonDeleteProduct.Visible = true;
                    labelID.Visible = true;
                },

                // Роль обычного пользователя (Покупателя)
                [AccountRole.user] = () =>
                {
                    // Действия:
                    buttonDeleteProduct.Visible = false;
                    labelID.Visible = false;
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
