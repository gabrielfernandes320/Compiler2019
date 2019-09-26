using System.Windows.Forms;
using System.Collections.Generic;
using Core;
using System;
using Core.Utils;
using Core.LexicalAnalysis;
using System.Linq;
using Core.Exceptions;
using GUI.DataGrid;
using ScintillaNET;
using System.Drawing;
using Core.SyntacticalAnalyzer;

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

            // Set margin to show line numbers
            sourceCode.Margins[0].Width = 34;
        }

        private void NewFileAction(object sender, EventArgs e)
        {
            // Clear tokens list
            dgTokens.DataSource = null;

            // Clear source code
            sourceCode.ClearAll();

            currentFileNamePath = NEW_FILENAME;

            // Change filename label
            fileNameLabel.Text = NEW_FILENAME;
        }

        private void OpenFileAction(object sender, EventArgs e)
        {
            // Clear tokens list
            dgTokens.DataSource = null;

            // Clear source code
            sourceCode.ClearAll();

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
                sourceCode.Text = fileHandler.GetText(openFileDialog.FileName);
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
                fileHandler.WriteFile(ConvertSourceCodeLinesToArray(sourceCode.Lines), saveFileDialog.FileName);
            }
        }

        private void AnalyzeCodeAction(object sender, EventArgs e)
        {
            tbConsole.Text = "Preparando...\n";

            // Clear tokens list before run
            dgTokens.DataSource = null;

            // Get text to lexical analysis
            string[] textToAnalyze = ConvertSourceCodeLinesToArray(sourceCode.Lines);

            try
            {
                // LEXICAL ANALISIS
                tbConsole.AppendText("Executando análise léxica...\n");

                // Initialize lexical analyzer
                LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer(textToAnalyze);
                IList<Token> extractedTokens = lexicalAnalyzer.Start();

                // Set extracted tokens to grid
                dgTokens.DataSource = ParseTokensToGrid(extractedTokens);

                tbConsole.AppendText("Análise léxica concluída\n");

                // SINTACTICAL ANALISIS
                tbConsole.AppendText("Executando análise sintática...\n");

                SyntacticalAnalyzer syntacticalAnalyzer = new SyntacticalAnalyzer(extractedTokens);

                syntacticalAnalyzer.Start();
            }
            catch (LexicalException error)
            {
                // Set error to console
                tbConsole.AppendText("ERRO! ");

                tbConsole.AppendText(error.Message + "\n");

                // Select error in the textbox
                SelectErrorLine(error.GetLine());

                // Show error dialog
                MessageBox.Show("Houve um erro ao efetuar a análise léxica do código fonte\n");
            }
            catch (SyntacticalException error)
            {
                // Set error to console
                tbConsole.AppendText("ERRO! ");

                tbConsole.AppendText(error.Message + "\n");

                // Select error in the textbox
                SelectErrorLine(error.GetLine());

                // Show error dialog
                MessageBox.Show("Houve um erro ao efetuar a análise sintática do código fonte\n");
            }
        }

        private void SelectErrorLine(int lineNumber)
        {

            Line sourceCodeLine = sourceCode.Lines.ElementAtOrDefault(lineNumber - 1);

            // Select line in the source code
            if (sourceCodeLine != null)
            {
                sourceCode.SetSelection(sourceCodeLine.EndPosition, sourceCodeLine.Position);
            }
        }

        private string[] ConvertSourceCodeLinesToArray(LineCollection sourceCodeLines)
        {
            return sourceCodeLines
                .Select(y => y.Text)
                .ToArray();
        }

        private IList<DataGridLineItem> ParseTokensToGrid(IList<Token> tokensList)
        {
            return tokensList
                .Select(y =>new DataGridLineItem
                {
                    Line = y.StartChar.Line.ToString(),
                    Code = y.Code.ToString(),
                    Value = y.Value
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

        private void dataGridRowFocusEvent(object sender, DataGridViewCellEventArgs e)
        {
            int line = int.Parse(dgTokens.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());

            Line sourceCodeLine = sourceCode.Lines.ElementAtOrDefault(line - 1);

            // Select line in the source code
            if (sourceCodeLine != null)
            {
                sourceCode.SetSelection(sourceCodeLine.EndPosition, sourceCodeLine.Position);
            }
        }

        private void dataGridFocusLeaveEvent(object sender, EventArgs e)
        {
            dgTokens.ClearSelection();
        }
    }
}
