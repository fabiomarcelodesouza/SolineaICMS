<%@ Page Title="Solinea ICMS - Alíquotas de ICMS" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master"
    AutoEventWireup="true" Theme="Default" CodeBehind="Estado.aspx.cs" Inherits="SolineaICMS.WebUI.Estado" %>

<%@ Register Src="~/UC/UCMensagens.ascx" TagName="Mensagem" TagPrefix="msg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <div>
                <msg:Mensagem ID="ucMensagem" runat="server" />
                <br />
            </div>
            <div class="divGrid">
                <asp:GridView ID="gvItens" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItens_RowDataBound"
                    DataKeyNames="CodigoEstado" SkinID="gridviewSkin" Width="320px">
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="UF" DataField="Uf" HeaderText="UF">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Nome" DataField="Nome" HeaderText="Nome">
                            <ItemStyle Width="130px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Alíquota (%)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAliquotaIcms" runat="server" Width="25px" Style="text-align: center;"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="divButtons">
                <table width="100%" border="0">
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Salvar" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancelar" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
