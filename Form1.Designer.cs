namespace AudioVideoShop
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GoToShop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoToShop
            // 
            this.GoToShop.Location = new System.Drawing.Point(12, 2);
            this.GoToShop.Name = "GoToShop";
            this.GoToShop.Size = new System.Drawing.Size(157, 79);
            this.GoToShop.TabIndex = 0;
            this.GoToShop.Text = "За покупками";
            this.GoToShop.UseVisualStyleBackColor = true;
            this.GoToShop.Click += new System.EventHandler(this.GoToShop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 87);
            this.button1.TabIndex = 1;
            this.button1.Text = "Логин";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 583);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GoToShop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoToShop;
        private System.Windows.Forms.Button button1;
    }
}

