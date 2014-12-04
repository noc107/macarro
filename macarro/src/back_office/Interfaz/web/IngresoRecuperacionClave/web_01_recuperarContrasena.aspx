<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_01_recuperarContrasena.aspx.cs" Inherits="back_office.Interfaz.web.IngresoRecuperacionClave.web_01_recuperarContrasena" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Recuperaci&oacute;n de Contrase&ntilde;a
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server"> 


<div class="content01" >


<table align="center" style="width:40%" >
  <tr>
    <td></td>
    <td> <asp:label CssClass="labels" ID="Label1" runat="server" Text="Contrase&ntilde;a"></asp:label> </td>
    <td> <asp:TextBox CssClass="textbox" ID="Ncontrasena" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox> </td>
    <td></td>
  </tr>
  <tr>
    <td></td>
    <td> <asp:Label CssClass="labels" ID="CcontrasenaL" runat="server" Text="Confirmar Contrase&ntilde;a"></asp:Label> </td>
    <td> <asp:TextBox CssClass="textbox" ID="Ccontrasena" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox> </td>
    <td></td>
  </tr>
</table>

<div style="text-align:center"> 
  <p>  <asp:Button CssClass="Boton" ID="Aceptar" runat="server" Text="Aceptar" /> </p>

</div>
</div>

</asp:Content>