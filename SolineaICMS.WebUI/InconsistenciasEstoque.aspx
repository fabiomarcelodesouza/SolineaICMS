<%@ Page Title="Solinea ICMS - Inconsistências de Estoque" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="InconsistenciasEstoque.aspx.cs" Inherits="SolineaICMS.WebUI.InconsistenciasEstoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function fctOcultaControlesChamadaAssincrona() {
            $("#<%= btnCorrigir.ClientID %>").css("display", "none");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblMensagemInc1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnCorrigir" CssClass="button" runat="server" Text="Corrigir" OnClick="btnCorrigir_Click"
                            OnClientClick="fctOcultaControlesChamadaAssincrona()" />
                    </td>
                </tr>
            </table>
            </p>
            <div class="divGrid">
                <asp:GridView ID="gvItens" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False"
                    OnRowDataBound="gvItens_RowDataBound" AllowPaging="True" PageSize="800" OnPageIndexChanging="gvItens_PageIndexChanging">
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="Codigo do Produto" DataField="CodigoProdutoCliente"
                            HeaderText="Codigo do Produto">
                            <HeaderStyle Width="20%" />
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Nome do Produto" DataField="NomeProduto" HeaderText="Nome do Produto">
                            <HeaderStyle Width="35%" />
                            <ItemStyle Width="35%" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Ncm" DataField="Ncm" HeaderText="Ncm">
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Quantidade" DataField="Quantidade" HeaderText="Quantidade">
                            <HeaderStyle Width="15%" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Qtd. Solinea" 
                            DataField="QuantidadeSolinea" HeaderText="Qtd. Solinea">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Qtd. Empresa" 
                            DataField="QuantidadeEmpresa" HeaderText="Qtd. Empresa">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UnidadeMedida" HeaderText="Unidade" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField AccessibleHeaderText="Corrigir" HeaderText="Corrigir">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkCorrigir" runat="server" Checked="true" />
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
