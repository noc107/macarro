<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_14_modificarMembresia.aspx.cs" Inherits="front_office.Interfaz.web.Membresia.web_14_modificarMembresia" %>

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
<h2 class="centrado subtitulo">Modificar Membresía</h2>
    <div>
        <asp:Label CssClass="avisoMensaje MensajeExito" ID="lmensaje" runat="server" Text="Membresía modificada con éxito"></asp:Label>
    </div>
    <br />
         <div class="formulario">
            <div class="formulario-izq">
                <div class="formulario-labels-textbox">
                    <asp:Label CssClass="labels labelsNombres" ID="lcarnet" runat="server" Text="Label"># Carnet:</asp:Label>
                    <asp:Label CssClass="labels labelsNombres inputTextbox" ID="lncarnet" runat="server" Text="Label">156312</asp:Label>
                    <br/>

                    <asp:Label CssClass="labels labelsNombres" ID="lnombre" runat="server" Text="Label">Nombre (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbnombre" runat="server" MaxLength="50" ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vnombre" 
                        runat="server" ControlToValidate ="tbnombre"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar un nombre">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="vtnombre" runat="server" 
                        ControlToValidate="tbnombre" 
                        Text="*"
                        ErrorMessage="Nombre no permitido" 
                        ForeColor="Red" 
                        ValidationExpression="^[a-zA-Z áéíóúÁÉÍÓÚ]*$">
                    </asp:RegularExpressionValidator>
                    <br/>

                    <asp:Label CssClass="labels labelsNombres" ID="lfechanacimiento" runat="server" Text="Label">Fecha Nacimiento (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbfechanacimiento" runat="server" TextMode="Date"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vfechanacimiento" 
                        runat="server" ControlToValidate ="tbfechanacimiento"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar la fecha de nacimiento">
                    </asp:RequiredFieldValidator>
                    <br/>

                    <asp:Label CssClass="labels labelsNombres" ID="ltelefono" runat="server" Text="Label">Teléfono (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbtelefono" runat="server" MaxLength="11"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vtelefono" 
                        runat="server" ControlToValidate ="tbtelefono"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar un teléfono">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="tbtelefono" 
                        Text="*"
                        ErrorMessage="Ingrese teléfono sin espacios ni guiones" 
                        ForeColor="Red" 
                        ValidationExpression="[0-9]*">
                    </asp:RegularExpressionValidator>
                    <br/>

                    <asp:Label CssClass="labels labelsNombres" ID="lciudad" runat="server" Text="Label">Ciudad (*):</asp:Label>
                    <asp:dropdownlist ID="ddlciudad" CssClass="comboEstilo combo_box marginDropdownlist cambioCategoria inputTextbox" runat="server">
                        <asp:ListItem Value="Seleccione">Seleccione una ciudad...</asp:ListItem>
                        <asp:ListItem Value="ciudad1">Ciudad1</asp:ListItem>
                    </asp:dropdownlist>

                    <asp:RequiredFieldValidator ID="vciudad" 
                        runat="server" ControlToValidate ="ddlciudad"
                        Text="*"
                        ForeColor="Red"
                        InitialValue="Seleccione"
                        ErrorMessage="Debe ingresar una ciudad">
                    </asp:RequiredFieldValidator>

                    <asp:Label CssClass="labels labelsNombres labelDescripcion" ID="ldireccion" runat="server" Text="Label">Dirección (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox inputTextarea" ID="tbdireccion" runat="server" MaxLength="99" TextMode="multiline"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vdireccion" 
                        runat="server" ControlToValidate ="tbdireccion"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar una dirección">
                    </asp:RequiredFieldValidator>
                    <br/>                                      
                </div>   
            </div>
            
            <div class="formualrio-der">
                <div class="formulario-labels-textbox">
                    <br/>
                    <asp:Label CssClass="labels labelsNombres" ID="lapellido" runat="server" Text="Label">Apellido (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbapellido" runat="server" MaxLength="50" ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vapellido" 
                        runat="server" ControlToValidate ="tbapellido"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar un apellido">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="tbapellido" 
                        Text="*"
                        ErrorMessage="Apellido no permitido" 
                        ForeColor="Red" 
                        ValidationExpression="^[a-zA-Z áéíóúÁÉÍÓÚ]*$">
                    </asp:RegularExpressionValidator>
                    <br/><br/><br/><br/>

                    <asp:Label CssClass="labels labelsNombres" ID="lestado" runat="server" Text="Label">Estado (*):</asp:Label>
                    <asp:dropdownlist ID="ddlestado" CssClass="comboEstilo combo_box marginDropdownlist cambioCategoria inputTextbox" runat="server">
                        <asp:ListItem Value="Seleccione">Seleccione un estado...</asp:ListItem>
                        <asp:ListItem Value="estado1">Estado1</asp:ListItem>
                    </asp:dropdownlist>

                    <asp:RequiredFieldValidator ID="vestado" 
                        runat="server" ControlToValidate ="ddlestado"
                        Text="*"
                        ForeColor="Red"
                        InitialValue="Seleccione"
                        ErrorMessage="Debe seleccionar un estado">
                    </asp:RequiredFieldValidator>
                    <br/> 

                    <asp:Label CssClass="labels labelsNombres" ID="lcodigopostal" runat="server" Text="Label">Codigo Postal: (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbcodigopostal" runat="server" MaxLength="5" ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vcodigopostal" 
                        runat="server" ControlToValidate ="tbcodigopostal"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar su código postal">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                        ControlToValidate="tbcodigopostal" 
                        Text="*"
                        ErrorMessage="Código postal no permitido" 
                        ForeColor="Red" 
                        ValidationExpression="[0-9]*">
                    </asp:RegularExpressionValidator>
                    <br/>                           
                </div>       
            </div>
        </div>
        
        <div class="botonesFormulario2">          
            <asp:button ID="AceptarBoton" CssClass="Boton botonAceptar" text="Aceptar" runat="server"/>            
            <asp:button CssClass="botonCancelar Boton" ID="CancelarBoton" text="Cancelar" runat="server"/>
        </div>

        <div>
            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ValidationSummary ID="ValidationSummary1"
                            runat="server"
                            DisplayMode="BulletList"
                            EnableClientScript="true"
                            ForeColor="Red"
                            HeaderText="" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table> 
        </div>
</asp:Content>