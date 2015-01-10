<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_12_detallePago.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_12_detallePago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/Membresia/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresía
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
    <h2>Detalle de Pago</h2>
    <div id="Mensajes">
        <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
        <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
    </div>
    <div id="izquierdaDPago">
        <asp:Label ID="tipTarjeta" CssClass="Identificadores2" runat="server" Text="Tipo de Tarjeta :"></asp:Label>
        <asp:Label ID="numTarjeta" CssClass="Identificadores2" runat="server" Text="Numero de Tarjeta :"></asp:Label>
        <asp:Label ID="nombEnTarjeta" CssClass="Identificadores2" runat="server" Text="Nombre en Tarjeta :"></asp:Label>
        <asp:Label ID="fPago" CssClass="Identificadores2" runat="server" Text="Fecha de Pago :"></asp:Label>
        <asp:Label ID="montoTot" CssClass="Identificadores2" runat="server" Text="Monto :"></asp:Label>
    </div>
    <div id="derechaDPago">
        <asp:Image ID="_tipoTarjeta" CssClass="Data2 imgData" runat="server" />
        <asp:Label ID="_numeroTarjeta" CssClass="Data2" runat="server" Text="xxxxxxxxxxxxxxxx"></asp:Label>
        <asp:Label ID="_nombreImpresoEnTarjeta" CssClass="Data2" runat="server" Text="xxxxxxxxxxxxxxxx"></asp:Label>
        <asp:Label ID="_fechaPago" CssClass="Data2" runat="server" Text="xxxxxxxxxxxxxxxx"></asp:Label>
        <asp:Label ID="_montoTotal" CssClass="Data2" runat="server" Text="xxxxxxxxxxxxxxxx"></asp:Label>
    </div>
    <div>
        <asp:Button ID="_volver" CssClass="VolverSolo Boton" runat="server" Text="Volver" OnClick="volver_Click"/>
    </div>
</asp:Content>
