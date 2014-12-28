<%@ Page UnobtrusiveValidationMode="None" Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_not_loged.Master" 
    AutoEventWireup="true" CodeBehind="web_01_inicioSesion.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave.web_01_inicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Inicio de Sesion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
     <link href="../../../../comun/resources/css/IngresoRecuperacionClave/modulo01.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Inicio de Sesion
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
   

<div class="content01" >

    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la reserva." 
        Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>

    <table align="center" style="width:30%" >
        <tr>
            <td></td>
            <td> <asp:label CssClass="labels" ID="LUsuario" runat="server" Text="Usuario"></asp:label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="correo" runat="server" MaxLength="40" 
                placeholder="Correo Electr&oacute;nico" ></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RegularExpressionValidator21" runat="server" 
                    ControlToValidate ="correo" Text="*" ForeColor="Red"
                    ErrorMessage="Debe ingresar el usuario">
                </asp:RequiredFieldValidator>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td> <asp:Label CssClass="labels" ID="LContrasena" runat="server" Text="Contrase&ntilde;a"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="Contrasena" runat="server" TextMode="Password" MaxLength="12" 
                placeholder="Contrase&ntilde;a"></asp:TextBox> 
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4">  <asp:ValidationSummary ID="ValidationSummary1" HeaderText="" DisplayMode="BulletList"
                EnableClientScript="true" runat="server" ForeColor="Red"/>
            </td>
        </tr>
    </table>

    <div style="text-align:center"> 

        <p><asp:Label CssClass="labels" ID="UsuarioInvalido" runat="server" Text=" "></asp:Label></p>

        <p> <asp:ValidationSummary ID="ValidationSummary0"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/> 
        </p>
        <p> <asp:Button CssClass="Boton01" ID="Button1" runat="server" Text="Iniciar Sesi&oacute;n" OnClick="Button1_Click" /> </p>
        <p> <asp:HyperLink CssClass="HiperLink" ID="Link1" runat="server" Text="&#191;No est&aacute;s registrado&#63;" NavigateUrl="~/Interfaz/web/IngresoRecuperacionClave/web_01_registro.aspx"></asp:HyperLink> </p>
        <p> 
            <asp:Button ID="BOlvidasteContrasena" runat="server" BackColor="#EBEBEB" BorderColor="#EBEBEB" BorderStyle="None" 
                Font-Italic="True" Font-Names="open sans" Font-Size="Medium" Font-Underline="True" ForeColor="#2980B9" 
                OnClick="BOlvidasteContrasena_Click" Text="¿Olvidaste tu contraseña?" Width="202px" />
        </p>
    </div>

</div>

</asp:Content>