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
           <asp:TableCell ColumnSpan="6" HorizontalAlign="Center" >
               <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensaje MensajeExito" Visible="false">  Mensaje de Confirmacion </asp:label>
               <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensaje MensajeError" Visible="false">  Mensaje de Confirmacion </asp:label>
               <br />
           </asp:TableCell>
       </asp:TableRow>
        </asp:Table>

    <asp:Table runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelNombre" runat="server" CssClass="labels">   Nombre : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelNombreCons" runat="server" > </asp:label>
            </asp:TableCell>

        <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelSegNombre" runat="server" CssClass="labels">  Segundo Nombre: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelSegNombreCons" runat="server" > </asp:label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelApellido" runat="server" CssClass="labels">   Apellido : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelApellidoCons" runat="server" > </asp:label>
            </asp:TableCell>
        
        <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelSegApellido" runat="server" CssClass="labels">  Segundo Apellido: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelSegApellidoCons" runat="server" > </asp:label>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow Height="50">
            
            <asp:TableCell >
                <asp:label ID="LabelCedulaTipo" runat="server" CssClass="labels">   Tipo de Documento </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelCedulaTipoCons" runat="server" ></asp:label>
            </asp:TableCell>
            
            <asp:TableCell></asp:TableCell>
            
            <asp:TableCell >
                <asp:label ID="LabelCedula" runat="server" CssClass="labels">  Identificación: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelCedulaCons" runat="server" ></asp:label>
            </asp:TableCell>
        
            
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelFechaNac" runat="server" CssClass="labels">   Fecha de Nacimiento : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelFechaNacCons" runat="server" > </asp:label>
            </asp:TableCell>
      
            <asp:TableCell></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelEstatus" runat="server" CssClass="labels">  Estatus: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelEstatusCons" runat="server" > </asp:label>
            </asp:TableCell>
        </asp:TableRow>
       
         <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelTelefono" runat="server" CssClass="labels">  Teléfono: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelTelefonoCons" runat="server" > </asp:label>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelCorreo" runat="server" CssClass="labels">  E-mail: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelCorreoCons" runat="server" > </asp:label>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelFechaIng" runat="server" CssClass="labels">   Fecha de Ingreso : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelFechaIngCons" runat="server" ></asp:label>
            </asp:TableCell>
        
        <asp:TableCell Width="100"></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelFechaEgre" runat="server" CssClass="labels">   Fecha de Egreso : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelFechaEgreCons" runat="server" > </asp:label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:label ID="LabelDireccion" runat="server" CssClass="labels" >   Dirección: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:label  ID="LabelDireccionCons" runat="server" Width="120">  </asp:label>
            </asp:TableCell>

            <asp:TableCell Width="100"></asp:TableCell>

            <asp:TableCell >
                <asp:label ID="LabelCargos" runat="server" CssClass="labels">   Cargos : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="list_cargos" runat="server" CssClass="list_box" >

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
