<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"  UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_5_gestionarEstacionamiento.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos.web_5_gestionarEstacionamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
        <link href="../../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Gestionar Estacionamiento</h2>
    
    <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>

    <asp:Table ID="TableEst" runat="server" CssClass="tabla">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="_nombreEstacionamiento" runat="server" Text="Nombre Estacionamiento" CssClass="labels nombreEst"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="LabelCapacidad" runat="server" Text="Capacidad: " CssClass="labels"></asp:Label>
                <asp:Label ID="_capacidad" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="LabelTarifa" runat="server" Text="Tarifa: " CssClass="labels"></asp:Label>
                <asp:Label ID="_tarifa" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="LabelEstado" runat="server" Text="Estado: " CssClass="labels"></asp:Label>
                <asp:Label ID="_estado" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="LabelTicket" runat="server" Text="Ticket perdido: " CssClass="labels"></asp:Label>
                <asp:Label ID="_tarifaPerdido" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Button ID="ButtonEditar" runat="server" Text="Editar" CssClass="Boton" OnClick="ButtonEditar_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    

</asp:Content>

