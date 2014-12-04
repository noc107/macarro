<%@ Page Language="C#"  MasterPageFile="~/Interfaz/temp/master_not_loged.Master" AutoEventWireup ="true" 
    CodeBehind="web_01_preguntaSeguridad.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="front_office.Interfaz.web.IngresoRecuperacionClave.web_01_preguntaSeguridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Responda la pregunta de seguridad
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server"> 

<div class="content01" >

    <div style="text-align:center">
        <p>
            <asp:Label CssClass="labels" ID="Label2" runat="server" Text="&#191;Oficio o profesi&oacute;n del abuelo paterno&#63;"></asp:Label>
        </p>
        <p>
            <asp:TextBox CssClass="textbox" ID="Respuesta" runat="server" placeholder="Respuesta"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="Respuesta" 
                ErrorMessage="Solo se admiten caracteres alfabéticos para la respuesta de seguridad"  
                Text="*" ForeColor="Red" ValidationExpression ="^([a-zA-Z]? ?)*$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate ="Respuesta"
                Text="*" ForeColor="Red" ErrorMessage="Debe ingresar la respuesta">
            </asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="" DisplayMode="List" EnableClientScript="true"
                runat="server" ForeColor="Red"/>
            </p>
        <p>
            <asp:Button CssClass="Boton" ID="Siguiente" runat="server" Text="Siguiente" />
        </p>
    </div>
    
</div>

</asp:Content>
