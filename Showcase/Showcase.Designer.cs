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
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.flowLayoutPanelProductCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCategoryFilter = new System.Windows.Forms.ComboBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.AdminGroupBox = new System.Windows.Forms.GroupBox();
            this.CreateUserButton = new System.Windows.Forms.Button();
            this.buttonOpenCart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonDeleteChanges = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AdminGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Каталог товаров";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(6, 19);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(188, 42);
            this.buttonAddProduct.TabIndex = 1;
            this.buttonAddProduct.Text = "Добавить товар";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanelProductCatalog
            // 
            this.flowLayoutPanelProductCatalog.AutoScroll = true;
            this.flowLayoutPanelProductCatalog.Location = new System.Drawing.Point(8, 29);
            this.flowLayoutPanelProductCatalog.Name = "flowLayoutPanelProductCatalog";
            this.flowLayoutPanelProductCatalog.Size = new System.Drawing.Size(627, 522);
            this.flowLayoutPanelProductCatalog.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 8);
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
            this.comboBoxCategoryFilter.Location = new System.Drawing.Point(514, 5);
            this.comboBoxCategoryFilter.Name = "comboBoxCategoryFilter";
            this.comboBoxCategoryFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategoryFilter.TabIndex = 4;
            this.comboBoxCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoryFilter_SelectedIndexChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameLabel.Location = new System.Drawing.Point(641, 9);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(141, 18);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Имя пользователя";
            // 
            // AdminGroupBox
            // 
            this.AdminGroupBox.Controls.Add(this.CreateUserButton);
            this.AdminGroupBox.Controls.Add(this.buttonAddProduct);
            this.AdminGroupBox.Location = new System.Drawing.Point(635, 417);
            this.AdminGroupBox.Name = "AdminGroupBox";
            this.AdminGroupBox.Size = new System.Drawing.Size(200, 133);
            this.AdminGroupBox.TabIndex = 6;
            this.AdminGroupBox.TabStop = false;
            this.AdminGroupBox.Text = "Админ панель";
            // 
            // CreateUserButton
            // 
            this.CreateUserButton.Location = new System.Drawing.Point(6, 67);
            this.CreateUserButton.Name = "CreateUserButton";
            this.CreateUserButton.Size = new System.Drawing.Size(188, 42);
            this.CreateUserButton.TabIndex = 2;
            this.CreateUserButton.Text = "Создать Пользователя";
            this.CreateUserButton.UseVisualStyleBackColor = true;
            this.CreateUserButton.Click += new System.EventHandler(this.CreateUserButton_Click);
            // 
            // buttonOpenCart
            // 
            this.buttonOpenCart.Location = new System.Drawing.Point(644, 29);
            this.buttonOpenCart.Name = "buttonOpenCart";
            this.buttonOpenCart.Size = new System.Drawing.Size(188, 42);
            this.buttonOpenCart.TabIndex = 3;
            this.buttonOpenCart.Text = "Открыть корзину";
            this.buttonOpenCart.UseVisualStyleBackColor = true;
            this.buttonOpenCart.Click += new System.EventHandler(this.buttonOpenCart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(854, 582);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanelProductCatalog);
            this.tabPage1.Controls.Add(this.buttonOpenCart);
            this.tabPage1.Controls.Add(this.AdminGroupBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.usernameLabel);
            this.tabPage1.Controls.Add(this.comboBoxCategoryFilter);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(846, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Интернет магазин";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.buttonDeleteChanges);
            this.tabPage2.Controls.Add(this.buttonSaveChanges);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(846, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "База данных";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Products",
            "Categories",
            "Accounts",
            "Workers"});
            this.comboBox1.Location = new System.Drawing.Point(719, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonDeleteChanges
            // 
            this.buttonDeleteChanges.ForeColor = System.Drawing.Color.Red;
            this.buttonDeleteChanges.Location = new System.Drawing.Point(149, 527);
            this.buttonDeleteChanges.Name = "buttonDeleteChanges";
            this.buttonDeleteChanges.Size = new System.Drawing.Size(140, 23);
            this.buttonDeleteChanges.TabIndex = 2;
            this.buttonDeleteChanges.Text = "Удалить изменения";
            this.buttonDeleteChanges.UseVisualStyleBackColor = true;
            this.buttonDeleteChanges.Click += new System.EventHandler(this.buttonDeleteChanges_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(3, 527);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(140, 23);
            this.buttonSaveChanges.TabIndex = 1;
            this.buttonSaveChanges.Text = "Сохранить изменения";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(834, 466);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // Showcase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 605);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Showcase";
            this.Text = "Приложение";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Showcase_FormClosing);
            this.Load += new System.EventHandler(this.Showcase_Load);
            this.AdminGroupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProductCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCategoryFilter;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.GroupBox AdminGroupBox;
        private System.Windows.Forms.Button CreateUserButton;
        private System.Windows.Forms.Button buttonOpenCart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Button buttonDeleteChanges;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}