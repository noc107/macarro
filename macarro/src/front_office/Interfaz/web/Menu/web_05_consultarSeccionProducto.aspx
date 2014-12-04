<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_not_loged.Master" AutoEventWireup="true" CodeBehind="web_05_consultarSeccionProducto.aspx.cs" Inherits="front_office.Interfaz.web.Menu.web_05_consultarSeccionProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMenuRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Menu de restaurante
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="middle_place_holder" runat="server">

  
<div class="EstilogridviewseccionFO">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid_view">
    <Columns>
        <asp:BoundField DataField="entradas" DataFormatString="Entradas" FooterText="nombre" HeaderText="Nombre de la Seccion" />
        <asp:ButtonField Text="Eliminar" ButtonType="Image" ControlStyle-Width="10px" ControlStyle-Height="10px" ImageUrl="~/comun/resources/img/View-128.png" >
<ControlStyle Height="30px" Width="30px"></ControlStyle>
        </asp:ButtonField>
    </Columns>
</asp:GridView>
</div>
<br /> 
<br /> 
<br /> 

<div class="EstilogridviewproductoFO">
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="grid_view">
    <Columns>
        <asp:BoundField DataField="entradas" DataFormatString="Tequeños" FooterText="nombre" HeaderText="Nombre del producto" />
        <asp:BoundField DataField="entradas" DataFormatString="Dedos de queso" FooterText="nombre" HeaderText="Descripcion" />
        <asp:BoundField DataField="entradas" DataFormatString="150" FooterText="nombre" HeaderText="Precio" />
        
    </Columns>
</asp:GridView>
</div>
</asp:Content>
