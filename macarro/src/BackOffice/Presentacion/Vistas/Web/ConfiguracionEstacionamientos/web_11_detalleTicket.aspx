<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"  UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_detalleTicket.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos.web_11_detalleTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
    <link href="../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Detalle ticket</h2>
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="Fh_entrada" runat="server" CssClass="labels">   Fecha-Hora - Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:label ID="l_entrada" runat="server" ></asp:label>
                   </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="Fh_salida" runat="server" CssClass="labels">   Fecha-Hora Salida : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="l_salida" runat="server" ></asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_placa" runat="server" CssClass="labels">   Placa : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="l_placa" runat="server" ></asp:label>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="l_precio" runat="server" CssClass="labels">Precio : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:label ID="L_monto" runat="server" ></asp:label>
                   </asp:TableCell>

               </asp:TableRow>
         </asp:Table>
    <br />
    <div>
    <div class="boton_centrado">
            <asp:Button ID="BotonAgregarEstacionamiento" runat="server" CssClass="Boton" Text="Volver" OnClick="BotonAgregarEstacionamiento_Click"/>
        </div>
    </div>  
</asp:Content>
