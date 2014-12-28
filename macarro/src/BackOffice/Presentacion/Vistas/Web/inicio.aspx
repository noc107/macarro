<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

    <asp:Label CssClass="avisoMensaje MensajeExito" ID="_mensajeExito" runat="server" Text="Label">Bienvenida &nbsp  a &nbsp  Macarro &nbsp  <%=Session["primerNombre"]%> &nbsp <%=Session["primerApellido"]%></asp:Label>
    
</asp:Content>

