<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_12_consultarMembresia.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_12_consultarMembresia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
        <link href="/comun/resources/css/loged_in.css" rel="stylesheet" />
    <link href="/comun/resources/css/standards.css" rel="stylesheet" />
    <link href="/comun/resources/css/Membresia/estilo.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresía
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
    <h2>Consultar Membresía</h2>
    <div id="Mensajes">
        <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
        <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
    </div>
    <asp:Panel ID="Carnet" CssClass="Carnet" runat="server">
        <div id="headerCarnet">
            <asp:Image ID="headerCarnetLogo" ImageUrl="/comun/resources/img/logo-macarro.png" runat="server" />
        </div>
        <div id="headerSeparador">
            <h2>Carnet</h2>
        </div>
        <div id="bodyCarnet">
            <div id="izquierdaCarnet">
                <asp:Label ID="_nombreD" CssClass="Identificadores" runat="server" Text="Label">Nombre :</asp:Label>
                <asp:Label ID="_apellidoD" CssClass="Identificadores" runat="server" Text="Label">Apellido :</asp:Label>
                <asp:Label ID="_fechaNacimientoD" CssClass="Identificadores" runat="server" Text="Label">F. Nacimiento :</asp:Label>
                <asp:Label ID="_fechaVencimientoD" CssClass="Identificadores" runat="server" Text="Label">F. Vencimiento :</asp:Label>
                <asp:Label ID="_tipoDocumentoIdentidad" CssClass="Identificadores" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_numeroTelefonoD" CssClass="Identificadores" runat="server" Text="Label">Teléfono :</asp:Label>
            </div>
            <div id="centroCarnet">
                <asp:Label ID="_nombre" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_apellido" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_fechaNacimiento" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_fechaVencimiento" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_numeroDocumentoIdentidad" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_numeroTelefono" CssClass="Data" runat="server" Text="Label"></asp:Label>
            </div>
            <div id="derechaCarnet">
                <asp:Image ID="_foto" CssClass="foto Data" runat="server" />
                <asp:Label ID="_numeroCarnet" CssClass="Data numeroCarnet" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    <div class="botones">
        <asp:Button ID="_descargarPDF" CssClass="Boton botonesDescargarPDF" runat="server" Text="Descargar PDF" OnClick="_descargarPDF_Click"/>
        <asp:Button ID="_verPagos" CssClass="Boton botonVerPagos" runat="server" Text="Ver Pagos" OnClick="_verPagos_Click"/>
    </div>
    

    

    <%-- Pagina en construccion --%>

</asp:Content>

