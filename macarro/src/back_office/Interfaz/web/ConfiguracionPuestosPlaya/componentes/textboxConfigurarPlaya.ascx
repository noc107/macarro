<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="textboxConfigurarPlaya.ascx.cs" Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.componentes.WebUserControl1" %>

<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="labelLargoDeLaPlaya" runat="server" Text="Largo de la Paya (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="largoDeLaPlaya" runat="server" CssClass="textbox" MaxLength="3"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="largoDeLaPlaya"
                    Text ="*"
                    ErrorMessage="Largo de la playa requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="largoDeLaPlaya" 
                    Text="*"
                    ErrorMessage="Largo de la playa debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="largoDeLaPlaya" 
                    Text="*"
                    ErrorMessage="Largo de la playa debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                    ControlToValidate="largoDeLaPlaya" 
                    Text="*"
                    ErrorMessage="Largo de la playa debe ser entero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0}$">
                </asp:RegularExpressionValidator>
            </td>         
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelAnchoDeLaPlaya" runat="server" Text="Ancho de la Playa (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="anchoDeLaPlaya" runat="server" CssClass="textbox" MaxLength="3"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="anchoDeLaPlaya"
                    Text="*"
                    ErrorMessage="Ancho de la playa requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="anchoDeLaPlaya" 
                    Text="*"
                    ErrorMessage="Ancho de la playa debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="anchoDeLaPlaya" 
                    Text="*"
                    ErrorMessage="Ancho de la playa debe ser mayor a cero" 
                    ForeColor="Red" 
                   ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="anchoDeLaPlaya" 
                    Text="*"
                    ErrorMessage="Ancho de la playa debe ser entero" 
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