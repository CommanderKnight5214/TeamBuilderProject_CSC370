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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string[] lines = { "James", "Dominic ", "Nick","Tony"};
            
            string docPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new
            StreamWriter(Path.Combine(docPath, "sampleLists.txt")))
            {
                foreach (string line in values)
                    outputFile.WriteLine(line);
            }
            MessageBox.Show("Your file has been saved in the Documents Folder", "Saved");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Name = Convert.ToString(this.textBox1.Text);
            this.richTextBox2.AppendText(Name+" ");
            
            values[count] = Name;
            count++;

           this.textBox1.Text = Convert.ToString(" ");



        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        //This Menu Tab allows the user to read to a file to the place of their choosing. 
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
