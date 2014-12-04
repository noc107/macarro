<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_CobrarTicket.aspx.cs" Inherits="front_office.Interfaz.web.Estacionamiento.web_5_CobrarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
        <link href="../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
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

        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
            <asp:TableRow>
                <asp:TableCell  HorizontalAlign="Center" >
                    <asp:label ID="LabelMensaje" runat="server" CssClass="labels centrado">  Mensaje de Confirmacion </asp:label>
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                   <asp:TableCell >
                        <asp:label ID="label_placa" runat="server" CssClass="labels">   Placa (*) : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_placa" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                            runat="server" 
                            ControlToValidate="tb_placa" ErrorMessage="No se admiten caracteres especiales"  Text="*" ForeColor="Red"
                           ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                   </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                   <asp:TableCell >
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Ticket Perdido (*) : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:DropDownList CssClass="combo_box" ID="DropDown_estatus" runat="server">
                                <asp:ListItem selected="true">Seleccione</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                                <asp:ListItem>SI</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate ="DropDown_estatus"
                                ErrorMessage="Seleccione el estatus" 
                                Text="*"
                                ForeColor="Red"
                                InitialValue="Seleccione">
                            </asp:RequiredFieldValidator>
                   </asp:TableCell>
             </asp:TableRow>    
            <asp:TableRow ID="fila_fecha_hora_entrada" Visible="False">
                   <asp:TableCell >
                        <asp:label ID="Fh_entrada" runat="server" CssClass="labels">   Fecha y Hora de Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:TextBox ID="tb_fechaHora_entrada" MaxLength="30" runat="server" CssClass="textbox" Enabled="False">04/10/2014 - 02:22 p.m.</asp:TextBox>       
                   </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow ID="fila_fecha_hora_salida" Visible="False">
                   <asp:TableCell >
                        <asp:label ID="Fh_salida" runat="server" CssClass="labels">   Fecha y Hora de Salida : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="TextBox1" MaxLength="30" runat="server" CssClass="textbox" Enabled="False">04/10/2014 - 04:00 p.m.</asp:TextBox>
                   </asp:TableCell>
               </asp:TableRow>
               <asp:TableRow ID="fila_monto" Visible="False">
                   <asp:TableCell >
                        <asp:label ID="label_estatus" runat="server" CssClass="labels">   Monto : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:TextBox ID="tb_monto" MaxLength="30" runat="server" CssClass="textbox" Enabled="False">6 Bs.</asp:TextBox>
                   </asp:TableCell>

               </asp:TableRow>
         </asp:Table>
    <br />
    <div class="boton_centrado">
            <asp:Button ID="Boton_buscar_ticket" runat="server" CssClass="Boton BotonMargin" Text="Buscar"/>
            <asp:Button ID="BotonPagarEstacionamiento" runat="server" CssClass="Boton BotonMargin" Text="Cobrar" Visible="false" />
        </div> 
    <br />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
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
