using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SEProject
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
       
        public Form1()
        {
            InitializeComponent();
        }
        public void DB_connect()
        {
            String oradb = "Data Source = HPPRO58; User ID = SYSTEM ; Password = avabbittu";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from login";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_login");
            dt = ds.Tables["TB1_login"];
            int t = dt.Rows.Count;

            after_login frm6 = new after_login();
            int Flag = 0;
            int i = 0;
            for ( ; i < t; i++)
            {
                dr = dt.Rows[i];
                if (textBox1.Text == dr["USERNAME"].ToString() && textBox2.Text == dr["PASSWORD"].ToString())
                {
                    Flag = 1;
                    frm6.Show();
                    break;
                }
            }
            if(Flag == 0)
                {
                    MessageBox.Show("Invalid Credentials");
                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new_registration frm3 = new new_registration();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Forgot_password frm4 = new Forgot_password();
           frm4.Show();
        }
    }
}
