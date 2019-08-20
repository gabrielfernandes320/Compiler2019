using System.Windows.Forms;
using CompilerCore.Utils;
using System.Collections;
using System.Collections.Generic;

namespace GUI
{
    public partial class Form1 : Form
    {
        Utils util = new Utils();
        public Form1()
        {
            InitializeComponent();
            

        }

        private void BtnAccept_Click(object sender, System.EventArgs e)
        {
            List<string> lines = new List<string>();

            foreach (var line in tbSourceCode.Lines)
            {
                lines.Add(line);
            }

            util.WriteFile(lines);
        }
    }
}
