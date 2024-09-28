using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DBS_project
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        OracleConnection conn;

        void connectDB()
        {
            conn = new OracleConnection("DATA SOURCE=127.0.0.1:1521/orcl;USER ID=c##librarylogin;PASSWORD=project");
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectDB();
            String name = textBox1.Text;
            String id = textBox2.Text;
            String bran = textBox3.Text;
            String sem = textBox4.Text;
            String ph = textBox5.Text;
            String add = textBox6.Text;

            OracleCommand cmd = new OracleCommand();
            OracleCommand cmd1 = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;

            cmd.CommandText = "insert into studentinfo (Name,StudentID,Semester,Branch,Contact,Address) values ('" + name + "','" + id + "','" + sem + "','" + bran + "','" + ph + "','" + add + "')";

            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Librariandashboard df = new Librariandashboard();
            df.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
