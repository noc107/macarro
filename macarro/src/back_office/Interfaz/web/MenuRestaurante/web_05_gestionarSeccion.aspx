<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_05_gestionarSeccion.aspx.cs" Inherits="back_office.Interfaz.web.MenuRestaurante.web_05_gestionarSeccion" %>
<%@ Register Src="~/Interfaz/web/MenuRestaurante/componentes/mensajeDeConfirmacion.ascx" TagPrefix="uc2" TagName="mensajeDeConfirmacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Menu de restaurante
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Gestionar Seccion</h2>
 <uc2:mensajeDeConfirmacion runat="server" ID="mensajeDeConfirmacion" />
    <br />

<div class="Estilogridviewseccion">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid_view">
    <Columns>
        <asp:BoundField DataField="entradas" DataFormatString="entradas" FooterText="nombre" HeaderText="nombre" />
        <asp:BoundField DataField="PL" DataFormatString="Platos Ligeros" FooterText="descripcion" HeaderText="descripcion" ValidateRequestMode="Enabled" />
        <asp:ButtonField AccessibleHeaderText="accion" Text="Modificar" ButtonType="Image" ControlStyle-Width="30px" ControlStyle-Height="30px" ImageUrl="~/comun/resources/img/Data-Edit-128.png" />
        <asp:ButtonField Text="Eliminar" ButtonType="Image" ControlStyle-Width="10px" ControlStyle-Height="10px" ImageUrl="~/comun/resources/img/Garbage-Closed-128.png" >
<ControlStyle Height="30px" Width="30px"></ControlStyle>
        </asp:ButtonField>
    </Columns>
</asp:GridView>
</div>
<br /> 
</asp:Content>
