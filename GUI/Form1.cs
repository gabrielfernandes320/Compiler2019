using System.Windows.Forms;
using CompilerCore.Utils;
using CompilerCore.Enums;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Core;

namespace GUI
{
    public partial class Form1 : Form
    {
        Util util = new Util();
 
        public Form1()
        {
            InitializeComponent();
            

        }

        private void BtnAccept_Click(object sender, System.EventArgs e)
        {
            string pathToRead = @"C:\temp\test.txt";
            List<Token> tokenList = new List<Token>();

            util.WriteFile(rtbSourceCode.Lines);
            rtbSourceCode.Clear();

            string[] lines = File.ReadAllLines(pathToRead);

            tokenList = util.LexicalAnalysis(lines);

            dgTokens.DataSource = tokenList;


            rtbSourceCode.Lines = lines;

           
            
            
            // tbSourceCode.Text = SpecialCharacters.Plus.GetStringValue();


        }
    }
}
