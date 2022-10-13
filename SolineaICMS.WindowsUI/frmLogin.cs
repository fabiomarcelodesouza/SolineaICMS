using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolineaICMS.Util;
using SolineaICMS.VO;
using SolineaICMS.BLL;

namespace SolineaICMS.WindowsUI
{
    public partial class frmLogin : Form
    {
        #region Atributos e Propriedades

        public voUsuario Usuario { get; set; }
        
        #endregion

        #region Eventos

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnEntrar.DialogResult = DialogResult.OK;
            btnSair.DialogResult = DialogResult.Cancel;

            this.AcceptButton = btnEntrar;
            this.CancelButton = btnSair;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                string login = txtUsuario.Text.Trim();
                string senha = UtilCriptografia.GetMd5Hash(txtSenha.Text.Trim());

                this.Usuario = new voUsuario(login, senha);
                this.Usuario = new bllUsuario().Login(this.Usuario);

                if (this.Usuario != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();              
                }
                else
                {
                    MessageBox.Show("Login inexistente ou senha incorreta, informe seu login e senha de acesso nos campos abaixo.");
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtUsuario.Focus();
            }            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion        
    }
}
