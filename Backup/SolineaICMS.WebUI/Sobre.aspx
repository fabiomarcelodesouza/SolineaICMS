<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="Sobre.aspx.cs" Inherits="SolineaICMS.WebUI.Sobre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Idealizadores e Realizadores </legend>
                <ul>
                    <li>Fabio Marcelo de Souza </li>
                    <li>Luiz Fernando Capeloto Macohin </li>
                    <li>Reginaldo Luiz Dourado </li>
                </ul>
            </fieldset>
            <fieldset>
                <legend>Histórico de Versões</legend>
                <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" 
                    ImageSet="Arrows" ExpandDepth="2" NodeWrap="True">
                    <DataBindings>
                        <asp:TreeNodeBinding DataMember="versoes" TextField="name" 
                            SelectAction="Expand" />
                        <asp:TreeNodeBinding DataMember="versao" TextField="numero" ToolTipField="data" 
                            SelectAction="Expand" />
                        <asp:TreeNodeBinding DataMember="alteracao" TextField="titulo" 
                            SelectAction="Expand" />
                        <asp:TreeNodeBinding DataMember="descricao" NavigateUrlField="url" 
                            TextField="#InnerText" SelectAction="Expand" />
                    </DataBindings>
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle
                        Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" 
                        ForeColor="#5555DD" />
                </asp:TreeView>
                <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/HistoricoVersoes.xml">
                </asp:XmlDataSource>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
