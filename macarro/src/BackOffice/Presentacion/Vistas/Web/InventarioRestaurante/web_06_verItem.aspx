<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_06_verItem.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.InventarioRestaurante.web_06_verItem" %>


<script runat="server">

    protected void Label1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/InventarioRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato, Daniel 
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Gestion de Inventario
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Detalle de Item</h2>


   <div id="Formulario2" class="Bloque">
       
       <asp:Button ID="BotonVolver" CssClass="Boton BotonVerVolver" runat="server" Text="Volver" OnClick="Button1_Click" />
       <asp:Label ID="lbNombre" CssClass="labels LabelVerNombre" runat="server" Text="Nombre:" ></asp:Label>
       <asp:Label ID="_nombreVer" CssClass="labels TextoVerNombre" runat="server" Text="Pasta" ></asp:Label>
   
       
        <asp:Label ID="Label2" CssClass="labels LabelVerCantidad" runat="server" Text="Cantidad:" ></asp:Label>
        <asp:Label ID="_cantidadVer" CssClass="labels TextoVerCantidad" runat="server" Text="20"></asp:Label>
    
       
        <asp:Label ID="Label3" CssClass="labels LabelVerDescripcion"  runat="server" Text="Descripción:" ></asp:Label>
        <asp:Label ID="_descripcionVer" CssClass="labels TextoVerDescripcion"  runat="server" Text="Este es un item" ></asp:Label>
        
        <asp:Label ID="Label6" CssClass="labels LabelVerPrecioVenta" runat="server" Text="Precio Venta:" ></asp:Label>
        <asp:Label ID="_precioVentaVer" CssClass="labels TextoVerPrecioVenta" runat="server" Text="500"></asp:Label>

        <asp:Label ID="Label7" CssClass="labels LabelVerPrecioCompra"  runat="server" Text="Precio Compra:" ></asp:Label>
        <asp:Label ID="_precioCompraVer" CssClass="labels TextoVerPrecioCompra" runat="server" Text="400" ></asp:Label>

        <asp:Label ID="Label4" CssClass="labels LabelVerProveedor" runat="server" Text="Proveedor:"  ></asp:Label>
        <asp:Label ID="_proveedorVer" CssClass="labels TextoVerProveedor"  runat="server" Text="Proveedor 1"  ></asp:Label>
     
         
        <asp:Label ID="Label1" CssClass="labels LabelVerEstado" runat="server" Text="Estado:"  ></asp:Label>
        <asp:Label ID="_estado" CssClass="labels TextoVerEstado"  runat="server" Text="Activado / Desactivado"  ></asp:Label>
       
        <asp:Label ID="Label8" CssClass="labels LabelVerActualizaciones"  runat="server" Text="Actualizaciones:" ></asp:Label>
        <asp:ListBox ID="_actualizaciones" CssClass="list_box ListBoxVerActualizaciones" Enabled="false" runat="server">
        </asp:ListBox>
      
   </div>
</asp:Content>
