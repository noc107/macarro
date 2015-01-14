<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="formularioAgregarPuesto.ascx.cs"
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes.formularioAgregarPuesto" %>

<div>
    <table>
        <tr>
            <td>
                <div class="centrar_texto">
                    <asp:Label ID="labelModoDeBusqueda" runat="server" Text="Seleccione (*)" CssClass="labels centrar_texto"></asp:Label>  
                </div>
             </td>
        </tr>
        <tr>
            <td>
            <asp:RadioButtonList ID="listaDeOpciones" runat="server" CssClass="radio_list" RepeatDirection="Horizontal" OnSelectedIndexChanged="listaDeOpciones_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem selected="true" Value="0">Generar Todo</asp:ListItem>
                <asp:ListItem Value="1">Generar Fila</asp:ListItem>
                <asp:ListItem Value="2">Generar Columna</asp:ListItem>
                <asp:ListItem Value="3">Generar ubicacion</asp:ListItem>
            </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="labelFila" runat="server" Text="Fila (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="fila" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>
            <% if (this.fila.Enabled == true){ %>
               <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="fila"
                    Text="*"
                    ErrorMessage="Fila de la playa requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="fila" 
                    Text="*"
                    ErrorMessage="Fila de la playa debe ser numerica" 
                    ForeColor="Red" 
                   ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="fila" 
                    Text="*"
                    ErrorMessage="Fila de la playa debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="fila" 
                    Text="*"
                    ErrorMessage="Fila de la playa debe ser entera" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0}$">
                </asp:RegularExpressionValidator>
                <% } %>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelColumna" runat="server" Text="Columna (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="columna" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>
                <% if (this.columna.Enabled == true){ %>
               <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="columna"
                    Text="*"
                    ErrorMessage="Columna de la playa requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="columna" 
                    Text="*"
                    ErrorMessage="Columna de la playa debe ser numerica" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="columna" 
                    Text="*"
                    ErrorMessage="Columna de la playa debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                    ControlToValidate="columna" 
                    Text="*"
                    ErrorMessage="Columna de la playa debe ser entera" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0}$">
                </asp:RegularExpressionValidator>
                <% } %>
            </td>
       </tr>
         <tr>
            <td>
                <asp:Label ID="labelDescripcion" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="descripcion" runat="server" CssClass="textbox inputTextbox inputTextarea" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
           
               <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="descripcion"
                    Text="*"
                    ErrorMessage="Descripcion requerida."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="descripcion" 
                    Text="*"
                    ErrorMessage="La descripcion no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelPrecio" runat="server" Text="Precio (*):" CssClass="labels"></asp:Label>
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