using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_2022
{
    public partial class Form2 : Form
    {
        public bool UserSuccessfullyAuthenticated { get; private set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*no connection to SQL server or MSQL server nor Azure. 
             * As such, local credentials built into software*/
            string username = "Dartban214";
            string password = "Christmas1a";
            if (textBox1.Text==username&&textBox2.Text==password)
            {
                if (DialogResult.OK == MessageBox.Show("Login Success"))
                {
                    UserSuccessfullyAuthenticated = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Login Failed. Please try again");
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
