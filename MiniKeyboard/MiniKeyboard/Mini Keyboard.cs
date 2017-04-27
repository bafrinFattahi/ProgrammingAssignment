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
using MyDialogs;
namespace MiniKeyboard
{

    public partial class Frm_ : Form
    { 
        public Frm_()
        {
            InitializeComponent();
             System.Console.WriteLine("\u00a9");
        }
        // Flags changes made and thus file needs saving
        bool booleanRequiresSaving = false;
        // The Path to the 'Dictionary' 
        string strPresentFilePathName = "";
        // Timing Functionality 
        bool boolFirstVisit = true;
        int intIntervalRequired = 500;
        // Global ListBox placed on the Form.
        int intMyListIndex = 0;
        // Buttons. Identifies which button is being selected be the user. 
        bool[] BoolIsButtonPressed = new bool[19];
        // Prediction. 
        string Str_KeyStrokes;
        // Is the line from the list that has the highest useage 
        int intPredictedIndex;
        int intNumberOfCharacters;
        int pedictedWorddLength;
        int Number = -1;
        private string currentFile = "";
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer_Double.Interval = intIntervalRequired;
            for (int intWhichButton = 0; intWhichButton <= 18; intWhichButton++)
                BoolIsButtonPressed[intWhichButton] = false;
            // Load the Dictionary  loadDictionary();  
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_Mode_Click(object sender, EventArgs e)
        {
            //If the program is on prediction mode switch it to multi-press and vise versa.  
            if (txt_ModeStatus.Text == "Prediction")
            {
                txt_ModeStatus.Text = "Multi-Press";
            }
            else if (txt_ModeStatus.Text == "Multi-Press")
            {
                txt_ModeStatus.Text = "Prediction";
            }


        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[1] = true;
                    Str_KeyStrokes = "1";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_1.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_1.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_1.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }



        private void btn_7_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[7] = true;
                    Str_KeyStrokes = "7";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_7.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_7.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_7.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Allow user to set the interval
            intIntervalRequired = Convert.ToInt32(My_Dialogs.InputBox("Please enter the 'Delay Value' which is for every 1000 is equal to 1 second. At present the Delay value is 500."));
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void saveASToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           

        }

        private void List_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Selection_complete(object sender, EventArgs e)
        {
            txt_wordBuilder.AppendText(lstGlobalListbox.Items[Number].ToString());
            Timer_Double.Enabled = false;
            boolFirstVisit = true;
            Number = -1;
        }

        private void btn_zero_Click(object sender, EventArgs e)
        {
            // It append the text content of the WordBuilder textbox, into the Note Pad textbox followed by a space.
            txt_Main.AppendText(txt_wordBuilder.Text + " ");
            Str_KeyStrokes = "";
            txt_KeySequence.Clear();
            txt_wordBuilder.Clear();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            //Start new line in the main Text box
            txt_Main.AppendText(Environment.NewLine);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[11] = true;
                    Str_KeyStrokes = "11";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_underline.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_underline.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_underline.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[2] = true;
                    Str_KeyStrokes = "2";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_2.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_2.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_2.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[3] = true;
                    Str_KeyStrokes = "3";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_3.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_3.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_3.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[4] = true;
                    Str_KeyStrokes = "4";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_4.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_4.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_4.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[5] = true;
                    Str_KeyStrokes = "5";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_5.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_5.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_5.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[6] = true;
                    Str_KeyStrokes = "6";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_6.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_6.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_6.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[8] = true;
                    Str_KeyStrokes = "8";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_8.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_8.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_8.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[9] = true;
                    Str_KeyStrokes = "9";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_9.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_9.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_9.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            if (txt_ModeStatus.Text == "Multi-Press")
            {
                Timer_Double.Enabled = false;
                //If first click then set boolean for the button number to true, clear the gloabl list box and apprend variable to 1 (Str_KeySrokes).
                if (boolFirstVisit == true)
                {
                    lstGlobalListbox.Items.Clear();
                    BoolIsButtonPressed[10] = true;
                    Str_KeyStrokes = "10";
                    //Append Keystrokes to display the variable Str_KeyStrokes
                    txt_KeySequence.AppendText(Str_KeyStrokes);
                    for (int Index = 0; Index <= List_star.Items.Count - 1; Index++)
                    {
                        lstGlobalListbox.Items.Add(List_star.Items[Index].ToString());
                    }
                    //If not first click then enable timer and proceed.
                    boolFirstVisit = false;
                    Timer_Double.Enabled = true;
                    Number = Number + 1;
                }
                else
                {
                    //If not first click and is the same click again then.
                    Number = Number + 1;
                    Timer_Double.Enabled = true;
                    if (Number == List_star.Items.Count)
                    {
                        Number = 0;
                    }
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //code to save the current file and create the new notepad page
            if (txt_Main.Text != "")
            {
                //Code for having the 'SaveAs' dialog box open, i have also set to same folder as project
                StreamWriter outputStream = default(StreamWriter);
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                SaveFileDialog1.InitialDirectory = "G:\\Sheffiled Hallam 2017 Semester 2\\Programming\\Assignment2-MiniKeyboard\\ProgrammingAssignment\\MiniKeyboard\\";
                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    currentFile = SaveFileDialog1.FileName;
                    outputStream = File.CreateText(currentFile);
                    outputStream.Write(txt_Main.Text);
                    outputStream.Close();
                }

                //clear the main text box, create a new page.
                txt_Main.Text = "";
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Code for having the 'Open' dialog box open, i have set to same folder as project
            StreamReader inputStream = default(StreamReader);
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = "G:\\Sheffiled Hallam 2017 Semester 2\\Programming\\Assignment2-MiniKeyboard\\ProgrammingAssignment\\MiniKeyboard\\";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = OpenFileDialog1.FileName;
                inputStream = File.OpenText(currentFile);
                txt_Main.Text = inputStream.ReadToEnd();
                inputStream.Close();

            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Code for the 'Save' option, I have set it to save the text in the main window
            if (!string.IsNullOrEmpty(currentFile))
            {
                StreamWriter outputStream = File.CreateText(currentFile);
                outputStream.Write(txt_Main.Text);
                outputStream.Close();
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Code for having the 'SaveAs' dialog box open, i have also set to same folder as project
            StreamWriter outputStream = default(StreamWriter);
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.InitialDirectory = "G:\\Sheffiled Hallam 2017 Semester 2\\Programming\\Assignment2-MiniKeyboard\\ProgrammingAssignment\\MiniKeyboard\\";
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = SaveFileDialog1.FileName;
                outputStream = File.CreateText(currentFile);
                outputStream.Write(txt_Main.Text);
                outputStream.Close();
            }
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            // End the program
            System.Environment.Exit(0);
        }

        private void txt_Main_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

