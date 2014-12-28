 <%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_14_agregarMembresia.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_14_agregarMembresia" %>

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
 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresía
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

    
    <div>
        <h2>Agregar Membresía</h2>
        <asp:Label ID="lexito" runat="server" Text="Membresia agregada" Visible="false" CssClass="aMensaje aMensajeExito "></asp:Label>
    </div>
        
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <div class="formulario">
                    <div class="formulario-izq">
                        <div class="formulario-labels-textbox">

                            <asp:Label CssClass="labels labelsNombres" ID="lfoto" runat="server" Text="Label">Seleccione foto (*):</asp:Label>
                            <asp:FileUpload ID="FileUpload" runat="server" />

                            <asp:Label CssClass="labels labelsNombres" ID="ltipotarjeta" runat="server" Text="Label">Tipo de Tarjeta (*):</asp:Label>
                            <asp:DropDownList ID="ddltipotarjeta" CssClass="comboEstilo combo_box marginDropdownlist cambioCategoria inputTextbox" runat="server">
                                <asp:ListItem Value="Seleccione">Seleccione tipo de tarjeta...</asp:ListItem>
                                <asp:ListItem Value="MESA">Visa</asp:ListItem>
                                <asp:ListItem Value="MESA">Mastercard</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="vtipotarjeta"
                                runat="server" ControlToValidate="ddltipotarjeta"
                                Text="*"
                                ForeColor="Red"
                                InitialValue="Seleccione"
                                ErrorMessage="Debe seleccionar el tipo de tarjeta">
                            </asp:RequiredFieldValidator>
                            <br />

                            <asp:Label CssClass="labels labelsNombres" ID="lnombretarjetahabiente" runat="server" Text="Label">Nombre TarjetaHabiente (*):</asp:Label>
                            <asp:TextBox CssClass="textbox inputTextbox" ID="tbnombretarjetahabiente" runat="server" MaxLength="50"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="vnombretarjetahabiente"
                                runat="server" ControlToValidate="tbnombretarjetahabiente"
                                Text="*"
                                ForeColor="Red"
                                ErrorMessage="Debe ingresar nombre de tarjetahabiente">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="tbnombretarjetahabiente"
                                Text="*"
                                ErrorMessage="Nombre tarjetahabiente no permitido"
                                ForeColor="Red"
                                ValidationExpression="^[a-zA-Z áéíóúÁÉÍÓÚ]*$">
                            </asp:RegularExpressionValidator>
                            <br />

                            <asp:Label CssClass="labels labelsNombres" ID="lfechavencimiento" runat="server" Text="Label">Fecha Vencimiento (*):</asp:Label>
                            <asp:TextBox CssClass="textbox inputTextbox" ID="tbfechavencimiento" runat="server" TextMode="Date"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="vfechavencimiento"
                                runat="server" ControlToValidate="tbfechavencimiento"
                                Text="*"
                                ForeColor="Red"
                                ErrorMessage="Debe ingresar la fecha de vencimiento de la tarjeta">
                            </asp:RequiredFieldValidator>
                            <br />

                            <asp:Label CssClass="labels labelsNombres" ID="ltotal" runat="server" Text="Label">Total a pagar:</asp:Label>
                            <asp:Label CssClass="labels labelsNombres inputTextbox" ID="tbtotal" runat="server" Text="Label">1500 BsF.</asp:Label>
                            <br />

                        </div>
                    </div>

                    <div class="formualrio-der">
                        <div class="formulario-labels-textbox">

                            <asp:Label CssClass="labels labelsNombres" ID="ltelefono" runat="server" Text="Label">Teléfono (*):</asp:Label>
                            <asp:TextBox CssClass="textbox inputTextbox" ID="tbtelefono" runat="server" MaxLength="11"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="vtelefono"
                                runat="server" ControlToValidate="tbtelefono"
                                Text="*"
                                ForeColor="Red"
                                ErrorMessage="Debe ingresar un teléfono">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                ControlToValidate="tbtelefono"
                                Text="*"
                                ErrorMessage="Teléfono no permitido"
                                ForeColor="Red"
                                ValidationExpression="[0-9]*">
                            </asp:RegularExpressionValidator>

                            <asp:Label CssClass="labels labelsNombres" ID="lcedulatarjetahabiente" runat="server" Text="Label">Cédula TarjetaHabiente (*):</asp:Label>
                            <asp:TextBox CssClass="textbox inputTextbox" ID="tbcedulatarjetahabiente" MaxLength="8" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server" ControlToValidate="tbcedulatarjetahabiente"
                                Text="*"
                                ForeColor="Red"
                                ErrorMessage="Debe ingresar cédula del tarjetahabiente">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                ControlToValidate="tbcedulatarjetahabiente"
                                Text="*"
                                ErrorMessage="Cédula de tarjetahabiente no permitida"
                                ForeColor="Red"
                                ValidationExpression="[0-9]*">
                            </asp:RegularExpressionValidator>
                            <br />

                            <asp:Label CssClass="labels labelsNombres" ID="lnumerotarjeta" runat="server" Text="Label">Número de tarjeta (*):</asp:Label>
                            <asp:TextBox CssClass="textbox inputTextbox" ID="tbnumerotarjeta" MaxLength="16" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="vnumerotarjeta"
                                runat="server" ControlToValidate="tbnumerotarjeta"
                                Text="*"
                                ForeColor="Red"
                                ErrorMessage="Debe ingresar el número de tarjeta">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                ControlToValidate="tbnumerotarjeta"
                                Text="*"
                                ErrorMessage="Número de tarjeta no permitido"
                                ForeColor="Red"
                                ValidationExpression="[0-9]*">
                            </asp:RegularExpressionValidator>
                            <br />

                            <asp:Label CssClass="labels labelsNombres" ID="lcodigoseguridad" runat="server" Text="Label">Código seguridad (*):</asp:Label>
                            <asp:TextBox CssClass="textbox inputTextbox" ID="tbcodigoseguridad" MaxLength="3" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server" ControlToValidate="tbcodigoseguridad"
                                Text="*"
                                ForeColor="Red"
                                ErrorMessage="Debe ingresar el código de seguridad">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                                ControlToValidate="tbcodigoseguridad"
                                Text="*"
                                ErrorMessage="Código de seguridad no permitido"
                                ForeColor="Red"
                                ValidationExpression="[0-9]*">
                            </asp:RegularExpressionValidator>
                            <br />
                        </div>
                    </div>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table> 
    <div>
             <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                 <asp:TableRow>
                     <asp:TableCell>
                         <asp:ValidationSummary ID="ValidationSummary1" CssClass="aMensaje aMensajeError"
                             runat="server"
                             DisplayMode="BulletList"
                             EnableClientScript="true"
                            
                             HeaderText="" />
                     </asp:TableCell>
                 </asp:TableRow>
             </asp:Table> 
        </div>
    
    <div class="centrado">
        <asp:Button CssClass="Boton" ID="AceptarBoton" Text="Aceptar" runat="server" OnClick="AceptarBoton_Click" Height="39px" Width="109px"></asp:Button>
        <asp:Button CssClass="Boton" ID="CancelarBoton" Text="Cancelar" runat="server" Height="39px" Width="109px" />
    </div>
    <br />
         
</asp:Content>