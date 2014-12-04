<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_02_gestionarProveedores.aspx.cs" Inherits="back_office.Interfaz.web.Proveedores.web_02_gestionarProveedores" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/gestionarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Gestionar Proveedores</h2>
    <asp:Label CssClass="avisomensaje" ID="Label13" runat="server"  Visible="False"></asp:Label>
    <div class="divPrincipal">
        <asp:GridView class="grid_view tabla" ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="RIF">
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Razón Social">
                <ItemStyle Width="300px" />
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
            </Columns>
        </asp:GridView>
    </div>
    <div class="divBoton">
        <asp:Button CssClass="Boton" ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />
    </div>
</asp:Content>


