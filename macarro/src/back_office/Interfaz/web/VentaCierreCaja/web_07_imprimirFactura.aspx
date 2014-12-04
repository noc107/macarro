<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_imprimirFactura.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Cierre de Caja
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Factura</h2>
    <div id="contFactura">
        <h3>Macarro</h3>
        <h5>J-456789754</h5>
        <h5>Venezuela</h5>
        <label>Factura Simplificada:</label><br/>
        <label>Fecha: </label><label> 00/00/0000</label>
        <p>&nbsp;</p>

        <div id="facturaFinal">
            <asp:Table ID="Table1" runat="server">

            </asp:Table>
        </div>
        <h5>Gracias por su Compra!</h5>
        <center><asp:Button ID="BotonDescargarFactura" runat="server" Text="Descargar" CssClass="Boton botonImprimir" /></center>
    </div>
</asp:Content>
