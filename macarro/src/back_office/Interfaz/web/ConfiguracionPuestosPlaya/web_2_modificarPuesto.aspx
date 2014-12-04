<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_modificarPuesto.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.web_2_modificarPuesto"
    MasterPageFile="~/Interfaz/temp/back_office_temp.Master"%>

<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/formularioModificarPuesto.ascx" TagPrefix="uc1" TagName="formularioModificarPuesto" %>
<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>







<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
     Modificar Puesto
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
    Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Modificar Puesto</h2>
    <div>
        <uc1:mensajeDeEstado runat="server" id="mensajeDeEstado" />
        <uc1:formularioModificarPuesto runat="server" ID="formularioModificarPuesto" />
        <br />
    </div>
</asp:Content>