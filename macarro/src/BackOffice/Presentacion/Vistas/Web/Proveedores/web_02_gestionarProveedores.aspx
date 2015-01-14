<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" ValidateRequest="false"  EnableEventValidation="false" CodeBehind="web_02_gestionarProveedores.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_gestionarProveedores" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/gestionarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Gestionar Proveedores</h2>
    <asp:Label CssClass="avisomensaje" ID="Label13" runat="server"  Visible="False"></asp:Label>
    <div class="divPrincipal">
        <asp:TextBox ID="textboxBuscar" CssClass="textbox tbBuscar" runat="server" MaxLength="98" placeholder="Buscar..." />
        <asp:Label ID="labelEstado" runat="server" CssClass="labels labelEstado" Text="Estado:"></asp:Label>
        <asp:DropDownList ID="comboEstado" CssClass="combo_box_estatus comboBuscar" runat="server">
            <asp:ListItem Text="Activado" Value="Activado" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Desactivado" Value="Desactivado"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="botonBuscar" runat="server" Text="Buscar" CssClass="Boton botonBuscar" />

        <asp:GridView CssClass="mGrid gridProveedores" ID="GVProveedores" AllowPaging="true" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" BorderStyle="None" 
             AllowSorting="True" GridLines="None" OnRowDataBound="GVProveedores_RowDataBound" OnRowCommand="gvProveedores_RowCommand" ForeColor="#99CCFF"
             OnPageIndexChanging="GVProveedores_PageIndexChanging" PageSize="5" DataKeyNames="Id" >
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField HeaderText="Id" Visible="false" DataField="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField HeaderText="Rif" DataField="Rif" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"  ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField HeaderText="Estado" DataField="Estado" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField HeaderText="Acciones" DataField="Acciones"  ItemStyle-Width="190px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
             </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
        </asp:GridView>
       <asp:Button CssClass="Boton botonRegresar" ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />

    </div>
</asp:Content>


