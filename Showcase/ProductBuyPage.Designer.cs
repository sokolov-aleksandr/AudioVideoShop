namespace AudioVideoShop
{
    partial class ProductBuyPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBuy = new System.Windows.Forms.Button();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.labelNameProduct = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxDecription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(12, 168);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(150, 39);
            this.buttonBuy.TabIndex = 0;
            this.buttonBuy.Text = "В корзину";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 1;
            this.pictureBoxProduct.TabStop = false;
            // 
            // labelNameProduct
            // 
            this.labelNameProduct.AutoSize = true;
            this.labelNameProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameProduct.Location = new System.Drawing.Point(165, 31);
            this.labelNameProduct.Name = "labelNameProduct";
            this.labelNameProduct.Size = new System.Drawing.Size(48, 18);
            this.labelNameProduct.TabIndex = 4;
            this.labelNameProduct.Text = "Name";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(165, 11);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(28, 13);
            this.labelPrice.TabIndex = 3;
            this.labelPrice.Text = "000";
            // 
            // textBoxDecription
            // 
            this.textBoxDecription.Location = new System.Drawing.Point(168, 90);
            this.textBoxDecription.Multiline = true;
            this.textBoxDecription.Name = "textBoxDecription";
            this.textBoxDecription.ReadOnly = true;
            this.textBoxDecription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDecription.Size = new System.Drawing.Size(346, 72);
            this.textBoxDecription.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Описание";
            // 
            // labelCategory
            // 
            this.labelCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(228, 194);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelCategory.Size = new System.Drawing.Size(35, 13);
            this.labelCategory.TabIndex = 7;
            this.labelCategory.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Категория: ";
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.ForeColor = System.Drawing.Color.Brown;
            this.buttonDeleteProduct.Location = new System.Drawing.Point(393, 176);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(121, 23);
            this.buttonDeleteProduct.TabIndex = 9;
            this.buttonDeleteProduct.Text = "Удалить товар";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(390, 201);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(24, 13);
            this.labelID.TabIndex = 10;
            this.labelID.Text = "ID: ";
            // 
            // ProductBuyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 223);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.buttonDeleteProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDecription);
            this.Controls.Add(this.labelNameProduct);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.pictureBoxProduct);
            this.Controls.Add(this.buttonBuy);
            this.Name = "ProductBuyPage";
            this.Text = "ProductBuyPage";
            this.Load += new System.EventHandler(this.ProductBuyPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label labelNameProduct;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxDecription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Label labelID;
    }
}