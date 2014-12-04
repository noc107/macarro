<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" AutoEventWireup="true" UnobtrusiveValidationMode="None"
     CodeBehind="web_07_modificarReserva.aspx.cs" Inherits="front_office.Interfaz.web.Reservas.web_07_modificarReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

          <link href="../../../comun/resources/css/Reservas/estilo.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Modificar Reserva
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

    <h2>Modificar Reserva</h2>

    <asp:Label ID="Label1" runat="server" Text="Se ha guardado correctamente la reserva." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
   
<div  id="principal">
    
     <asp:Table ID="tabla" runat="server" HorizontalAlign="Center" CssClass ="tabla"> 
               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_servicio" runat="server" CssClass="labels">   Nombre Servicio <span>(*)</span>: </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_servicio" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="tb_servicio"
                    Text="*"
                    ErrorMessage="Servicio Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="tb_servicio" 
                    Text="*"
                    ErrorMessage="El servicio no debe ser numerico" 
                    ForeColor="Red" 
                   ValidationExpression="^[a-zA-Z'.\s]{1,50}">
              </asp:RegularExpressionValidator>

                      

                   
                   </asp:TableCell>

                   <asp:TableCell>
                       <asp:Label ID="label_cantidad" runat="server" CssClass="labels"> Cantidad de Reserva <span>(*)</span> : </asp:Label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:TextBox ID="tb_cantidad" MaxLength="30" runat="server" CssClass="textbox" ></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="tb_cantidad"
                    Text="*"
                    ErrorMessage="Cantidad Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="tb_cantidad" 
                    Text="*"
                    ErrorMessage="La cantidad debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="tb_cantidad" 
                    Text="*"
                    ErrorMessage="La cantidad debe menor a 9" 
                    ForeColor="Red" 
                    ValidationExpression="[1-9]">
                </asp:RegularExpressionValidator>

                       
                       
                        </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_horai" runat="server" CssClass="labels">   Hora Inicio <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                <asp:DropDownList ID="tb_horai" MaxLength="30" runat="server" CssClass="textbox" TextMode="Time"></asp:DropDownList>

                             <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server"
                    ControlToValidate="tb_horai"
                    Text="*"
                    ErrorMessage="Hora Inicio Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                                

                   </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="label_horaf" runat="server" CssClass="labels">   Hora Fin <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                 <asp:DropDownList ID="dd_horaf" MaxLength="30" runat="server" CssClass="textbox" TextMode="Time"></asp:DropDownList>
                  <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                    ControlToValidate="dd_horaf"
                    Text="*"
                    ErrorMessage="Hora Fin Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                       
                         </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_fecha" runat="server" CssClass="labels">   Fecha <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_fecha" MaxLength="30" runat="server" CssClass="textbox" TextMode="Date"></asp:TextBox>
                          
                 <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                    ControlToValidate="tb_fecha"
                    Text="*"
                    ErrorMessage="Fecha Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                   
                   </asp:TableCell>

                  

               </asp:TableRow>
         </asp:Table>

    <br />
      <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonAceptar_Click" />
        <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" CssClass="Boton" OnClick="botonCancelar_Click" />

     

    </div>
    <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
  />

</asp:Content>
