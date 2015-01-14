<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_CobrarTicket.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Configuracionestacionamientos.web_11_CobrarTicket" %>
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
        <h2>Cobrar Ticket</h2>
      <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensajeBot MensajeExito Textocentrado" Visible="false">   </asp:label>
    <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensajeBot MensajeError Textocentrado" Visible="false">   </asp:label>
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
            <asp:TableRow>
                <asp:TableCell  HorizontalAlign="Center" >
                  <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                   <asp:TableCell >
                        <asp:label ID="_label_tarifaTicketPerdido" runat="server" CssClass="labels">   Ticket Perdido: </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:DropDownList CssClass="combo_box" ID="DropDown_estado" runat="server" OnSelectedIndexChanged="DropDown_estado_SelectedIndexChanged"  AutoPostBack="true" >
                                <asp:ListItem selected="true" Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1" Text="NO"> </asp:ListItem>
                                <asp:ListItem Value="2" Text="SI"></asp:ListItem>
                            </asp:DropDownList>
                        <%-- Validator del esatdo de ticket --%>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" 
                                runat="server"
                                 ControlToValidate ="DropDown_estado"
                                ErrorMessage="Seleccione el estatus" 
                                Text="*"
                                ForeColor="Red"
                              
                                InitialValue="0">
                            </asp:RequiredFieldValidator>
                   </asp:TableCell>
             </asp:TableRow>    
            <asp:TableRow>
                   <asp:TableCell >
                        <asp:label ID="_labelNumeroTicket" runat="server" CssClass="labels" Visible="false">   Ticket (*) : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="_textboxNumeroTicket" MaxLength="4" runat="server" CssClass="textbox" Visible="false"></asp:TextBox>
                       <%-- Validator del ticket --%>
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidatorCaracteres" 
                            runat="server" 
                            ControlToValidate="_textboxNumeroTicket"
                             ErrorMessage="No se admiten caracteres especiales ni letras"  
                            Text="*" 
                            ForeColor="Red"
                           ValidationExpression="^[0-9]*$"
                            >
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatoVacio" 
                    runat="server"
                    ControlToValidate="_textboxNumeroTicket" 
                    ErrorMessage="Introducir un numero de ticket" 
                    ForeColor="Red"
                    Text="*"
                    >
                </asp:RequiredFieldValidator>
                </asp:RegularExpressionValidator>
                   </asp:TableCell>
                     </asp:TableRow>

                <asp:TableRow>
                 <asp:TableCell >
                        <asp:label ID="_labelPlaca" runat="server" CssClass="labels" Visible="false">   Placa (*) : </asp:label>
                   </asp:TableCell>
                 <asp:TableCell >
                <asp:TextBox ID="_textboxPlaca" MaxLength="8" runat="server" CssClass="textbox" Visible="false"> </asp:TextBox>
                       <%-- Validator del placa --%>
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator1" 
                            runat="server" 
                            ControlToValidate="_textboxPlaca"
                             ErrorMessage="No se admiten caracteres especiales"  
                            Text="*" 
                            ForeColor="Red"
                           ValidationExpression="[a-zA-Z0-9ñÑ ,.-]{1,20}"
                            >
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="_textboxPlaca" 
                    ErrorMessage="Introducir un numero de placa" 
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
            <asp:Button ID="BotonPagarEstacionamiento" runat="server" CssClass="Boton BotonMargin" Text="Cobrar" Visible="true"   OnClick="BotonPagarEstacionamiento_Click"/>
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
