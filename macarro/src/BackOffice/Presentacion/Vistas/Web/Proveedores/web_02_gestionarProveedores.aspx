<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" ValidateRequest="false"  EnableEventValidation="false" CodeBehind="web_02_gestionarProveedores.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_gestionarProveedores" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/gestionarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Gestionar Proveedores</h2>
    <asp:Label CssClass="avisomensaje" ID="Label13" runat="server"  Visible="False"></asp:Label>
    <div class="divPrincipal">
        <asp:GridView CssClass="grid_view tabla mGrid" ID="GridView1" AllowPaging="true" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" BorderStyle="None" 
             AllowSorting="True" GridLines="None" ForeColor="#99CCFF" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField HeaderText="RIF" DataField="PRO_rif">
                </asp:BoundField>
                <asp:BoundField HeaderText="Razón Social" DataField="PRO_razonSocial">
                </asp:BoundField>
                <asp:ButtonField Text="Ver" CommandName="Consultar" ButtonType="Image" ImageUrl="~/comun/resources/img/View-128.png">
                <ControlStyle Height="50px" Width="50px" />
                <ItemStyle Width="100px" />
                </asp:ButtonField>
                <asp:ButtonField Text="Editar" CommandName="Modificar" ButtonType="Image" ImageUrl="~/comun/resources/img/Data-Edit-128.png">
                <ControlStyle Height="50px" Width="50px" />
                <ItemStyle Width="100px" />
                </asp:ButtonField>
                <asp:ButtonField Text="Eliminar" CommandName="Eliminar" ButtonType="Image" ImageUrl="~/comun/resources/img/Garbage-Closed-128.png">
                <ControlStyle Height="50px" Width="50px" />
                <ItemStyle Width="100px" />
                </asp:ButtonField>
                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID ="eliminar" runat="server" ButtonType="Image" ImageUrl="~/comun/resources/img/Garbage-Closed-128.png" Height="50" Width="50"  CommandName="Eliminar"/>
                    <%--    <a href="../Proveedores/web_02_modificarProveedor.aspx"> <asp:Image ID="Image1" ImageUrl="~/comun/resources/img/Garbage-Closed-128.png" runat="server" Height="50" Width="50" /> </a>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
        </asp:GridView>
    </div>
    <div class="divBoton">
        <asp:Button CssClass="Boton" ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />
    </div>
</asp:Content>


