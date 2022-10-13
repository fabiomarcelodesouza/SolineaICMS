<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMensagens.ascx.cs"
    Inherits="SolineaICMS.WebUI.UC.UCMensagens" %>
<asp:Panel ID="pnlMensagem" runat="server" Style="display: none;">
    <div class="ui-widget">
        <div class="ui-state-highlight ui-corner-all classMensagem" style="padding: 0.2em;">
            <table border="0" id="tblMensagem" style="height: 100%;">
                <tr>
                    <td>
                        <asp:Image ID="imgMensagem" ImageUrl="" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMensagem" Font-Size="Small" runat="server" Text="mensagem"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Panel>
