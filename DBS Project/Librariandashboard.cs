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
    public partial class Librariandashboard : Form
    {
        public Librariandashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if(MessageBox.Show("Are you sure you want to exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                Application.Exit();
            }*/
            this.Close();
            Form1 ff = new Form1();
            ff.Show();
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addnewbook abs = new Addnewbook();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook abs = new ViewBook();
            abs.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent abs = new AddStudent();  
            abs.Show();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent viewStudent = new ViewStudent();    
            viewStudent.Show(); 
        }

        private void isuueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issuebook abs = new Issuebook();
            abs.Show();
        }

        private void Librariandashboard_Load(object sender, EventArgs e)
        {

        }

        private void issueReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookstatus bs = new bookstatus();   
            bs.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payments fp = new payments();
            fp.Show();    
        }
    }
}
