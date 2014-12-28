<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_14_consultarMembresia.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_14_consultarMembresia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/Membresia/estilo.css" rel="stylesheet" />
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
    <div>
     
        <asp:Label ID="lexito" runat="server" Text="Membresia agregada" Visible="false" CssClass="aMensaje aMensajeExito "></asp:Label>
    </div>

    <asp:Table ID="TableBusqueda" runat="server" HorizontalAlign="Center" Width="16px"> 
       
  <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres " ID="lcarnet2" runat="server" Text="Label">N. carnet:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres " ID="lcarnet" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres " ID="Label3" runat="server" Text="Label">Status:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres " ID="lstatus" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="Label8" runat="server" Text="Label">Fecha Admisión:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres" ID="lfAdm" runat="server" Text=""></asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="Label11" runat="server" Text="Label">Fecha Vencimiento:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres" ID="lfVen" runat="server" Text=""></asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="Label1" runat="server" Text="Label">Descuento:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres" ID="ldescuento" runat="server" Text=""></asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres " ID="lxx" runat="server" Text="Label">Nombre:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres " ID="lnombre" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="lcedulag" runat="server" Text="Label">Cédula:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres" ID="lcedula" runat="server" Text=""></asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="lfechanacimiento2" runat="server" Text="Label">Fecha Nacimiento:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres" ID="lfechanacimiento" runat="server" Text=""></asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Height="50">
                <asp:Label CssClass="labels labelsNombres" ID="ltelefono3" runat="server" Text="Label">Teléfono:</asp:Label>
            </asp:TableCell><asp:TableCell>&nbsp</asp:TableCell>
            <asp:TableCell>
                <asp:Label CssClass="labels labelsNombres" ID="ltelefono" runat="server" Text=""></asp:Label>
                <br />
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>                   
 
    <br />
    <div class="centrado">
                <asp:Button ID="Button1" runat="server" CssClass="Boton BotonMargin" Text="Aceptar" Height="39px" Width="109px"/>
     </div>    
    <br />
</asp:Content>
