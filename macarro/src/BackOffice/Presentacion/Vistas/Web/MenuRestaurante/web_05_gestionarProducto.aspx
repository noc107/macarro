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
    <h2>Gestionar Producto</h2>

   <asp:Label ID="MensajeExito" runat="server" Text="Se ha Borrado Exitosamente el Plato." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <br />

<div class="Estilogridview;">
<asp:GridView ID="_gvPlatos" AllowPaging="true" OnRowCommand="gridviewPlatos_RowCommand" GridLines="None" Width="810px" ForeColor="#99CCFF" runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Codigo"  PageIndex="1" PageSize="20">
    <AlternatingRowStyle CssClass="alt" />
    <PagerStyle CssClass="pgr"/>
    <Columns>
        <asp:BoundField  DataField="nombre" FooterText="nombre" HeaderText="nombre" />
        <asp:BoundField  DataField="descripcion" FooterText="descripcion" HeaderText="descripcion" ValidateRequestMode="Enabled" />
        <asp:BoundField  DataField="precio" HeaderText="precio" />
        <asp:BoundField  DataField="seccion" HeaderText="seccion" />
       


         <asp:TemplateField>
         <ItemTemplate>
            <asp:ImageButton id="_modificarBoton"
           Text="Sort Ascending"
           CommandName="Modificar"
           CommandArgument='<%#  Eval("Codigo") + "|" +  Eval("nombre") + "|" + Eval("descripcion") + "|" + Eval("precio")  + "|" +   Eval("seccion")  %>'
           ImageUrl="~/comun/resources/img/Data-Edit-128.png"
           ControlStyle-Width="30px" ControlStyle-Height="30px"
           runat="server"  />
           </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField>
         <ItemTemplate>
            <asp:ImageButton id="_eliminarBoton"
           Text="Sort Ascending"
           CommandName="Eliminar"
           CommandArgument='<%#  Eval("Codigo")  %>'
           ImageUrl="~/comun/resources/img/Garbage-Closed-128.png"
           ControlStyle-Width="30px" ControlStyle-Height="30px" OnClientClick="VerificarOperacionGestion('middle_place_holder_campoOculto');"
           runat="server"  />
           </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate> No existen registros.</EmptyDataTemplate>
    <PagerSettings FirstPageImageUrl="&lt;&lt;" FirstPageText="1" LastPageImageUrl="&gt;&gt;" LastPageText="n" NextPageImageUrl="&gt;" />
</asp:GridView>
 <asp:HiddenField  runat="server" ID="campoOculto"  Value="0"/>
</div>
<br /> </asp:Content>
