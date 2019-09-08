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
            this.bsTokens = new System.Windows.Forms.BindingSource(this.components);
            this.tokenBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tokenBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.rtbSourceCode = new System.Windows.Forms.RichTextBox();
            this.dgTokens = new System.Windows.Forms.DataGridView();
            this.codeHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startCharDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTokens)).BeginInit();
            this.mainTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsTokens
            // 
            this.bsTokens.DataSource = typeof(Core.Token);
            // 
            // tokenBindingSource1
            // 
            this.tokenBindingSource1.DataSource = typeof(Core.Token);
            // 
            // tokenBindingSource
            // 
            this.tokenBindingSource.DataSource = typeof(Core.Token);
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
            this.menuStrip1.Text = "menuStrip1";
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
            this.menuItem_file_new.Size = new System.Drawing.Size(180, 22);
            this.menuItem_file_new.Text = "Novo";
            this.menuItem_file_new.Click += new System.EventHandler(this.NewFileAction);
            // 
            // menuItem_file_open
            // 
            this.menuItem_file_open.Name = "menuItem_file_open";
            this.menuItem_file_open.Size = new System.Drawing.Size(180, 22);
            this.menuItem_file_open.Text = "Abrir";
            this.menuItem_file_open.Click += new System.EventHandler(this.OpenFileAction);
            // 
            // menuItem_file_save
            // 
            this.menuItem_file_save.Name = "menuItem_file_save";
            this.menuItem_file_save.Size = new System.Drawing.Size(180, 22);
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
            // rtbSourceCode
            // 
            this.rtbSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSourceCode.HideSelection = false;
            this.rtbSourceCode.Location = new System.Drawing.Point(4, 31);
            this.rtbSourceCode.Margin = new System.Windows.Forms.Padding(0);
            this.rtbSourceCode.MinimumSize = new System.Drawing.Size(100, 200);
            this.rtbSourceCode.Name = "rtbSourceCode";
            this.rtbSourceCode.Size = new System.Drawing.Size(674, 570);
            this.rtbSourceCode.TabIndex = 3;
            this.rtbSourceCode.Text = "";
            // 
            // dgTokens
            // 
            this.dgTokens.AllowUserToAddRows = false;
            this.dgTokens.AllowUserToDeleteRows = false;
            this.dgTokens.AutoGenerateColumns = false;
            this.dgTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTokens.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTokens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgTokens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeHeader,
            this.valueHeader,
            this.typeDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.startCharDataGridViewTextBoxColumn});
            this.dgTokens.DataSource = this.bsTokens;
            this.dgTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTokens.Location = new System.Drawing.Point(678, 31);
            this.dgTokens.Margin = new System.Windows.Forms.Padding(0);
            this.dgTokens.Name = "dgTokens";
            this.dgTokens.ReadOnly = true;
            this.dgTokens.RowHeadersVisible = false;
            this.dgTokens.Size = new System.Drawing.Size(226, 570);
            this.dgTokens.TabIndex = 2;
            // 
            // codeHeader
            // 
            this.codeHeader.DataPropertyName = "Code";
            this.codeHeader.HeaderText = "Código";
            this.codeHeader.Name = "codeHeader";
            this.codeHeader.ReadOnly = true;
            // 
            // valueHeader
            // 
            this.valueHeader.DataPropertyName = "Value";
            this.valueHeader.HeaderText = "Valor";
            this.valueHeader.Name = "valueHeader";
            this.valueHeader.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Visible = false;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Visible = false;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Visible = false;
            // 
            // startCharDataGridViewTextBoxColumn
            // 
            this.startCharDataGridViewTextBoxColumn.DataPropertyName = "StartChar";
            this.startCharDataGridViewTextBoxColumn.HeaderText = "StartChar";
            this.startCharDataGridViewTextBoxColumn.Name = "startCharDataGridViewTextBoxColumn";
            this.startCharDataGridViewTextBoxColumn.ReadOnly = true;
            this.startCharDataGridViewTextBoxColumn.Visible = false;
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.88987F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.11013F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayout.Controls.Add(this.tokenLabel, 1, 0);
            this.mainTableLayout.Controls.Add(this.dgTokens, 1, 1);
            this.mainTableLayout.Controls.Add(this.rtbSourceCode, 0, 1);
            this.mainTableLayout.Controls.Add(this.fileNameLabel, 0, 0);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.mainTableLayout.RowCount = 2;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.15807F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.84193F));
            this.mainTableLayout.Size = new System.Drawing.Size(908, 605);
            this.mainTableLayout.TabIndex = 5;
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokenLabel.Location = new System.Drawing.Point(678, 12);
            this.tokenLabel.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(226, 19);
            this.tokenLabel.TabIndex = 5;
            this.tokenLabel.Text = "Tokens";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AccessibleDescription = "";
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(4, 12);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(94, 13);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "dinamic_file_name";
            this.fileNameLabel.MouseHover += new System.EventHandler(this.fileNameLabelMouseOverAction);
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
            ((System.ComponentModel.ISupportInitialize)(this.bsTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTokens)).EndInit();
            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource tokenBindingSource;
        private System.Windows.Forms.BindingSource bsTokens;
        private System.Windows.Forms.BindingSource tokenBindingSource1;
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
        private System.Windows.Forms.RichTextBox rtbSourceCode;
        private System.Windows.Forms.DataGridView dgTokens;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startCharDataGridViewTextBoxColumn;
    }
}

