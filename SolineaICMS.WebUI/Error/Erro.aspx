<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="Erro.aspx.cs" Inherits="SolineaICMS.WebUI.Error.Erro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <div id="divErro">
                <p>
                    <b>Desculpe, ocorreu um erro no sistema. Entre em contato com a equipe Solinea ICMS
                        pelo telefone
                        <asp:Label ID="lblTelefoneSuporte" runat="server" Text="" />
                        ou envie um email para <span id="spnEmailSuporte" runat="server" /></b>
                </p>
                <p>
                    <asp:Label ID="lblTitNomeProcedure" runat="server" Text="Nome da procedure: " Font-Bold="true"
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblNomeProcedure" runat="server" Text="" Visible="false"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblTitCausaProvavel" runat="server" Text="Causa provável: " Font-Bold="true"
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblCausaProvavel" runat="server" Text="" Visible="false"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblTitTipoExcecao" runat="server" Text="Tipo da exceção: " Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblTipoExcecao" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblTitMsgErro" runat="server" Text="Descrição do erro original: "
                        Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblMsgErro" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblTitStackTrace" runat="server" Text="StackTrace: " Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblStackTrace" runat="server" Text=""></asp:Label>
                </p>
            </div>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btnVoltar" CssClass="button" runat="server" Text="Voltar" OnClientClick="history.back(); return false;" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
