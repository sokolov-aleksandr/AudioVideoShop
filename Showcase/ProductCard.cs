using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using AudioVideoShop;

namespace AudioVideoShop
{
    /// <summary>
    /// Карточка товара в каталоге магазина
    /// </summary>
    public partial class ProductCard : UserControl
    {
        private Label labelPrice;
        private Label labelNameProduct;
        private Button buttonShow;
        private Label labelNotInStock;
        private PictureBox pictureBoxProduct;

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool InStock { get; private set; }
        public string Category { get; private set; }
        public string Decription { get; private set; }
        public string ImagePath { get; private set; }
        public string FullImagePath { get; private set; }

        public ProductCard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelNameProduct = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.labelNotInStock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(10, 5);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 0;
            this.pictureBoxProduct.TabStop = false;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(7, 158);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(28, 13);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "000";
            // 
            // labelNameProduct
            // 
            this.labelNameProduct.AutoSize = true;
            this.labelNameProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameProduct.Location = new System.Drawing.Point(7, 178);
            this.labelNameProduct.Name = "labelNameProduct";
            this.labelNameProduct.Size = new System.Drawing.Size(48, 18);
            this.labelNameProduct.TabIndex = 2;
            this.labelNameProduct.Text = "Name";
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(10, 199);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(150, 23);
            this.buttonShow.TabIndex = 3;
            this.buttonShow.Text = "Посмотреть";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // labelNotInStock
            // 
            this.labelNotInStock.AutoSize = true;
            this.labelNotInStock.ForeColor = System.Drawing.Color.Firebrick;
            this.labelNotInStock.Location = new System.Drawing.Point(7, 225);
            this.labelNotInStock.Name = "labelNotInStock";
            this.labelNotInStock.Size = new System.Drawing.Size(74, 13);
            this.labelNotInStock.TabIndex = 4;
            this.labelNotInStock.Text = "Не в наличии";
            this.labelNotInStock.Visible = false;
            // 
            // ProductCard
            // 
            this.Controls.Add(this.labelNotInStock);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.labelNameProduct);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.pictureBoxProduct);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(170, 247);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonBuy_Click(object sender, EventArgs e) // buttonShow
        {
            ProductBuyPage buyPage = new ProductBuyPage(this);
            buyPage.ShowDialog();
        }

        /// <summary>
        /// Заполнение карточки товара данными
        /// </summary>
        /// <param name="name">Имя товара</param>
        /// <param name="price">Цена товара</param>
        /// <param name="imagePath">Относительный путь к изображению карточки товара</param>
        public void SetProduct(string name, decimal price, string imagePath, bool inStock, string category, string decription)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
            InStock = inStock;
            Category = category;
            Decription = decription;
            
            labelNameProduct.Text = name;
            labelPrice.Text = $"{price} ₽";
            
            if (imagePath != null)
            {
                FullImagePath = Path.Combine(Application.StartupPath, "Data", imagePath); // Получаем абсолютный путь к изображению

                if (File.Exists(FullImagePath))
                {
                    try
                    {
                        pictureBoxProduct.Image = Image.FromFile(FullImagePath);
                    }
                    catch (OutOfMemoryException ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Изображения не существует: " + imagePath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                labelNotInStock.Visible = !inStock;
            }
        }
    }
}
