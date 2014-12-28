<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_07_modificarSombrilla.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Reservas.web_07_modificarSombrilla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

          <link href="../../../../comun/resources/css/Reservas/estilo.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
     Reservar
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

   <h2>Modificar Puestos en la Playa</h2>
    <h3>Seleccione el puesto de su preferencia: </h3>
<div  id="reservar">
    <asp:Image ID="Image1" runat="server" ImageUrl ="../../../../comun/resources/img/menuf.png" CssClass="menu"/>
        <div class="img">
            <asp:Table ID="tabla" runat="server" HorizontalAlign="Center" CssClass ="playa"> 
            </asp:Table>
        </div>
    <asp:Label ID="lseleccion" runat="server" Text="Puesto Seleccionado y precio: " CssClass="labels"></asp:Label>
      <asp:ListBox ID="l_puesto" runat="server"></asp:ListBox>
        <br />
        <asp:Label ID="lprecio" runat="server" Text="Total: " CssClass="labels"></asp:Label>
        <asp:Label ID="total" runat="server" Text="total" CssClass="labels"></asp:Label>
            <br />
            <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonAceptar_Click" />
        <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" CssClass="Boton" OnClick="botonCancelar_Click"  />

</div>
    

</asp:Content>
