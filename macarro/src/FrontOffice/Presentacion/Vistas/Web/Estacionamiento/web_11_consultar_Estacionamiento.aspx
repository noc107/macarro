<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_consultar_Estacionamiento.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Estacionamiento.web_11_consultar_Estacionamiento" %>
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
    <h2>Consultar Estacionamiento</h2>
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
               <asp:TableRow>
                   <asp:TableCell >
                        <asp:label ID="label1" runat="server" CssClass="labels">   Estacionamiento (*) : </asp:label>
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
                <asp:TableRow ID="fila_nombre" Visible="False">
                   <asp:TableCell  >
                        <asp:label ID="label_nombre" runat="server" CssClass="labels">   Nombre : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_fechaHora_entrada" MaxLength="30" runat="server" CssClass="textbox">Est. Playa Sur.</asp:TextBox>
                   </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="fila_capacidad" Visible="False">
                   <asp:TableCell  >
                        <asp:label ID="label_Capacidad" runat="server" CssClass="labels">   Capacidad : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="TextBox1" MaxLength="30" runat="server" CssClass="textbox"> 100 Puestos</asp:TextBox>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow ID="fila_tarifa" Visible="False">
                   <asp:TableCell  >
                        <asp:label ID="label_Tarifa" runat="server" CssClass="labels">   Tarifa Horaria: </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                       <asp:TextBox ID="tb_tarifa" MaxLength="30" runat="server" CssClass="textbox"> 3 Bs.</asp:TextBox>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow ID="tarifa_perdido" Visible="False">
                   <asp:TableCell  >
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Tarifa de Ticket Perdido : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_perdido" MaxLength="30" runat="server" CssClass="textbox">300 Bs</asp:TextBox>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow ID="fila_estatus" Visible="False">
                   <asp:TableCell  >
                        <asp:label ID="label_estatus" runat="server" CssClass="labels">   Estatus : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:TextBox ID="TextBox2" MaxLength="30" runat="server" CssClass="textbox">Activo</asp:TextBox>
                   </asp:TableCell>

               </asp:TableRow>
         </asp:Table>
    <br />
    <div>
    <div class="boton_centrado">
            <asp:Button ID="BotonAgregarEstacionamiento" runat="server" CssClass="Boton" Text="Buscar"/>
        </div>
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
