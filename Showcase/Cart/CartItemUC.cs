using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public partial class CartItemUC : UserControl
    {
        CartItem _cartItem;

        public CartItemUC()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        public void SetItemUI(CartItem cartItem)
        {
            _cartItem = cartItem;
            var product = cartItem.product;

            NameLabel.Text = product.Name;
            PriceLabel.Text = $"{product.Price} ₽";
            CategoryLabel.Text = product.Category;
            CountLabel.Text += cartItem.Count.ToString();

            string fullImagePath;
            if (product.ImagePath != null)
            {
                fullImagePath = Path.Combine(Application.StartupPath, "Data", product.ImagePath); // Получаем абсолютный путь к изображению

                if (File.Exists(fullImagePath))
                {
                    try
                    {
                        ItemPictureBox.Image = Image.FromFile(fullImagePath);
                    }
                    catch (OutOfMemoryException ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Изображения не существует: " + product.ImagePath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
