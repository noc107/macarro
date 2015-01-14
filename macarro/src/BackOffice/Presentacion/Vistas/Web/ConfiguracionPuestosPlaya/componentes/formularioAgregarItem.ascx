<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="formularioAgregarItem.ascx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes.formularioAgregarItem" %>

<div>    
    <table>
        <tr>
            <td>
                <asp:Label ID="labelTipoDeItem" runat="server" Text="Tipo de item (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="tipoDeItem" CssClass="combo_box" runat="server">
                    <asp:ListItem Value="Seleccione..">Seleccione..</asp:ListItem>
                    <asp:ListItem Value="MESA">MESA</asp:ListItem>
                    <asp:ListItem Value="SILLA">SILLA</asp:ListItem>
                    <asp:ListItem Value="SOMBRILLA">SOMBRILLA</asp:ListItem>
                </asp:DropDownList>
          
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="tipoDeItem"
                    ErrorMessage="Seleccione el tipo de Item" 
                    Text="*"
                    ForeColor="Red"
                    InitialValue="Seleccione..">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelPrecio" runat="server" Text="Precio de alquiler (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="precio" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
        
                <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="precio"
                    Text="*"
                    ErrorMessage="Precio requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe tener maximo dos decimales" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelCantidad" runat="server" Text="Cantidad del Item (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="cantidad" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
          
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="cantidad"
                    Text="*"
                    ErrorMessage="Cantidad de item(s) es requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="cantidad" 
                    Text="*"
                    ErrorMessage="Cantidad de item debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="cantidad" 
                    Text="*"
                    ErrorMessage="Cantidad de item debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                    ControlToValidate="cantidad" 
                    Text="*"
                    ErrorMessage="Cantidad de item debe ser entera" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0}$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        
    </table>
    <table>
        <tr>
            <td>
                <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" />
            </td>
        </tr>
    </table>    
</div>