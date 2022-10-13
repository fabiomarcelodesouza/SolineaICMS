<%@ Page Title="Solinea ICMS - Log In" Language="C#" MasterPageFile="~/Master/SolineaICMS.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SolineaICMS.WebUI.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        Acesso ao Solinea ICMS
    </h2>
    <br />
    <div runat="server" id="divMsgLogin">
        <div id="divMsgInicial" runat="server" visible="true">
            <table border="0" id="tblMsgInicial">
                <tr>
                    <td>
                        <asp:Label ID="lblMsgInicial" runat="server" Text="Por favor, informe seu login e senha de acesso nos campos abaixo."></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divMsgErroAutenticacao" runat="server" visible="false">
            <table border="0" id="tblMsgErro">
                <tr>
                    <td>
                        <asp:Image ID="imgErroAutenticacao" ImageUrl="~/Images/Icons/error32px.png" AlternateText="Login inexistente ou senha incorreta, informe seu login e senha de acesso nos campos abaixo."
                            runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMsgErroAutenticacao" Font-Size="Medium" ForeColor="Red" runat="server"
                            Text="Login inexistente ou senha incorreta, informe seu login e senha de acesso nos campos abaixo."></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div class="accountInfo" style="float:left;">
        <fieldset class="login">
            <legend>Dados do Usuário</legend>
            <asp:UpdatePanel runat="server" ID="uppnlDadosUsuario">
                <Triggers>
                    <asp:PostBackTrigger ControlID="LoginButton" />
                </Triggers>
                <ContentTemplate>
                    <p>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            CssClass="validator" ErrorMessage="Informe seu login" Display="Dynamic" ToolTip="Informe seu login"
                            ValidationGroup="LoginUserValidationGroup">
                            <asp:Image ID="imgErrorLogin" ImageUrl="~/Images/Icons/error16px.png" AlternateText="Informe seu login"
                                runat="server" />
                            Informe seu login</asp:RequiredFieldValidator>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Login:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="200px"></asp:TextBox>
                    </p>
                    <p>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            CssClass="validator" ErrorMessage="Informe sua senha" Display="Dynamic" ToolTip="Informe sua senha"
                            ValidationGroup="LoginUserValidationGroup">
                            <asp:Image ID="imgErrorSenha" ImageUrl="~/Images/Icons/error16px.png" AlternateText="Informe sua senha"
                                runat="server" />
                            Informe sua senha</asp:RequiredFieldValidator>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"
                            Width="200px"></asp:TextBox>
                    </p>
                    <p class="submitButton">
                        <asp:Button ID="LoginButton" CssClass="button" runat="server" CommandName="Login"
                            Text="Entrar" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" />
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
        </fieldset>        
    </div>
    <%--<div style="float:right; width:500px;">
        <p style="text-align:justify;">
            O Solinea ICMS é um sistema capaz de apurar créditos de ICMS para empresas que adquiram mercadorias com recolhimento de ICMS, em regime de substituição tributária, e revendam essas mercadorias para estabelecimentos situados em outros estados do Brasil, recolhendo novamente o ICMS.
        </p>
    </div>--%>
</asp:Content>
