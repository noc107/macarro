<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_modificarPuesto.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.web_2_modificarPuesto"
    MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"%>

<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/formularioModificarPuesto.ascx" TagPrefix="uc1" TagName="formularioModificarPuesto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>







<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
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
          <table>
            <tr>
                <td>
                    <div class="btn_aceptar_posicion">
                        <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonAceptar_Click" />
                    </div>
                </td>
                <td>
                    <div class="btn_aceptar_posicion">
                        <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" CssClass="Boton" OnClick="botonCancelar_Click"/>
                     </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>