<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="formularioConsultarPuesto.ascx.cs" 
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.componentes.formularioConsultarPuesto" %>

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
            <asp:RadioButtonList  ID="listaDeOpciones" runat="server" CssClass="radio_list"  RepeatDirection="Horizontal" OnSelectedIndexChanged="listaDeOpciones_SelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem   selected="true" Value="0">Consultar Todo</asp:ListItem>
                <asp:ListItem  Value="1">Consultar por Fila</asp:ListItem>
                <asp:ListItem Value="2">Consultar por Columna</asp:ListItem>
                <asp:ListItem Value="3">Consultar por ubicacion</asp:ListItem>
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
                <asp:TextBox ID="fila" runat="server" CssClass="textbox" MaxLength="3"></asp:TextBox>
           
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
            </td>
         </tr>
        <tr>
            <td>
                <asp:Label ID="labelColumna" runat="server" Text="Columna (*):" CssClass="labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="columna" runat="server" CssClass="textbox" MaxLength="3"></asp:TextBox>
           
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
        <div class="btn_aceptar_posicion">
            <asp:Button ID="botonBuscar" runat="server" Text="Buscar" CssClass="Boton" OnClick="botonBuscar_Click" />
        </div>
    </div>
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UDP" runat="server"> 
                  
       <ContentTemplate> 
                       <asp:GridView ID="GridView_ConsultarPuesto" runat="server"  Width="530px" Height="96px" ForeColor="#333333" 
                           GridLines="None"
                           AllowPaging="true" PageSize="10"
                          >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PageButtonCount="4" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />

                   </asp:GridView>
                  </ContentTemplate> 
                </asp:UpdatePanel>


    </div>
</div>