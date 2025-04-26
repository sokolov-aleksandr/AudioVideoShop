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

        private decimal _totalPrice = 0;

        public CartForm(Cart cart)
        {
            InitializeComponent();
            _cart = cart;
        }
        private void CardForm_Load(object sender, EventArgs e)
        {
            UpdateCartUI(_cart);

            UpdateTotalPrice();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearCart();
        }

        private void UpdateCartUI(Cart cart)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in cart.Items)
            {
                CartItemUC cartItemUC = new CartItemUC(this);
                cartItemUC.SetItemUI(item);

                flowLayoutPanel1.Controls.Add(cartItemUC);
            }
        }
        
        private void ClearCart()
        {
            _cart.Clear();
            flowLayoutPanel1.Controls.Clear();
            UpdateTotalPrice();
        }

        public void RemoveItem(CartItemUC cartItemUC, int quantityToRemove = 1)
        {
            _cart.RemoveItem(cartItemUC.CartItem.Product, quantityToRemove);

            // Проверяем, остался ли этот товар в корзине
            var stillExists = _cart.Items.FirstOrDefault(i => i.Product.Id == cartItemUC.CartItem.Product.Id);
            if (stillExists == null)
            {
                flowLayoutPanel1.Controls.Remove(cartItemUC);
            }

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            _totalPrice = CalculateTotalPrice(_cart);
            labelTotalPrice.Text = $"{_totalPrice.ToString()} ₽";
        }

        private decimal CalculateTotalPrice(Cart cart)
        {
            decimal totalPrice = 0;
            
            foreach (var item in cart.Items)
            {
                totalPrice += item.Product.Price * item.Quantity;
            }

            return totalPrice;
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            // Здесь может быть реализация покупки в отдельном классе

            // TODO: сделай обработку количества товара тут

            MessageBox.Show("Спасибо за покупку!");
            ClearCart();
        }
    }
}
