<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="formularioModificarPuesto.ascx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes.formularioModificarPuesto" %>

<div>
    
    <table>
        <tr>
            <td>
                <asp:Label ID="labelFila" runat="server" Text="Fila (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="fila" runat="server" CssClass="textbox" MaxLength="10" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelColumna" runat="server" Text="Columna (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="columna" runat="server" CssClass="textbox" MaxLength="10" Enabled="false"></asp:TextBox>
            </td>             
       </tr>
         <tr>
            <td>
                <asp:Label ID="labelDescripcion" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="descripcion" runat="server" CssClass="textbox inputTextbox inputTextarea" MaxLength="100"></asp:TextBox>           
            
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
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
            
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="El precio debe ser un valor numerico" 
                    ForeColor="Red" 
                   ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="precio" 
                    Text="*"
                    ErrorMessage="Precio debe tener maximo dos decimales" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
               <asp:ValidationSummary ID="ValidationSummary2"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>
            </td>
        </tr>
    </table>

    <div>
      
        
    </div>

</div>