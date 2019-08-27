using System.Windows.Forms;
using CompilerCore.Utils;
using Core.Enum;
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
            //rtbSourceCode.Clear();

            string letters = File.ReadAllText(pathToRead);

            tokenList = util.LexicalAnalysis(letters);

            dgTokens.DataSource = tokenList;


            // tbSourceCode.Text = SpecialCharacters.Plus.GetStringValue();


        }
    }
}
