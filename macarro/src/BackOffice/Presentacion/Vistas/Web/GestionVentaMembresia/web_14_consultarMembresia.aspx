<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" CodeBehind="web_14_consultarMembresia.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia.web_14_consultarMembresia" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
     <link href="../../../comun/resources/css/ModuloMembresia/consultarMembresia.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato, Daniel
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresia
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    

    <h2>Consultar Membresia</h2>

    <div>
        <asp:Label ID="MensajeExito" runat="server" Text="Membresia" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    </div>

    <div style="margin:0 auto;">

        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="Label13"  runat="server" Text="N° Carnet:"   ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="lbCarnet"  runat="server" Text="####"   ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="Label1"  runat="server" Text="Status:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbStatus"  runat="server" Text="" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="Label10" runat="server" Text="Fecha Admision:"   ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label  ID="lbFechaAdm" CssClass="labels" runat="server" Text=""   ></asp:Label>
                </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="Label12"  runat="server" Text="Fecha Vencimiento:" ></asp:Label>
                </asp:TableCell>
                 <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbFechaVen"  runat="server" Text="" ></asp:Label>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="Label2"  runat="server" Text="Cedula:"   ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label   CssClass="labels" ID="lbCedula" runat="server" Text=""   ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels"  ID="Label3" runat="server" Text="Nombre:"   ></asp:Label>
                  </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="lbNombre" runat="server" Text=""   ></asp:Label>
                </asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="Label4" runat="server" Text="Apellido:" ></asp:Label>
                 </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbApellido"  runat="server" Text="" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                   <asp:Label  CssClass="labels" ID="Label5" runat="server" Text="Fecha de Nacimiento:" ></asp:Label>
                 </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="lbFechaNac" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="Label6" runat="server" Text="Telefono:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbTelefono" runat="server" Text="" ></asp:Label>
               </asp:TableCell>
            </asp:TableRow>
           
            <asp:TableRow>
                <asp:TableCell Height="50">
                     <asp:Label  CssClass="labels" ID="Label11" runat="server" Text="Descuento Aplicado:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp&nbsp
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbDescuento" runat="server" Text="" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
    </asp:Table>

    <div class="marginBotonRegresar">

        <asp:Button  CssClass="Boton" ID="ButtonRegresar" runat="server" Text="Regresar"  />
    </div>




<br/>

</div>
</asp:Content>