using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        public static Form1 Instance {  get { return _instance; } }

        public Form1()
        {
            InitializeComponent();
            _instance = this;
        }


        private void GoToShop_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Hide();
        }

        
    }
}
