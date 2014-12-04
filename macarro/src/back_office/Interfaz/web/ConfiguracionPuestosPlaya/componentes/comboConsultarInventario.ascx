<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="comboConsultarInventario.ascx.cs" 
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.componentes.comboConsultarInventario" %>

<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="labelTipoDeConsulta" runat="server" Text="Tipo de Item (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="tipoDeConsulta" runat="server" CssClass="combo_box">
                    <asp:ListItem Value="Seleccione..">Seleccione..</asp:ListItem>
                </asp:DropDownList>
           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="tipoDeConsulta"
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
                    HeaderText=""
                    DisplayMode="List"
                    EnableClientScript="true"
                    runat="server" 
                    ForeColor="Red"/>
            </td>          
        </tr>
    </table>
    <br />
    <div>
        <div class="btn_aceptar_posicion">
            <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton"/>
        </div>
    </div>
</div>
