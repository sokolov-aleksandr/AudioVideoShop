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
    public partial class CartForm : Form
    {
        private Cart _cart;
        
        public CartForm(Cart cart)
        {
            InitializeComponent();
            _cart = cart;
        }
        private void CardForm_Load(object sender, EventArgs e)
        {
            UpdateCartUI(_cart);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCartUI(Cart cart)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in cart.Items)
            {
                CartItemUC cartItemUC = new CartItemUC();
                cartItemUC.SetItemUI(item);

                flowLayoutPanel1.Controls.Add(cartItemUC);
            }
        }
    }
}
