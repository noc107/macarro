<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None"
     AutoEventWireup="true" CodeBehind="web_07_modificarSombrilla1.aspx.cs" 
    Inherits="FrontOffice.Presentacion.Vistas.Web.Reservas.web_07_modificarSombrilla1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

     <link href="../../../../comun/resources/css/Reservas/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reservacion Puesto y Sombrilla
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
    <h2>Reservacion de Puesto y Sombrilla</h2>
    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la cuenta." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>

    <div id="reservar" >            
     <asp:Table ID="tabla" runat="server" HorizontalAlign="Center" CssClass ="tabla"> 
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

                <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_horai" runat="server" CssClass="labels">   Hora Inicio <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                <asp:TextBox ID="tb_hora_i" MaxLength="30" runat="server" CssClass="textbox" TextMode="Time"></asp:TextBox>

                             <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server"
                    ControlToValidate="tb_hora_i"
                    Text="*"
                    ErrorMessage="Hora Inicio Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                                

                   </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="label_horaf" runat="server" CssClass="labels">   Hora Fin <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                 <asp:TextBox ID="dd_hora_f" MaxLength="30" runat="server" CssClass="textbox" TextMode="Time"></asp:TextBox>
                  <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                    ControlToValidate="dd_hora_f"
                    Text="*"
                    ErrorMessage="Hora Fin Requerida"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                       
                         </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                
                     
                       
                        
               </asp:TableRow>
         </asp:Table>
      

             <p> Su puesto de playa viene incluido con: <b> sombrilla, mesa y dos sillas.
            </b> </p>
         <asp:Button CssClass="Boton" ID="Button1" runat="server"  Text="Aceptar" OnClick="Button1_Click" />
          
         <asp:Button CssClass="Boton" ID="Button2" runat="server"  Text="Cancelar" OnClick="Button2_Click" />
    </div>


    <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
  />
    <p></p>
</asp:Content>

