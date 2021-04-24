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
    /*Group Members of Pro-gaming: James Schwantes, Dominic Simon, Nickolas Spreitzer, and Tony Mastrocola.  
     * 4/9/2021, 
     * The purpose of this program is to build teams with each team having different members.
     */
    public partial class Form1 : Form
    {
        // global variables the array values holds all the names in a big array 
        // String Name;
        int count = 0;
        string[] values = new string[400];
        string[] testNames = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
        string[] testGroup = { "aaron abe abe", "abel abdul abdul" };
        string[] splitted = new string[400];
        string[] randomNumbers = new string[400];
        string[] saveArray = new string[400];
        int undoCounter = 0;
        int indexSearch = 0;
        int temp = 0;

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
            MessageBox.Show("Click the top text box to enter a name \n Press 'Add' after each single name is entered \n'Undo Name' will delete the last name entered " +
                 "\n \n Use the bottom text box to enter the size of your team \n 'Create Group' will be used to create your group solutions \n (use when names and size are fullfilled)" +
                 "\n \n 'Clear' will reset ALL areas of the application \n \n The two boxes at the bottom are for Name and Group output. \n \n" +
                 "The 'Open' button is used to select any document of choice.\n\nMake sure that the text file your opening has this format. \n" +
                 "Example: FirstName_LastName FirstName2_LastName2 \n \nThe 'Save As' button is used to save to a document", "Quick Start Guide");
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
                            //splitted = testGroup[indexSearch].Split(' ');
                            fileContent = reader.ReadToEnd();
                            string[] splitFile = fileContent.Split(' ');

                            //splitFile = fileContent.Split(' ');
                            for (int i = 0; i < splitFile.Length; i++)
                            {
                                int counter = 0;
                                counter++;

                                values[i] = splitFile[i];
                            }
                            this.richTextBox2.Text = fileContent;
                            //string testing = String.Concat(splitFile);
                            //this.richTextBox1.Text = testing;
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
            // switch so you divide people by groups and test groups for the random nbumber
            // This is the create group button the code for checking for duplicate names is underway and on a good track but not finished
            // Takes random function and gives a name a random number and displays it in textbox1 "group" textbox
            //
            //
            //
            //

            try
            {
                this.richTextBox1.Clear();
                string[] groupNumStorage = new string[100];
                Random random = new Random();
                int numOfGroups = Convert.ToInt32(this.textBox2.Text);
                //int randomNumber =   testNames.Length/numOfGroups;
                //int randomNumberCount = 0;
                //int checkAnswer = 0;
                for (int i = 0; i <= count - 1; i++)
                {
                    int randomNumber = random.Next(numOfGroups);
                    //randomNumberCount = randomNumber;

                    //groupNumStorage
                    // makes it so it displays groups starting at 1 and not 0
                    int answer = randomNumber + 1;


                    if (values[i] == null)
                    {
                        continue;
                    }
                    else
                    {   // sets each index of randomNumbers to annswer so it can print off the groups when writing to file
                        randomNumbers[i] = answer.ToString();
                        this.richTextBox1.AppendText(answer + " " + values[i] + " " + "\n");
                        //this.richTextBox2.AppendText(randomNumbers[i]);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid Name, Character, " + "\n" + "or Group Size, Check your" + "\n" + "Name and Size boxs.");
            }

            //
            // below is the code for adding names to each persons array index so the duplicate checker can look for duplicated names does not curretly work correct
            // so it is not implemeted
            // below that starting at line 263 
            // is the code for checking for duplicates in groups it works but a count variable is making the array index go out of bounds
            // so it works but errors out 
            // 

            /*for (int index = 0; index<testNames.Length;index++)
            {
                if (randomNumber==index)
                {
                    groupNumStorage[answer] = testNames[i];
                }
            }*/


            //Name = Convert.ToString(this.richTextBox1.Text);


            //string output = String.Join(" ",groupNumStorage);
            //this.richTextBox2.AppendText(output);


            /*
            // grou checker 

            
            for (int i = 0; i <= testGroup.Length; i++)
            {

                do
                {
                    string result = String.Concat(splitted);
                    
                    splitted = testGroup[indexSearch].Split(' ');
                    //this.richTextBox2.AppendText(testGroup[indexSearch]);
                    //this.richTextBox2.AppendText(result + " ");

                    if (temp < splitted.Length)
                    {
                        if (splitted[indexSearch] != splitted[temp])
                        {
                            //for (int f = 0; f<=splitted.Length  ;f++)
                            //{
                            this.richTextBox1.AppendText(splitted[indexSearch] + " ");

                            //}

                        }
                        else
                        {
                            this.richTextBox1.AppendText(splitted[indexSearch] + " ");
                            this.richTextBox1.AppendText("Duplicate found ");

                        }
                        temp++;
                        indexSearch++;
                    }

                } while (indexSearch < testGroup[i].Length );
                for (int a = 0; a< splitted.Length;a++)
                {
                    splitted[a] = "";
                }
                indexSearch = 0;
                temp = 0;
            }
            
            */
            /*
            for (int i =0;i<numOfGroups;i++)
             {
                 this.richTextBox1.AppendText(numOfGroups.ToString() + " ");
             }
            */

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }
    }
}
