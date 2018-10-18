using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SEProject
{
    public partial class after_login : Form
    {
        
       
        public after_login()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            about_us frm5 = new about_us();
            frm5.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu frm7 = new Menu();
            frm7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            place_order frm8 = new place_order();
            frm8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            subscribe frm9 = new subscribe();
            frm9.Show();
        }
    }
}
