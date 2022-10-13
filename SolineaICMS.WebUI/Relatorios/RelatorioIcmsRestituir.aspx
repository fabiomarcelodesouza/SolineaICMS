<%@ Page Title="Solinea ICMS - Relatório de ICMS à Restituir" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="RelatorioIcmsRestituir.aspx.cs" Inherits="SolineaICMS.WebUI.Relatorios.RelatorioIcmsRestituir" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        function DefineMascaras() {
            $(".data").mask("99/99/9999");
        }

        function fctValidaFiltros() {
            dataInicio = $("#<%= txtDataInicio.ClientID %>");
            dataFinal = $("#<%= txtDataFinal.ClientID %>");

            if (dataInicio.val()== "") {
                fctChamaModalInformacao("Data Inicial", "O campo 'Data Inicial' não foi preenchido.", "Information");
                dataInicio.focus();
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server">
        <ContentTemplate>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeFiltros" runat="Server" TargetControlID="filtrosContentPanel"
                ExpandControlID="filtrosHeaderPanel" CollapseControlID="filtrosHeaderPanel" Collapsed="false"
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
                    <table border="0" width="100%">
                        <tr>
                            <td style="width: 10%;">
                                Tipo de Nota
                            </td>
                            <td colspan="3">
                                <asp:RadioButtonList ID="rblTipoNota" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Saída" Value="S" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Entrada" Value="E"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Data Inicial
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDataInicio" class="data" />
                                <asp:ImageButton runat="Server" ID="imgDataInicio" ImageUrl="~/Images/Calendar.png"
                                    AlternateText="Clique para exibir o calendário" /><br />
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderInicio" runat="server" TargetControlID="txtDataInicio"
                                    PopupButtonID="imgDataInicio" Format="dd/MM/yyyy" />
                            </td>
                            <td>
                                Data Final
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDataFinal" class="data" />
                                <asp:ImageButton runat="Server" ID="imgDataFinal" ImageUrl="~/Images/Calendar.png"
                                    AlternateText="Clique para exibir o calendário" /><br />
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderFinal" runat="server" TargetControlID="txtDataFinal"
                                    PopupButtonID="imgDataFinal" Format="dd/MM/yyyy" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnGerar" runat="server" Text="Gerar" CssClass="button" OnClick="btnGerar_Click"
                                    OnClientClick="javascript:return fctValidaFiltros();" />
                                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="button" OnClick="btnLimpar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </fieldset>
            <asp:Panel ID="pnlReportViewer" runat="server">
                <rsweb:ReportViewer ID="rptvRelatorioIcmsRestituir" runat="server" Width="100%" Height="500px">
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
