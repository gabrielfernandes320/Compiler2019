using System.Windows.Forms;
using CompilerCore.Utils;
using CompilerCore.Enums;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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




            util.WriteFile(tbSourceCode.Lines);
            tbSourceCode.Clear();

            string[] lines = File.ReadAllLines(pathToRead);
            tbSourceCode.Lines = lines;

            tbSourceCode.Clear();
            tbSourceCode.Text = SpecialCharacters.Plus.GetStringValue();


        }
    }
}
