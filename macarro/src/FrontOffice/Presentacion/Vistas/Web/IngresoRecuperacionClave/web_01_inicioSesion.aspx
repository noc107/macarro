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
   
<div>
    <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
</div>

<div  class="content01" >
    <br />
    <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell> <asp:label CssClass="labels" ID="LUsuario" runat="server" Text="Usuario"></asp:label> </asp:TableCell>
            <asp:TableCell> <asp:TextBox CssClass="textbox" ID="correo" runat="server" MaxLength="40" 
                placeholder="Correo Electr&oacute;nico" ></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RegularExpressionValidator21" runat="server" 
                    ControlToValidate ="correo" Text="*" ForeColor="Red"
                    ErrorMessage="Debe ingresar el usuario">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell> <asp:Label CssClass="labels" ID="LContrasena" runat="server" Text="Contrase&ntilde;a"></asp:Label> </asp:TableCell>
            <asp:TableCell> <asp:TextBox CssClass="textbox" ID="Contrasena" runat="server" TextMode="Password" MaxLength="12" 
                placeholder="Contrase&ntilde;a"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate ="Contrasena" Text="*" ForeColor="Red"
                    ErrorMessage="Debe ingresar una contraseña">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <div style="text-align:center"> 
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ValidationSummary ID="ValidationSummary2"
                        HeaderText=""
                        DisplayMode="BulletList"
                        EnableClientScript="true"
                        runat="server" 
                        CssClass="avisoMensajeBot MensajeError"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <p> <asp:Button CssClass="Boton01" ID="Button1" runat="server" Text="Iniciar Sesi&oacute;n" OnClick="Boton_IniciarSesion" /> </p>
        <p> <asp:HyperLink CssClass="HiperLink" ID="Link1" runat="server" Text="&#191;No est&aacute;s registrado&#63;" NavigateUrl="~/Presentacion/Vistas/web/IngresoRecuperacionClave/web_01_registro.aspx"></asp:HyperLink> </p>
        <p> 
            <asp:Button ID="BOlvidasteContrasena" runat="server" BackColor="#EBEBEB" BorderColor="#EBEBEB" BorderStyle="None" 
                Font-Italic="True" Font-Names="open sans" Font-Size="Medium" Font-Underline="True" ForeColor="#2980B9" 
                OnClick="BOlvidasteContrasena_Click" Text="¿Olvidaste tu contraseña?" Width="202px" />
        </p>
    </div>

</div>

</asp:Content>