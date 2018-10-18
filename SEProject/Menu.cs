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
    public partial class Menu : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
       
        public Menu()
        {
            InitializeComponent();
        }
        public void DB_connect()
        {
            String oradb = "Data Source = HPPRO58; User ID = SYSTEM ; Password = avabbittu";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int i = 0;
                DB_connect();
                comm = new OracleCommand();
                comm.CommandText = "select * from menu";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "menu");
                dt = ds.Tables["menu"];
                int t = dt.Rows.Count;
                MessageBox.Show(t.ToString());
                dr = dt.Rows[i];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "menu";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            conn.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
