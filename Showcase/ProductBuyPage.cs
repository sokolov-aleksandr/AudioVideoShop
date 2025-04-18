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
        
        
        public ProductBuyPage(ProductCard productCard)
        {
            InitializeComponent();

            // Заполняем данные из карточки
            labelNameProduct.Text = productCard.Name;
            labelPrice.Text = $"{productCard.Price.ToString()} ₽";
            textBoxDecription.Text = productCard.Decription;
            pictureBoxProduct.Image = Image.FromFile(productCard.FullImagePath);
            labelCategory.Text = productCard.Category;
            buttonBuy.Enabled = productCard.InStock;
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {

        }
    }
}
