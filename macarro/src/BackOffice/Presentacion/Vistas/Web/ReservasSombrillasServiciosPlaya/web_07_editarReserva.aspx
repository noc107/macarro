<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None"
     AutoEventWireup="true" CodeBehind="web_07_editarReserva.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya.web_07_editarReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ReservasSombrillasServiciosPlaya/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
   
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2 class="centrado subtitulo">Editar Reserva</h2>
    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la reserva." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>

    <div class="lab">
    
        
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center" CssClass ="tabla"> 

              <asp:TableRow>
                   <asp:TableCell>
                          <asp:label ID="label_nombre" runat="server" CssClass="labels">   Nombre <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:DropDownList ID="ddlNombre" runat="server" CssClass ="combo_box"></asp:DropDownList>
             
               </asp:TableCell>
                  
               
                   <asp:TableCell>
                       <asp:Label ID="label_cantidad" runat="server" CssClass="labels"> Cantidad de Reserva <span>(*)</span> : </asp:Label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:TextBox ID="tb_cantidad" MaxLength="30"  runat="server" CssClass="textbox"></asp:TextBox>
                   
                   <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="tb_cantidad"
                    Text="*"
                    ErrorMessage="Cantidad Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
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
                        <asp:label ID="label_horaI" runat="server" CssClass="labels">   Hora de Inicio <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_horaI" MaxLength="30" runat="server" CssClass="textbox" TextMode="DateTime">
                          
                        </asp:TextBox>
                     <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="tb_horaI"
                    Text="*"
                    ErrorMessage="Hora Inicio Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                   </asp:TableCell>

                   <asp:TableCell>
                        <asp:label ID="label_horaF" runat="server" CssClass="labels">   Hora de Fin <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_horaF" MaxLength="30" runat="server" CssClass="textbox" TextMode="DateTime">
                         
                        </asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                    ControlToValidate="tb_horaF"
                    Text="*"
                    ErrorMessage="Hora Fin Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                         </asp:TableCell>
               </asp:TableRow>
                            <asp:TableRow>
                    <asp:TableCell>
                        <asp:label ID="label_costo" runat="server" CssClass="labels">   Costo <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_costo" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>

               <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="tb_costo"
                    Text="*"
                    ErrorMessage="Costo Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="tb_costo" 
                    Text="*"
                    ErrorMessage="El Costo debe ser numerico" 
                    ForeColor="Red" 
                   ValidationExpression="^\d+(.[0-9]*)*$">
                </asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="tb_costo" 
                    Text="*"
                    ErrorMessage="El Costo debe ser mayor a cero" 
                    ForeColor="Red" 
                    ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                </asp:RegularExpressionValidator>
                   </asp:TableCell>
               </asp:TableRow>
         </asp:Table>

            <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonAceptar_Click" />
            <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" CssClass="Boton" OnClick="botonCancelar_Click" />

           </div>

       
          
     


                <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server"/>

</asp:Content>