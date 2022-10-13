<%@ Page Title="Solinea ICMS - Relatório de Inconsistências de Estoque" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="RelatorioInconsistenciasEstoque.aspx.cs" Inherits="SolineaICMS.WebUI.Relatorios.RelatorioInconsistenciasEstoque" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        function DefineMascaras() {
            $(".data").mask("99/99/9999");
        }

        function fctPreencheNomeProduto(codigo) {
            $("#<%= btnRecuperaNomeProduto.ClientID %>")[0].click();
        }

        function AjustaTamanhoAutoComplete() {
            var list = $find("AutoCompleteEx").get_completionList();
            list.style.width = "auto";
            list.style.width = "auto";
        }

        function fctValidaFiltros() {
            dataInicio = $("#<%= txtDataInicio.ClientID %>");
            dataFinal = $("#<%= txtDataFinal.ClientID %>");

            if (dataInicio.val() == "") {
                fctChamaModalInformacao("Data Inicial", "O campo 'Data Inicial' não foi preenchido.", "Information");
                dataInicio.focus()
                return false;
            }

            if (dataFinal.val() != "") {
                if (fctConverteData(dataInicio.val()) > fctConverteData(dataFinal.val())) {
                    fctChamaModalInformacao("Data Inválida", "A 'Data Final' deve ser maior ou igual a 'Data Inicial'.", "Information");
                    dataInicio.focus();
                    return false;
                }
            }
        }            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeFiltros" runat="Server" TargetControlID="filtrosContentPanel"
                ExpandControlID="filtrosHeaderPanel" CollapseControlID="filtrosHeaderPanel" Collapsed="true"
                ImageControlID="imgFiltros" TextLabelID="lblExibirOcultarFiltros" CollapsedText="Filtrar"
                ExpandedText="Filtrar" CollapsedImage="~/Images/expand.jpg" ExpandedImage="~/Images/collapse.jpg"
                SuppressPostBack="true" />
            <fieldset>
                <legend>
                    <asp:Panel ID="filtrosHeaderPanel" runat="server" Style="cursor: pointer;" align="left">
                        <asp:ImageButton ID="imgFiltros" runat="server" ImageUrl="~/Images/expand.jpg" AlternateText="Exibir" />
                        <asp:Label ID="lblExibirOcultarFiltros" Text="" runat="server"></asp:Label>
                    </asp:Panel>
                </legend>
                <asp:Panel ID="filtrosContentPanel" runat="server" Style="overflow: hidden;">
                    <fieldset>
                        <legend>Dados da Nota Fiscal</legend>
                        <table border="0" width="100%">
                            <tr>
                                <td align="left">
                                    Filtrar pela data das notas fiscais de
                                </td>
                                <td align="left">
                                    Data Inicial
                                </td>
                                <td align="left">
                                    Data Final
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:RadioButtonList ID="rblTipoNota" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Saída" Value="S" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Entrada" Value="E"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtDataInicio" class="data" />
                                    <asp:ImageButton runat="Server" ID="imgDataInicio" ImageUrl="~/Images/Calendar.png"
                                        AlternateText="Clique para exibir o calendário" /><br />
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderInicio" runat="server" TargetControlID="txtDataInicio"
                                        PopupButtonID="imgDataInicio" Format="dd/MM/yyyy" />
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtDataFinal" class="data" />
                                    <asp:ImageButton runat="Server" ID="imgDataFinal" ImageUrl="~/Images/Calendar.png"
                                        AlternateText="Clique para exibir o calendário" /><br />
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderFinal" runat="server" TargetControlID="txtDataFinal"
                                        PopupButtonID="imgDataFinal" Format="dd/MM/yyyy" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset>
                        <legend>Dados do Produto</legend>
                        <table border="0" width="100%">
                            <tr>
                                <td align="left">
                                    Código do Produto
                                </td>
                                <td align="left">
                                    Nome do Produto
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 20%;">
                                    <asp:TextBox ID="txtCodigoProduto" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNomeProduto" runat="server" autocomplete="off" Width="100%"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender runat="server" BehaviorID="AutoCompleteEx" ID="autoComplete1"
                                        TargetControlID="txtNomeProduto" ServiceMethod="ListaAutoComplete" MinimumPrefixLength="2"
                                        CompletionInterval="50" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        DelimiterCharacters=";,:" ShowOnlyCurrentWordInCompletionListItem="true" OnClientPopulated="AjustaTamanhoAutoComplete">
                                        <Animations>
                                        <OnShow>
                                            <Sequence>
                                                <%-- Make the completion list transparent and then show it --%>
                                                <OpacityAction Opacity="0" />
                                                <HideAction Visible="true" />
                            
                                                <%--Cache the original size of the completion list the first time
                                                    the animation is played and then set it to zero --%>
                                                <ScriptAction Script="
                                                    // Cache the size and setup the initial size
                                                    var behavior = $find('AutoCompleteEx');
                                                    if (!behavior._height) {
                                                        var target = behavior.get_completionList();
                                                        behavior._height = target.offsetHeight - 2;
                                                        target.style.height = '0px';
                                                    }" />
                            
                                                <%-- Expand from 0px to the appropriate size while fading in --%>
                                                <Parallel Duration=".4">
                                                    <FadeIn />
                                                    <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />                                                    
                                                </Parallel>
                                            </Sequence>
                                        </OnShow>
                                        <OnHide>
                                            <%-- Collapse down to 0px and fade out --%>
                                            <Parallel Duration=".4">
                                                <FadeOut />
                                                <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                                            </Parallel>
                                        </OnHide>
                                        </Animations>
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <table border="0" width="100%">
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="button" OnClick="btnFiltrar_Click"
                                    OnClientClick="javascript:return fctValidaFiltros();" />
                                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="button" OnClick="btnLimpar_Click" />
                                <asp:Button ID="btnRecuperaNomeProduto" runat="server" Text="btnRecuperaNomeProduto"
                                    Style="display: none;" OnClick="btnRecuperaNomeProduto_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </fieldset>
            <asp:Panel ID="pnlReportViewer" runat="server">
                <rsweb:ReportViewer ID="rptvRelatorioInconsistenciasEstoque" runat="server" Width="100%"
                    Height="500px" ShowPrintButton="true">
                </rsweb:ReportViewer>
            </asp:Panel>
            <asp:Panel ID="pnlMensagem" runat="server">
                <table width="100%" style="border-color: Gray; border-style: solid; border-width: 1px;">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMensagem" runat="server" Text="Não foram encontrados registros." />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
