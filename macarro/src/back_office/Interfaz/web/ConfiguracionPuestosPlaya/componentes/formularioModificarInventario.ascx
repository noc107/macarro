﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="formularioModificarInventario.ascx.cs" 
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.componentes.formularioModificarInventario" %>

<div>    
    <table>
        <tr>
            <td>
                <asp:Label ID="labelPrecio" runat="server" Text="Precio de alquiler (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="precio" runat="server" CssClass="textbox"></asp:TextBox>
         
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
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelEstado" runat="server" Text="Estado del Item (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="estadoDelItem" CssClass="combo_box" runat="server">
                    <asp:ListItem Value="Seleccione..">Seleccione..</asp:ListItem>
                </asp:DropDownList>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="estadoDelItem"
                    ErrorMessage="Seleccione el tipo de Item" 
                    Text="*"
                    ForeColor="Red"
                    InitialValue="Seleccione..">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelDescripcion" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="descripcion" runat="server" CssClass="textbox inputTextbox inputTextarea"></asp:TextBox>           
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
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
               <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>
            </td>
        </tr>
    </table>
    <br />
    <div>
        <table>
            <tr>
                <td>
                    <div class="btn_aceptar_posicion">
                <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton"/>
            </div>
                </td>
                <td>
                    <div class="btn_aceptar_posicion">
                <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" CssClass="Boton"/>
            </div>
                </td>
            </tr>
        </table>
        
    </div>
</div>