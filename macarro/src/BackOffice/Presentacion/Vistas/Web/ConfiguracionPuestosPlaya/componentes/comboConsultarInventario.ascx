<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="comboConsultarInventario.ascx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes.comboConsultarInventario" %>

<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="labelTipoDeConsulta" runat="server" Text="Tipo de Item (*):" CssClass="labels"></asp:Label>
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
        
    </table>
    <table>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1"
                CssClass="avisoMensaje MensajeError"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" /> 
            </td>          
        </tr>
    </table>
    <br />

</div>
