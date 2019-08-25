namespace GUI
{
    partial class Form1
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.dgTokens = new System.Windows.Forms.DataGridView();
            this.rtbSourceCode = new System.Windows.Forms.RichTextBox();
            this.tokenBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bsTokens = new System.Windows.Forms.BindingSource(this.components);
            this.tokenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(476, 36);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "button1";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // dgTokens
            // 
            this.dgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTokens.Location = new System.Drawing.Point(633, 65);
            this.dgTokens.Name = "dgTokens";
            this.dgTokens.Size = new System.Drawing.Size(256, 553);
            this.dgTokens.TabIndex = 2;
            // 
            // rtbSourceCode
            // 
            this.rtbSourceCode.Location = new System.Drawing.Point(12, 65);
            this.rtbSourceCode.Name = "rtbSourceCode";
            this.rtbSourceCode.Size = new System.Drawing.Size(615, 553);
            this.rtbSourceCode.TabIndex = 3;
            this.rtbSourceCode.Text = "";
            // 
            // tokenBindingSource1
            // 
            this.tokenBindingSource1.DataSource = typeof(Core.Token);
            // 
            // bsTokens
            // 
            this.bsTokens.DataSource = typeof(Core.Token);
            // 
            // tokenBindingSource
            // 
            this.tokenBindingSource.DataSource = typeof(Core.Token);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 629);
            this.Controls.Add(this.rtbSourceCode);
            this.Controls.Add(this.dgTokens);
            this.Controls.Add(this.btnAccept);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dgTokens;
        private System.Windows.Forms.RichTextBox rtbSourceCode;
        private System.Windows.Forms.BindingSource tokenBindingSource;
        private System.Windows.Forms.BindingSource bsTokens;
        private System.Windows.Forms.BindingSource tokenBindingSource1;
    }
}

