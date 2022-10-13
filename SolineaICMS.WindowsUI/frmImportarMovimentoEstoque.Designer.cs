namespace SolineaICMS.WindowsUI
{
    partial class frmImportarMovimentoEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.btnSelecionarArquivo = new System.Windows.Forms.Button();
            this.lblNomeArquivo = new System.Windows.Forms.Label();
            this.btnImportarArquivo = new System.Windows.Forms.Button();
            this.pbImportacao = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerImportacao = new System.ComponentModel.BackgroundWorker();
            this.btnExcluirGeral = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.FileName = "ofdArquivo";
            this.ofdArquivo.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdArquivo_FileOk);
            // 
            // btnSelecionarArquivo
            // 
            this.btnSelecionarArquivo.Location = new System.Drawing.Point(12, 12);
            this.btnSelecionarArquivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            this.btnSelecionarArquivo.Size = new System.Drawing.Size(139, 39);
            this.btnSelecionarArquivo.TabIndex = 0;
            this.btnSelecionarArquivo.Text = "&Selecionar Arquivo";
            this.btnSelecionarArquivo.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivo.Click += new System.EventHandler(this.btnSelecionarArquivo_Click);
            // 
            // lblNomeArquivo
            // 
            this.lblNomeArquivo.AutoSize = true;
            this.lblNomeArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeArquivo.Location = new System.Drawing.Point(157, 23);
            this.lblNomeArquivo.Name = "lblNomeArquivo";
            this.lblNomeArquivo.Size = new System.Drawing.Size(46, 18);
            this.lblNomeArquivo.TabIndex = 1;
            this.lblNomeArquivo.Text = "label1";
            this.lblNomeArquivo.Visible = false;
            // 
            // btnImportarArquivo
            // 
            this.btnImportarArquivo.Enabled = false;
            this.btnImportarArquivo.Location = new System.Drawing.Point(12, 57);
            this.btnImportarArquivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportarArquivo.Name = "btnImportarArquivo";
            this.btnImportarArquivo.Size = new System.Drawing.Size(139, 39);
            this.btnImportarArquivo.TabIndex = 2;
            this.btnImportarArquivo.Text = "&Importar Arquivo";
            this.btnImportarArquivo.UseVisualStyleBackColor = true;
            this.btnImportarArquivo.Click += new System.EventHandler(this.btnImportarArquivo_Click);
            // 
            // pbImportacao
            // 
            this.pbImportacao.Location = new System.Drawing.Point(12, 102);
            this.pbImportacao.Margin = new System.Windows.Forms.Padding(1);
            this.pbImportacao.Name = "pbImportacao";
            this.pbImportacao.Size = new System.Drawing.Size(621, 28);
            this.pbImportacao.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbImportacao.TabIndex = 3;
            // 
            // backgroundWorkerProgressBar
            // 
            this.backgroundWorkerProgressBar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProgressBar_DoWork);
            // 
            // backgroundWorkerImportacao
            // 
            this.backgroundWorkerImportacao.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerImportacao_DoWork);
            this.backgroundWorkerImportacao.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerImportacao_RunWorkerCompleted);
            // 
            // btnExcluirGeral
            // 
            this.btnExcluirGeral.Location = new System.Drawing.Point(499, 57);
            this.btnExcluirGeral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcluirGeral.Name = "btnExcluirGeral";
            this.btnExcluirGeral.Size = new System.Drawing.Size(135, 39);
            this.btnExcluirGeral.TabIndex = 4;
            this.btnExcluirGeral.Text = "&Excluir Geral";
            this.btnExcluirGeral.UseVisualStyleBackColor = true;
            this.btnExcluirGeral.Click += new System.EventHandler(this.btnExcluirGeral_Click);
            // 
            // frmImportarMovimentoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 139);
            this.Controls.Add(this.btnExcluirGeral);
            this.Controls.Add(this.pbImportacao);
            this.Controls.Add(this.btnImportarArquivo);
            this.Controls.Add(this.lblNomeArquivo);
            this.Controls.Add(this.btnSelecionarArquivo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 186);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 186);
            this.Name = "frmImportarMovimentoEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solinea ICMS - Importar Movimentação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.Button btnSelecionarArquivo;
        private System.Windows.Forms.Label lblNomeArquivo;
        private System.Windows.Forms.Button btnImportarArquivo;
        private System.Windows.Forms.ProgressBar pbImportacao;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerImportacao;
        private System.Windows.Forms.Button btnExcluirGeral;
    }
}