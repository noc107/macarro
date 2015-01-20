<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="True" ValidateRequest="false" CodeBehind="web_02_consultarProveedor.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_consultarProveedor" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/consultarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Consultar Proveedor</h2>
    <asp:Label CssClass="avisoMensaje MensajeExito" ID="Label23" runat="server" Visible="False"></asp:Label>
    <div class="divArriba">
            <asp:Label CssClass="labels rif" ID="Label1" runat="server" Text="RIF:"></asp:Label>
            <asp:Label CssClass="labels rif1" ID="Rif" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels nombre" ID="Label3" runat="server" Text="Razón Social:"></asp:Label>
            <asp:Label CssClass="labels nombre1" ID="RazonSocial" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels correo" ID="Label5" runat="server" Text="Correo:"></asp:Label>
            <asp:Label CssClass="labels correo1" ID="Correo" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels pagweb" ID="Label7" runat="server" Text="Pagina Web:"></asp:Label>
            <asp:Label CssClass="labels pagweb1" ID="PaginaWeb" runat="server" Text="CONTENIDO"></asp:Label>

            <asp:Label CssClass="labels direccion" ID="Pais" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels telefono" ID="Label9" runat="server" Text="Telefono:"></asp:Label>
            <asp:Label  CssClass="labels telefono1" ID="Telefono" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels contrato" ID="Label11" runat="server" Text="Fecha Contrato:"></asp:Label>
            <asp:Label CssClass="labels contrato1" ID="FechaContrato" runat="server" Text="CONTENIDO"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labels estado" ID="Label2" runat="server" Text="Estado:"></asp:Label>
            <asp:Label CssClass="labels estado1" ID="Estado" runat="server" Text="CONTENIDO"></asp:Label>
           
            <asp:Label CssClass="labels item" ID="Label13" runat="server" Text="Items: "></asp:Label>


            <asp:ListBox ID="ListItem" runat="server" CssClass = "item1 list_box" ReadOnly="true"></asp:ListBox>


            <asp:Button CssClass="Boton abajo" ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click"/>


    </div>




</asp:Content>




