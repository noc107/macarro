<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CampoNumerico.ascx.cs" 
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.componentes.CampoNumerico" %>

<asp:TextBox ID="tb_numero" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="tb_numero"
                    Text ="*"
                    ErrorMessage="Campo requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tb_numero" 
                    Text="*"
                    ErrorMessage="Campo debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="tb_numero" 
                    Text="*"
                    ErrorMessage="Campo debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                    ControlToValidate="tb_numero" 
                    Text="*"
                    ErrorMessage="Campo debe ser entero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0}$">
                </asp:RegularExpressionValidator>
