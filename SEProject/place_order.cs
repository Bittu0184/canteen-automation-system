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
    public partial class place_order : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public place_order()
        {
            InitializeComponent();
        }
        public void DB_connect()
        {
            String oradb = "Data Source = HPPRO58; User ID = SYSTEM ; Password = avabbittu";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkedListBox1.Items.Add
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from menu";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "men");
            dt = ds.Tables["men"];
            int t = dt.Rows.Count;
            int i = 0;
            for (; i < t; i++)
            {
                dr = dt.Rows[i];
                int len = dr["item"].ToString().Length;
                //dr["item"].ToString() + "                     " + dr["price"].ToString()
                int full = "dashfjkgjdngahgnklgierhgknkgnerifinr".Length;
                int l = 25;
                String s = "";
                while (l > 0)
                {
                    s = s + " ";
                    l--;
                }
                checkedListBox1.Items.Insert(i, dr["item"].ToString() + s + dr["price"].ToString());
                
            }            
        }
        //Items.Add(checkedListBox1.CheckedItems[j].ToString());
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = checkedListBox1.CheckedItems[0].ToString() + "\n";
            for (int j = 1; j < checkedListBox1.CheckedItems.Count; j++)
            {
                richTextBox1.AppendText(checkedListBox1.CheckedItems[j].ToString() + "\n");
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
