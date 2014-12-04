<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_14_agregarMembresia.aspx.cs" Inherits="front_office.Interfaz.web.Membresia.web_14_agregarMembresia" %>

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
<h2 class="centrado subtitulo">Agregar Membresía</h2>
    <div>
        <asp:Label CssClass="avisoMensaje MensajeExito" ID="lmensaje" runat="server" Text="Membresía agregada con éxito"></asp:Label>
    </div>
         <div class="formulario">
            <div class="formulario-izq">
                <div class="formulario-labels-textbox">
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
                    <br />            
                
                    <asp:Label CssClass="labels labelsNombres" ID="lfechanacimiento" runat="server" Text="Label">Fecha Nacimiento (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbfechanacimiento" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>

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
                        ErrorMessage="Teléfono no permitido" 
                        ForeColor="Red" 
                        ValidationExpression="[0-9]*">
                    </asp:RegularExpressionValidator>
                    <br/>

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
    
                    <asp:Label CssClass="labels labelsNombres labelDescripcion" ID="ldireccion" runat="server" Text="Label">Dirección (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox inputTextarea" ID="tbdireccion" runat="server" TextMode="multiline"></asp:TextBox>
                    <br/>
                    

                    <asp:RequiredFieldValidator ID="vdireccion" 
                        runat="server" ControlToValidate ="tbdireccion"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar una dirección">
                    </asp:RequiredFieldValidator>
                    <br/>                     
                    
                    <asp:Label CssClass="labels labelsNombres" ID="ltipotarjeta" runat="server" Text="Label">Tipo de Tarjeta (*):</asp:Label>
                    <asp:dropdownlist ID="ddltipotarjeta" CssClass="comboEstilo combo_box marginDropdownlist cambioCategoria inputTextbox" runat="server">
                        <asp:ListItem Value="Seleccione">Seleccione tipo de tarjeta...</asp:ListItem>
                        <asp:ListItem Value="MESA">Visa</asp:ListItem>
                        <asp:ListItem Value="MESA">Mastercard</asp:ListItem>
                    </asp:dropdownlist>
                    <br />
                    <asp:RequiredFieldValidator ID="vtipotarjeta" 
                        runat="server" ControlToValidate ="ddltipotarjeta"
                        Text="*"
                        ForeColor="Red"
                        InitialValue="Seleccione"
                        ErrorMessage="Debe seleccionar el tipo de tarjeta">
                    </asp:RequiredFieldValidator>
                    <br/>
           
                    <asp:Label CssClass="labels labelsNombres" ID="lnombretarjetahabiente" runat="server" Text="Label">Nombre TarjetaHabiente (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbnombretarjetahabiente" runat="server" MaxLength="50" ></asp:TextBox>  

                    <asp:RequiredFieldValidator ID="vnombretarjetahabiente" 
                        runat="server" ControlToValidate ="tbnombretarjetahabiente"
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
                        runat="server" ControlToValidate ="tbfechavencimiento"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar la fecha de vencimiento de la tarjeta">
                     </asp:RequiredFieldValidator>
                    <br/>
                
                    <asp:Label CssClass="labels labelsNombres" ID="lcarnet" runat="server" Text="Label">Total a pagar:</asp:Label>
                    <asp:Label CssClass="labels labelsNombres inputTextbox" ID="lncarnet" runat="server" Text="Label">1500 BsF.</asp:Label>
                    <br/>                 

                </div>   
            </div>
            
            <div class="formualrio-der">
                <div class="formulario-labels-textbox">
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
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="tbapellido" 
                        Text="*"
                        ErrorMessage="Deben ser caracteres alfabéticos" 
                        ForeColor="Red" 
                        ValidationExpression="^[a-zA-Z ]*$">
                    </asp:RegularExpressionValidator> 
                    <br/>                 
                    
                    <asp:Label CssClass="labels labelsNombres" ID="lcedula" runat="server" Text="Label">Cédula (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbcedula" runat="server" MaxLength="8" ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="vcedula" 
                        runat="server" ControlToValidate ="tbcedula"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe ingresar su cédula">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                        ControlToValidate="tbcedula" 
                        Text="*"
                        ErrorMessage="Cédula no permitida" 
                        ForeColor="Red" 
                        ValidationExpression="[0-9]*">
                    </asp:RegularExpressionValidator>
                    <br/>

                    <asp:Label CssClass="labels labelsNombres" ID="lcodigopostal" runat="server" Text="Label">Codigo Postal (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbcodigopostal" MaxLength="5" runat="server" ></asp:TextBox>

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
                    <br/> 
                    
                    <br/><br/><br/><br/><br/><br/>
                    <asp:Label CssClass="labels labelsNombres" ID="lcedulatarjetahabiente" runat="server" Text="Label">Cédula TarjetaHabiente (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbcedulatarjetahabiente" MaxLength="8" runat="server" ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ControlToValidate ="tbcedulatarjetahabiente"
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
                    <br/>
                                       
                    <asp:Label CssClass="labels labelsNombres" ID="lnumerotarjeta" runat="server" Text="Label">Número de tarjeta (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbnumerotarjeta" MaxLength="16" runat="server" ></asp:TextBox> 
                    
                    <asp:RequiredFieldValidator ID="vnumerotarjeta" 
                        runat="server" ControlToValidate ="tbnumerotarjeta"
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
                    <br/>  
                    
                    <asp:Label CssClass="labels labelsNombres" ID="lcodigoseguridad" runat="server" Text="Label">Código seguridad (*):</asp:Label>
                    <asp:TextBox CssClass="textbox inputTextbox" ID="tbcodigoseguridad" MaxLength="3" runat="server" ></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" ControlToValidate ="tbcodigoseguridad"
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
                    <br/>         
                </div>       
            </div>
        </div>

       <div class="botonesFormulario1">          
            <asp:button ID="AceptarBoton" CssClass="Boton botonAceptar" text="Aceptar" runat="server"/>            
            <asp:button CssClass="botonCancelar Boton" ID="CancelarBoton" text="Cancelar" runat="server"/>
        </div>

         <div>
             <asp:Table runat="server" HorizontalAlign="Center">
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