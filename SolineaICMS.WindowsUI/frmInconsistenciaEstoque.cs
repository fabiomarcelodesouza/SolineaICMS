using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolineaICMS.VO;
using SolineaICMS.BLL;

namespace SolineaICMS.WindowsUI
{
    public partial class frmInconsistenciaEstoque : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Usuario
        /// </summary>
        public voUsuario Usuario { get; set; }

        /// <summary>
        /// Inverter a progressão da barra
        /// </summary>
        private bool ProgredirBarraAoContrario { get; set; }

        /// <summary>
        /// Propriedade utilizada para controlar se a aplicação está importando o arquivo ou se a importação já foi finalizada
        /// </summary>
        private bool Corrigindo { get; set; }

        /// <summary>
        /// Delegate utilizado para atualizar a barra de progresso
        /// </summary>        
        delegate void SetControlValueCallback(Control oControl, int valorAtual, System.Windows.Forms.RightToLeft rightToLeft, bool rightToLeftLayout);

        bllInconsistenciasEstoque bllInconsistenciasEstoque;

        #endregion

        #region Construtores

        public frmInconsistenciaEstoque()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmInconsistenciaEstoque_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.dgvItens.AutoGenerateColumns = false;
            int qtdeInconsistencias = UpdateGrid(new voInconsistenciasEstoque());

            if (qtdeInconsistencias > 0)
            {
                dgvItens.AutoGenerateColumns = false;
                AtualizaInformacoes(qtdeInconsistencias);
            }
            else
            {
                MessageBox.Show("Não foram encontradas inconsistências de estoque");
            }
        }

        #endregion

        private int UpdateGrid(voInconsistenciasEstoque voInconsistenciasEstoque)
        {
            this.bllInconsistenciasEstoque = new BLL.bllInconsistenciasEstoque();
            IList<voInconsistenciasEstoque> listItems = bllInconsistenciasEstoque.Select(voInconsistenciasEstoque);

            dgvItens.DataSource = listItems;

            return listItems.Count;
        }

        private void AtualizaInformacoes(int qtdeInconsistencias)
        {
            if (qtdeInconsistencias == 0)
            {
                lblMensagemInc1.Visible = false;
                btnCorrigir.Visible = false;
            }
            else if (qtdeInconsistencias == 1)
            {
                lblMensagemInc1.Visible = true;
                lblMensagemInc1.Text = String.Format("Foi encontrada 1 inconsistência de estoque:");
            }
            else if (qtdeInconsistencias > 1)
            {
                lblMensagemInc1.Visible = true;
                lblMensagemInc1.Text = String.Format("Foram encontradas {0} inconsistências de estoque:", qtdeInconsistencias);
            }
        }

        private void dgvItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }       
    }
}
