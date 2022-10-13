using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolineaICMS.Util;
using SolineaICMS.BLL;
using SolineaICMS.VO;

namespace SolineaICMS.WindowsUI
{
    public partial class frmPrincipal : Form
    {
        #region Atributos e Propriedades

        public voUsuario Usuario { get; set; }
        
        #endregion

        #region Construtores

        public frmPrincipal(voUsuario usuario)
        {            
            this.Usuario = usuario;
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show("ConnectionString: " + ConfigurationManager.ConnectionString);
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarMovimentoEstoque frmImportarMovimentoEstoque = new frmImportarMovimentoEstoque();
            frmImportarMovimentoEstoque.MdiParent = this;
            frmImportarMovimentoEstoque.Usuario = this.Usuario;            
            frmImportarMovimentoEstoque.Show();
        }

        private void cargaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarCargaInicial frmImportarCargaInicial = new frmImportarCargaInicial();
            frmImportarCargaInicial.MdiParent = this;
            frmImportarCargaInicial.Usuario = this.Usuario;
            frmImportarCargaInicial.Show();
        }

        #endregion
    }
}
