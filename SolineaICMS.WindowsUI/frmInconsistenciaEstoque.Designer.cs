namespace SolineaICMS.WindowsUI
{
    partial class frmInconsistenciaEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.CodigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ncm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeSolinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corrigir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblMensagemInc1 = new System.Windows.Forms.Label();
            this.btnCorrigir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoProduto,
            this.UnidadeMedida,
            this.NomeProduto,
            this.Ncm,
            this.Quantidade,
            this.QuantidadeSolinea,
            this.QuantidadeEmpresa,
            this.Corrigir});
            this.dgvItens.Location = new System.Drawing.Point(12, 74);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.Size = new System.Drawing.Size(861, 187);
            this.dgvItens.TabIndex = 0;
            this.dgvItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItens_CellClick);
            // 
            // CodigoProduto
            // 
            this.CodigoProduto.DataPropertyName = "CodigoProdutoCliente";
            this.CodigoProduto.HeaderText = "Código do Produto";
            this.CodigoProduto.Name = "CodigoProduto";
            this.CodigoProduto.ReadOnly = true;
            // 
            // UnidadeMedida
            // 
            this.UnidadeMedida.DataPropertyName = "UnidadeMedida";
            this.UnidadeMedida.HeaderText = "Unidade";
            this.UnidadeMedida.Name = "UnidadeMedida";
            this.UnidadeMedida.ReadOnly = true;
            // 
            // NomeProduto
            // 
            this.NomeProduto.DataPropertyName = "NomeProduto";
            this.NomeProduto.HeaderText = "Nome do Produto";
            this.NomeProduto.Name = "NomeProduto";
            this.NomeProduto.ReadOnly = true;
            // 
            // Ncm
            // 
            this.Ncm.DataPropertyName = "Ncm";
            this.Ncm.HeaderText = "Ncm";
            this.Ncm.Name = "Ncm";
            this.Ncm.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // QuantidadeSolinea
            // 
            this.QuantidadeSolinea.DataPropertyName = "QuantidadeSolinea";
            this.QuantidadeSolinea.HeaderText = "Qtd. Solinea";
            this.QuantidadeSolinea.Name = "QuantidadeSolinea";
            this.QuantidadeSolinea.ReadOnly = true;
            // 
            // QuantidadeEmpresa
            // 
            this.QuantidadeEmpresa.DataPropertyName = "QuantidadeEmpresa";
            this.QuantidadeEmpresa.HeaderText = "Qtd. Empresa";
            this.QuantidadeEmpresa.Name = "QuantidadeEmpresa";
            this.QuantidadeEmpresa.ReadOnly = true;
            // 
            // Corrigir
            // 
            this.Corrigir.DataPropertyName = "CheckboxSelecionado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "True";
            this.Corrigir.DefaultCellStyle = dataGridViewCellStyle1;
            this.Corrigir.FalseValue = "false";
            this.Corrigir.HeaderText = "Corrigir";
            this.Corrigir.IndeterminateValue = "";
            this.Corrigir.Name = "Corrigir";
            this.Corrigir.ReadOnly = true;
            this.Corrigir.TrueValue = "true";
            // 
            // lblMensagemInc1
            // 
            this.lblMensagemInc1.AutoSize = true;
            this.lblMensagemInc1.Location = new System.Drawing.Point(98, 9);
            this.lblMensagemInc1.Name = "lblMensagemInc1";
            this.lblMensagemInc1.Size = new System.Drawing.Size(35, 13);
            this.lblMensagemInc1.TabIndex = 1;
            this.lblMensagemInc1.Text = "label1";
            // 
            // btnCorrigir
            // 
            this.btnCorrigir.Location = new System.Drawing.Point(71, 25);
            this.btnCorrigir.Name = "btnCorrigir";
            this.btnCorrigir.Size = new System.Drawing.Size(75, 32);
            this.btnCorrigir.TabIndex = 2;
            this.btnCorrigir.Text = "&Corrigir";
            this.btnCorrigir.UseVisualStyleBackColor = true;
            // 
            // frmInconsistenciaEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 273);
            this.Controls.Add(this.btnCorrigir);
            this.Controls.Add(this.lblMensagemInc1);
            this.Controls.Add(this.dgvItens);
            this.Name = "frmInconsistenciaEstoque";
            this.Text = "frmInconsistenciaEstoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInconsistenciaEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.Label lblMensagemInc1;
        private System.Windows.Forms.Button btnCorrigir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ncm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeSolinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeEmpresa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Corrigir;
    }
}