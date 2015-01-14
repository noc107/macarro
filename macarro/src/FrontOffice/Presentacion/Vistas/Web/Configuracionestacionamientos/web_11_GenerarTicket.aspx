<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_GenerarTicket.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Configuracionestacionamiento.web_11_GenerarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
     <link href="../../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
      <h2>Generar Ticket</h2>
        <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensajeBot MensajeExito Textocentrado" Visible="false">  </asp:label>
    <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensajeBot MensajeError Textocentrado" Visible="false">   </asp:label>
   
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
            <asp:TableRow>
                <asp:TableCell  Height="50">
                    <asp:label ID="_labelEstacionamiento" runat="server" CssClass="labels">   Estacionamiento: </asp:label>
                </asp:TableCell>
                   <asp:TableCell>
                        <asp:label ID="_nombreEstacionamiento" runat="server" CssClass="labels"> </asp:label>
                        

                   </asp:TableCell>
            </asp:TableRow>   
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="_labelPlaca" runat="server" CssClass="labels">   Placa(*) : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                      <asp:TextBox ID="_textBoxPlaca" MaxLength="8" runat="server" CssClass="textbox"></asp:TextBox>
                  <%-- Validator del placa --%>
                         <asp:RegularExpressionValidator ID="expresionRegularPlaca" runat="server" 
                        ControlToValidate="_textBoxPlaca"
                        Text="*"
                        ErrorMessage="No se permiten caracteres especiales."
                        ValidationExpression="[a-zA-Z0-9ñÑ ,.]{1,20}"
                        ForeColor="Red">
                        </asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="expresionRegularPlaca2" runat="server"             
                        ErrorMessage="Debe ingresar hasta un maximo de 8 caracteres"            
                        ValidationExpression="^([\S\s]{0,10})$"             
                        ControlToValidate="_textBoxPlaca"            
                        ForeColor="Red"
                        Text="*">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatoVacio" runat="server"
                    ControlToValidate="_textBoxPlaca" 
                    ErrorMessage="Introducir una placa" 
                    ForeColor="Red"
                    Text="*"
                    >
                </asp:RequiredFieldValidator>
                    </asp:RegularExpressionValidator>

                   </asp:TableCell>
               </asp:TableRow>          
           
         

         </asp:Table>
    <br />
    <div class="boton_centrado">
            <asp:Button ID="BotonGenerarTicket" runat="server" CssClass="Boton" Text="Aceptar" OnClick="BotonGenerarTicket_Click"/>
        
        </div>
    <br />
     <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ValidationSummary ID="ValidationSummary2" CssClass="avisoMensaje MensajeError"
                    HeaderText=""
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server" 
                    />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
 