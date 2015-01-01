<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_CobrarTicket.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Estacionamiento.web_11_CobrarTicket" %>
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
                        <asp:label ID="labelNumeroTicket" runat="server" CssClass="labels">   Ticket (*) : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="textboxNumeroTicket" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                       <%-- Validator del ticket --%>
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidatorCaracteres" 
                            runat="server" 
                            ControlToValidate="textboxNumeroTicket"
                             ErrorMessage="No se admiten caracteres especiales ni letras"  
                            Text="*" 
                            ForeColor="Red"
                           ValidationExpression="^[0-9]*$"
                            >

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatoVacio" runat="server"
                    ControlToValidate="textboxNumeroTicket" 
                    ErrorMessage="Debe introducir un numero de ticket." 
                    ForeColor="Red"
                    Text="*"
                    >
                </asp:RequiredFieldValidator>
                </asp:RegularExpressionValidator>
                
                   </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                   <asp:TableCell >
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Ticket Perdido: </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:DropDownList CssClass="combo_box" ID="DropDown_estado" runat="server">
                                <asp:ListItem selected="true">Seleccione</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                                <asp:ListItem>SI</asp:ListItem>
                            </asp:DropDownList>
                        <%-- Validator del esatdo de ticket --%>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate ="DropDown_estado"
                                ErrorMessage="Seleccione el estatus" 
                                Text="*"
                                ForeColor="Red"
                                InitialValue="Seleccione">
                            </asp:RequiredFieldValidator>
                   </asp:TableCell>
             </asp:TableRow>    
           
         </asp:Table>
    <br />
    <div class="boton_centrado">
            <asp:Button ID="BotonPagarEstacionamiento" runat="server" CssClass="Boton BotonMargin" Text="Cobrar" Visible="true" />
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
