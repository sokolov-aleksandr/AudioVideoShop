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
        
        
        public ProductBuyPage(Product product, string fullImagePath)
        {
            InitializeComponent();

            // Заполняем данные из карточки
            labelNameProduct.Text = product.Name;
            labelPrice.Text = $"{product.Price.ToString()} ₽";
            textBoxDecription.Text = product.Decription;
            pictureBoxProduct.Image = Image.FromFile(fullImagePath);
            labelCategory.Text = product.Category;
            buttonBuy.Enabled = product.InStock;
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {

        }
    }
}
