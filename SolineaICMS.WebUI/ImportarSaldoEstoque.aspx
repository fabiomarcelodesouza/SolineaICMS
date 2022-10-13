<%@ Page Title="Solinea ICMS - Importar Saldo de Estoque" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="ImportarSaldoEstoque.aspx.cs" Inherits="SolineaICMS.WebUI.ImportarSaldoEstoque" %>

<%@ Register Src="~/UC/UCMensagens.ascx" TagName="Mensagem" TagPrefix="msg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function fctOcultaControlesChamadaAssincrona() {
            $("#<%= btnImportarArquivo.ClientID %>").css("display", "none");
        }

        function fctUploadComplete() {
            $("#<%= btnImportarArquivo.ClientID %>").css("display", "");
            $(".classMensagem").css("display", "none");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0" OnAsyncPostBackError="ScriptManager1_AsyncPostBackError"
        EnablePageMethods="true">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args) {
            if (args.get_error() != undefined) {
                var errorMessage = args.get_error().message;
                args.set_errorHandled(true);

                alert(errorMessage);
            }
        }        
    </script>
    <asp:UpdatePanel ID="uppnlPrincipal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Label ID="myThrobber" runat="server"><img src="Images/ajax-loader.gif" alt="Em processamento, aguarde..." /><br /> Em processamento, aguarde...</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <msg:Mensagem ID="ucMensagem" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Selecione o arquivo de saldo de estoque para importar.
                        <br />
                        <b>IMPORTANTE: O arquivo que irá ser importado deve estar no formato Excel (extensão
                            ".xls" ou ".xlsx") ou no formato XML.</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <ajaxToolkit:AsyncFileUpload runat="server" ID="fupFile" Width="400px" UploaderStyle="Traditional"
                            UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" PersistFile="true" 
                            OnClientUploadComplete="fctUploadComplete" CompleteBackColor="#CCCCCC" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnImportarArquivo" runat="server" Text="Importar Arquivo" OnClick="btnImportarArquivo_Click"
                            OnClientClick="fctOcultaControlesChamadaAssincrona()" Style="display: none;" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
