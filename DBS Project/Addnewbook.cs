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
    public partial class Addnewbook : Form
    {
        public Addnewbook()
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
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String bname = name.Text;
            String bid = id.Text;
            String bprice = price.Text;
            String bquantity = quantity.Text;
            String bpublication = publication.Text;
            String bauthor = author.Text;

            connectDB();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Book (bookid,name,author,publisher,price,quantity) values ('" + bid + "','" + bname + "','" + bauthor + "','" + bpublication + "','" + bprice + "','" + bquantity + "')";
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Librariandashboard ds = new Librariandashboard();
            ds.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id.Clear();
            name.Clear();
            price.Clear();
            quantity.Clear();
            publication.Clear();
            author.Clear();
        }
    }
}
