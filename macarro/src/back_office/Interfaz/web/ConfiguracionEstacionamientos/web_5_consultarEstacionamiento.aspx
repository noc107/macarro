<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master"  UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_5_consultarEstacionamiento.aspx.cs" Inherits="back_office.Interfaz.web.ConfiguracionEstacionamientos.web_5_consultarEstacionamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
     <link href="../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
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
        <h2>Detalle Estacionamiento</h2>
       <br /><br />
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_nombre" runat="server" CssClass="labels">   Nombre : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="l_nombre" runat="server">   Est. Playa Sur.</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_Capacidad" runat="server" CssClass="labels">   Capacidad : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="l_capacidad" runat="server">  100 puestos.</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_Tarifa" runat="server" CssClass="labels">   Tarifa Horaria: </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="label3" runat="server"> 3 Bs.</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Tarifa de Ticket Perdido : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="label4" runat="server"> 300 Bs.</asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_estatus" runat="server" CssClass="labels">   Estatus : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:label ID="label5" runat="server">  Activo.</asp:label>
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
