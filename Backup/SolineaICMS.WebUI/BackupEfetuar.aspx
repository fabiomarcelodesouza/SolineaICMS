<%@ Page Title="Solinea ICMS - Gerenciar Usuários" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master"
    AutoEventWireup="true" Theme="Default" CodeBehind="BackupEfetuar.aspx.cs" Inherits="SolineaICMS.WebUI.BackupEfetuar"
    EnableEventValidation="false" %>

<%@ Register Src="~/UC/UCMensagens.ascx" TagName="Mensagem" TagPrefix="msg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <table width="100%" border="0">
                <tr>
                    <td>
                        <msg:Mensagem ID="ucMensagem" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="divButtons">
                <table width="100%" border="0">
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSim" runat="server" CssClass="button" Text="Sim" 
                                onclick="btnSim_Click" />
                            <asp:Button ID="btnNao" runat="server" CssClass="button" Text="Não" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
