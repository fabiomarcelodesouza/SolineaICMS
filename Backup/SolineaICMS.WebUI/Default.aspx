<%@ Page Title="Solinea ICMS" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SolineaICMS.WebUI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            Seja bem vindo ao Solinea ICMS.
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
