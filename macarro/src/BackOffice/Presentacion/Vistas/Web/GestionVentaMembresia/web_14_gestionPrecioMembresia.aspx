<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" CodeBehind="web_14_gestionPrecioMembresia.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia.web_14_gestionPrecioMembresia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMembresia/buscarMembresia.css" rel="stylesheet" />
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

    <h2>Control de Precio de Membresia</h2>

    <div style="margin: 0 auto;">
        <div>
            <asp:Label ID="MensajeExito" runat="server" Text="Costo Modificado" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
        </div>
    </div>
    <div class="centrado">
        <asp:Label CssClass="labels" ID="Label4" runat="server" Text="Monto de la Membresia actual"></asp:Label>
        <br />
        <br />
    </div>
    <div class="centrado">
        <asp:TextBox CssClass="textbox" ID="Costo" runat="server" MaxLength="8" Width="104px"></asp:TextBox>
    </div>
    <asp:RangeValidator ID="rvclass"
        runat="server"
        ControlToValidate="Costo"
        Text="*"
        ErrorMessage="Costo no permitido"
        ForeColor="Red"
        MaximumValue="9999999999"
        MinimumValue="0"
        Type="Double">
    </asp:RangeValidator>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ControlToValidate="Costo"
        Text="*"
        ErrorMessage="Monto de la membresia vacio"
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <div>
        <asp:Table ID="tabla1" HorizontalAlign="Center" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary2"
                        runat="server"
                        DisplayMode="BulletList"
                        EnableClientScript="true"
                        ShowSumary="True"
                        HeaderText="" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </div>
    <div class="marginBotonCentrar">
        <asp:Button CssClass="Boton" ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"></asp:Button>
    </div>

</asp:Content>
