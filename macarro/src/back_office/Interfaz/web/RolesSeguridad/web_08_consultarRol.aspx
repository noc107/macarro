﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_08_consultarRol.aspx.cs" Inherits="back_office.Interfaz.web.RolesSeguridad.web_08_consultarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Roles y Acciones
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/RolesSeguridad/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Detalle de Rol</h2>


     <asp:Table ID="Table0" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">             
                <asp:Label CssClass="avisoMensaje" ID="LabelMensaje" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:Label CssClass="avisoMensaje" ID="Label6" runat="server" Text="Label"></asp:Label>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" Style="padding-bottom:20px">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="labels labels_Consulta"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <br />
                <asp:Label ID="Label4" runat="server" CssClass="labels" Text="Administrador"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <br />
                <asp:Label ID="Label2" runat="server" Text="Descripcion:" CssClass="labels labels_Consulta"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <br />
                <asp:Label ID="Label5" runat="server" CssClass="labels" Text="Esta encargado de la administracion interna"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <br />
                <asp:Label ID="Label3" runat="server" Text="Acciones Asignadas:" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <br />
                <asp:ListBox ID="ListBox2" runat="server" CssClass = "list_box_propio list_box" ReadOnly="true">
                    <asp:ListItem>Accion1</asp:ListItem>
                    <asp:ListItem>Accion2</asp:ListItem>
                    <asp:ListItem>Accion3</asp:ListItem>
                    <asp:ListItem>Accion4</asp:ListItem>
                    <asp:ListItem>Accion5</asp:ListItem>
                </asp:ListBox>
            </asp:TableCell>                     
        </asp:TableRow>
     </asp:Table>

     <asp:Table  ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <br />
                <asp:Button ID="Button1" runat="server" Text="Volver" CssClass="Boton" OnClick="Button1_Click"/>
            </asp:TableCell>               
       </asp:TableRow>
     </asp:Table>
    </asp:Content>