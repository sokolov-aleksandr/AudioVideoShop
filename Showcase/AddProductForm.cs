using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AudioVideoShop
{
    public partial class AddProductForm : Form
    {
        private string productName = string.Empty;
        private string productCategory = string.Empty;
        private decimal productPrice = 0;
        private bool inStock = false;
        private string productDescription = string.Empty;
        private string pathToImage = string.Empty;

        private List<TextBox> decimalFields = new List<TextBox>();
        private List<TextBox> requiredFields = new List<TextBox>();

        private Showcase _showcase; // Ссылка на форму витрины

        public AddProductForm(Showcase showcase)
        {
            InitializeComponent();
            _showcase = showcase;
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // Заполнение полей для проверки на корректность
            decimalFields.Add(input_priceProduct);

            requiredFields.Add(input_nameProduct);
            requiredFields.Add(input_decription);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateTextBoxes(decimalFields, requiredFields);
            if (!isValid)
                return;

            // Заполняем переменные
            productName = input_nameProduct.Text;
            productCategory = comboBoxCategoryProduct.Text;
            productPrice = decimal.Parse(input_priceProduct.Text); // Уже проводилась проверка на корректность ввода
            inStock = checkBoxInStock.Checked;
            productDescription = input_decription.Text;

            _showcase.CreateProduct(productName, productCategory, productPrice, inStock, productDescription, pathToImage);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOpenImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите изображение";
                openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string originalPath = openFileDialog.FileName;
                    string imagesFolder = Path.Combine(Application.StartupPath, "Data", "Images");

                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);

                    // Генерация уникального имени
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalPath)}";
                    string destPath = Path.Combine(imagesFolder, fileName);

                    File.Copy(originalPath, destPath, true);

                    // Сохраняем относительный путь
                    pathToImage = Path.Combine("Images", fileName);

                    // Показываем имя файла в кнопке
                    buttonOpenImage.Text = Path.GetFileName(originalPath);
                }
            }
        }

        /// <summary>
        /// Проверяем текстовые поля ввода на корректность
        /// </summary>
        /// <param name="decimalFields">Поля проверки на decimal</param>
        /// <param name="requiredFields">Поля, обязательные для заполнения (не должны быть пустыми)</param>
        /// <returns>Булевое значение того, корректны ли поля или нет</returns>
        private bool ValidateTextBoxes(List<TextBox> decimalFields, List<TextBox> requiredFields)
        {
            bool isValid = true;

            foreach (TextBox field in requiredFields)
            {
                // Если строка пустая
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    field.BackColor = Color.LightCoral; // то перекрашиваем в красный
                    isValid = false;
                }
                else
                {
                    field.BackColor = SystemColors.Window; // Если поле уже исправили
                }
            }

            foreach (TextBox decTextBox in decimalFields)
            {
                // Если число в поле не decimal
                if (!decimal.TryParse(decTextBox.Text, out _))
                {
                    decTextBox.BackColor = Color.LightCoral; // то перекрашиваем в красный
                    isValid = false;
                }
                else
                {
                    decTextBox.BackColor = SystemColors.Window;
                }
            }

            if (!isValid)
            {
                MessageBox.Show("Некоторые поля заполнены некорректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }


    }
}
