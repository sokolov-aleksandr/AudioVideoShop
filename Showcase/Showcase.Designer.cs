namespace AudioVideoShop
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
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanelProductCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Каталог товаров";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelProductCatalog
            // 
            this.flowLayoutPanelProductCatalog.Location = new System.Drawing.Point(12, 25);
            this.flowLayoutPanelProductCatalog.Name = "flowLayoutPanelProductCatalog";
            this.flowLayoutPanelProductCatalog.Size = new System.Drawing.Size(627, 548);
            this.flowLayoutPanelProductCatalog.TabIndex = 2;
            // 
            // Showcase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 585);
            this.Controls.Add(this.flowLayoutPanelProductCatalog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Showcase";
            this.Text = "Showcase";
            this.Load += new System.EventHandler(this.Showcase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProductCatalog;
    }
}