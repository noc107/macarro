<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" CodeBehind="web_14_modificarMembresia.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia.web_14_modificarMembresia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMembresia/modificarMembresia.css" rel="stylesheet" />
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
    
<h2>Modificar Membresia</h2>
    <div>
        <asp:Label ID="MensajeExito" runat="server" Text="Membresia Modificada" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    </div>
    <div style="margin:0 auto;">
        
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="lbCodigo"  runat="server" Text="ID de Membresía:"   ></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="textbox" ID="ID" runat="server" Text="####"   ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>

                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbStatus"  runat="server" Text="Estado: " ></asp:Label>
                </asp:TableCell>

                <asp:TableCell Height="50">
                    <asp:DropDownList  CssClass="combo_box" ID="Estado" runat="server" >
                        <asp:ListItem Text="Activado"></asp:ListItem>
                        <asp:ListItem Text="Desactivado"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="Estado"
                        Text="*"
                        ErrorMessage="Estado requerido."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label CssClass="labels" ID="lbDescuento" runat="server" Text="Aplicar Descuento (*):" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="Descuento" runat="server" MaxLength="5"></asp:TextBox>

                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="Descuento"
                        Text="*"
                        ErrorMessage="Aplicar Descuento."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                
                    <asp:RangeValidator ID="rvclass"
                        runat="server"
                        ControlToValidate="Descuento"
                        Text="*"
                        ErrorMessage="Descuento de (0-100)"
                        ForeColor="Red"
                        MaximumValue="100"
                        MinimumValue="0"
                        Type="Double">
                    </asp:RangeValidator>

                </asp:TableCell>
            </asp:TableRow>    
                            
        <div>
            <asp:Table ID="tabla1" HorizontalAlign="Center" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                            runat="server"
                            DisplayMode="BulletList"
                            EnableClientScript="true"
                            ShowSumary="True"
                            HeaderText="" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

        </div>
       
         <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" style="margin-top: 0px" Width="395px">
            <asp:TableRow>
                <asp:TableCell CssClass="centrado" Height="50">
                     <asp:Button  CssClass="Boton"  ID="btnCancelar" runat="server" Text="Cancelar"></asp:Button>
                </asp:TableCell>
                <asp:TableCell  CssClass="centrado">
                </asp:TableCell>
                <asp:TableCell  CssClass="centrado">
                     <asp:Button  CssClass="Boton"  ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnGuardar_Click"  ></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <br />
    </div>
   
    
</asp:Content>
