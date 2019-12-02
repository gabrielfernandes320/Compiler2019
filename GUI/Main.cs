using System.Windows.Forms;
using System.Collections.Generic;
using Core;
using System;
using Core.Utils;
using Core.LexicalAnalysis;
using System.Linq;
using Core.Exceptions;
using ScintillaNET;
using Core.SyntacticalAnalysis;
using System.Data;
using System.Threading.Tasks;

namespace GUI
{
    public partial class Main : Form
    {
        private const string NEW_FILENAME = "novo-arquivo.lms";
        private string currentFileNamePath = NEW_FILENAME;

        private readonly FileHandler fileHandler = new FileHandler();
        private ToolTip toolTip = new ToolTip();

        private volatile bool analyzePaused;
        private volatile bool analyzeStopped;
        private volatile bool analyzeResumed;

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
            AnalyzeCode(true);
        }

        private void CompileCodeAction(object sender, EventArgs e)
        {
            AnalyzeCode(false);
        }

        private async void AnalyzeCode(bool debugMode)
        {
            tbConsole.Text = "Preparando...\n";

            // Reset analyze controls
            analyzeStopped = false;
            analyzeResumed = false;
            analyzePaused = false;

            // Enable stop button
            stopDebugButton.Visible = true;
            stopDebugButton.Enabled = true;

            // Initialize tokens data table
            DataTable tokensDataTable = CreateTokensDataTable();
            dgTokens.DataSource = tokensDataTable;

            // Get text to lexical analysis
            string[] textToAnalyze = ConvertSourceCodeLinesToArray(sourceCode.Lines);

            try
            {
                // LEXICAL ANALISIS
                tbConsole.AppendText("Executando análise léxica...\n");

                // Initialize lexical analyzer
                LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer(textToAnalyze);
                IList<Token> extractedTokens = lexicalAnalyzer.Start();

                if (debugMode)
                {
                    // Enable debug control buttons
                    resumeDebugButton.Visible = true;
                    resumeDebugButton.Enabled = true;
                    continueDebugButton.Visible = true;
                    continueDebugButton.Enabled = true;


                    // Add extracted tokens to data table
                    _ = Task.Run(() =>
                    {
                        AddExtractedTokensToDataTable(tokensDataTable, extractedTokens);
                    });
                }

                tbConsole.AppendText("Análise léxica concluída\n");

                // SYNTACTICAL ANALISIS
                tbConsole.AppendText("Executando análise sintática...\n");

                SyntacticalAnalyzer syntacticalAnalyzer = new SyntacticalAnalyzer(extractedTokens);

                foreach (SyntacticalAnalysisProcessing processing in syntacticalAnalyzer.Start())
                {
                    if (debugMode && processing.RemovedToken != null && tokensDataTable.Rows.Count > 0)
                    {
                       tokensDataTable.Rows.RemoveAt(0);
                    }

                    // Stop analyze
                    if (analyzeStopped)
                    {
                        StopAnalyze();

                        return;
                    }

                    // Controls debug mode
                    if (debugMode)
                    {
                        // Set expansions to analyzer data source
                        dgAnalyzer.DataSource = processing.ExpansionStack.ToList();

                        if (!analyzeResumed)
                        {
                            // Select last processed line
                            SelectLine(processing.LineNumber);
                        }

                        // Wait until continue debug action
                        while (analyzePaused)
                        {
                            if (analyzeStopped)
                            {
                                StopAnalyze();

                                return;
                            }

                            await Task.Delay(250);
                        }

                        if (!analyzeResumed)
                        {
                            analyzePaused = true;
                        } else
                        {
                            await Task.Delay(10);
                        }
                    }
                }

                tbConsole.AppendText("Análise sintática concluída\n");
            }
            catch (LexicalException error)
            {
                // Set error to console
                tbConsole.AppendText("ERRO! ");

                tbConsole.AppendText(error.Message + "\n");

                // Select error in the textbox
                SelectLine(error.GetLine());

                // Show error dialog
                MessageBox.Show("Houve um erro ao efetuar a análise léxica do código fonte\n");
            }
            catch (SyntacticalException error)
            {
                // Set error to console
                tbConsole.AppendText("ERRO! ");

                tbConsole.AppendText(error.Message + "\n");

                // Select error in the textbox
                SelectLine(error.GetLine());

                // Show error dialog
                MessageBox.Show("Houve um erro ao efetuar a análise sintática do código fonte\n");
            }
            catch (SemanticException error)
            {
                // Set error to console
                tbConsole.AppendText("ERRO! ");

                tbConsole.AppendText(error.Message + "\n");

                // Select error in the textbox
                SelectLine(error.GetLine());

                // Show error dialog
                MessageBox.Show("Houve um erro ao efetuar a análise semantica do código fonte\n");
            }

            // Disabled buttons
            ResetDebugControlButtons();
        }

