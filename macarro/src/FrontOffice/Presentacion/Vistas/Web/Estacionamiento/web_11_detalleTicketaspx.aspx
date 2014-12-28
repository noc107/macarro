<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_11_detalleTicketaspx.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Estacionamiento.web_11_detalleTicketaspx" %>
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
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="Fh_entrada" runat="server" CssClass="labels">   Fecha-Hora - Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:label ID="l_entrada" runat="server" >   04/10/2014 - 02:22pm</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="Fh_salida" runat="server" CssClass="labels">   Fecha-Hora Salida : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="l_salida" runat="server" >   04/10/2014 - 04:22pm</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_placa" runat="server" CssClass="labels">   Placa : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="Label1" runat="server" >   MAV-91-V </asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Ticket Perdido : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                          <asp:label ID="Label2" runat="server" >  NO</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_estatus" runat="server" CssClass="labels">   Monto : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:label ID="L_monto" runat="server" >  6 Bs</asp:label>
                   </asp:TableCell>

               </asp:TableRow>
         </asp:Table>
    <br />
    <div>
    <div class="boton_centrado">
            <asp:Button ID="BotonAgregarEstacionamiento" runat="server" CssClass="Boton" Text="Volver"/>
        </div>
    </div> 
</asp:Content>
