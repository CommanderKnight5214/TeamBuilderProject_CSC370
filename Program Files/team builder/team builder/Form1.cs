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
    * the only thing implemented in sprint 3 is it displays groups instead of names and the group they are in it also saves groups to an txt file
    * While there is more code than just what was implemted we did not include it in this sprint because it is not complety working with inputed names but works with hardcoded names going to change this
    * 
    * 
    */
    public partial class Form1 : Form
    {// global variables the array values holds all the names in a big array 
        string Name;
        string[] arr = { };
        int count = 0;
        string[] values = new string[400];
        string[] splitted = { };
        string[] randomNumbers = new string[400];
        string[] saveArray = new string[400];
        string[] checkArray = new string[400];
        string[] groupNumStorage = new string[100];
        string[] displayArray = { };
        string[] teamString = new string[400];
        string tempStringDisplay = "";
        bool ArraySaved = false;
        bool RandomNumbersSaved = false;
        int ErrorCounter = 0;
        int beginningLine = 0;
        int teamCount = 0;
        int undoCounter = 0;
        int runTimeCount = 0;
        int numOfGroupsCount = 0;


        string generalPurposeErrorMessage = "Invalid Team Size." + "\n" + "Check your Team Size Box.";
        string ErrorMessageForTeamSize = "You need to have a list of Names, and a Team Size \nin order to create a group.";
        string WarningLabel = "Warning!";
        //this is all the arrays i use for testig
        string[] outputarray = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
        string[] testNames = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
        string[] testGroup = { "aaron abe abe", "abel abdul abdul", "abel abdul adam" };
        string[] testGroup2 = { "aaron abe abe", "abel abdul abdul", "abel abdul adam", "abel abdul adam", "abel abdul adam", "abel abdul adam" };
        string[] sameGroupCheck = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
        //int indexSearch = 0;
        //int temp = 0;
        // add check for space and wrong format for add names

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //this is the clear button
        {
            for (int i = 0; i != values.Length; i++) //sets all indexs in values to empty string
            {
                values[i] = " ";
                //this.richTextBox1.AppendText(i + " ");
            }
            this.richTextBox1.Clear();
            this.richTextBox1.AppendText("");
            this.textBox1.Clear();
            this.textBox3.Clear();
            this.richTextBox2.Clear();

            for (int i = 0; i < teamString.Length; i++)
            {
                if (teamString[i] != "")
                {
                    teamString[i] = "";
                }
            }
            if(ArraySaved == true)
            {
                for (int i = 0; i < saveArray[i].Length; i++)
                {
                    if (saveArray[i] != "")
                    {
                        saveArray[i] = "";
                    }
                }
            }
            if(RandomNumbersSaved == true)
            {
                for (int i = 0; i < randomNumbers[i].Length; i++)
                {
                    if (randomNumbers[i] != "")
                    {
                        randomNumbers[i] = "";
                    }
                }
            }
            for (int i = 0; i < values[i].Length; i++)
            {
                if (values[i] != "")
                {
                    values[i] = "";
                }
            }
            for (int i = 0; i < saveArray.Length; i++)
            {
                if (saveArray[i] != "")
                {
                    saveArray[i] = "";
                }
            }

            Name = "";
            ArraySaved = false;
            teamCount = 0;
            count = 0;
            textBox1.Focus();
        }
        //This is the add button, the primary purpose of this button is to allow the user to add names to the rich text box. 
        private void button1_Click(object sender, EventArgs e)
        {
            Name = Convert.ToString(this.textBox1.Text);
            if(Name == "" || Name == " ")
            {
                MessageBox.Show("You must enter a Name into \nthe Name Text Box before adding.", "No Name");
            }
            else
            {
                this.richTextBox2.AppendText(Name + " ");
                values[count] = Name;
                count++;
                this.textBox1.Text = Convert.ToString(" ");
                
            }
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //This is the save as tool strip, the primary function of this tool strip is to allow the user to save the groups that were added to the program in a text file. 
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //puts groups and names into 1 array so StreamWriter can save to file
            for (int i = 0; i <= count; i++)
            {
                saveArray[i] = randomNumbers[i] + " " + values[i];
            }
            ArraySaved = true;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "Document"; // Default file name
            saveFileDialog1.DefaultExt = ".txt"; // Default file extension
            saveFileDialog1.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            saveFileDialog1.ShowDialog();
            
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);


            foreach (string line in teamString)    // this will print names virtically
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
            //
            //there is a problem with open menu strip i am working on fixing it will display the information in the file but wont add the information in the file
            //to the values array
            //
                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Text documents (.txt)|*.txt";
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
                                count++;
                            }
                            this.richTextBox2.Text = fileContent;
                            
                            //string testing = String.Concat(splitFile);
                            //this.richTextBox1.Text = testing;
                        }
                    }
                }
            ErrorCounter = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)  // undo button
        {
            //undo button clears textbox 2 "name" text box it checks to see if values is empty if not it sets array to get rid of last index by the variable count
            //and sets to empty string for formating in the file 
            //   int undoLocation = values.Length - 1;
            // values[undoLocation] = " ";
            this.richTextBox2.Clear();
            //int undoCounter = 0;
            if (count == 0)
            {
                MessageBox.Show("There are no more names" + "\n" + "in the Name Display box.", "No Names");
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
            //groupChecker(testGroup2, testGroup5);


            groupCreator(values);
            //richTextBox2.AppendText("\n");
            //groupCheckArrayCreator(groupNumStorage);
            //duplicateRemover(outputarray);
            /*
             groupCreator(testNames);


             if(runTimeCount>1)
             {
                 MessageBox.Show("yeet");
             }
            */
            //groupCheckArrayCreator(testGroup3);


            //groupChecker(testGroup);
            //replace values with numgroupstorage for testing
            //groupCheckArrayCreator(testGroup);
            // switch so you divide people by groups and test groups for the random nbumber
            // This is the create group button the code for checking for duplicate names is underway and on a good track but not finished
            // Takes random function and gives a name a random number and displays it in textbox1 "group" textbox
            //int numOfGroups = Convert.ToInt32(this.textBox2.Text);
            runTimeCount++;
            teamCount = 0;
            int numOfGroups = 0;
            string TeamSize = this.textBox3.Text;
            if (teamCount != 0)
            {
                for (int i = 0; i < teamString.Length; i++)
                {
                    if (teamString[i] != "")
                    {
                        teamString[i] = "";
                    }
                }
                teamCount = 0;
            }
            else if (TeamSize == "" && ErrorCounter == 0)
            {
                MessageBox.Show(ErrorMessageForTeamSize, WarningLabel);
                ErrorCounter++;
            }
            else if (count == 0)
            {
                MessageBox.Show(ErrorMessageForTeamSize, WarningLabel);
                ErrorCounter++;
            }
            else
            {
                try
                {
                    numOfGroups = Convert.ToInt32(this.textBox3.Text);
                    this.richTextBox1.Clear();
                    Random random = new Random();//change to count
                    for (int i = 0; i <= testNames.Length; i++)
                    {
                        int randomNumber = random.Next(numOfGroups);

                        //makes it so it displays groups starting at 1 and not 0
                        int answer = randomNumber + 1;


                        if (values[i] == null)
                        {
                            continue;
                        }

                        else
                        {
                            count++;
                            // sets each index of randomNumbers to annswer so it can print off the groups when writing to file
                            randomNumbers[i] = answer.ToString();
                            RandomNumbersSaved = true;
                            //this.richTextBox1.AppendText(answer + " " + values[i] + " " + "\n");
                            /*
                            groupNumStorage[randomNumber] += (" "+testNames[i]  );
                            if(randomNumber==0)
                            {
                            MessageBox.Show(String.Concat(groupNumStorage[0]));
                            }*/
                            for (int addingNames = 0; addingNames < count; addingNames++) //adds names to a group this is where code changed from displayig names to displaying groups.
                            {
                                if (randomNumber == addingNames)
                                {
                                    groupNumStorage[randomNumber] += (" " + values[i]);
                                }
                            }
                            //this.richTextBox2.AppendText(answer + " " + values[i] + " " + "\n");
                            //this.richTextBox2.AppendText(randomNumbers[i]);

                            //}
                            //for(int addingToGroupStorage= 0; addingToGroupStorage<)
                        }
                    }
                }
                catch
                {
                    /*
                    if (ErrorCounter == 0)
                    {
                        MessageBox.Show(generalPurposeErrorMessage, WarningLabel);
                        ErrorCounter = 0;
                    }
                    */
                    /*
                    else
                    {
                    */
                        ErrorCounter = 0;
                    /*
                    }
                    */
                }
                
            }
            ErrorCounter = 0;
            
            

            for (int displayIndex = 0; displayIndex < numOfGroups; displayIndex++) //this displays the groups in a pretty way
            {
                int saveDisplayIndex = displayIndex + 1;                                //groupnumstorage
                tempStringDisplay = "\nTeam: " + saveDisplayIndex.ToString() + groupNumStorage[displayIndex];

                teamString[teamCount] = tempStringDisplay;
                this.richTextBox1.AppendText(tempStringDisplay);
                teamCount++;
            }
            for (int clearig = 0; clearig < groupNumStorage.Length; clearig++)
            {
                groupNumStorage[clearig] = "";
            }
            runTimeCount++;

            textBox1.Focus();

        }//this makes the array so it can be checked for duplicates it works but not impletmeted
        public void groupCreator(string[] Names)
        {
            if (this.textBox3.Text == "")
            {
                MessageBox.Show(ErrorMessageForTeamSize, WarningLabel);
                ErrorCounter++;
            }
            else if (count == 0)
            {
                ErrorCounter++;
            }
            else
            {
                try
                {
                    double sizeOfGroups = Convert.ToDouble(this.textBox3.Text);
                    double product = Names.Length / sizeOfGroups;
                    double numOfGroup = Math.Ceiling(product);
                    //MessageBox.Show(numOfGroup.ToString());    
                    int sizeOfGroup = (int)numOfGroup;
                    int numOfGroups = (int)sizeOfGroups;
                    numOfGroupsCount = numOfGroups;
                    //MessageBox.Show(numOfGroups.ToString());
                    int[] groupNumStorageSize = new int[400];
                    //int sizeOfGroups = testNames.Length %numOfGroups ;
                    //this.richTextBox1.Clear();
                    Random random = new Random();//change to count
                    for (int i = 0; i <= count; i++)
                    {
                        int randomNumber = random.Next(numOfGroups);
                        int randomNumber2 = random.Next(numOfGroups);
                        int randomNumber3 = random.Next(numOfGroups);
                        int randomNumber4 = random.Next(numOfGroups);
                        //makes it so it displays groups starting at 1 and not 0
                        int answer = randomNumber + 1;


                        if (Names[i] == null)
                        {
                            continue;
                        }

                        else
                        {
                            count++;
                            // sets each index of randomNumbers to annswer so it can print off the groups when writing to file
                            randomNumbers[i] = answer.ToString();

                            for (int addingNames = 0; addingNames < count; addingNames++) //adds names to a group this is where code changed from displayig names to displaying groups.
                            {

                                if (randomNumber == addingNames)
                                {
                                    if (groupNumStorageSize[randomNumber] < sizeOfGroup) // this line will make all groups even example 20 names 4 groups 5 names per group every group will get 5 names
                                    {

                                        //groupNumStorage[randomNumber] += (" " + Names[i]);
                                        // groupNumStorageSize[randomNumber]++;


                                        // the if statements below will try to create as equal groups as they can 

                                        if (groupNumStorageSize[randomNumber] < groupNumStorageSize[randomNumber2])
                                        {
                                            groupNumStorage[randomNumber] += (" " + Names[i]);
                                            groupNumStorageSize[randomNumber]++;
                                        }
                                        else if (groupNumStorageSize[randomNumber2] < groupNumStorageSize[randomNumber3])
                                        {

                                            groupNumStorage[randomNumber2] += (" " + Names[i]);
                                            groupNumStorageSize[randomNumber2]++;
                                        }
                                        else
                                        {
                                            groupNumStorage[randomNumber3] += (" " + Names[i]);
                                            groupNumStorageSize[randomNumber3]++;
                                        }
                                    }
                                    else
                                    {
                                        i--;

                                    }

                                }
                            }

                            //this.richTextBox1.AppendText(answer + " " + Names[i] + " " + "\n");
                        }
                    }


                    for (int displayIndex = 0; displayIndex < numOfGroups; displayIndex++) //this displays the groups in a pretty way
                    {
                        int saveDisplayIndex = displayIndex + 1;                                //groupnumstorage
                        tempStringDisplay = "\nTeam " + saveDisplayIndex.ToString() + ": " + groupNumStorage[displayIndex];

                        teamString[teamCount] = tempStringDisplay;
                        this.richTextBox1.AppendText(tempStringDisplay);
                        teamCount++;
                    }
                    //MessageBox.Show(String.Concat(groupNumStorageSize));
                    for (int clearig = 0; clearig < groupNumStorage.Length; clearig++)
                    {
                        groupNumStorage[clearig] = "";
                    }
                    textBox1.Focus();

                }
                catch
                {
                    MessageBox.Show(generalPurposeErrorMessage, WarningLabel);
                }

            }   
        }
            

    


        public void groupCheckArrayCreator(string[] array)
        {   //string[] = {//group1// "aaron abdul abe abel abraham", //group2//"adam adan adolfo adolph adrian"};
            string[] splitArray = { };
            //sameGroupCheck
            outputarray = values;

            //string[] testGroup = { "aaron abe abe", "abel abdul abdul", "abel abdul adam", "abel abdul adam", "abel abdul adam", "abel abdul adam" };
            for (int i = 0; i < numOfGroupsCount; i++)//goes to end of array
            {
                splitted = array[i].Split(' ');//splits array
                for (int split = 0; split < splitted.Length; split++)
                {
                    for (int testIndex = 0; testIndex < count; testIndex++)
                    {
                        if (splitted[split] == values[testIndex])
                        {
                            // MessageBox.Show(splitted[split].ToString()+ "same name found");
                            outputarray[testIndex] += " " + array[i];
                        } //here make a clone of output array
                        else
                        {
                            //MessageBox.Show(splitted[split].ToString() + "same name not found");
                        }
                    }
                }


                //expect error here

                for (int reset = 0; reset < splitted.Length; reset++)//clears the array for the next index of main array
                {
                    splitted[reset] = "";
                }

            }
            //this function call removes all the duplicates after the code above adds all names to each person they have been grouped with
            //for (int outputReset = 0; outputReset < outputarray.Length; outputReset++)//clears the array for the next index of main array
            //{
            //    outputarray[outputReset] = "";
            //}
        }

        //pass this result to groupCheckArrayCreator // pass that to group checker then duplicate remover
        public void groupCreatorTest(string[] Names)
        {
            double sizeOfGroups = Convert.ToDouble(this.textBox3.Text);
            double product = Names.Length / sizeOfGroups;
            double numOfGroup = Math.Ceiling(product);
            //MessageBox.Show(numOfGroup.ToString());    
            int numOfGroups = (int)numOfGroup;
            numOfGroupsCount = numOfGroups;
            //MessageBox.Show(numOfGroups.ToString());
            int[] groupNumStorageSize = new int[400];
            try
            {
                //int sizeOfGroups = testNames.Length %numOfGroups ;
                this.richTextBox1.Clear();
                Random random = new Random();//change to count
                for (int i = 0; i <= Names.Length; i++)
                {
                    int randomNumber = random.Next(numOfGroups);
                    int randomNumber2 = random.Next(numOfGroups);
                    int randomNumber3 = random.Next(numOfGroups);
                    int randomNumber4 = random.Next(numOfGroups);
                    //makes it so it displays groups starting at 1 and not 0
                    int answer = randomNumber + 1;


                    if (Names[i] == null)
                    {
                        continue;
                    }

                    else
                    {
                        count++;
                        // sets each index of randomNumbers to annswer so it can print off the groups when writing to file
                        randomNumbers[i] = answer.ToString();

                        for (int addingNames = 0; addingNames < Names.Length; addingNames++) //adds names to a group this is where code changed from displayig names to displaying groups.
                        {

                            if (randomNumber == addingNames)
                            {
                                if (groupNumStorageSize[randomNumber] < sizeOfGroups) // this line will make all groups even example 20 names 4 groups 5 names per group every group will get 5 names
                                {                                                  // the if statements below will try to create as equal groups as they can 

                                    if (groupNumStorageSize[randomNumber] < groupNumStorageSize[randomNumber2] || groupNumStorageSize[randomNumber] < groupNumStorageSize[randomNumber3])
                                    {
                                        groupNumStorage[randomNumber] += (" " + Names[i]);
                                        groupNumStorageSize[randomNumber]++;
                                    }
                                    else if (groupNumStorageSize[randomNumber2] < groupNumStorageSize[randomNumber3] && groupNumStorageSize[randomNumber] == groupNumStorageSize[randomNumber3] || groupNumStorageSize[randomNumber2] == groupNumStorageSize[randomNumber3])
                                    {

                                        groupNumStorage[randomNumber2] += (" " + Names[i]);
                                        groupNumStorageSize[randomNumber2]++;
                                    }
                                    else
                                    {
                                        groupNumStorage[randomNumber3] += (" " + Names[i]);
                                        groupNumStorageSize[randomNumber3]++;
                                    }
                                }
                                else
                                {
                                    i--;
                                }

                            }
                        }

                        this.richTextBox1.AppendText(answer + " " + Names[i] + " " + "\n");
                    }
                }
            }
            catch
            {
                MessageBox.Show(generalPurposeErrorMessage, WarningLabel);
            }
            for (int displayIndex = 0; displayIndex < numOfGroups; displayIndex++) //this displays the groups in a pretty way
            {
                int saveDisplayIndex = displayIndex + 1;                                //groupnumstorage
                this.richTextBox2.AppendText("\nteam: " + saveDisplayIndex.ToString() + groupNumStorage[displayIndex]);
            }
            MessageBox.Show(String.Concat(groupNumStorageSize));
            //for(int clearig = 0; clearig<groupNumStorage.Length;clearig++)
            //{
            // groupNumStorage[clearig] = "";
            // }


            textBox1.Focus();

        }//pass this result to groupCheckArrayCreator // pass that to group checker then duplicate remover


        public void groupCheckArrayCreatorTest(string[] array)
        {   //string[] = {//group1// "aaron abdul abe abel abraham", //group2//"adam adan adolfo adolph adrian"};
            string[] splitArray = { };
            //sameGroupCheck
            string[] sameGroupCheck = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };

            //string[] testGroup = { "aaron abe abe", "abel abdul abdul", "abel abdul adam", "abel abdul adam", "abel abdul adam", "abel abdul adam" };
            for (int i = 0; i < numOfGroupsCount; i++)//goes to end of array
            {
                splitted = array[i].Split(' ');//splits array
                for (int split = 0; split < splitted.Length; split++)
                {
                    for (int testIndex = 0; testIndex < sameGroupCheck.Length; testIndex++)
                    {
                        if (splitted[split] == sameGroupCheck[testIndex])
                        {
                            // MessageBox.Show(splitted[split].ToString()+ "same name found");
                            outputarray[testIndex] += " " + array[i];
                        } //here make a clone of output array
                        else
                        {
                            //MessageBox.Show(splitted[split].ToString() + "same name not found");
                        }
                    }
                }


                //expect error here

                for (int reset = 0; reset < splitted.Length; reset++)//clears the array for the next index of main array
                {
                    splitted[reset] = "";
                }

            }
            duplicateRemoverTest(outputarray); //this function call removes all the duplicates after the code above adds all names to each person they have been grouped with
                                               //for (int outputReset = 0; outputReset < outputarray.Length; outputReset++)//clears the array for the next index of main array
                                               //{
                                               //    outputarray[outputReset] = "";
                                               //}
        }//this makes the array so it can be checked for duplicates it works but not impletmeted // pass to groupChecker

        public void duplicateRemoverTest(string[] outputArray) // this removes all duplicate nnames
        {
            string[] a = { };
            string[] a2 = new string[400];
            //string[] array1 = { "aaron abe abe", "abel abdul abdul", "abel abdul adam" };

            for (int str = 0; str < testNames.Length; str++)
            {

                arr = outputArray[str].Split(' '); //splits array ////

                a = arr.Distinct().ToArray();//removes all duplicates in the array and saves to another array

                //MessageBox.Show(String.Concat(a));

                a2[str] = string.Join(" ", a); //joins array together

                for (int reset = 0; reset < arr.Length; reset++)
                {
                    arr[reset] = ""; //resets the splitted array
                }
            }

            for (int output = 0; output < a2.Length; output++)
            {
                if (a2[output] != null)
                {
                    this.richTextBox2.AppendText(a2[output] + "\n");

                }
                //this.richTextBox2.AppendText(outputarray[output]+ "\n" );
                //this.richTextBox2.AppendText(splitArray[output] + "\n");
                // outputs array with no duplicates
            }

        } //after this display the array. 

        public void groupChecker(string[] temp, string[] original)   // this is the code for checking for duplicates in groups takes in an array and will return to a global array the array so it can be processed ikn the next click
        {
            for (int i = 0; i < temp.Length; i++)//goes to end of array
            {
                splitted = temp[i].Split(' ');//splits array
                string tempTest = splitted[0];
                splitted[0] = "";
                //MessageBox.Show(tempTest);
                //MessageBox.Show(splitted[0]);
                if (splitted.Distinct().Count() != splitted.Count())//tests if any values of the first index of main array are duplicates in each index of splitted array
                {

                    // MessageBox.Show(String.Concat(temp));
                    //temp = original;

                    splitted[0] = tempTest;
                    // MessageBox.Show(splitted[0]);
                    tempTest = "";
                    //MessageBox.Show(tempTest);
                    //MessageBox.Show(String.Concat(splitted));
                    //take the temp array copy to original pass original to duplicate remover then display it

                }

                else
                {
                    //call create group function again
                }



                for (int reset = 0; reset < splitted.Length; reset++)//clears the array for the next index of main array
                {
                    splitted[reset] = "";
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // attempts that did not work not usefull to code but shows thought process


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
         string[] parts = {};
         //string text = "1,2,3,4,5";
         //string[] parts = text.Split(',');
         for (int i =0; i<testGroup.Length;i++)
         {
              parts = testGroup[i].Split(',');
         }
         HashSet<string> hset = new HashSet<string>();
         foreach(string item in parts)
         {
             hset.Add(item);
         }
         if (hset.Count < parts.Length)
         {
            this.richTextBox2.AppendText(parts[item]);
         }
         else
         {
             this.richTextBox1.AppendText(parts[item]);
         }
        */
        /*
        for (int i =0;i<testGroup.Length;i++)
            {
            if (testGroup.Distinct().Count() != testGroup.Count())
            {
             MessageBox.Show("good");
            }
            else
            {
             MessageBox.Show("bad");

            }
        }

        */
        /*
        for(int i = 0; i<testGroup.Length;i++)
        {
            splitted = testGroup[i].Split(' ');
            if (splitted.Distinct().Count() != splitted.Count())
            {
                MessageBox.Show("List " + i.ToString() +" contains duplicate values.");
            }
            else
            {
                MessageBox.Show("list " + i.ToString()+ " is good");
            }
            MessageBox.Show(String.Concat(splitted));
            for(int reset=0;reset<splitted.Length;reset++)
            {
                splitted[reset] ="";
            }
        }
        */
        /*
        int temp = 0;
        // group checker take 2
        int count2 =0;
        for(int i =0;i<testGroup.Length;i++)
        {
            //MessageBox.Show(testGroup[i]);
            splitted = testGroup[i].Split(' ');
            count++;
            int follower =1;
            for(int search = 0; search< splitted.Length;search++)
            {

                if(follower<count)
                {
                        follower++;
                    if(splitted[temp]==splitted[follower] && follower<splitted.Length)
                    {
                        MessageBox.Show("duplicate");
                    }
                    else
                    {
                        MessageBox.Show("passed");
                    }
                }

                //MessageBox.Show(temp.ToString() +" "+ follower.ToString());



            }               
        temp++;
        }
        */

        // grou checker 

        /*
        for (int i = 0; i <= testGroup.Length; i++)
        {

            for(int tempVariable = 0; tempVariable<3;tempVariable++)
            {
                string result = String.Concat(splitted);

                splitted = testGroup[tempVariable].Split(' ');
                //this.richTextBox2.AppendText(testGroup[indexSearch]);
                //this.richTextBox2.AppendText(result + " ");

                //check the comparision

                if (temp < testGroup.Length)
                {

                    if (splitted[indexSearch] != splitted[temp])
                    {

                        //for (int f = 0; f<=splitted.Length  ;f++)
                        //{
                        this.richTextBox1.AppendText(splitted[indexSearch] + " ");
                        MessageBox.Show("passed" + indexSearch);
                        //}

                    }
                    else
                    {
                        this.richTextBox1.AppendText(splitted[indexSearch] + " ");
                        this.richTextBox1.AppendText("Duplicate found ");
                        MessageBox.Show(string.Concat(splitted));
                    }
                    tempVariable++;
                    temp++;
                    indexSearch++;
                }

            } //while (indexSearch < testGroup[i].Length );
            /*for (int a = 0; a< splitted.Length;a++)
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
        /*
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
        */

        /*          
                    string[] a = { };
                    string[] a2 = new string[400];
                    string[] array1 = {"aaron abe abe", "abel abdul abdul", "abel abdul adam" };
                    string[] arr = { };
                    for (int str = 0; str < array1.Length; str++)
                    {

                        arr = array1[str].Split(' ');
                        a = arr.Distinct().ToArray();

                        MessageBox.Show(String.Concat(a));

                            a2[str] = string.Join(" ", a);

                        for (int reset = 0; reset < arr.Length; reset++)
                        {
                            arr[reset] = "";
                        }
                    }

                    for (int output = 0; output < a2.Length; output++)
                    {
                        //this.richTextBox2.AppendText(outputarray[output]+ "\n" );
                        //this.richTextBox2.AppendText(splitArray[output] + "\n");
                        this.richTextBox2.AppendText(a2[output] + "\n");
                    }
                    */

        /*for (int output=0;output<outputarray.Length;output++)
        {
            this.richTextBox2.AppendText(outputarray[output]+ "\n" );
            //this.richTextBox2.AppendText(splitArray[output] + "\n");
            //this.richTextBox2.AppendText(a[output] + "\n");
        }*/


    }
}
