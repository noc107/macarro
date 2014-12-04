﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_09_consultarUsuario.aspx.cs" Inherits="back_office.Interfaz.web.UsuariosInternos.web_09_consultarUsuario" %>
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
    <h2>Consultar Usuario</h2> 
    <br />
    <br />

    <asp:Table runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="Label1Nombre" runat="server" CssClass="labels">   Nombre : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="Label1NombreCons" runat="server" > Nombre</asp:label>
            </asp:TableCell>

        <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelSegNombre" runat="server" CssClass="labels">  Segundo Nombre: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelSegNombreCons" runat="server" > Segundo Nombre</asp:label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelApellido" runat="server" CssClass="labels">   Apellido : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelApellidoCons" runat="server" > Apellido</asp:label>
            </asp:TableCell>
        
        <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelSegApellido" runat="server" CssClass="labels">  Segundo Apellido: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelSegApellidoCons" runat="server" > Segundo Apellido</asp:label>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow Height="50">
            <asp:TableCell >
                <asp:label ID="LabelCedula" runat="server" CssClass="labels">   Cédula : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelCedulaCons" runat="server" > 20.121.121</asp:label>
            </asp:TableCell>
        
        <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelCorreo" runat="server" CssClass="labels">  E-mail: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelCorreoCons" runat="server" > prueba@hotmail.com</asp:label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelFechaNac" runat="server" CssClass="labels">   Fecha de Nacimiento : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelFechaNacCons" runat="server" > 01/01/2014</asp:label>
            </asp:TableCell>
      
            <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelEstatus" runat="server" CssClass="labels">  Estatus: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelEstatusCons" runat="server" > Activo</asp:label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelFechaIng" runat="server" CssClass="labels">   Fecha de Ingreso : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelFechaIngCons" runat="server" > 01/01/2014</asp:label>
            </asp:TableCell>
        
        <asp:TableCell Width="100"></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelFechaEgre" runat="server" CssClass="labels">   Fecha de Egreso : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelFechaEgreCons" runat="server" > 01/01/2014</asp:label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="Label1" runat="server" CssClass="labels">   Dirección: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="Label2" runat="server"> dirección </asp:label>
            </asp:TableCell>

            <asp:TableCell Width="100"></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelCargos" runat="server" CssClass="labels">   Cargos : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="list_cargos" runat="server" CssClass="list_box">
                    <asp:ListItem>Rol 1</asp:ListItem>
                    <asp:ListItem>Rol 2</asp:ListItem>
                </asp:ListBox>

            </asp:TableCell>
        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan ="5" HorizontalAlign="Center">
                 <br />
                 <br />
                <asp:Button ID="ButtonAceptar" Class="Boton" runat="server" Text="Volver" OnClick="volver_consultar" />
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
   
</asp:Content>