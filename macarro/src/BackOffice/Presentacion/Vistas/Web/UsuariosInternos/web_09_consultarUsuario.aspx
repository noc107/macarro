<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_09_consultarUsuario.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.UsuariosInternos.web_09_consultarUsuario" %>

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

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
                <asp:Label ID="_mensajeExito" runat="server" CssClass="avisoMensaje MensajeExito" Visible="false">  Mensaje de Confirmacion </asp:Label>
                <asp:Label ID="_mensajeError" runat="server" CssClass="avisoMensaje MensajeError" Visible="false">  Mensaje de Confirmacion </asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    
    

    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label ID="LabelNombre" runat="server" CssClass="labels">   Nombre : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelNombreCons" runat="server"> </asp:Label>
            </asp:TableCell>

            <asp:TableCell></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelSegNombre" runat="server" CssClass="labels">  Segundo Nombre: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelSegNombreCons" runat="server">#### </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label ID="LabelApellido" runat="server" CssClass="labels">   Apellido : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelApellidoCons" runat="server"> </asp:Label>
            </asp:TableCell>

            <asp:TableCell></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelSegApellido" runat="server" CssClass="labels">  Segundo Apellido: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelSegApellidoCons" runat="server">#### </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow Height="50">

            <asp:TableCell>
                <asp:Label ID="LabelCedulaTipo" runat="server" CssClass="labels">   Tipo de Documento </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelCedulaTipoCons" runat="server"></asp:Label>
            </asp:TableCell>

            <asp:TableCell></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelCedula" runat="server" CssClass="labels">  Identificación: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelCedulaCons" runat="server">####</asp:Label>
            </asp:TableCell>


        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label ID="LabelFechaNac" runat="server" CssClass="labels">   Fecha de Nacimiento : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelFechaNacCons" runat="server"> </asp:Label>
            </asp:TableCell>

            <asp:TableCell></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelEstatus" runat="server" CssClass="labels">  Estatus: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelEstatusCons" runat="server">#### </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label ID="LabelTelefono" runat="server" CssClass="labels">   Telefono : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelTelefonoCons" runat="server"> </asp:Label>
            </asp:TableCell>

            <asp:TableCell></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelCorreo" runat="server" CssClass="labels">  Correo: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelCorreoCons" runat="server"> ####</asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label ID="LabelFechaIng" runat="server" CssClass="labels">   Fecha de Ingreso : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelFechaIngCons" runat="server"></asp:Label>
            </asp:TableCell>

            <asp:TableCell Width="100"></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelFechaEgre" runat="server" CssClass="labels">   Fecha de Egreso : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelFechaEgreCons" runat="server">#### </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label ID="LabelDireccion" runat="server" CssClass="labels">   Dirección: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelDireccionCons" runat="server" Width="120">  </asp:Label>
            </asp:TableCell>

            <asp:TableCell Width="100"></asp:TableCell>

            <asp:TableCell>
                <asp:Label ID="LabelCargos" runat="server" CssClass="labels">   Cargos : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="list_cargos" runat="server" CssClass="list_box"></asp:ListBox>

            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5" HorizontalAlign="Center">
                <br />
                <br />
                <asp:Button ID="ButtonAceptar" Class="Boton" runat="server" Text="Volver" OnClick="volver_consultar" />
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

</asp:Content>
