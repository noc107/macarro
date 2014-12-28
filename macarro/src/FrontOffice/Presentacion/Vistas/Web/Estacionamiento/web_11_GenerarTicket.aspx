<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_GenerarTicket.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Estacionamiento.web_5_GenerarTicket" %>
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
        <asp:label ID="LabelMensajeExito" runat="server" CssClass="avisoMensajeBot MensajeExito Textocentrado" Visible="false">  Estacionamiento agregado con Éxito </asp:label>
    <asp:label ID="LabelMensajeError" runat="server" CssClass="avisoMensajeBot MensajeError Textocentrado" Visible="false">  Estacionamiento no Agregado </asp:label>
   
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
            <asp:TableRow>
                <asp:TableCell  Height="50">
                    <asp:label ID="label2" runat="server" CssClass="labels">   Estacionamiento (*): </asp:label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList CssClass="combo_box" ID="DropDown_estacionamiento" runat="server" AutoPostBack="True" OnSelectedIndexChanged = "comboEstacionamientoSelector">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate ="DropDown_estacionamiento"
                                ErrorMessage="Seleccione Estacionamiento" 
                                Text="*"
                                ForeColor="Red"
                                InitialValue="Seleccione Estacionamiento">
                            </asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>   
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Placa : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_placa" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                        

                   </asp:TableCell>
               </asp:TableRow>          
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label1" runat="server" CssClass="labels">   Fecha de Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_fechaEntrada" MaxLength="30" runat="server" CssClass="textbox" ViewStateMode="Inherit" Enabled="False"></asp:TextBox>
                   </asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label4" runat="server" CssClass="labels">   Hora de Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_horaEntrada" MaxLength="30" runat="server" CssClass="textbox" ViewStateMode="Inherit" Enabled="False">12:55 p.m.</asp:TextBox>
                   </asp:TableCell>
            </asp:TableRow>  

         </asp:Table>
    <br />
    <div class="boton_centrado">
            <asp:Button ID="BotonGenerarTicket" runat="server" CssClass="Boton" Text="Aceptar" OnClick="BotonGenerarTicket_Click"/>
        </div>
    <br />
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ValidationSummary ID="ValidationSummary2"
                    HeaderText=""
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server" 
                    ForeColor="Red"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
 