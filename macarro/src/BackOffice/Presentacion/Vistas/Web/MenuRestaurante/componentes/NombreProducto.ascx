<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NombreProducto.ascx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.MenuRestaurante.componentes.TextoTipoUno" %>


 <asp:TextBox   ID="nombreProducto" runat="server"  CssClass="textbox" Height="30px" ></asp:TextBox>
<asp:RequiredFieldValidator id="RequiredFieldValidator" runat="server"
                    ControlToValidate="nombreProducto"
                    Text="*"
                    ErrorMessage="Nombre requerido."
                    ForeColor="Red">
 </asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" 
                    ControlToValidate="nombreProducto" 
                    Text="*"
                    ErrorMessage="Nombre no debe contener numeros ni caracteres especiales." 
                    ForeColor="Red" 
                    ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)$"> 
 </asp:RegularExpressionValidator> 

  

