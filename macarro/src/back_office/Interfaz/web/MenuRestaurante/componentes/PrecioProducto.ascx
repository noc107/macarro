<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrecioProducto.ascx.cs" 
    Inherits="back_office.Interfaz.web.MenuRestaurante.componentes.PrecioProducto" %>

 <asp:TextBox ID="precioProducto" runat="server" CssClass="textbox" Height="30px" ></asp:TextBox>
<asp:RequiredFieldValidator id="RequiredFieldValidator" runat="server"
                    ControlToValidate="precioProducto"
                    Text="*"
                    ErrorMessage="Precio requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="precioProducto" 
                    Text="*"
                    ErrorMessage="Precio debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="precioProducto" 
                    Text="*"
                    ErrorMessage="Precio debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="precioProducto" 
                    Text="*"
                    ErrorMessage="Precio debe tener maximo dos decimales" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                </asp:RegularExpressionValidator>  


