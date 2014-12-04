<%@ Page UnobtrusiveValidationMode="None" Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" 
    AutoEventWireup="true" CodeBehind="web_01_modificar.aspx.cs" Inherits="front_office.Interfaz.web.IngresoRecuperacionClave.web_01_modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato , Daniel
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Perfil
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

<link rel="Stylesheet" type="text/css" href="/comun/resources/css/IngresoRecuperacionClave/modulo01.css" />

<div class="content01" >

    <table style="width:100%">
        <tr>
            <td> <asp:Label CssClass="labels" ID="Label2" runat="server" Text="Primer Nombre (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input1" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="input1" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el nombre" Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate ="input1"
                        Text="*" ForeColor="Red" ErrorMessage="Debe ingresar el primer nombre">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:Label CssClass="labels" ID="label3" runat="server" Text="Segundo Nombre:"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input2" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="input2" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el nombre" Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label CssClass="labels" ID="label4" runat="server" Text="Primer Apellido (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input3" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="input3" ErrorMessage="Solo se admiten caracteres alfabéticos para el apellido"  
                    Text="*" ForeColor="Red" ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate ="input3"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar el primer apellido">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:Label CssClass="labels" ID="label5" runat="server" Text="Segundo Apellido: "></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input4" MaxLength="20" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="input4" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para el apellido" Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label6" runat="server" Text="Documento de Identificaci&oacute;n (*) :"> </asp:Label> </td>
            <td> 
                <asp:DropDownList class="DropDownList" ID="DropDownList1" runat="server">
                    <asp:ListItem> Seleccione documento </asp:ListItem>
                    <asp:ListItem>C&eacute;dula</asp:ListItem>
                    <asp:ListItem>Pasaporte</asp:ListItem>
                </asp:DropDownList> 
                <asp:RequiredFieldValidator CssClass="ValidacionPreguntaSeguridad" ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate ="DropDownList1" ErrorMessage="Seleccionar un documento" 
                    InitialValue="Seleccione documento" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td> 
            <td> <asp:TextBox CssClass="textbox" ID="input5" MaxLength="10" runat="server" ></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="input5" 
                    Text="*" ErrorMessage="Solo se admiten caracteres numéricos enteros para el documento de identificación" 
                    ForeColor="Red" ValidationExpression="^([1-9][0-9]*)(.[0-9]*){2}$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate ="input5"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar el número del documento de identidad">
                </asp:RequiredFieldValidator>
            </td>
            <td> </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label7" runat="server" Text="E-mail(*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input6" ReadOnly="true" runat="server" ></asp:TextBox> </td> 
            <td> <asp:Label CssClass="labels" ID="label8" runat="server" Text="Fecha de Nacimiento (*) :"></asp:Label> </td>
            <td> <asp:TextBox ID="tb_fecha" MaxLength="30" runat="server" CssClass="textbox" TextMode="Date"></asp:TextBox> 
                <asp:RangeValidator ID="validatorfechanac" runat="server" ControlToValidate="tb_fecha" 
                    ErrorMessage="El cliente debe tener entre 18 y 65 años" MinimumValue="01-01-1949" MaximumValue="01-12-1996"
                    Type="Date" Text="*" ForeColor="Red">
                </asp:RangeValidator> 
                <asp:RequiredFieldValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate ="tb_fecha"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar la fecha de nacimiento">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label10" runat="server" Text="Contrase&ntilde;a (*) :"></asp:Label></td>
            <td> <asp:TextBox CssClass="textbox" ID="Contrasena" MaxLength="12" onpaste="return false" oncut="return false" oncopy="return false" TextMode="Password" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Contrasena" ID="ValidarContrasena" 
                    ValidationExpression = "(?=^.{6,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" runat="server" 
                    ErrorMessage="Formato incorrecto." ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCon" runat="server" ControlToValidate ="Contrasena"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar la contraseña">
                </asp:RequiredFieldValidator>
            </td>
            <td> <asp:Label CssClass="labels" ID="label12" runat="server" Text="Pregunta de Seguridad (*) :"></asp:Label> </td>
            <td> 
                <asp:DropDownList class="DropDownList" ID="DropDownList2" runat="server">
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
                <asp:RequiredFieldValidator CssClass="ValidacionPreguntaSeguridad" ID="Validator5" runat="server" 
                    ControlToValidate ="DropDownList2" ErrorMessage="Seleccionar una pregunta"
                    InitialValue="Seleccione una pregunta" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>     
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label11" runat="server" Text="Repetir Contrase&ntilde;a (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="Rcontrasena" MaxLength="12" onpaste="return false" oncut="return false" oncopy="return false" TextMode="Password" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Rcontrasena" ID="ValidarRcontrasena" 
                    ValidationExpression = "(?=^.{6,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" runat="server" 
                    ErrorMessage="Formato incorrecto." ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRcon" runat="server" ControlToValidate ="RContrasena"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar nuevamente la contraseña">
                </asp:RequiredFieldValidator>
            </td>       
            <td> <asp:Label CssClass="labels" ID="label13" runat="server" Text="Respuesta de Seguridad (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input9" MaxLength="30" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="input9" 
                    ErrorMessage="Solo se admiten caracteres alfabéticos para la respuesta de seguridad" Text="*" ForeColor="Red"
                    ValidationExpression ="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RegularExpressionValidator09" runat="server" ControlToValidate ="input9"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar la respuesta de seguridad">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label9" runat="server" Text="Tel&eacute;fono (*) :"></asp:Label> </td>
            <td> <asp:TextBox CssClass="textbox" ID="input10" MaxLength="11" runat="server"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="input10" 
                    Text="*" ErrorMessage="Teléfono inválido" ForeColor="Red" ValidationExpression="^([1-9][0-9]*)(.[0-9]*){7}$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate ="input10"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar un teléfono">
                </asp:RequiredFieldValidator>
            </td> 
            <td>  </td>
            <td> </td>
        </tr>
        <tr>
            <td><asp:Label CssClass="labels" ID="label1" runat="server" Text="Pa&iacute;s (*) :"></asp:Label></td>
            <td>
                <asp:DropDownList class="DropDownList" ID="DropDownList3" runat="server">
                    <asp:ListItem> Seleccione </asp:ListItem>
                    <asp:ListItem>Venezuela</asp:ListItem>
                </asp:DropDownList> 
                <asp:RequiredFieldValidator CssClass="ValidacionPais" ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate ="DropDownList3" ErrorMessage="Seleccionar un país" 
                    InitialValue="Seleccione" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
            <td><asp:Label CssClass="labels" ID="label15" runat="server" Text="Direcci&oacute;n (*) :"></asp:Label></td>
            <td rowspan="3" > <asp:TextBox CssClass="textbox" ID="TextBox16" Height="120px" Wrap="true" MaxLength="100" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate ="TextBox16"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar una dirección">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label CssClass="labels" ID="label16" runat="server" Text="Estado (*) :"></asp:Label></td>
            <td>
                <asp:DropDownList class="DropDownList" ID="DropDownList4" runat="server">
                    <asp:ListItem> Seleccione </asp:ListItem>
                    <asp:ListItem>Dtto Capital</asp:ListItem>
                </asp:DropDownList> 
                <asp:RequiredFieldValidator CssClass="ValidacionEstado" ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate ="DropDownList4" ErrorMessage="Seleccionar un estado" 
                    InitialValue="Seleccione" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label CssClass="labels" ID="label17" runat="server" Text="Ciudad (*) :"></asp:Label></td>
            <td>
                <asp:DropDownList class="DropDownList" ID="DropDownList5" runat="server">
                    <asp:ListItem> Seleccione </asp:ListItem>
                    <asp:ListItem>Caracas</asp:ListItem>
                </asp:DropDownList> 
                <asp:RequiredFieldValidator CssClass="ValidacionCiudad" ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate ="DropDownList5" ErrorMessage="Seleccionar una ciudad" 
                    InitialValue="Seleccione" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> <asp:Label CssClass="labels" ID="label14" runat="server" Text="Campos obligatorios (*) "></asp:Label> </td>
            <td> </td> 
            <td> </td>
            <td> </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2"><asp:ValidationSummary ID="ValidationSummary2" HeaderText="" DisplayMode="BulletList"
                EnableClientScript="true" runat="server" ForeColor="Red"/></td>
            <td></td>
        </tr>
    </table>

    <div style="text-align:center" >
        <asp:Button CssClass="Boton01" ID="Button1" runat="server" Text="Aceptar" />
        <asp:Button CssClass="Boton01" ID="Button2" runat="server" Text="Cancelar" />
        <br />
    </div> 
     
    <div style="text-align:left" >
        <p>  <asp:HyperLink CssClass="HiperLink" ID="Link1" runat="server" Text="Desactivar cuenta"></asp:HyperLink> </p>
    </div>

</div>

</asp:Content>
