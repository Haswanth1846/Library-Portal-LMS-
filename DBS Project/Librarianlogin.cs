using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBS_project
{
    public partial class Librarianlogin : Form
    {
        public Librarianlogin()
        {
            InitializeComponent();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Clear();
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Librariandashboard  abs = new Librariandashboard();
            abs.Show();
        }
    }
}
