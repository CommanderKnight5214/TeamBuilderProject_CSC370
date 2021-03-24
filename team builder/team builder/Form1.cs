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
    }
}
