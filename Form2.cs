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
        private string textboxtext="";
        public Form2(string textboxtext1)
        {
            InitializeComponent();
            textboxtext=textboxtext1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textboxtext.Contains(textBox1.Text))
                this.Close();
        }
    }
}
