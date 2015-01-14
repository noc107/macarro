<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_facturacion.aspx.cs" CodeFile="web_07_facturacion.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.web_07_facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">   
    <script src="../../../../comun/resources/js/jquery-1.11.1.js"></script> 
  <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
  <script src="../../../../comun/resources/js/ModuloCierreCaja/moduloCierreCaja.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Cierre de Caja
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Facturación</h2>
            
    <asp:Label ID="MensajeExito" runat="server"  CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="MensajeErrorLista" runat="server"  CssClass="avisoMensaje MensajeError"></asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="BloqueNuevo">
        <div class="BloqueDatosUsuario">
            <asp:Label ID="labelCorreo" runat="server" Text="Correo (*):" CssClass="labelFacturacion TablaNombre labels"></asp:Label>
            <asp:TextBox ID="_textBoxCorreoCliente" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>

            <%-- Validator del Usuario --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="_textBoxCorreoCliente" 
                    ErrorMessage="Debe introducir un ID de usuario." 
                    ForeColor="Red"
                    Text="*"
                    >
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="_textBoxCorreoCliente"
                    ErrorMessage="El ID debe ser un correo" 
                    ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    Text = "*" 
                    >
            </asp:RegularExpressionValidator>
            </asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="_labelNombre" runat="server" Text="Nombre:" CssClass="labelFacturacion TablaNombre labels "></asp:Label>
            <asp:Label ID="_labelNombreIntroducir" runat="server" Text="" CssClass="labels"></asp:Label>
            <br />
            <asp:Label ID="_labelDocumento" runat="server" Text="Documentación:" CssClass="labelFacturacion TablaNombre labels"></asp:Label>
            <asp:Label ID="_labelDocumentoIntroducir" runat="server" Text="" CssClass="labels"></asp:Label>
        </div>
    </div>

    <asp:Panel ID="_bloquesNuevaFactura" runat="server">        
        <div id="Bloques">
            <div id="elementosAbajo">
                <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary2" runat="server"
                    HeaderText=""
                    DisplayMode="BulletList"
                    EnableClientScript="true"  
                    /> <br />

                <div id="buttonsFactura">
                    <asp:Button ID="_crearFactura" runat="server" Text="Crear Factura" CssClass="bFactura Boton botonFactura" OnClick="botonCrearFactura_Click" />
                    <asp:Button ID="_cancelarFactura" runat="server" Text="Cancelar" CausesValidation="false" CssClass="Boton botonFactura" OnClick="botonCancelar_Click" />   
                </div>                
            </div>

        </div>
    </asp:Panel>

    <asp:Panel ID="_bloquesFacturas" runat="server">
    
    <div id="Bloques">
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="Servicios" class="Bloques">   
                
            <h3 class="h3">Lista Servicios</h3>
            <div class="containerBuscadorServicio" style="margin-top: -10px;">
                <asp:TextBox ID="_textBoxBuscar" runat="server"
                        AutoPostBack="True" 
                        EnableTheming="False" 
                        CssClass="buscadorServicio textbox"
                        MaxLength="20"
                        placeholder="Buscar"
                        >
                </asp:TextBox>
                <asp:RegularExpressionValidator ID="expresionRegularBuscar" runat="server" 
                    ControlToValidate="_textBoxBuscar"
                    Text="*"
                    ErrorMessage="No se permiten caracteres especiales."
                    ValidationExpression="[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ ,.]{1,20}"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
                <asp:DropDownList ID="_listaFiltro" runat="server" CssClass="comboFiltro combo_box_estatus">                    
                    <asp:ListItem Value = "0" Selected="True">Todo</asp:ListItem>
                    <asp:ListItem Value = "1">Plato</asp:ListItem>
                    <asp:ListItem Value = "2">Ticket</asp:ListItem>
                    <asp:ListItem Value = "3">Puesto</asp:ListItem>
                    <asp:ListItem Value = "4">Reserva</asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="imgBuscar" 
                    runat="server"
                    ImageUrl="~/comun/resources/img/icon-buscar.png" 
                    CssClass=" botonCualquiera btnSearch"
                    />
            </div>

            <div class="gridServicios">
                
                <asp:GridView CssClass="mGrid" ID="_gridServicios" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="8"
              HorizontalAlign="Center" BorderStyle="None" OnPageIndexChanging="Servicios_PageIndexChanging"  AllowSorting="true" GridLines="None" Width="100%" ForeColor="#99CCFF"
              ShowHeaderWhenEmpty="true" datakeynames="IdLineaFactura">  

                    <AlternatingRowStyle CssClass="alt" />

                    <Columns>    
                        <asp:TemplateField>
                        
                            <ItemTemplate>
                                <asp:CheckBox ID="checkServicios" runat="server" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:BoundField ReadOnly="True" Visible="False" DataField="IdLineaFactura" />
                        <asp:BoundField DataField="ServicioFactura" HeaderText="Nombre Servicio" ControlStyle-Width="150px">  
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" >       
                        <ItemStyle Width="95px" HorizontalAlign="Center" />
                        </asp:BoundField>       
                        
                        <asp:BoundField DataField="Precio" HeaderText="Precio" >       
                        <ItemStyle  HorizontalAlign="Center" />
                        </asp:BoundField>                          
                   
                    </Columns> 
    
                    <PagerStyle CssClass="pgr" /> 
                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
       
                </asp:GridView>
           
            </div>
            <div class="containerMas">                    
                        <asp:ImageButton ID="botonAgregarServicio" runat="server" CssClass="botonServicio agregar" ToolTip="Agregar Servicio" ImageUrl="~/comun/resources/img/agregar.png" OnClick="botonAgregarServicio_Click" />
                    
            </div>
            
        </div>   

        <div id="Factura" class="Bloques">
            <h3 class="h3" style="margin-left:-20px;">Detalle Factura</h3>           
            <div class="gridServicios" style="margin-top: 50px;width:83%;">
                <asp:GridView CssClass="mGrid" ID="_gridDetalleFactura" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="8"
              HorizontalAlign="Center" BorderStyle="None" OnPageIndexChanging="Factura_PageIndexChanging"  AllowSorting="true" GridLines="None" Width="100%" ForeColor="#99CCFF"
              ShowHeaderWhenEmpty="true" datakeynames="IdLineaFactura">  

                    <AlternatingRowStyle CssClass="alt" />

                    <Columns>    
                        <asp:TemplateField>
                        
                            <ItemTemplate>
                                <asp:CheckBox ID="checkFactura" runat="server" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:BoundField ReadOnly="True" Visible="False" DataField="IdLineaFactura" />
                        <asp:BoundField DataField="ServicioFactura" HeaderText="Nombre Servicio" ControlStyle-Width="150px">  
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" >       
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>       

                        <asp:BoundField DataField="Cantidad" HeaderText="Cant."  >       
                        <ItemStyle HorizontalAlign="Center" />                          
                        </asp:BoundField>       
                        
                        <asp:BoundField DataField="Precio" HeaderText="Precio" >       
                        <ItemStyle  HorizontalAlign="Center" />
                        </asp:BoundField>                          
                   
                    </Columns> 
    
                    <PagerStyle CssClass="pgr" /> 
                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
       
                </asp:GridView>
            </div>
            <div class="containerMenos containerMas">
                <asp:ImageButton ID="botonDeshacerServicio" runat="server" CssClass="botonServicio quitar" ToolTip="Deshacer" ImageUrl="~/comun/resources/img/menos.png" OnClick="botonDeshacerServicio_Click" />                
            </div>

            <asp:Label ID="labelMostrarTotal" runat="server" Text="Total:" CssClass="labelTotal TablaNombre labels "></asp:Label>
            <asp:Label ID="_labelTotal" runat="server" Text="800000,00" CssClass="labels"></asp:Label>
            
        
            
  
        </div>

        <div id="elementosAbajo">
            <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1" runat="server"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"  
                /> <br />

            <div id="buttonsFactura">

                <asp:Button ID="botonGuardar" runat="server" Text="Guardar" CssClass="Boton botonFactura" OnClick="botonGuardar_Click" />
                <asp:Button ID="botonFacturar" runat="server" Text="Facturar"  CssClass="Boton botonFactura" OnClick="botonFacturar_Click" />   
            </div>                
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    
    </asp:Panel>
</asp:Content>
