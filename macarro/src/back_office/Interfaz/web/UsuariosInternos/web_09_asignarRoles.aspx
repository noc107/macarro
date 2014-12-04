<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_09_asignarRoles.aspx.cs" Inherits="back_office.Interfaz.web.UsuariosInternos.web_09_asignarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Usuarios Internos
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

    <h2>Asignar Roles</h2>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:label ID="LabeLstIzq" runat="server" CssClass="labels"> Roles Asignadas: (*) </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:listbox ID="lstIzquierda" runat="server" CssClass = "list_box list_box_propio" Width="150">
                <asp:ListItem>Rol1</asp:ListItem>
                <asp:ListItem>Rol2</asp:ListItem>
                <asp:ListItem>Rol3</asp:ListItem>
                <asp:ListItem>Rol4</asp:ListItem>
                </asp:listbox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <asp:ImageButton ID="ImageButton1" runat="server" src="../../../comun/resources/img/menos.png" CssClass ="mas_menos_info"/>
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:label ID="LabeL1" runat="server" CssClass="labels"> Roles disponibles: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:listbox ID="Listbox1" runat="server" CssClass = "list_box list_box_propio" Width="150">
                <asp:ListItem>Rol1</asp:ListItem>
                <asp:ListItem>Rol2</asp:ListItem>
                <asp:ListItem>Rol3</asp:ListItem>
                <asp:ListItem>Rol4</asp:ListItem>
                </asp:listbox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <asp:ImageButton ID="ImageButton2" runat="server" src="../../../comun/resources/img/agregar.png" CssClass ="mas_menos_info"/>
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell  HorizontalAlign="Center">
               <br />
               <br />
                <asp:Button ID="bAceptar" Class="Boton" runat="server" Text="Aceptar" />
            </asp:TableCell>
            <asp:TableCell Width="50"></asp:TableCell>
            <asp:TableCell Width="50"></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <br />
                <br />
                <asp:Button ID="bRegresar" Class="Boton" runat="server" Text="Cancelar"   CausesValidation="false"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
