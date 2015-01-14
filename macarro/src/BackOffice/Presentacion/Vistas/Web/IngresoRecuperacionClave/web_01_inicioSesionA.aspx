<%@ Page UnobtrusiveValidationMode="None" Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/log_in.Master" AutoEventWireup="true" CodeBehind="web_01_inicioSesionA.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave.web_01_inicioSesionA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

<link rel="Stylesheet" type="text/css" href="/comun/resources/css/IngresoRecuperacionClave/modulo01.css" />


<div class="content01" >
<div>
    <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
</div>

<asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
  <asp:TableRow>
    <asp:TableCell> <asp:label CssClass="labels" ID="Label1" runat="server" Text="Usuario"></asp:label> </asp:TableCell>
    <asp:TableCell> <asp:TextBox CssClass="textbox" ID="correo" runat="server" MaxLength="40" placeholder="Correo Electr&oacute;nico"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate ="correo" Text="*" ForeColor="Red"
            ErrorMessage="Debe ingresar el usuario">
        </asp:RequiredFieldValidator>
    </asp:TableCell>
  </asp:TableRow>
  <asp:TableRow>
    <asp:TableCell> <asp:Label CssClass="labels" ID="Label2" runat="server" Text="Contrase&ntilde;a"></asp:Label> </asp:TableCell>
    <asp:TableCell> <asp:TextBox CssClass="textbox" ID="Contrasena" runat="server" TextMode="Password" MaxLength="12" placeholder="Contrase&ntilde;a"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate ="Contrasena" Text="*" ForeColor="Red"
                    ErrorMessage="Debe ingresar una contraseña">
        </asp:RequiredFieldValidator>
    </asp:TableCell>
  </asp:TableRow>
</asp:Table>

<div style="text-align:center"> 
  <p>  <asp:Button CssClass="Boton01" ID="Boton_iniciarSesion" runat="server" Text="Iniciar Sesi&oacute;n" OnClick="Boton_IniciarSesion" /> </p>
</div>
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ValidationSummary ID="ValidationSummary1"
                        HeaderText=""
                        DisplayMode="BulletList"
                        EnableClientScript="true"
                        runat="server" 
                        CssClass="avisoMensajeBot MensajeError"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</div>

</asp:Content>