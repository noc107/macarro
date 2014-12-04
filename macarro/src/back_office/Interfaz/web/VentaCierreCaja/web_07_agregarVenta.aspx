<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_agregarVenta.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Cierre de Caja
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Agregar Venta</h2>
            
    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la cuenta." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="MensajeErrorLista" runat="server" Text="Debes seleccionar un servicio." Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>

    <div id="Bloques">
    <div id="Servicios" class="Bloques">
        <h3 class="h3">Agregar Servicio</h3>
            <asp:ListBox ID="ListaServicios" runat="server" CssClass="list_box listaServicios">
                <asp:ListItem Value="servicio1">Servicio 1</asp:ListItem>
                <asp:ListItem Value="servicio2">Servicio 2</asp:ListItem>
                <asp:ListItem Value="servicio3">Servicio 3</asp:ListItem>
                <asp:ListItem Value="servicio4">Servicio 4</asp:ListItem>
            </asp:ListBox>
        
        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="botonServicio agregar" ToolTip="Agregar Servicio" ImageUrl="~/comun/resources/img/agregar.png" OnClick="ButtonAgregarServicio_Click" />
        
    </div>
    
    <div id="Factura" class="Bloques">
        <h3 class="h3">Detalle Factura</h3>
       
        
            
        
        <div id="tablaFactura">
        <asp:Table ID="TableFactura" runat="server" CssClass="detalleFactura" CellSpacing="0" HorizontalAlign="Center">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="2">Servicio</asp:TableHeaderCell>
                <asp:TableHeaderCell>Cant</asp:TableHeaderCell>
                <asp:TableHeaderCell>Total</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow CssClass="alterna">
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 1</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 2</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="alterna">
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 3</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 4</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="alterna">
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 5</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 6</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow >
            <asp:TableRow CssClass="alterna">
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 7</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 8</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="alterna">
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 9</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="celda" ColumnSpan="2">Servicio 10</asp:TableCell>
                <asp:TableCell CssClass="celda">1</asp:TableCell>
                <asp:TableCell CssClass="celda">00.0</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </div>
        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="botonServicio quitar" ToolTip="Deshacer" ImageUrl="~/comun/resources/img/menos.png" />
        
            
  
    </div>

        <div id="elementosAbajo">
                    <div id="listaRadioButtons">                              
                        <asp:RadioButtonList ID="cliente" runat="server" CssClass="radio_list" RepeatDirection="Horizontal">
                            <asp:ListItem selected="true" Value="0">Cliente</asp:ListItem>
                            <asp:ListItem Value="1">Miembro</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>   
                    <div id="campoUsuario" class="bloqueElemento">
                        <asp:Label ID="LabelIdClienteMiembro" runat="server" Text="ID (*):" CssClass="labels"></asp:Label>
                        <asp:TextBox ID="TextBoxCliente" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>

                        <%-- Validator del Usuario --%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                               ControlToValidate="TextBoxCliente" 
                               ErrorMessage="Debe introducir un ID de usuario." 
                               ForeColor="Red"
                               Text="*"
                               >
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="TextBoxCliente"
                                ErrorMessage="El ID debe ser un correo" 
                                ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Text = "*" 
                                >
                        </asp:RegularExpressionValidator>
                     </div>
                     <div id="campoTicket" class="bloqueElemento">   
                        <asp:Label ID="LabelTicket" runat="server" Text="Ticket:" CssClass="labels"></asp:Label>
                        <asp:TextBox ID="TextBoxTicket" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>

                        <%-- Validator del ticket --%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="TextBoxTicket"
                                ErrorMessage="El Ticket debe ser numérico" 
                                ForeColor="Red" 
                                ValidationExpression="(^\d+)"
                                Text = "*"
                                >
                        </asp:RegularExpressionValidator>

                    </div>

                        <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1" runat="server"
                            HeaderText=""
                            DisplayMode="BulletList"
                            EnableClientScript="true"  
                            /> <br />

                    <div id="buttonsFactura">
                        <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="Boton botonFactura" OnClick="ButtonAgregar_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Facturar" CssClass="Boton botonFactura" OnClick="ButtonFacturar_Click" />   
                    </div>                
        </div>
    </div>
</asp:Content>
