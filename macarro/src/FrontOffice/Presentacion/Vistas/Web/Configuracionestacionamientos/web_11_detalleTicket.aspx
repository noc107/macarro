<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_11_detalleTicket.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Configuracionestacionamiento.web_11_detalleTicket" %>
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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
     <h2>Detalle ticket</h2>
    <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensajeBot MensajeExito Textocentrado" Visible="false">   </asp:label>
    <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensajeBot MensajeError Textocentrado" Visible="false">   </asp:label>
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="_labelFechaEntrada" runat="server" CssClass="labels">   Fecha-Hora - Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:label ID="_Entrada" runat="server"   CssClass="labels">   04/10/2014 - 02:22pm</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="_labelFechaSalida" runat="server" CssClass="labels">   Fecha-Hora Salida : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="_salida" runat="server"  CssClass="labels" >   04/10/2014 - 04:22pm</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="_labelPlaca" runat="server" CssClass="labels">   Placa : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="_placa" runat="server"  CssClass="labels" >   MAV-91-V </asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="_labelPerdido" runat="server" CssClass="labels">   Ticket Perdido : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                          <asp:label ID="_perdido" runat="server"  CssClass="labels" >  NO</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="_labelMonto" runat="server" CssClass="labels">   Monto : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:label ID="_monto" runat="server"  CssClass="labels" >  6 Bs</asp:label>
                   </asp:TableCell>

               </asp:TableRow>
         </asp:Table>
    <br />
    <div>
    <div class="boton_centrado">
            <asp:Button ID="BotonVolver" runat="server" CssClass="Boton" Text="Volver" OnClick="BotonVolver_Click"/>
        </div>
    </div> 
</asp:Content>
