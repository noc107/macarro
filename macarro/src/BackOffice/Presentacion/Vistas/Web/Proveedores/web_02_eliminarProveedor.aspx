<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="web_02_eliminarProveedor.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_eliminarProveedor" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/eliminarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Eliminar Proveedor</h2>
    <asp:Label CssClass="avisomensaje" ID="Mensaje" runat="server" Visible="False"></asp:Label>
    <div class="divArriba">
        <div class="divIzquierdo">
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label1" runat="server" Text="RIF (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Rif" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label3" runat="server" Text="Razón Social (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="RazonSocial" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label5" runat="server" Text="Correo (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Correo" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label7" runat="server" Text="Pagina Web (*)"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="PaginaWeb" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label9" runat="server" Text="Telefono (*):"></asp:Label>
            <asp:Label  CssClass="labels etiquetaDerecha" ID="Telefono" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label11" runat="server" Text="Fecha Contrato (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="FechaContrato" runat="server" Text="CONTENIDO"></asp:Label>
        </div>
        <div class="divDerecho">
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label2" runat="server" Text="País (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Pais" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label4" runat="server" Text="Estado (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Estado" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Ciudad" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels etiquetaIzquierda" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label>
            <asp:Label CssClass="labels etiquetaDerecha" ID="Direccion" runat="server" Text="CONTENIDO"></asp:Label>
        </div>
    </div>
    <div class="divAbajo">
        <asp:GridView class="grid_view tabla mGrid" ID="GridItems" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Lista de Items" DataField="Nombre" />
            </Columns>
        </asp:GridView>
    </div>
     <div class="divBoton">
        <asp:Button CssClass="Boton margenBoton" ID="Button1" runat="server" Text="Eliminar" OnClientClick="return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')" OnClick="Button1_Click"/>
        <asp:Button CssClass="Boton margenBoton" ID="Button2" runat="server" Text="Regresar" OnClick="Button2_Click"/>
    </div>
</asp:Content>



