<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_GenerarTicket.aspx.cs" Inherits="front_office.Interfaz.web.Estacionamiento.web_5_GenerarTicket" %>
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
      <h2>Generar Ticket</h2>
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
            <asp:TableRow>
                <asp:TableCell  HorizontalAlign="Center" >
                    <asp:label ID="LabelMensaje" runat="server" CssClass="labels centrado">  Mensaje de Confirmacion </asp:label>
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow>
                <asp:TableCell  Height="50">
                    <asp:label ID="label2" runat="server" CssClass="labels">   Estacionamiento (*): </asp:label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList CssClass="combo_box" ID="DropDown_estacionamiento" runat="server">
                        <asp:ListItem selected="true">Seleccione Estacionamiento</asp:ListItem>
                        <asp:ListItem>Estacionamiento 1</asp:ListItem>
                        <asp:ListItem>Estacionamiento 2</asp:ListItem>
                        <asp:ListItem>Estacionamiento 3</asp:ListItem>
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
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                            runat="server" 
                            ControlToValidate="tb_placa" ErrorMessage="No se admiten caracteres especiales"  Text="*" ForeColor="Red"
                           ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                   </asp:TableCell>
               </asp:TableRow>          
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label1" runat="server" CssClass="labels">   Fecha de Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="TextBox1" MaxLength="30" runat="server" CssClass="textbox" ViewStateMode="Inherit" Enabled="False">10/12/2014</asp:TextBox>
                   </asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label4" runat="server" CssClass="labels">   Hora de Entrada : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="TextBox3" MaxLength="30" runat="server" CssClass="textbox" ViewStateMode="Inherit" Enabled="False">12:55 p.m.</asp:TextBox>
                   </asp:TableCell>
            </asp:TableRow>  
            <asp:TableRow>
                   <asp:TableCell  Height="50">
                        <asp:label ID="label3" runat="server" CssClass="labels">   Tarifa : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="TextBox2" MaxLength="30" runat="server" CssClass="textbox" ViewStateMode="Inherit" Enabled="False">3 Bs x Hora</asp:TextBox>
                   </asp:TableCell>
            </asp:TableRow> 
         </asp:Table>
    <br />
    <div class="boton_centrado">
            <asp:Button ID="BotonGenerarTicket" runat="server" CssClass="Boton" Text="Aceptar"/>
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
 