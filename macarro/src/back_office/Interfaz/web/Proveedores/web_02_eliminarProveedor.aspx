<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_02_consultarProveedor.aspx.cs" Inherits="back_office.Interfaz.web.Proveedores.web_02_consultarProveedor" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/eliminarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Eliminar Proveedor</h2>
    <asp:Label CssClass="avisomensaje" ID="Label23" runat="server" Visible="False"></asp:Label>
    <div class="divArriba">
        <div class="divIzquierdo">
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label1" runat="server" Text="RIF (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label13" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label3" runat="server" Text="Razón Social (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label15" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label5" runat="server" Text="Correo (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label17" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label7" runat="server" Text="Pagina Web (*)"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label19" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label9" runat="server" Text="Telefono (*):"></asp:Label>
            <asp:Label  CssClass="labels etiquetaDerecha" ID="Label21" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label11" runat="server" Text="Fecha Contrato (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label22" runat="server" Text="CONTENIDO"></asp:Label>
        </div>
        <div class="divDerecho">
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label2" runat="server" Text="País (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label12" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label4" runat="server" Text="Estado (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label14" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label16" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label8" runat="server" Text="Municipio (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label18" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Label20" runat="server" Text="CONTENIDO"></asp:Label>
        </div>
    </div>
    <div class="divAbajo">
        <asp:GridView class="grid_view tabla" ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Lista de Items Ofrecidos" />
            </Columns>
        </asp:GridView>
    </div>
     <div class="divBoton">
        <asp:Button CssClass="Boton margenBoton" ID="Button1" runat="server" Text="Eliminar" OnClientClick="return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')"/>
        <asp:Button CssClass="Boton margenBoton" ID="Button2" runat="server" Text="Regresar" OnClick="Button1_Click"/>
    </div>
</asp:Content>



