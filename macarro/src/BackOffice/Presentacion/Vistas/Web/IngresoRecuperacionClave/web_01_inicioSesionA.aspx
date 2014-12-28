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


<table align="center" style="width:30%" >
  <tr>
    <td></td>
    <td> <asp:label CssClass="labels" ID="Label1" runat="server" Text="Usuario"></asp:label> </td>
    <td> <asp:TextBox CssClass="textbox" ID="correo" runat="server" MaxLength="40" placeholder="Correo Electr&oacute;nico"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate ="correo" Text="*" ForeColor="Red"
            ErrorMessage="Debe ingresar el usuario">
        </asp:RequiredFieldValidator>
    </td>
    <td></td>
  </tr>
  <tr>
    <td></td>
    <td> <asp:Label CssClass="labels" ID="Label2" runat="server" Text="Contrase&ntilde;a"></asp:Label> </td>
    <td> <asp:TextBox CssClass="textbox" ID="Contrasena" runat="server" TextMode="Password" MaxLength="12" placeholder="Contrase&ntilde;a"></asp:TextBox> 
    </td>
    <td></td>
  </tr>
  <tr>
      <td colspan="4"> 
        <asp:ValidationSummary ID="ValidationSummary2" HeaderText="" DisplayMode="BulletList" EnableClientScript="true" runat="server" 
            ForeColor="Red"/>
      </td>
  </tr>
</table>

<div style="text-align:center"> 
  <p>  <asp:Button CssClass="Boton01" ID="Button1" runat="server" Text="Iniciar Sesi&oacute;n" OnClick="Button1_Click" /> </p>
</div>
        <asp:ValidationSummary ID="ValidationSummary1"
                       HeaderText=""
                       DisplayMode="BulletList"
                       EnableClientScript="true"
                       runat="server" 
                        ForeColor="Red"/>
</div>

</asp:Content>