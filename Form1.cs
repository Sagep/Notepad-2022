using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Notepad_2022
{
    public partial class Form1 : Form
    {
        //global variables. 
        private bool darkmode = false;
        private string docPath;
        private string fileContent;
        SaveFileDialog saver = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            init();
        }
        //initialization of global variables.
        private void init()
        {
            //intialization of file content and docment paths. 
            docPath = string.Empty;
            fileContent = string.Empty;

            //initialization of saving files
            saver.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saver.FilterIndex = 2;

            //initialization of opening files
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
        }
        //not used
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //close
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                docPath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                textBox1.Text = fileContent;
            }
        }

        //save as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saver.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                docPath = saver.FileName;
            }
            if (docPath != String.Empty)
                using (StreamWriter outputFile = new StreamWriter(docPath))
                {
                    outputFile.WriteLine(textBox1.Text);
                }
        }

        //save
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter(docPath))
            {
                outputFile.WriteLine(textBox1.Text);
            }
        }

        //Shortcut keys
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (docPath != String.Empty)
                    saveToolStripMenuItem1_Click(sender, e);
                else
                    saveAsToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O)
                openToolStripMenuItem_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.N)
                newToolStripMenuItem_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.M)
                viewModeToolStripMenuItem_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.F)
                searcher();
        }
        //not needed
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //New file
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                DialogResult closedwithoutsave = MessageBox.Show("Alert! \nYou're about to lose all your progress. \nAre you sure you want to do this? ", "Close without Save", MessageBoxButtons.YesNoCancel);
                if (closedwithoutsave == DialogResult.Yes)
                {
                    textBox1.Text = String.Empty;
                    init();
                }
                else if (closedwithoutsave == DialogResult.No)
                {
                    if (docPath != String.Empty)
                        saveToolStripMenuItem1_Click(sender, e);
                    else
                        saveAsToolStripMenuItem_Click(sender, e);
                    textBox1.Text = String.Empty;
                    init();
                }
            }

        }

        //Color Mode
        private void viewModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult darkmoderesult;
            if (darkmode == false)
            {
                darkmoderesult = MessageBox.Show("Swap to dark mode?", "Dark Mode", MessageBoxButtons.YesNo);
                textBox1.BackColor = Color.Gray;
                textBox1.ForeColor = Color.White;
                menuStrip1.BackColor = Color.Black;
                menuStrip1.ForeColor = Color.White;
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                darkmode = true;
            }
            else
            {
                darkmoderesult = MessageBox.Show("Swap to light mode?", "Light Mode", MessageBoxButtons.YesNo);
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                menuStrip1.BackColor = Color.White;
                menuStrip1.ForeColor = Color.Black;
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                darkmode = false;
            }
        }

        //not needed
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        //character and word count. 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Character Count: " + textBox1.Text.Count();
            int i = 0;
            char currentletter = ' ';
            char lastletter = ' ';
            int words = 0;
            foreach (char A in textBox1.Text)
            {
                if (i != 0)
                {
                    lastletter = textBox1.Text[i -= 1];
                    currentletter = textBox1.Text[i + 1];
                    if (currentletter == '.' || currentletter == '?' || currentletter == '!' || currentletter == ' ' || currentletter == '\n')
                        if (lastletter != '.' && lastletter != '!' && lastletter != '?' && lastletter != ' ' && lastletter != '\n')
                            words++;
                    i += 1;
                }
                i += 1;
            }
            label1.Text += " - Word Count: " + words;
        }
        //Font changer
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontchanger = new FontDialog();
            fontchanger.ShowColor = true;
            fontchanger.ShowEffects = true;
            fontchanger.ShowApply = true;
            if (fontchanger.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = fontchanger.Font;
            }
        }
        //Search function
        private void searcher()
        {
        }
    }
}

