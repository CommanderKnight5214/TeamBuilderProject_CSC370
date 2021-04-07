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
        // global variables the array values holds all the names in a big array 
        // String Name;
        int count = 0;
        string[] values = new string[400];
        string[] testNames = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
        int undoCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != values.Length; i++)
            {
                values[i] = " ";
                //this.richTextBox1.AppendText(i + " ");
            }
            this.richTextBox1.Clear();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.richTextBox2.Clear();
            count = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            //   int undoLocation = values.Length - 1;
            // values[undoLocation] = " ";
            this.richTextBox2.Clear();
            //int undoCounter = 0;
            if (count == 0)
            {
                this.label3.Text = "There are no more names" + "\n" + "in the text box.";
            }
            else
            {


                while (undoCounter != count - 1)
                {
                    this.richTextBox2.AppendText(values[undoCounter] + " ");
                    undoCounter++;
                    if (count == 1)
                    {
                        values[0] = "";
                    }
                    if (count > 1)
                    {
                        values[count - 1] = "";
                    }
                }
                int undoPlaceHolder = undoCounter;
                undoCounter = 0;
                count--;
            }

            /*
            // Shifting elements
            for (int i = undoPlaceHolder - 1; i < undoCounter; i++)
            {
                values[i] = values[i =1] ;
                
            }
            */
            //values[undoCounter] = " ";
            //undoCounter = 0;
            //count--;
            // this.richTextBox2.AppendText(values.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                 * int groupCount = count/numOfGroups;
                this.richTextBox1.Clear();

                Random random = new Random();
                int numOfGroups = Convert.ToInt32(this.textBox2.Text);

                for (int i =0; i<=count;i++)
                {
                int randomNumber = random.Next(numOfGroups);
                this.richTextBox1.AppendText(randomNumber +" "+ values[i] + " " + "\n" );
                }
                */
                this.richTextBox1.Clear();
                int[] groupNumStorage = new int[100];
                Random random = new Random();
                int numOfGroups = Convert.ToInt32(this.textBox2.Text);
                //int randomNumberCount = 0;
                for (int i = 0; i <= count; i++)
                {
                    int randomNumber = random.Next(numOfGroups);
                    //randomNumberCount = randomNumber;

                    //groupNumStorage


                    int answer = randomNumber + 1; // makes it so it displays groups starting at 1 and not 0
                    this.richTextBox1.AppendText(answer + " " + values[i] + " ");


                }
            }
            catch
            {
                this.label3.Text = "Invalid Name, Character, " + "\n" + "or Group Size, Check your" + "\n" + "Name and Size boxs.";
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
