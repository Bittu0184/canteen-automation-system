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
    public partial class Forgot_password : Form
    {
        OracleConnection conn;
        
        public Forgot_password()
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
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;

            cm.CommandText = "update login set password = :ps where USERNAME = :un";
            cm.CommandType = CommandType.Text;
            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "ps";
            pa1.DbType = DbType.String;
            pa1.Value = textBox2.Text;

            OracleParameter pa2 = new OracleParameter();
            pa2.ParameterName = "un";
            pa2.DbType = DbType.String;
            pa2.Value = textBox1.Text;

            cm.Parameters.Add(pa1);
            cm.Parameters.Add(pa2);
            cm.ExecuteNonQuery();
            MessageBox.Show("updated");
            conn.Close();

        }
    }
}