        private void StopAnalyze()
        {
            // Reset data grids
            dgAnalyzer.DataSource = null;
            dgTokens.DataSource = null;

            tbConsole.AppendText("Análise abortada pelo usuário\n");
        }

        private void ResetDebugControlButtons()
        {
            stopDebugButton.Visible = false;
            stopDebugButton.Enabled = false;
            resumeDebugButton.Visible = false;
            resumeDebugButton.Enabled = false;
            continueDebugButton.Visible = false;
            continueDebugButton.Enabled = false;
        }

        private DataTable CreateTokensDataTable()
        {
            DataTable tokensDataTable = new DataTable("tokens");

            DataColumn column;

            column = new DataColumn();
            column.ColumnName = "code";
            column.ReadOnly = true;
            tokensDataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "value";
            column.ReadOnly = true;
            tokensDataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "line";
            column.ReadOnly = true;
            tokensDataTable.Columns.Add(column);

            return tokensDataTable;
        }

        private void SelectLine(int lineNumber)
        {
            Line sourceCodeLine = sourceCode.Lines.ElementAtOrDefault(lineNumber - 1);

            // Select line in the source code
            if (sourceCodeLine != null)
            {
                sourceCode.SetSelection(sourceCodeLine.Position, sourceCodeLine.EndPosition);
            }
        }

        private string[] ConvertSourceCodeLinesToArray(LineCollection sourceCodeLines)
        {
            return sourceCodeLines
                .Select(y => y.Text)
                .ToArray();
        }

        private void AddExtractedTokensToDataTable(DataTable dataTable, IList<Token> tokensList)
        {
            DataRow row;

            foreach (Token y in tokensList)
            {
                row = dataTable.NewRow();
                row["line"] = y.StartChar.Line.ToString();
                row["code"] = y.Code.ToString();
                row["value"] = y.Value;
                dataTable.Rows.Add(row);
            }
        }

        private void AboutAction(object sender, EventArgs e)
        {

        }
        
        private void FileNameLabelMouseOverAction(object sender, EventArgs e)
        {
            toolTip.RemoveAll();

            toolTip.SetToolTip(this.fileNameLabel, currentFileNamePath);

            toolTip.Show(currentFileNamePath, this.fileNameLabel);
        }

        private void DataGridRowFocusEvent(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Cells[2] is the Line number in the datagrid
                int line = int.Parse(dgTokens.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());

                Line sourceCodeLine = sourceCode.Lines.ElementAtOrDefault(line - 1);

                // Select line in the source code
                if (sourceCodeLine != null)
                {
                    sourceCode.SetSelection(sourceCodeLine.Position, sourceCodeLine.EndPosition);
                }
            } catch (Exception error)
            {
                // Internal error
                Console.WriteLine(error.Message);
            }
        }

        private void DataGridFocusLeaveEvent(object sender, EventArgs e)
        {
            dgTokens.ClearSelection();
        }

        private void ContinueAnalyzeAction(object sender, EventArgs e)
        {
            // Go to next step
            analyzePaused = false;
        }

        private void StopAnalyzeAction(object sender, EventArgs e)
        {
            // Close analyze
            analyzeStopped = true;

            // Disabled buttons
            ResetDebugControlButtons();
        }

        private void ResumeAnalyzeAction(object sender, EventArgs e)
        {
            // Skip steps
            analyzeResumed = true;
            analyzePaused = false;

            // Disable continue button
            continueDebugButton.Enabled = false;
        }
    }
}
