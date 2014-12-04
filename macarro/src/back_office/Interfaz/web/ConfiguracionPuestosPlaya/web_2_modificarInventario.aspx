<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_modificarInventario.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.web_2_modificarInventario"
    MasterPageFile="~/Interfaz/temp/back_office_temp.Master"%>

<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/formularioModificarInventario.ascx" TagPrefix="uc1" TagName="formularioModificarInventario" %>
<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>



<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Modificar Inventario
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
    Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Modificar Inventario</h2>
    <div>
        <uc1:mensajeDeEstado runat="server" id="mensajeDeEstado" />
        <uc1:formularioModificarInventario runat="server" id="formularioModificarInventario" />
        <br />
    </div>
</asp:Content>