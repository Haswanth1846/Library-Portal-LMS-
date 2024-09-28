using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS_project
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook abs = new ReturnBook();
            abs.Show();
        }

        private void takeBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeBook abs = new TakeBook();
            abs.Show();
        }

        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookDetails bookDetails = new BookDetails();
            bookDetails.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 fr = new Form1();
            fr.Show();
        }
    }
}
