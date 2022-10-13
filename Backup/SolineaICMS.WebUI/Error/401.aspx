<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="401.aspx.cs" Inherits="SolineaICMS.WebUI.Error._401" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        Desculpe, mas você não tem autorização para acessar essa funcionalidade.
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnVoltar" CssClass="button" runat="server" Text="Voltar" OnClientClick="history.back(); return false;" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
