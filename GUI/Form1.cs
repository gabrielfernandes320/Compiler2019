using System.Windows.Forms;
using System.Collections.Generic;
using Core;
using System;
using Core.Utils;
using Core.LexicalAnalysis;
using System.Linq;
using Core.Exceptions;

namespace GUI
{
    public partial class Form1 : Form
    {
        FileHandler fileHandler = new FileHandler();
 
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, System.EventArgs e)
        {
            // Clear tokens list
            dgTokens.DataSource = null;

            // Save text of editor do file
            string pathToRead = @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/test.txt";
            fileHandler.WriteFile(rtbSourceCode.Lines);

            // Get text to lexical analysis
            string[] textToAnalyze = rtbSourceCode.Lines;

            // rtbSourceCode.Clear();

            try
            {
                // Initialize lexical analyzer
                LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer(textToAnalyze);

                // Generate tokens list
                IList<Token> tokensList = new List<Token>(lexicalAnalyzer.ExtractTokens());

                // Set extracted token reordered list to form
                dgTokens.DataSource = tokensList.Reverse().ToList();

                // Debug
                /*foreach (Token token in tokensList)
                {
                    Console.WriteLine(token.Code);
                }*/
            }
            catch (LexicalException error)
            {
                MessageBox.Show(error.Message);
            }

            // tbSourceCode.Text = SpecialCharacters.Plus.GetStringValue();
        }
    }
}
