<%@ Page UnobtrusiveValidationMode="None" Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" 
    AutoEventWireup="true" CodeBehind="web_01_modificar.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave.web_01_modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Perfil
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

<link rel="Stylesheet" type="text/css" href="/comun/resources/css/IngresoRecuperacionClave/modulo01.css" />

<div class="content01" >

    <table style="width:100%">
        <tr>
           <td> <asp:Label CssClass="labels" ID="LPriNombre" runat="server" Text="Primer Nombre (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="PriNombre" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularPriNombre" 
                    runat="server" ControlToValidate="PriNombre" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el nombre" 
                    Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidarRequeridoPriNombre" 
                    runat="server" 
                    ControlToValidate ="PriNombre"
                    Text="*" ForeColor="Red" 
                    ErrorMessage="Debe ingresar el primer nombre">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:Label CssClass="labels" ID="LSegNombre" runat="server" Text="Segundo Nombre:"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="SegNombre" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularSegNombre" 
                    runat="server" 
                    ControlToValidate="SegNombre" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el nombre" 
                    Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label CssClass="labels" ID="LPriApellido" runat="server" Text="Primer Apellido (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="PriApellido" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularPriApellido" 
                    runat="server" 
                    ControlToValidate="PriApellido" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el apellido"  
                    Text="*" ForeColor="Red" 
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidarRequeridoPriApellido" 
                    runat="server" 
                    ControlToValidate ="PriApellido"
                    Text="*" ForeColor="Red" 
                    ErrorMessage="Debe ingresar el primer apellido">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:Label CssClass="labels" ID="LSegApellido" runat="server" Text="Segundo Apellido:"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="SegApellido" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularSegApellido" 
                    runat="server" 
                    ControlToValidate="SegApellido" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el apellido" 
                    Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="LTipoDocIdentidad" runat="server" Text="Documento de Identificaci&oacute;n (*) :"></asp:Label> </td>
            <td> 
                <asp:DropDownList class="DropDownList" ID="TipoDocIdentidad" runat="server">
                    <asp:ListItem> Seleccione documento </asp:ListItem>
                    <asp:ListItem>C&eacute;dula</asp:ListItem>
                    <asp:ListItem>Pasaporte</asp:ListItem>
                </asp:DropDownList> 
                <asp:RequiredFieldValidator ID="ValidarExpRegularTipoDocIdentidad" 
                    runat="server" 
                    ControlToValidate ="TipoDocIdentidad" 
                    ErrorMessage="Seleccionar un documento" 
                    InitialValue="Seleccione documento"
                    Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:TextBox CssClass="textbox" ID="NumeroDocumento" MaxLength="10" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
            <td> </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="LCorreo" runat="server" Text="Correo (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="Correo" MaxLength="40" runat="server" ReadOnly="true"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularCorreo" 
                    runat="server" 
                    ControlToValidate="Correo" 
                    Text="*"  ForeColor="Red" 
                    ErrorMessage="Correo inválido"
                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidarRequeridoCorreo" 
                    runat="server" 
                    ControlToValidate ="Correo"
                    Text="*" ForeColor="Red" 
                    ErrorMessage="Debe ingresar un Correo">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:Label CssClass="labels" ID="LFechaNac" runat="server" Text="Fecha de Nacimiento (*) :"></asp:Label> </td>
            <td> <asp:TextBox ID="FechaNac" MaxLength="30" runat="server" CssClass="textbox" TextMode="Date"></asp:TextBox> 
                <asp:RangeValidator ID="ValidarFechaNac" 
                    runat="server" 
                    ControlToValidate="FechaNac"
                    ErrorMessage="El cliente debe tener entre 18 y 65 años" 
                    MinimumValue="01-01-1949" MaximumValue="01-12-1996"
                    Type="Date" Text="*" ForeColor="Red">
                </asp:RangeValidator>
                <asp:RequiredFieldValidator ID="ValidarRequeridoFechaNac" runat="server" ControlToValidate ="FechaNac"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar la fecha de nacimiento">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2"> <asp:label ID="Label19" CssClass="labels" runat="server"
                 Text="La contrase&ntilde;a debe contener entre 6-12 caracteres al menos una letra mayúscula, 
               una letra minúscula y un n&uacute;mero o carácter especial excepto guion bajo “_” ."></asp:label></td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="LContrasena" runat="server" Text="Contrase&ntilde;a (*) :"></asp:Label></td>
            <td> <asp:TextBox CssClass="textbox" ID="Contrasena" MaxLength="12" onpaste="return false" oncut="return false" oncopy="return false" TextMode="Password" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularContrasena" 
                    Display = "Dynamic" 
                    ControlToValidate = "Contrasena" 
                    ValidationExpression = "(?=^.{6,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" runat="server" 
                    ErrorMessage="Formato incorrecto." ForeColor="Red">
                </asp:RegularExpressionValidator>
            </td>
            <td> <asp:Label CssClass="labels" ID="LRepContrasena" runat="server" Text="Repetir Contrase&ntilde;a (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="RContrasena" MaxLength="12" onpaste="return false" oncut="return false" oncopy="return false" TextMode="Password" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularRepContrasena" 
                    Display = "Dynamic"
                    runat="server" 
                    ControlToValidate = "RContrasena"  
                    ValidationExpression = "(?=^.{6,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"  
                    ErrorMessage="Formato incorrecto." ForeColor="Red">
                </asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompararContrasena" runat="server" ControlToCompare="Contrasena" 
                    ControlToValidate="RContrasena" 
                    ErrorMessage="Las contrase&ntilde;as deben conincidir" ForeColor="Red"></asp:CompareValidator>
            </td>  
        </tr>
        <tr>
             <td> <asp:Label CssClass="labels" ID="LPreSeguridad" runat="server" Text="Pregunta de Seguridad (*) :"></asp:Label> </td>
            <td> 
                <asp:DropDownList class="DropDownList" ID="PreSeguridad" runat="server">
                    <asp:ListItem> Seleccione una pregunta </asp:ListItem>
                    <asp:ListItem> ¿Cuál es la ciudad de nacimiento su madre? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es el nombre del colegio donde estudio? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es la profesión de su abuela materna? </asp:ListItem>
                    <asp:ListItem> ¿Cuál era su caricatura favorita en su infancia? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es el segundo nombre de su padre? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es el nombre de su abuelo paterno? </asp:ListItem>
                    <asp:ListItem> ¿Cuál fue el modelo de su primer automóvil? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es el nombre de su cantante o grupo favorito? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es su deporte favorito? </asp:ListItem>
                    <asp:ListItem> ¿Cuál es su película favorita? </asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator  ID="ValidarRequeridoPreSeguridad" 
                    runat="server" 
                    ControlToValidate ="PreSeguridad" 
                    ErrorMessage="Seleccionar una pregunta" 
                    InitialValue="Seleccione una pregunta" 
                    Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>          
            <td> <asp:Label CssClass="labels" ID="LRespSeguridad" runat="server" Text="Respuesta de Seguridad (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="RespSeguridad" MaxLength="30" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="ValidarExpRegularRespSeguridad" 
                    runat="server" 
                    ControlToValidate="RespSeguridad" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para la respuesta de seguridad" 
                    Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidarRequeridoRespSeguridad" 
                    runat="server" 
                    ControlToValidate ="RespSeguridad"
                    Text="*" ForeColor="Red" 
                    ErrorMessage="Debe ingresar la respuesta de seguridad">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <td><asp:Label CssClass="labels" ID="LDireccion1" runat="server" Text="Dirección (Línea 1) (*) :"></asp:Label></td>
            <td colspan = "3">
                <asp:TextBox CssClass="textbox" ID="Direccion1" MaxLength="100" runat="server" Width="628px"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="ValidarDireccion" 
                    runat="server" 
                    ControlToValidate ="Direccion1"
                    Text="*" ForeColor="Red" 
                    ErrorMessage="Debe ingresar una dirección">
                </asp:RequiredFieldValidator>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label14" runat="server" Text="Campos obligatorios (*)"></asp:Label> </td>
            <td> </td> 
            <td> </td>
            <td> </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2"><asp:ValidationSummary ID="ValidationSummary1" 
                HeaderText="" 
                DisplayMode="BulletList"
                EnableClientScript="true"
                 runat="server" ForeColor="Red"/></td>
            <td></td>
        </tr>
    </table>

    <div style="text-align:center" >
        <asp:Button CssClass="Boton01" ID="aceptar" runat="server" Text="Aceptar" OnClick="aceptar_Click" />
        <asp:Button CssClass="Boton01" ID="cancelar" runat="server" Text="Cancelar" OnClick="cancelar_Click" />
        <br />
    </div> 
     
    <div style="text-align:left" >
        <p>  <asp:HyperLink CssClass="HiperLink" ID="Link1" runat="server" Text="Desactivar cuenta"></asp:HyperLink> </p>
    </div>

</div>

</asp:Content>