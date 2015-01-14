<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="formularioModificarInventario.ascx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes.formularioModificarInventario" %>

<div>    
    <table>
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
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="El precio debe ser un valor numerico" 
                    ForeColor="Red" 
                   ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe tener maximo dos decimales" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CustomValidator1"
                ControlToValidate="precio"
                OnServerValidate="CustomValidator1_ServerValidate"
                runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelEstado" runat="server" Text="Estado del Item (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="estadoDelItem" OnSelectedIndexChanged="estadoDelItem_SelectedIndexChanged" CssClass="combo_box" runat="server">
                    <asp:ListItem Value="Seleccione.." Text="Seleccione.."></asp:ListItem>                    
                </asp:DropDownList>
                
             <% if (this.estadoDelItem.Enabled == true){ %>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="estadoDelItem"
                    ErrorMessage="Seleccione el tipo de Item" 
                    Text="*"
                    ForeColor="Red"
                    InitialValue="Seleccione..">
                </asp:RequiredFieldValidator>                
                <%} %>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelDescripcion" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="descripcion" runat="server" CssClass="textbox inputTextbox inputTextarea" MaxLength="100"></asp:TextBox>           
                  <% if (this.descripcion.Enabled == true){ %>
               <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="descripcion"
                    Text="*"
                    ErrorMessage="Descripcion requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                    ControlToValidate="descripcion" 
                    Text="*"
                    ErrorMessage="La descripcion no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <%} %>
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