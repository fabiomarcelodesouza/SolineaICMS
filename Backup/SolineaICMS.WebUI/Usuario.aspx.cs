#region Usings

using System;
using System.Web.UI.WebControls;
using SolineaICMS.BLL;
using SolineaICMS.Util;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class Usuario : PageBase
    {
        #region Propriedades

        private bool LoginExiste { get; set; }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento chamado no Load da Página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiteMaster)this.Master).Perfil = "A";

            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Usuários";
                ViewState["CodigoUsuario"] = 0;
                this.LoginExiste = false;
                UpdateGrid(new voUsuario());
            }
            else
            {
                ucMensagem.HideMessage();
            }
        }

        /// <summary>
        /// Evento chamado no clique do botão Pesquisar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            ucMensagem.HideMessage();

            voUsuario voUsuario = new voUsuario();

            voUsuario = new voUsuario();

            voUsuario.Nome = txtFiltroNome.Text;
            voUsuario.Login = txtFiltroLogin.Text;

            if (!string.IsNullOrEmpty(ddlFiltroPerfil.SelectedValue))
            {
                voUsuario.Perfil = ddlFiltroPerfil.SelectedValue;
            }

            if (!string.IsNullOrEmpty(ddlFiltroAtivo.SelectedValue))
            {
                voUsuario.Ativo = Convert.ToBoolean(ddlFiltroAtivo.SelectedValue);
            }

            UpdateGrid(voUsuario);

            RegistraScript("EstadoControlesCadastroUsuario", "fctEstadoControles('pesquisar')", 30);
        }

        /// <summary>
        /// Evento chamado no clique do botão Limpar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            base.ResetControls(this);
            ucMensagem.HideMessage();

            UpdateGrid(new voUsuario());

            RegistraScript("EstadoControlesCadastroUsuario", "fctEstadoControles('limpar')", 30);
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            ViewState["CodigoUsuario"] = 0;
            RegistraScript("EstadoControlesCadastroUsuario", "fctEstadoControles('incluir')", 30);
        }

        /// <summary>
        /// Evento chamado no clique do botão Salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    if ((int)ViewState["CodigoUsuario"] == 0)
                    {
                        ucMensagem.MessageType = UtilEnums.MessageType.Success;
                        ucMensagem.Mensagem = "Usuário incluído com sucesso.";
                    }
                    else
                    {
                        ucMensagem.MessageType = UtilEnums.MessageType.Success;
                        ucMensagem.Mensagem = "Usuário alterado com sucesso.";
                    }

                    ucMensagem.ShowMessage();

                    UpdateGrid(new voUsuario());

                    RegistraScript("EstadoControlesCadastroUsuario", "fctEstadoControles('salvar')", 30);
                }
                else
                {
                    btnIncluir.Style.Add("display", "none");
                }
            }
            catch (Exception ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;
                ucMensagem.Mensagem = ex.Message;
                ucMensagem.ShowMessage();
            }
        }

        /// <summary>
        /// Evento chamado no clique do botão Editar da grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int index = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
            string perfil = (gvItens.DataKeys[((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex]["Perfil"]).ToString();
            ViewState["CodigoUsuario"] = (int)gvItens.DataKeys[((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex]["CodigoUsuario"];

            txtNome.Text = gvItens.Rows[index].Cells[0].Text;
            txtLogin.Text = gvItens.Rows[index].Cells[1].Text;

            switch (perfil)
            {
                case "Administrador":
                    ddlPerfil.SelectedIndex = 1;
                    break;
                case "Usuário":
                    ddlPerfil.SelectedIndex = 2;
                    break;
                default:
                    ddlPerfil.SelectedIndex = 0;
                    break;
            }

            if (((CheckBox)(gvItens.Rows[index].Cells[3].Controls[0])).Checked)
            {
                ddlAtivo.SelectedIndex = 1;
            }
            else
            {
                ddlAtivo.SelectedIndex = 2;
            }

            btnIncluir.Style.Add("display", "none");
        }

        /// <summary>
        /// Evento chamado na paginação da Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItens.PageIndex = e.NewPageIndex;
            UpdateGrid(new voUsuario());

            RegistraScript("EstadoControlesCadastroUsuario", "fctEstadoControles('load')", 30);
        }

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            base.RetornoConfirmacaoPagina += new ConfirmacaoSim(btnRespostaConfirmacao_Click);
        }

        private void btnRespostaConfirmacao_Click(object sender, EventArgs e)
        {
            RegistraScript("EstadoControlesCadastroUsuario", "fctEstadoControles('cancelar')", 30);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            base.GeraConfirmacao("Cancelar?", string.Format("Tem certeza que deseja cancelar?"));
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Atualiza a grid com o filtro selecionado
        /// </summary>
        /// <param name="voUsuario">Objeto utilizado como filtro</param>
        private void UpdateGrid(voUsuario voUsuario)
        {
            bllUsuario bllUsuario = new bllUsuario();

            gvItens.DataSource = bllUsuario.Select(voUsuario);
            gvItens.DataBind();
        }

        /// <summary>
        /// Salva um usuário no banco de dados
        /// </summary>
        private bool Save()
        {
            if (!this.LoginExiste)
            {
                bllUsuario bllUsuario = new bllUsuario();
                voUsuario voUsuario = new voUsuario();

                voUsuario.CodigoUsuario = (int)ViewState["CodigoUsuario"];

                if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    voUsuario.Nome = txtNome.Text.Trim();
                }
                else
                {
                    throw new Exception("O campo NOME é obrigatório");
                }

                if (!string.IsNullOrWhiteSpace(txtLogin.Text))
                {
                    voUsuario.Login = txtLogin.Text.Trim();
                }
                else
                {
                    throw new Exception("O campo LOGIN é obrigatório");
                }

                if (!string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    if (txtSenha.Text.Trim() == txtConfirmaSenha.Text.Trim())
                    {
                        voUsuario.Senha = getMD5Hash(txtSenha.Text.Trim());
                    }
                    else
                    {
                        throw new Exception("O campo CONFIRMAÇÃO DE SENHA não é idêntico ao campo SENHA");
                    }
                }
                else
                {
                    throw new Exception("O campo SENHA é obrigatório");
                }

                if (!string.IsNullOrEmpty(ddlPerfil.SelectedValue))
                {
                    voUsuario.Perfil = ddlPerfil.SelectedValue;                 
                }
                else
                {
                    throw new Exception("O campo PERFIL é obrigatório");
                }

                if (!string.IsNullOrEmpty(ddlAtivo.SelectedValue))
                {
                    voUsuario.Ativo = Convert.ToBoolean(ddlAtivo.SelectedValue);
                }
                else
                {
                    throw new Exception("O campo ATIVO é obrigatório");
                }

                if ((int)ViewState["CodigoUsuario"] == 0)
                {
                    bllUsuario.Insert(voUsuario);
                }
                else
                {
                    bllUsuario.Update(voUsuario);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica se o login informado já foi cadastrado
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void VerificaLoginExiste(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                UtilEnums.Acao acao;
                int codigoUsuarioEditando;
                voUsuario voUsuario = new voUsuario();
                bllUsuario bllUsuario = new bllUsuario();

                voUsuario = new voUsuario();
                voUsuario.Login = txtLogin.Text.Trim();

                if ((int)ViewState["CodigoUsuario"] != 0)
                {
                    acao = UtilEnums.Acao.Editar;
                    codigoUsuarioEditando = (int)ViewState["CodigoUsuario"];
                }
                else
                {
                    acao = UtilEnums.Acao.Incluir;
                    codigoUsuarioEditando = 0;
                }

                this.LoginExiste = bllUsuario.LoginExiste(acao, voUsuario, codigoUsuarioEditando);

                args.IsValid = !this.LoginExiste;
            }
        }

        #endregion
    }
}

#endregion