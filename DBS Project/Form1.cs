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
    public partial class Form1 : Form
    {
        public Form1()
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void username_MouseEnter(object sender, EventArgs e)
        {
            if(user.Text=="Username")
            {
                user.Clear();
            }
        }

        private void password_MouseEnter(object sender, EventArgs e)
        {
            if (pass.Text == "Password")
            {
                pass.Clear();
                pass.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Librarianlogin abs  = new Librarianlogin();
            abs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectDB();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from studentlogin where username = '"+user.Text+"' and password = '"+pass.Text+"'";
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count!=0)
            {
                this.Close();
                StudentDashboard sd = new StudentDashboard();   
                sd.Show();
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            reg re = new reg(); 
            re.Show();
        }
    }
}
