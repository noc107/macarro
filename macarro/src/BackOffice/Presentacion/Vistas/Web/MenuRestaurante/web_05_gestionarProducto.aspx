<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_05_gestionarProducto.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.MenuRestaurante.web_05_gestionarProducto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/mensajeDeConfirmacion.ascx" TagPrefix="uc2" TagName="mensajeDeConfirmacion" %>

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
    <h2>Gestionar Platos</h2>

    <div>
        
         <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensaje MensajeExito" Visible="false">  Mensaje de Confirmacion </asp:label>
         <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensaje MensajeError" Visible="false">  Mensaje de Confirmacion </asp:label>
    </div>

    <div class="Estilogridview;">
        <asp:GridView ID="_gvPlatos" CssClass="mGrid" AllowPaging="True" HorizontalAlign="Center" runat="server" BorderStyle="None"
                        AllowSorting="true" GridLines="None" AutoGenerateColumns="False" Width="800px" ForeColor="#99CCFF" PageSize="8"
                        OnRowDataBound="GVPlatos_RowDataBound" OnPageIndexChanging="GVPlatos_PageIndexChanging">
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
             <asp:BoundField HeaderText="Plato" DataField="Plato" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">                               </asp:BoundField>
             <asp:BoundField HeaderText="Precio" DataField="Precio"  ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">                             </asp:BoundField>
             <asp:BoundField HeaderText="Descripción" DataField="Descripción"  ItemStyle-Width="170px" ItemStyle-HorizontalAlign="Center">                  </asp:BoundField>
             <asp:BoundField HeaderText="Sección" DataField="Sección"  ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">                          </asp:BoundField>
             <asp:BoundField HeaderText="Ver Editar Eliminar" DataField="Ver Editar Eliminar"  ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Center">  </asp:BoundField>
            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
        </asp:GridView>
    </div>
    <br /> 
</asp:Content>
