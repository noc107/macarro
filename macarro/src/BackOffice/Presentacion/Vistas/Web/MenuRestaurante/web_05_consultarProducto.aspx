<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" CodeBehind="web_05_consultarProducto.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.MenuRestaurante.web_05_consultarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMenuRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
       <script src="/comun/resources/js/ModuloMenuRestaurante/MenuRestaurante.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Menu de restaurante
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

    <div  id="contenedor" class="Estilocontenedor;">
        <div class="Divporfila;">
            <div class="Estilodivlabels; Estilodivtextbox;">

                <h2>Consultar Plato</h2>

                <div>
                    <asp:Label ID="MensajeExito" runat="server" Text="Producto Modificado Exitosamente" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
                </div>

                <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                    <asp:TableRow ID="TableRow6" runat="server">
                        <asp:TableCell ID="TableCell15" runat="server">
                            <asp:Label ID="_nombrePlatoLabel" runat="server" Text="Nombre:" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell16" runat="server">
                            <asp:Label ID="lbNombre" runat="server" Text="" CssClass="labels"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow ID="TableRow10" runat="server">
                        <asp:TableCell ID="TableCell17" runat="server">
                            <asp:Label ID="Label10" runat="server" Text="Descripcion:" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell18" runat="server">
                            <asp:Label ID="lbDescripcion" runat="server" Text="" CssClass="labels"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow ID="TableRow1" runat="server">
                        <asp:TableCell ID="TableCell1" runat="server">
                            <asp:Label ID="Label7" runat="server" Text="Precio:" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell2" runat="server">
                            <asp:Label ID="lbPrecio" runat="server" Text="" CssClass="labels"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow ID="TableRow2" runat="server">
                        <asp:TableCell ID="TableCell3" runat="server">
                            <asp:Label ID="Label8" runat="server" Text="Seccion:" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell4" runat="server">
                            <asp:Label ID="lbSeccion" runat="server" Text="" CssClass="labels"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <br />

                <asp:Table ID="Table3" runat="server" HorizontalAlign="Center">
                    <asp:TableRow ID="TableRow4" runat="server">
                        <asp:TableCell ID="TableCell6" runat="server">
                            <asp:Button ID="ButtonAgregar" CssClass="Boton" runat="server" Text="Regresar" />
                            <asp:HiddenField runat="server" ID="campoOculto" Value="0" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

            </div>
        </div>
 </div>
</asp:Content>
