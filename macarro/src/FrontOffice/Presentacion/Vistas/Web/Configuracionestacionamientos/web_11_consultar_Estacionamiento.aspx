<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_consultar_Estacionamiento.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamiento.web_11_consultar_Estacionamiento"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
    <link href="../../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Consultar Estacionamiento</h2>
     <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensajeBot MensajeExito Textocentrado" Visible="false">  </asp:label>
    <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensajeBot MensajeError Textocentrado" Visible="false">  </asp:label>
        <asp:Table ID="tablaConsultarEst" runat="server" HorizontalAlign="Center" Height="207px" Width="497px"> 
       <asp:TableRow>      
            <asp:TableCell CssClass="celda">
                <asp:Label ID="nombreEstacionamiento" runat="server" Text="Nombre:" CssClass="labels"></asp:Label>
           <asp:Label ID="_nombreEstacionamiento" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="labelDisponible" runat="server" Text="Puestos disponibles: " CssClass="labels"></asp:Label>
                <asp:Label ID="_disponible" runat="server" Text="disponibles" CssClass="labels"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="labelCapacidad" runat="server" Text="Capacidad: " CssClass="labels"></asp:Label>
                <asp:Label ID="_capacidad" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="labelTarifa" runat="server" Text="Tarifa: " CssClass="labels"></asp:Label>
                <asp:Label ID="_tarifa" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="labelEstado" runat="server" Text="Estado: " CssClass="labels"></asp:Label>
                <asp:Label ID="_estado" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell CssClass="celda"></asp:TableCell>
            <asp:TableCell CssClass="celda">
                <asp:Label ID="labelTicket" runat="server" Text=" Tarifa ticket perdido: " CssClass="labels"></asp:Label>
                <asp:Label ID="_tarifaPerdido" runat="server" Text="Label" CssClass="labels"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
       
    </asp:Table>
    
    <br />
    <div>
    <div class="boton_centrado">
            <asp:Button ID="BotonVolver" runat="server" CssClass="Boton" Text="Volver" OnClick="BotonVolver_Click"/>
        </div>
    </div> 
    <br />
     
</asp:Content>
