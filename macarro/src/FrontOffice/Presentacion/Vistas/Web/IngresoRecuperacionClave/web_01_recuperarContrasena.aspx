<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_not_loged.Master" AutoEventWireup="true" 
    UnobtrusiveValidationMode="None" CodeBehind="web_01_recuperarContrasena.aspx.cs" 
    Inherits="FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave.web_01_recuperarContrasena" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Recuperaci&oacute;n de Contrase&ntilde;a
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server"> 

<div class="content01" >

    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado con éxito la nueva contraseña." 

        Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>

    <table align="center" style="width:40%" >
       <tr>
           <td colspan="3"> <asp:label ID="Label2" CssClass="labels" runat="server"
                 Text="La contrase&ntilde;a debe contener entre 6-12 caracteres al menos una letra mayúscula, 
               una letra minúscula y un n&uacute;mero o carácter especial excepto guion bajo “_” ."></asp:label></td>
        
       </tr>
       <tr>
            <td></td>
            <td> 
                <asp:label CssClass="labels" ID="LContrasena" runat="server" Text="Contrase&ntilde;a"></asp:label> 

            </td>
            <td> 
                <asp:TextBox CssClass="textbox" ID="Ncontrasena" runat="server" MaxLength="12" placeholder="Ejemplo1.*?"
                onpaste="return false" oncut="return false" oncopy="return false" TextMode="Password"></asp:TextBox> 
            </td>
        </tr>

        <tr>
            <td colspan="3">
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Ncontrasena" ID="ValidarContrasena" 
                    ValidationExpression = "(?=^.{6,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" runat="server" 
                    ErrorMessage="Formato incorrecto." ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate ="Ncontrasena"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar la contraseña">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

      <tr>
            <td></td>
            <td> 
                <asp:Label CssClass="labels" ID="LCcontrasena" runat="server" Text="Confirmar Contrase&ntilde;a"></asp:Label> 
            </td>
            <td> 
                <asp:TextBox CssClass="textbox" ID="Ccontrasena" runat="server" TextMode="Password" MaxLength="12"
                    placeholder="Ejemplo1.*?" onpaste="return false" oncut="return false" oncopy="return false"></asp:TextBox> 
            </td>
       </tr>
       <tr>
            <td colspan="3">
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Ccontrasena" ID="ValidarConfirmacionContrasena" 
                    ValidationExpression = "(?=^.{6,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" runat="server" 
                    ErrorMessage="Formato incorrecto." ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Ccontrasena" 
                    ControlToValidate="Ncontrasena" ErrorMessage="Contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate ="Ccontrasena"
                    Text="*" ForeColor="Red" ErrorMessage="Debe ingresar nuevamente la contraseña">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
               <!-- <asp:ValidationSummary ID="ValidationSummary1" HeaderText="" DisplayMode="BulletList" EnableClientScript="true"
                    runat="server" ForeColor="Red"/> -->
            </td>
        </tr>
    </table>

    <div style="text-align:center"> 
        <p>  
            <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary2"
                HeaderText=""
                DisplayMode="List"
                EnableClientScript="true"
                runat="server"/>
            <asp:Button CssClass="Boton" ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" /> 
        </p>
    </div>

</div>

</asp:Content>