using System.Windows.Forms;
using System.Collections.Generic;
using Core;
using System;
using Core.Utils;
using Core.LexicalAnalysis;
using System.Linq;
using Core.Exceptions;
using GUI.DataGrid;

namespace GUI
{
    public partial class Main : Form
    {
        private const string NEW_FILENAME = "novo-arquivo.lms";

        private string currentFileNamePath = NEW_FILENAME;

        private readonly FileHandler fileHandler = new FileHandler();
        private ToolTip toolTip = new ToolTip();

        public Main()
        {
            InitializeComponent();
            
            // Set initial filename label
            fileNameLabel.Text = NEW_FILENAME;
        }

        private void NewFileAction(object sender, EventArgs e)
        {
            // Clear tokens list
            dgTokens.DataSource = null;

            // Clear source code
            rtbSourceCode.Clear();

            // Change filename label
            fileNameLabel.Text = NEW_FILENAME;
        }

        private void OpenFileAction(object sender, EventArgs e)
        {
            // Clear tokens list
            dgTokens.DataSource = null;

            // Clear source code
            rtbSourceCode.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Linguagem Subset Pascal|*.lms";
            openFileDialog.Title = "Salvar Linguagem Subset Pascal";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                currentFileNamePath = openFileDialog.FileName;

                // Set filename label
                fileNameLabel.Text = openFileDialog.SafeFileName;

                // Read content from file
                rtbSourceCode.Text = fileHandler.GetText(openFileDialog.FileName);
            }
        }

        private void SaveFileAction(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Linguagem Subset Pascal|*.lms";
            saveFileDialog.Title = "Salvar Linguagem Subset Pascal";
            saveFileDialog.FileName = currentFileNamePath;
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                currentFileNamePath = saveFileDialog.FileName;

                // Save text of editor to file
                fileHandler.WriteFile(rtbSourceCode.Lines, saveFileDialog.FileName);
            }
        }

        private void AnalyzeCodeAction(object sender, EventArgs e)
        {
            // Clear tokens list before run
            dgTokens.DataSource = null;

            // Get text to lexical analysis
            string[] textToAnalyze = rtbSourceCode.Lines;

            try
            {
                // Initialize lexical analyzer
                LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer(textToAnalyze);

                // Generate tokens list
                IList<Token> tokensList = new List<Token>(lexicalAnalyzer.ExtractTokens());

                // Set extracted token reordered list to form
                dgTokens.DataSource = ParseTokensToGrid(tokensList);
            }
            catch (LexicalException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private IList<DataGridLineItem> ParseTokensToGrid(IList<Token> tokensList)
        {
            return tokensList
                .Reverse()
                .Select(e =>new DataGridLineItem
                {
                    Line = e.StartChar.Line.ToString(),
                    Code = e.Code.ToString(),
                    Value = e.Value
                })
                .ToList();
        }

        private void CompileCodeAction(object sender, EventArgs e)
        {

        }

        private void AboutAction(object sender, EventArgs e)
        {

        }
        
        private void fileNameLabelMouseOverAction(object sender, EventArgs e)
        {
            toolTip.RemoveAll();

            toolTip.SetToolTip(this.fileNameLabel, currentFileNamePath);

            toolTip.Show(currentFileNamePath, this.fileNameLabel);
        }

        private void DgTokens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
