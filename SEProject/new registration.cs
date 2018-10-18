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
    public partial class new_registration : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public new_registration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            dr = dt.Rows[0];
            int flag = 1;
            for (int i = 0; i <= t; i++)
            {
                if (textBox1.Text == dr["USERNAME"].ToString())
                {
                    flag = 0;
                    break;
                }
            }
            if (textBox2.Text == textBox3.Text && flag == 1 && textBox1.Text != "" && textBox2.Text != "")
            {
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "insert into login values('" + textBox1.Text + "','" + textBox2.Text + "')";
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Account created!");
            }
            else
            {
                MessageBox.Show("Already exists or Invalid Password , TRY AGAIN");
            }
        }
    }
}
