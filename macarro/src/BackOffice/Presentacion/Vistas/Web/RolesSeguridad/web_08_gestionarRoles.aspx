<%@ Page Title="Gestionar Roles" Language="C#"  MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_08_gestionarRoles.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.RolesSeguridad.web_08_gestionarRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Roles y Acciones
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/standards.css" rel="stylesheet" />
    <link href="../../../comun/resources/css/RolesSeguridad/Estilos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Gestionar Roles</h2>

    <asp:Label ID="MensajeExitoso" runat="server"  Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="MensajeErrores" runat="server"  Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">

                <asp:GridView ID="GVRol" CssClass="mGrid" AllowPaging="True" HorizontalAlign="Center" runat="server" BorderStyle="None"
                    AllowSorting="true" GridLines="None" AutoGenerateColumns="False" Width="700px" ForeColor="#99CCFF" PageSize="8"
                     OnRowDataBound="GVRol_RowDataBound" OnPageIndexChanging="GVRol_PageIndexChanging">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:BoundField HeaderText="Rol" DataField="Rol" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField HeaderText="Descripción" DataField="Descripción"  ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField HeaderText="Ver Editar Eliminar" DataField="Ver Editar Eliminar"  ItemStyle-Width="190px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
 
                        <%--<asp:BoundField HeaderText="ID" DataField="ROL_id" Visible="false"></asp:BoundField>
                        <asp:BoundField HeaderText="Rol" DataField="ROL_nombre" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField HeaderText="Descripción" DataField="ROL_descripcion" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:TemplateField HeaderText="Ver Editar Eliminar" ItemStyle-Width="190px">
                            <ItemTemplate>
                                <asp:ImageButton ID="consultar" ImageUrl="../../../comun/resources/img/View-128.png" CssClass="actions_icons" runat="server" OnClick="consultarBtn_Click"/>
                                <asp:ImageButton ID="editar" ImageUrl="../../../comun/resources/img/Data-Edit-128.png" CssClass="actions_icons" runat="server" OnClick="editarBtn_Click"/>
                                <asp:ImageButton ID="eliminar" ImageUrl="../../../comun/resources/img/Garbage-Closed-128.png" CssClass="actions_icons" runat="server" OnClientClick="return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')" OnClick="eliminarBtn_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <PagerStyle CssClass="pgr" />
                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                </asp:GridView>
                <%--<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\tecssil\Downloads\macarro\src\MACARRO.mdf;Integrated Security=True;Connect Timeout=30" SelectCommand="Procedure_ConsultarRolGeneral" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

