<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DescripcionProducto.ascx.cs" 
    Inherits="back_office.Interfaz.web.MenuRestaurante.componentes.DescripcionProducto" %>


 <asp:TextBox ID="descripcionProducto" runat="server" CssClass="textbox" Height="30px" ></asp:TextBox>
<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="descripcionProducto"
                    Text="*"
                    ErrorMessage="Descripción requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" 
                    ControlToValidate="descripcionProducto" 
                    Text="*"
                    ErrorMessage="Descripción solo puede incluir Letras, Numeros, Puntos, Dos Puntos y Comas" 
                    ForeColor="Red" 
                    ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.: ]+)$"> 
 </asp:RegularExpressionValidator>  