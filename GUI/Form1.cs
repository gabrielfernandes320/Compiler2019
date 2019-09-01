using System.Windows.Forms;
using System.Collections.Generic;
using Core;
using System;
using Core.Utils;
using Core.LexicalAnalysis;

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
            string pathToRead = @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/test.txt";
            IList<Token> tokenList = new List<Token>();

            fileHandler.WriteFile(rtbSourceCode.Lines);
            // rtbSourceCode.Clear();

            // Get text to lexical analysis
            string textToAnalyze = fileHandler.GetText();

            // Initialize lexical analyzer
            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer(textToAnalyze);

            // Generate tokens list
            tokenList = lexicalAnalyzer.ExtractTokens();

            // Set extracted token to form
            dgTokens.DataSource = tokenList;
            
            // Debug
            /*foreach (Token token in tokenList)
            {
                Console.WriteLine(token.Code);
            }*/

            // tbSourceCode.Text = SpecialCharacters.Plus.GetStringValue();
        }
    }
}
