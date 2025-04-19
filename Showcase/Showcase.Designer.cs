﻿namespace AudioVideoShop
{
    partial class Showcase
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
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.flowLayoutPanelProductCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCategoryFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Каталог товаров";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(682, 125);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(122, 42);
            this.buttonAddProduct.TabIndex = 1;
            this.buttonAddProduct.Text = "Добавить товар";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanelProductCatalog
            // 
            this.flowLayoutPanelProductCatalog.AutoScroll = true;
            this.flowLayoutPanelProductCatalog.Location = new System.Drawing.Point(12, 51);
            this.flowLayoutPanelProductCatalog.Name = "flowLayoutPanelProductCatalog";
            this.flowLayoutPanelProductCatalog.Size = new System.Drawing.Size(627, 522);
            this.flowLayoutPanelProductCatalog.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фильтр";
            // 
            // comboBoxCategoryFilter
            // 
            this.comboBoxCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoryFilter.FormattingEnabled = true;
            this.comboBoxCategoryFilter.Items.AddRange(new object[] {
            "Все",
            "Аудио",
            "Видео",
            "Аудио/Видео",
            "Прочее"});
            this.comboBoxCategoryFilter.Location = new System.Drawing.Point(518, 27);
            this.comboBoxCategoryFilter.Name = "comboBoxCategoryFilter";
            this.comboBoxCategoryFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategoryFilter.TabIndex = 4;
            this.comboBoxCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoryFilter_SelectedIndexChanged);
            // 
            // Showcase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 585);
            this.Controls.Add(this.comboBoxCategoryFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanelProductCatalog);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.label1);
            this.Name = "Showcase";
            this.Text = "Showcase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Showcase_FormClosing);
            this.Load += new System.EventHandler(this.Showcase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProductCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCategoryFilter;
    }
}