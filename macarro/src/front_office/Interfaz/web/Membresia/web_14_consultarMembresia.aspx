<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_14_consultarMembresia.aspx.cs" Inherits="front_office.Interfaz.web.Membresia.web_14_consultarMembresia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/Membresia/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato , Daniel
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresía
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
    <h2>Consultar Membresía</h2>

    <asp:Table ID="TableBusqueda" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell Height="50"><asp:Label ID="lnumcarnet" runat="server" CssClass="labels" Text="N° Carnet"></asp:Label></asp:TableCell>
            <asp:TableCell  Height="50"><asp:TextBox ID="tbbuscar" MaxLength="5" runat="server"  CssClass="textbox" Height="25px" Width="100px"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell  Height="50"><asp:Button ID="BotonBuscar" runat="server" CssClass="Boton BotonMargin" Text="Buscar"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:Table ID="tabla" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres " ID="Label3" runat="server" Text="Label">Status:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres " ID="Label4" runat="server" Text="Label">Activa</asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="Label8" runat="server" Text="Label">Fecha Admisión:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres" ID="Label9" runat="server" Text="Label">12-11-2014</asp:Label>
                    <br/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="Label11" runat="server" Text="Label">Fecha Vencimiento:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres" ID="Label12" runat="server" Text="Label">12-11-2015</asp:Label>
                    <br/>
            </asp:TableCell>
        </asp:TableRow>
         
        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres " ID="lnombre" runat="server" Text="Label">Nombre:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres " ID="Label1" runat="server" Text="Label">Pedro Pérez</asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="lcedula" runat="server" Text="Label">Cédula:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres" ID="Label5" runat="server" Text="Label">20156234</asp:Label>
                    <br/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="lfechanacimiento" runat="server" Text="Label">Fecha Nacimiento:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres" ID="Label2" runat="server" Text="Label">12-12-1990</asp:Label>
                    <br/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="ltelefono" runat="server" Text="Label">Teléfono:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres" ID="Label10" runat="server" Text="Label">04261058784</asp:Label>
                    <br/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="Label6" runat="server" Text="Label">Dirección:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label CssClass="labels labelsNombres" ID="Label7" runat="server" Text="Label">
                        Avenida las Acacias con calle Circunvalación. 1010. Caracas. Distrito Capital
                 </asp:Label>
                    <br/>
            </asp:TableCell>
        </asp:TableRow>  
    </asp:Table>                   
   
    <br />
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell  Height="50"><asp:Button ID="Button1" runat="server" CssClass="Boton BotonMargin" Text="Aceptar"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table> 
</asp:Content>
