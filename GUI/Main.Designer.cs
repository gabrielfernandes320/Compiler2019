namespace GUI
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_file_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_file_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_compile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_compile_analyze = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_compile_compile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_help_about = new System.Windows.Forms.ToolStripMenuItem();
            this.dgTokens = new System.Windows.Forms.DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTokens = new System.Windows.Forms.BindingSource(this.components);
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.analyzeLabel = new System.Windows.Forms.Label();
            this.tokensLabel = new System.Windows.Forms.Label();
            this.dgAnalyzer = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.derivedItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sourceCode = new EasyScintilla.SimpleEditor();
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.tokenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTokens)).BeginInit();
            this.mainTableLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAnalyzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivedItemBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_file,
            this.menuItem_compile,
            this.menuItem_help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "mainMenu";
            // 
            // menuItem_file
            // 
            this.menuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_file_new,
            this.menuItem_file_open,
            this.menuItem_file_save});
            this.menuItem_file.Name = "menuItem_file";
            this.menuItem_file.Size = new System.Drawing.Size(61, 20);
            this.menuItem_file.Text = "Arquivo";
            // 
            // menuItem_file_new
            // 
            this.menuItem_file_new.Name = "menuItem_file_new";
            this.menuItem_file_new.Size = new System.Drawing.Size(105, 22);
            this.menuItem_file_new.Text = "Novo";
            this.menuItem_file_new.Click += new System.EventHandler(this.NewFileAction);
            // 
            // menuItem_file_open
            // 
            this.menuItem_file_open.Name = "menuItem_file_open";
            this.menuItem_file_open.Size = new System.Drawing.Size(105, 22);
            this.menuItem_file_open.Text = "Abrir";
            this.menuItem_file_open.Click += new System.EventHandler(this.OpenFileAction);
            // 
            // menuItem_file_save
            // 
            this.menuItem_file_save.Name = "menuItem_file_save";
            this.menuItem_file_save.Size = new System.Drawing.Size(105, 22);
            this.menuItem_file_save.Text = "Salvar";
            this.menuItem_file_save.Click += new System.EventHandler(this.SaveFileAction);
            // 
            // menuItem_compile
            // 
            this.menuItem_compile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_compile_analyze,
            this.menuItem_compile_compile});
            this.menuItem_compile.Name = "menuItem_compile";
            this.menuItem_compile.Size = new System.Drawing.Size(68, 20);
            this.menuItem_compile.Text = "Compilar";
            // 
            // menuItem_compile_analyze
            // 
            this.menuItem_compile_analyze.Name = "menuItem_compile_analyze";
            this.menuItem_compile_analyze.Size = new System.Drawing.Size(198, 22);
            this.menuItem_compile_analyze.Text = "Analizar Código Fonte";
            this.menuItem_compile_analyze.Click += new System.EventHandler(this.AnalyzeCodeAction);
            // 
            // menuItem_compile_compile
            // 
            this.menuItem_compile_compile.Enabled = false;
            this.menuItem_compile_compile.Name = "menuItem_compile_compile";
            this.menuItem_compile_compile.Size = new System.Drawing.Size(198, 22);
            this.menuItem_compile_compile.Text = "Compilar Código Fonte";
            this.menuItem_compile_compile.Click += new System.EventHandler(this.CompileCodeAction);
            // 
            // menuItem_help
            // 
            this.menuItem_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_help_about});
            this.menuItem_help.Name = "menuItem_help";
            this.menuItem_help.Size = new System.Drawing.Size(50, 20);
            this.menuItem_help.Text = "Ajuda";
            // 
            // menuItem_help_about
            // 
            this.menuItem_help_about.Name = "menuItem_help_about";
            this.menuItem_help_about.Size = new System.Drawing.Size(183, 22);
            this.menuItem_help_about.Text = "Sobre Compiler 2019";
            this.menuItem_help_about.Click += new System.EventHandler(this.AboutAction);
            // 
            // dgTokens
            // 
            this.dgTokens.AllowUserToAddRows = false;
            this.dgTokens.AllowUserToDeleteRows = false;
            this.dgTokens.AllowUserToResizeRows = false;
            this.dgTokens.AutoGenerateColumns = false;
            this.dgTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTokens.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgTokens.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTokens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgTokens.CausesValidation = false;
            this.dgTokens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.Line});
            this.dgTokens.DataSource = this.bsTokens;
            this.dgTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTokens.Location = new System.Drawing.Point(0, 286);
            this.dgTokens.Margin = new System.Windows.Forms.Padding(0);
            this.dgTokens.MultiSelect = false;
            this.dgTokens.Name = "dgTokens";
            this.dgTokens.ReadOnly = true;
            this.dgTokens.RowHeadersVisible = false;
            this.dgTokens.RowTemplate.ReadOnly = true;
            this.dgTokens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTokens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTokens.Size = new System.Drawing.Size(220, 309);
            this.dgTokens.TabIndex = 2;
            this.dgTokens.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRowFocusEvent);
            //this.dgTokens.Leave += new System.EventHandler(this.dataGridFocusLeaveEvent);
            // 
            // Line
            // 
            this.Line.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Line.DataPropertyName = "Line";
            this.Line.FillWeight = 47F;
            this.Line.HeaderText = "Linha";
            this.Line.MaxInputLength = 5;
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.Width = 47;
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.88987F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.11013F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.mainTableLayout.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.mainTableLayout.RowCount = 1;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.75541F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.24459F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 601F));
            this.mainTableLayout.Size = new System.Drawing.Size(908, 605);
            this.mainTableLayout.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.analyzeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tokensLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgAnalyzer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgTokens, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(681, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.469055F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.53094F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 595);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // analyzeLabel
            // 
            this.analyzeLabel.AutoSize = true;
            this.analyzeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyzeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzeLabel.Location = new System.Drawing.Point(3, 0);
            this.analyzeLabel.Name = "analyzeLabel";
            this.analyzeLabel.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.analyzeLabel.Size = new System.Drawing.Size(214, 22);
            this.analyzeLabel.TabIndex = 3;
            this.analyzeLabel.Text = "Análise";
            // 
            // tokensLabel
            // 
            this.tokensLabel.AutoSize = true;
            this.tokensLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokensLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokensLabel.Location = new System.Drawing.Point(3, 260);
            this.tokensLabel.Name = "tokensLabel";
            this.tokensLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.tokensLabel.Size = new System.Drawing.Size(214, 26);
            this.tokensLabel.TabIndex = 4;
            this.tokensLabel.Text = "Tokens";
            // 
            // dgAnalyzer
            // 
            this.dgAnalyzer.AllowUserToAddRows = false;
            this.dgAnalyzer.AllowUserToDeleteRows = false;
            this.dgAnalyzer.AllowUserToResizeRows = false;
            this.dgAnalyzer.AutoGenerateColumns = false;
            this.dgAnalyzer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAnalyzer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgAnalyzer.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgAnalyzer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgAnalyzer.CausesValidation = false;
            this.dgAnalyzer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgAnalyzer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAnalyzer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.valueDataGridViewTextBoxColumn1});
            this.dgAnalyzer.DataSource = this.derivedItemBindingSource;
            this.dgAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAnalyzer.Location = new System.Drawing.Point(0, 22);
            this.dgAnalyzer.Margin = new System.Windows.Forms.Padding(0);
            this.dgAnalyzer.MultiSelect = false;
            this.dgAnalyzer.Name = "dgAnalyzer";
            this.dgAnalyzer.ReadOnly = true;
            this.dgAnalyzer.RowHeadersVisible = false;
            this.dgAnalyzer.RowTemplate.ReadOnly = true;
            this.dgAnalyzer.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAnalyzer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAnalyzer.Size = new System.Drawing.Size(220, 238);
            this.dgAnalyzer.TabIndex = 5;
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn1
            // 
            this.valueDataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn1.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn1.Name = "valueDataGridViewTextBoxColumn1";
            this.valueDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // derivedItemBindingSource
            // 
            this.derivedItemBindingSource.DataSource = typeof(Core.SyntacticalAnalysis.DerivedItem);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.sourceCode, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbConsole, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.fileNameLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.917526F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.08247F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(668, 595);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // sourceCode
            // 
            this.sourceCode.AutoCAutoHide = false;
            this.sourceCode.AutoCCancelAtStart = false;
            this.sourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceCode.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.sourceCode.Location = new System.Drawing.Point(3, 22);
            this.sourceCode.Name = "sourceCode";
            this.sourceCode.ScrollWidth = 100;
            this.sourceCode.Size = new System.Drawing.Size(662, 460);
            this.sourceCode.Styler = null;
            this.sourceCode.TabIndex = 6;
            // 
            // tbConsole
            // 
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Location = new System.Drawing.Point(3, 488);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(662, 104);
            this.tbConsole.TabIndex = 7;
            this.tbConsole.Text = "";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AccessibleDescription = "";
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileNameLabel.Location = new System.Drawing.Point(0, 5);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(668, 14);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "dinamic_file_name";
            this.fileNameLabel.MouseHover += new System.EventHandler(this.fileNameLabelMouseOverAction);
            // 
            // tokenBindingSource
            // 
            this.tokenBindingSource.DataSource = typeof(Core.Token);
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.FillWeight = 110.2238F;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.FillWeight = 47F;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 47;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(908, 629);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Compiler 2019";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTokens)).EndInit();
            this.mainTableLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAnalyzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivedItemBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bsTokens;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file_new;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file_open;
        private System.Windows.Forms.ToolStripMenuItem menuItem_compile;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file_save;
        private System.Windows.Forms.ToolStripMenuItem menuItem_compile_analyze;
        private System.Windows.Forms.ToolStripMenuItem menuItem_compile_compile;
        private System.Windows.Forms.ToolStripMenuItem menuItem_help;
        private System.Windows.Forms.ToolStripMenuItem menuItem_help_about;
        private System.Windows.Forms.DataGridView dgTokens;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private EasyScintilla.SimpleEditor sourceCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label analyzeLabel;
        private System.Windows.Forms.Label tokensLabel;
        private System.Windows.Forms.RichTextBox tbConsole;
        private System.Windows.Forms.DataGridView dgAnalyzer;
        private System.Windows.Forms.BindingSource derivedItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource tokenBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}

