<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_consultarPuesto.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.web_2_consultarPuesto" 
    MasterPageFile="~/Interfaz/temp/back_office_temp.Master"%>

<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/formularioConsultarPuesto.ascx" TagPrefix="uc1" TagName="formularioConsultarPuesto" %>
<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>



<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Consultar Puesto
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
    Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Consultar Puesto</h2>
    <div>
        <uc1:mensajeDeEstado runat="server" id="mensajeDeEstado" />
        <uc1:formularioConsultarPuesto runat="server" ID="formularioConsultarPuesto" />
        <br />
        <div>
            <asp:GridView ID="consultarPuesto" runat="server">

            </asp:GridView>
        </div>
    </div>
</asp:Content>
