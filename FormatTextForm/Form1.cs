using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatTextForm
{
    public partial class Form1 : Form
    {
        /*
         * Below depicts the algorithm for print an output based on advised conditions
         * Create a Windows Forms application that contain two Textboxes for both input text and output text
         * Receive text input from the input Textbox
         * Check the text received to ensure it has just 300 characters else remove the trailing characters
         * Split the words in the remaining 300 characters and put them in a list
         * Loop through each word and determine the following:
         *      1. If the characters in each word are 3, change the word to capital letters
         *      2. If the word represents the last word in the loop, reverse the word
         * Add the words back to form the text after each loop
         * Print out the final result in the output text
         * Create a try - catch for each method and  print out any exception noticed inthe output text for review.
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Text = "";
                if (!string.IsNullOrEmpty(txtInput.Text))
                {
                    //Remove other characters greater than 300
                    string txtManip = DoTextManipulation(txtInput.Text);
                    txtOutput.Text = string.IsNullOrEmpty(txtManip) ? "Empty Response" : txtManip;
                }
                else
                {
                    txtOutput.Text = "Kindly enter a text in the input box.";
                }
            }
            catch (Exception ex)
            {
                //output error
                txtOutput.Text = ex.Message;
            }
        }
        public string DoTextManipulation(string input)
        {
            string output = string.Empty;
            try
            {
                if (input.Length > 300)
                {
                    //do remove
                    input = input.Remove(300, input.Length - 300);
                    //split to words and do necessary checks
                    output = ComputeOutput(input);
                }
                else
                {
                    output = ComputeOutput(input);
                }
            }
            catch (Exception ex)
            {
                //output error
                txtOutput.Text = ex.Message;
            }
            return output;
        }
        private string ComputeOutput(string input)
        {
            string formOutput = string.Empty;
            try
            {
                //do spliting
                List<string> inputWordsLen = input.Split(' ').ToList();
                //count words
                int wordCount = inputWordsLen.Count;
                int i = 0;
                foreach (string word in inputWordsLen)
                {
                    string theWord = string.Empty;
                    i++;
                    if (word.Length == 3)
                    {
                        //convert word with length = 3 to capital letters
                        theWord = word.ToUpper();
                    }
                    else { theWord = word; }
                    //reverse the last word and replace it with word
                    theWord = i == wordCount - 1 ? ReverseString(word) : theWord;
                    formOutput += theWord + " ";
                }
            }
            catch(Exception ex)
            {
                //output error
                txtOutput.Text = ex.Message;
            }
            return formOutput;
        }
        private string ReverseString(string input)
        {
            //convert each letter to char and put in char array for reversing
            char[] inputChar = input.ToCharArray();
            Array.Reverse(inputChar);
            return new string(inputChar);
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }
    }
}
