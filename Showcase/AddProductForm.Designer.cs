namespace AudioVideoShop
{
    partial class AddProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.input_nameProduct = new System.Windows.Forms.TextBox();
            this.input_priceProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.input_decription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxInStock = new System.Windows.Forms.CheckBox();
            this.comboBoxCategoryProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOpenImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование товара";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(182, 397);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(96, 42);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // input_nameProduct
            // 
            this.input_nameProduct.Location = new System.Drawing.Point(15, 41);
            this.input_nameProduct.Name = "input_nameProduct";
            this.input_nameProduct.Size = new System.Drawing.Size(263, 20);
            this.input_nameProduct.TabIndex = 2;
            // 
            // input_priceProduct
            // 
            this.input_priceProduct.Location = new System.Drawing.Point(15, 126);
            this.input_priceProduct.Name = "input_priceProduct";
            this.input_priceProduct.Size = new System.Drawing.Size(118, 20);
            this.input_priceProduct.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Цена товара";
            // 
            // input_decription
            // 
            this.input_decription.Location = new System.Drawing.Point(15, 188);
            this.input_decription.Multiline = true;
            this.input_decription.Name = "input_decription";
            this.input_decription.Size = new System.Drawing.Size(263, 109);
            this.input_decription.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Описание";
            // 
            // checkBoxInStock
            // 
            this.checkBoxInStock.AutoSize = true;
            this.checkBoxInStock.Location = new System.Drawing.Point(15, 152);
            this.checkBoxInStock.Name = "checkBoxInStock";
            this.checkBoxInStock.Size = new System.Drawing.Size(77, 17);
            this.checkBoxInStock.TabIndex = 7;
            this.checkBoxInStock.Text = "В наличии";
            this.checkBoxInStock.UseVisualStyleBackColor = true;
            // 
            // comboBoxCategoryProduct
            // 
            this.comboBoxCategoryProduct.FormattingEnabled = true;
            this.comboBoxCategoryProduct.Items.AddRange(new object[] {
            "Аудио",
            "Видео",
            "Аудио/Видео",
            "Прочее"});
            this.comboBoxCategoryProduct.Location = new System.Drawing.Point(15, 86);
            this.comboBoxCategoryProduct.Name = "comboBoxCategoryProduct";
            this.comboBoxCategoryProduct.Size = new System.Drawing.Size(120, 21);
            this.comboBoxCategoryProduct.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Категория товара";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(15, 397);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 42);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Добавить изображение товара";
            // 
            // buttonOpenImage
            // 
            this.buttonOpenImage.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenImage.Location = new System.Drawing.Point(15, 316);
            this.buttonOpenImage.Name = "buttonOpenImage";
            this.buttonOpenImage.Size = new System.Drawing.Size(163, 27);
            this.buttonOpenImage.TabIndex = 12;
            this.buttonOpenImage.Text = "Открыть";
            this.buttonOpenImage.UseVisualStyleBackColor = false;
            this.buttonOpenImage.Click += new System.EventHandler(this.buttonOpenImage_Click);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 451);
            this.Controls.Add(this.buttonOpenImage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxCategoryProduct);
            this.Controls.Add(this.checkBoxInStock);
            this.Controls.Add(this.input_decription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_priceProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.input_nameProduct);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label1);
            this.Name = "AddProductForm";
            this.Text = "AddProductForm";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox input_nameProduct;
        private System.Windows.Forms.TextBox input_priceProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_decription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxInStock;
        private System.Windows.Forms.ComboBox comboBoxCategoryProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOpenImage;
    }
}