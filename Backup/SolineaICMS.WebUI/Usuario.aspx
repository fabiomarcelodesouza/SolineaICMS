<%@ Page Title="Solinea ICMS - Gerenciar Usuários" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="Usuario.aspx.cs" Inherits="SolineaICMS.WebUI.Usuario"
    EnableEventValidation="false" %>

<%@ Register Src="~/UC/UCMensagens.ascx" TagName="Mensagem" TagPrefix="msg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function fctEstadoControles(acao) {
            if (acao == "load") {
                fctLimpaControles();

                document.getElementById("<%= txtFiltroNome.ClientID %>").disabled = false;
                document.getElementById("<%= txtFiltroLogin.ClientID %>").disabled = false;
                document.getElementById("<%= ddlFiltroPerfil.ClientID %>").disabled = false;
                document.getElementById("<%= ddlFiltroAtivo.ClientID %>").disabled = false;
                document.getElementById("<%= btnPesquisar.ClientID %>").disabled = false;
                document.getElementById("<%= btnLimpar.ClientID %>").disabled = false;

                document.getElementById("<%= txtNome.ClientID %>").disabled = true;
                document.getElementById("<%= txtLogin.ClientID %>").disabled = true;
                document.getElementById("<%= txtSenha.ClientID %>").disabled = true;
                document.getElementById("<%= txtConfirmaSenha.ClientID %>").disabled = true;
                document.getElementById("<%= ddlPerfil.ClientID %>").disabled = true;
                document.getElementById("<%= ddlAtivo.ClientID %>").disabled = true;

                document.getElementById("<%= btnIncluir.ClientID %>").style.display = "";
                document.getElementById("<%= btnSalvar.ClientID %>").style.display = "none";
                document.getElementById("<%= btnCancelar.ClientID %>").style.display = "none";
            }
            else if (acao == "incluir") {
                fctLimpaControles();

                document.getElementById("<%= txtFiltroNome.ClientID %>").disabled = true;
                document.getElementById("<%= txtFiltroLogin.ClientID %>").disabled = true;
                document.getElementById("<%= ddlFiltroPerfil.ClientID %>").disabled = true;
                document.getElementById("<%= ddlFiltroAtivo.ClientID %>").disabled = true;
                document.getElementById("<%= btnPesquisar.ClientID %>").disabled = true;
                document.getElementById("<%= btnLimpar.ClientID %>").disabled = true;

                document.getElementById("<%= txtNome.ClientID %>").disabled = false;
                document.getElementById("<%= txtLogin.ClientID %>").disabled = false;
                document.getElementById("<%= txtSenha.ClientID %>").disabled = false;
                document.getElementById("<%= txtConfirmaSenha.ClientID %>").disabled = false;
                document.getElementById("<%= ddlPerfil.ClientID %>").disabled = false;
                document.getElementById("<%= ddlAtivo.ClientID %>").disabled = false;

                document.getElementById("<%= btnIncluir.ClientID %>").style.display = "none";
                document.getElementById("<%= btnSalvar.ClientID %>").style.display = "";
                document.getElementById("<%= btnCancelar.ClientID %>").style.display = "";

                document.getElementById("<%= txtNome.ClientID %>").focus();
            }
            else if (acao == "editar") {            
                fctLimpaControles();

                $find("<%= cpeFiltros.ClientID %>")._doClose();
                $find("<%= cpeIncluiralterar.ClientID %>")._doOpen();
            }
            else if (acao == "cancelar") {
                if (confirm("Tem certeza que deseja cancelar?")) {
                    fctLimpaControles();

                    document.getElementById("<%= txtFiltroNome.ClientID %>").disabled = false;
                    document.getElementById("<%= txtFiltroLogin.ClientID %>").disabled = false
                    document.getElementById("<%= ddlFiltroPerfil.ClientID %>").disabled = false;
                    document.getElementById("<%= ddlFiltroAtivo.ClientID %>").disabled = false;
                    document.getElementById("<%= btnPesquisar.ClientID %>").disabled = false;
                    document.getElementById("<%= btnLimpar.ClientID %>").disabled = false;

                    document.getElementById("<%= txtNome.ClientID %>").disabled = true;
                    document.getElementById("<%= txtLogin.ClientID %>").disabled = true;
                    document.getElementById("<%= txtSenha.ClientID %>").disabled = true;
                    document.getElementById("<%= txtConfirmaSenha.ClientID %>").disabled = true;
                    document.getElementById("<%= ddlPerfil.ClientID %>").disabled = true;
                    document.getElementById("<%= ddlAtivo.ClientID %>").disabled = true;

                    document.getElementById("<%= btnIncluir.ClientID %>").style.display = "";
                    document.getElementById("<%= btnSalvar.ClientID %>").style.display = "none";
                    document.getElementById("<%= btnCancelar.ClientID %>").style.display = "none";
                }
            }
            else if (acao == "salvar") {
                fctLimpaControles();

                document.getElementById("<%= txtFiltroNome.ClientID %>").disabled = false;
                document.getElementById("<%= txtFiltroLogin.ClientID %>").disabled = false
                document.getElementById("<%= ddlFiltroPerfil.ClientID %>").disabled = false;
                document.getElementById("<%= ddlFiltroAtivo.ClientID %>").disabled = false;
                document.getElementById("<%= btnPesquisar.ClientID %>").disabled = false;
                document.getElementById("<%= btnLimpar.ClientID %>").disabled = false;

                document.getElementById("<%= txtNome.ClientID %>").disabled = true;
                document.getElementById("<%= txtLogin.ClientID %>").disabled = true;
                document.getElementById("<%= txtSenha.ClientID %>").disabled = true;
                document.getElementById("<%= txtConfirmaSenha.ClientID %>").disabled = true;
                document.getElementById("<%= ddlPerfil.ClientID %>").disabled = true;
                document.getElementById("<%= ddlAtivo.ClientID %>").disabled = true;

                document.getElementById("<%= btnIncluir.ClientID %>").style.display = "";
                document.getElementById("<%= btnSalvar.ClientID %>").style.display = "none";
                document.getElementById("<%= btnCancelar.ClientID %>").style.display = "none";
            }
            else if (acao == "pesquisar") {
                document.getElementById("<%= txtFiltroNome.ClientID %>").disabled = false;
                document.getElementById("<%= txtFiltroLogin.ClientID %>").disabled = false
                document.getElementById("<%= ddlFiltroPerfil.ClientID %>").disabled = false;
                document.getElementById("<%= ddlFiltroAtivo.ClientID %>").disabled = false;
                document.getElementById("<%= btnPesquisar.ClientID %>").disabled = false;
                document.getElementById("<%= btnLimpar.ClientID %>").disabled = false;

                document.getElementById("<%= txtNome.ClientID %>").disabled = true;
                document.getElementById("<%= txtLogin.ClientID %>").disabled = true;
                document.getElementById("<%= txtSenha.ClientID %>").disabled = true;
                document.getElementById("<%= txtConfirmaSenha.ClientID %>").disabled = true;
                document.getElementById("<%= ddlPerfil.ClientID %>").disabled = true;
                document.getElementById("<%= ddlAtivo.ClientID %>").disabled = true;

                document.getElementById("<%= btnIncluir.ClientID %>").style.display = "";
                document.getElementById("<%= btnSalvar.ClientID %>").style.display = "none";
                document.getElementById("<%= btnCancelar.ClientID %>").style.display = "none";
            }
            else if (acao == "limpar") {
                fctLimpaControles();

                document.getElementById("<%= txtFiltroNome.ClientID %>").disabled = false;
                document.getElementById("<%= txtFiltroLogin.ClientID %>").disabled = false
                document.getElementById("<%= ddlFiltroPerfil.ClientID %>").disabled = false;
                document.getElementById("<%= ddlFiltroAtivo.ClientID %>").disabled = false;
                document.getElementById("<%= btnPesquisar.ClientID %>").disabled = false;
                document.getElementById("<%= btnLimpar.ClientID %>").disabled = false;

                document.getElementById("<%= txtNome.ClientID %>").disabled = true;
                document.getElementById("<%= txtLogin.ClientID %>").disabled = true;
                document.getElementById("<%= txtSenha.ClientID %>").disabled = true;
                document.getElementById("<%= txtConfirmaSenha.ClientID %>").disabled = true;
                document.getElementById("<%= ddlPerfil.ClientID %>").disabled = true;
                document.getElementById("<%= ddlAtivo.ClientID %>").disabled = true;

                document.getElementById("<%= btnIncluir.ClientID %>").style.display = "";
                document.getElementById("<%= btnSalvar.ClientID %>").style.display = "none";
                document.getElementById("<%= btnCancelar.ClientID %>").style.display = "none";
            }

            return false;
        }

        function fctLimpaControles() {
            document.getElementById("<%= txtFiltroNome.ClientID %>").value = "";
            document.getElementById("<%= txtFiltroLogin.ClientID %>").value = "";
            document.getElementById("<%= ddlFiltroPerfil.ClientID %>").value = "";
            document.getElementById("<%= ddlFiltroAtivo.ClientID %>").value = "";

            document.getElementById("<%= txtNome.ClientID %>").value = "";
            document.getElementById("<%= txtLogin.ClientID %>").value = "";
            document.getElementById("<%= txtSenha.ClientID %>").value = "";
            document.getElementById("<%= txtConfirmaSenha.ClientID %>").value = "";
            document.getElementById("<%= ddlPerfil.ClientID %>").value = "";
            document.getElementById("<%= ddlAtivo.ClientID %>").value = "";

            return false;
        }

        $(document).ready(function () {
            fctEstadoControles("load");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeFiltros" runat="Server" TargetControlID="filtrosContentPanel"
                ExpandControlID="filtrosHeaderPanel" CollapseControlID="filtrosHeaderPanel" Collapsed="true"
                ImageControlID="imgFiltros" TextLabelID="lblExibirOcultarFiltros" CollapsedText="Filtrar"
                ExpandedText="Filtrar" CollapsedImage="~/Images/expand.jpg" ExpandedImage="~/Images/collapse.jpg"
                SuppressPostBack="true" />
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeIncluiralterar" runat="Server" TargetControlID="incluirAlterarContentPanel"
                ExpandControlID="incluirAlterarHeaderPanel" CollapseControlID="incluirAlterarHeaderPanel"
                Collapsed="false" ImageControlID="imgIncluirAlterar" TextLabelID="lblIncluirAlterar"
                CollapsedText="Incluir / Alterar" ExpandedText="Incluir / Alterar" CollapsedImage="~/Images/expand.jpg"
                ExpandedImage="~/Images/collapse.jpg" SuppressPostBack="true" />
            <msg:Mensagem ID="ucMensagem" runat="server" />
            <fieldset>
                <legend>
                    <asp:Panel ID="filtrosHeaderPanel" runat="server" Style="cursor: pointer;" align="left">
                        <asp:ImageButton ID="imgFiltros" runat="server" ImageUrl="~/Images/expand.jpg" AlternateText="Exibir" />
                        <asp:Label ID="lblExibirOcultarFiltros" Text="" runat="server"></asp:Label>
                    </asp:Panel>
                </legend>
                <asp:Panel ID="filtrosContentPanel" runat="server">
                    <table id="tblFiltros" border="0" width="100%">
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="lblFiltroNome" AssociatedControlID="txtFiltroNome" runat="server"
                                    Text="Nome"></asp:Label>
                            </td>
                            <td style="width: 85%">
                                <asp:TextBox ID="txtFiltroNome" runat="server" Width="530px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFiltroLogin" AssociatedControlID="txtFiltroLogin" runat="server"
                                    Text="Login"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFiltroLogin" runat="server" Width="205px" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFiltroPerfil" AssociatedControlID="ddlFiltroPerfil" Text="Perfil"
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFiltroPerfil" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="A">Administrador</asp:ListItem>
                                    <asp:ListItem Value="U">Usuário</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFiltroAtivo" AssociatedControlID="ddlFiltroAtivo" Text="Ativo"
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFiltroAtivo" runat="server" Width="63px">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="true">Sim</asp:ListItem>
                                    <asp:ListItem Value="false">Não</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click"
                                    CssClass="button" />
                                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click"
                                    CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </fieldset>
            <fieldset>
                <legend>
                    <asp:Panel ID="incluirAlterarHeaderPanel" runat="server" Style="cursor: pointer;"
                        align="left">
                        <asp:ImageButton ID="imgIncluirAlterar" runat="server" ImageUrl="~/Images/expand.jpg"
                            AlternateText="Exibir" />
                        <asp:Label ID="lblIncluirAlterar" Text="" runat="server"></asp:Label>
                    </asp:Panel>
                </legend>
                <asp:Panel ID="incluirAlterarContentPanel" runat="server" Style="overflow: hidden;">
                    <asp:ValidationSummary ID="summaryValidation" runat="server" ValidationGroup="SalvarValidationGroup"
                        CssClass="validationSummary" />
                    <table id="tblOperacoes" border="0" width="100%">
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="lblNome" AssociatedControlID="txtNome" runat="server" Text="Nome"></asp:Label>
                            </td>
                            <td style="width: 85%">
                                <asp:TextBox ID="txtNome" runat="server" Width="530px" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                    ForeColor="Red" ErrorMessage="O campo NOME é obrigatório" ToolTip="O campo NOME é obrigatório"
                                    ValidationGroup="SalvarValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLogin" AssociatedControlID="txtLogin" runat="server" Text="Login"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLogin" runat="server" Width="205px" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLogin" SetFocusOnError="true" runat="server" ControlToValidate="txtLogin"
                                    ForeColor="Red" ErrorMessage="O campo LOGIN é obrigatório" ToolTip="O campo LOGIN é obrigatório"
                                    ValidationGroup="SalvarValidationGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="ctvLoginExistente" runat="server" ControlToValidate="txtLogin"
                                    ErrorMessage="O LOGIN informado já está sendo utilizado, por favor escolha outro LOGIN"
                                    ToolTip="O LOGIN informado já está sendo utilizado, por favor escolha outro LOGIN"
                                    OnServerValidate="VerificaLoginExiste" ValidationGroup="SalvarValidationGroup"
                                    SetFocusOnError="true">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSenha" AssociatedControlID="txtSenha" runat="server" Text="Senha"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSenha" runat="server" Width="205px" MaxLength="32" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSenha" SetFocusOnError="true" runat="server" ControlToValidate="txtSenha"
                                    ForeColor="Red" ErrorMessage="O campo SENHA é obrigatório" ToolTip="O campo SENHA é obrigatório"
                                    ValidationGroup="SalvarValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblConfirmaSenha" AssociatedControlID="txtConfirmaSenha" runat="server"
                                    Text="Confirme a senha"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmaSenha" runat="server" Width="205px" MaxLength="32" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConfirmacaoSenha" SetFocusOnError="true" runat="server"
                                    ControlToValidate="txtConfirmaSenha" ForeColor="Red" ErrorMessage="O campo CONFIRMAÇÃO DE SENHA é obrigatório"
                                    ToolTip="O campo CONFIRMAÇÃO DE SENHA é obrigatório" ValidationGroup="SalvarValidationGroup"
                                    Display="Dynamic">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvSenha" SetFocusOnError="true" runat="server" ErrorMessage="O campo CONFIRMAÇÃO DE SENHA não é idêntico ao campo SENHA"
                                    ForeColor="Red" ControlToValidate="txtConfirmaSenha" ControlToCompare="txtSenha"
                                    ValidationGroup="SalvarValidationGroup" Display="Dynamic">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPerfil" AssociatedControlID="ddlPerfil" Text="Perfil" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPerfil" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="A">Administrador</asp:ListItem>
                                    <asp:ListItem Value="U">Usuário</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPerfil" runat="server" ControlToValidate="ddlPerfil"
                                    ForeColor="Red" ErrorMessage="O campo PERFIL é obrigatório" ToolTip="O campo PERFIL é obrigatório"
                                    ValidationGroup="SalvarValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAtivo" AssociatedControlID="ddlAtivo" Text="Ativo" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAtivo" runat="server" Width="63px">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="true">Sim</asp:ListItem>
                                    <asp:ListItem Value="false">Não</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvAtivo" runat="server" ControlToValidate="ddlAtivo"
                                    ForeColor="Red" ErrorMessage="O campo ATIVO é obrigatório" ToolTip="O campo ATIVO é obrigatório"
                                    ValidationGroup="SalvarValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" CssClass="button" OnClick="btnIncluir_Click"
                                    Style="display: none;" />
                                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"
                                    CssClass="button" ValidationGroup="SalvarValidationGroup" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="btnCancelar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </fieldset>
            <br />
            <asp:GridView ID="gvItens" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                SkinID="gridviewSkin" OnPageIndexChanging="gvItens_PageIndexChanging" DataKeyNames="CodigoUsuario, Perfil">
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome">
                        <ControlStyle Width="50%" />
                        <HeaderStyle Width="50%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Login" HeaderText="Login">
                        <ControlStyle Width="21%" />
                        <HeaderStyle Width="21%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="Perfil" DataField="Perfil" HeaderText="Perfil">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="Ativo" HeaderText="Ativo">
                        <ControlStyle Width="12%" />
                        <HeaderStyle Width="12%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnCodigoUsuario" runat="server" Value='<%# Eval("CodigoUsuario") %>' />
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Images/Icons/edit16px.png"
                                OnClick="btnEditar_Click" OnClientClick="fctEstadoControles('editar')" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
