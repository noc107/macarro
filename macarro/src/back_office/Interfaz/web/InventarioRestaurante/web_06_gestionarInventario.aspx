<%@ Page Title="Gestionar Inventario" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_06_gestionarInventario.aspx.cs" Inherits="back_office.Interfaz.web.InventarioRestaurante.web_06_gestionarInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Gestion de Inventario
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/InventarioRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Gestionar Inventario</h2>
    <div ID="Mensajes" class="BloqueMensaje">
    <asp:Label ID="MensajeFallo" CssClass="LabelMensajeFallo" runat="server" Text="El item no ha podido ser eliminado debido a que X" Visible="false"></asp:Label>
    </div>
    <br /><br />
<asp:GridView ID="Inventario"  CssClass="mGrid" AllowPaging="true" HorizontalAlign="Center" runat="server" onrowcommand="userGridview_RowCommand"
                         BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"
                                              ForeColor="#99CCFF" PageSize="5" OnRowDataBound="Inventario_RowDataBound" OnSelectedIndexChanged="Inventario_SelectedIndexChanged" OnPageIndexChanging="Inventario_PageIndexChanged">
            <AlternatingRowStyle CssClass="alt" />  
            <Columns>    
                
                <asp:BoundField DataField="Codigo" HeaderText="Código">  
                <ItemStyle Width="80px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Nombre" HeaderText="Nombre" >       
                <ItemStyle Width="270px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" >       
                <ItemStyle Width="80px" HorizontalAlign="Center" />
                </asp:BoundField>

               
                <asp:BoundField HeaderText="Acciones" DataField="Acciones" >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />  
        </asp:GridView>
</asp:Content>
