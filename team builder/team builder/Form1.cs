using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace team_builder
{
    /*Group Members of Pro-gaming: James, Dominic, Nick, and Tony.  
     * 3/25/2020, 
     * The purpose of this program is to build teams with each team having different members.
     */
    public partial class Form1 : Form
    {
        String Name;
        int count = 0;
        string[] values = new string[400];

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        //This is the add button, the primary purpose of this button is to allow the user to add names to the rich text box. 
        private void button1_Click(object sender, EventArgs e)
        {

            Name = Convert.ToString(this.textBox1.Text);
            this.richTextBox2.AppendText(Name + " ");
            values[count] = Name;
            count++;

            this.textBox1.Text = Convert.ToString(" ");



        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //This is the save as tool strip, the primary function of this tool strip is to allow the user to save the groups that were added to the program in a text file. 
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

            
            foreach (string line in values)    // this will print names virtically
                sw.WriteLine(line);
            

            
           //string result = String.Concat(values);
            //sw.WriteLine(result);                   //this will print names vnext to each other
            

            sw.Close();
        }

        //This is the help menu tool strip, the primary function of this tool strip is to explain how the application works for the user. 
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save will place a txtfile called \nsampletest in documents folder \nand will overwrite everytime you \nclick save \nSave as will let user \npick where they want to save \nthe text doc and lets them \nname it", "Help Menu");
        }

        //This is the Open menu tool strip, the primary function of this tool strip is to read in a file with a list of names on it. 
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                            this.textBox1.Text = fileContent;
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }

