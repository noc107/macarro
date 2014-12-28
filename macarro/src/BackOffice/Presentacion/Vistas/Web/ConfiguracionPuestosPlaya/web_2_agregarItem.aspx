<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_agregarItem.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.web_2_agregarItem" 
    MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" %>

<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/formularioAgregarItem.ascx" TagPrefix="uc1" TagName="formularioAgregarItem" %>
<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>



<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Gestion de playa</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
        Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Agregar Item</h2>
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <uc1:mensajeDeEstado runat="server" ID="mensajeDeEstado" />
        <uc1:formularioAgregarItem runat="server" ID="formularioAgregarItem" />
        </ContentTemplate>
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="botonAceptar" />
            </Triggers>
            </asp:UpdatePanel>
    </div>
    <div>
        <div class="btn_aceptar_posicion">
            <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonAceptar_Click"/>
        </div>
    </div>
</asp:Content>
