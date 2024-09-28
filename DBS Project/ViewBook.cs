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
    public partial class ViewBook : Form
    {
        public ViewBook()
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

        private void ViewBook_Load(object sender, EventArgs e)
        {
            connectDB();
            panel2.Visible = false;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Book";
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        String bid;
        String rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                bid = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            connectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Book where bookid = '"+bid+"'";

            OracleDataAdapter aa = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            aa.Fill(ds);

            rowid = (string)ds.Tables[0].Rows[0][0];

            textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][2].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox6.Text = ds.Tables[0].Rows[0][4].ToString();
            textBox7.Text = ds.Tables[0].Rows[0][5].ToString();
            

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!= "")
            {
                connectDB();
                panel2.Visible = false;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Book where Name LIKE '"+textBox1.Text+ "%'";
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                connectDB();
                panel2.Visible = false;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Book";
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String bname = textBox3.Text;
            String bauthor = textBox4.Text;
            String bpublisher = textBox5.Text;
            String bprice = textBox6.Text;
            String bquan = textBox7.Text;

            connectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Book set name = '"+bname+"', Author = '"+bauthor+"', publisher = '"+bpublisher+"', price = '"+bprice+"', quantity = '"+bquan+"' where bid = '"+rowid+"' ";
    



        }
    }
}
