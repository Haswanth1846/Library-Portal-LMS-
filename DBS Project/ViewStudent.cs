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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DBS_project
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            connectDB();
            panel2.Visible = false;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from studentinfo";
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        String bid;
        String rowid;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            connectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from studentinfo where name = '" + bid + "'";

            OracleDataAdapter aa = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            aa.Fill(ds);

            rowid = (string)ds.Tables[0].Rows[0][0];

            textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
            textBox6.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                connectDB();
                panel2.Visible = false;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from studentinfo where studentid LIKE '" + textBox1.Text + "%'";
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
                cmd.CommandText = "select * from studentinfo";
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
