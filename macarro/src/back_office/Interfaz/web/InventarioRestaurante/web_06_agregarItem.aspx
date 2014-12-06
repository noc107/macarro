<%@ Page Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_06_agregarItem.aspx.cs" Inherits="back_office.Interfaz.web.InventarioRestaurante.web_06_agregarItem" %>


<script runat="server">

    protected void Label1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/InventarioRestaurante/Estilos.css" rel="stylesheet" />
    <link href="../../../comun/resources/css/standards.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato, Daniel 
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Gestion de Inventario
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Agregar Item</h2>
    <div ID="Mensaje" class="BloqueMensaje" >
        <asp:Label ID="MensajeExito" CssClass="avisoMensaje MensajeExito"   runat="server" Text="El item ha sido creado satisfactoriamente" Visible="false" ></asp:Label>
        <asp:Label ID="MensajeFallo" CssClass="avisoMensaje MensajeError"   runat="server" Text="El item no ha podido ser creado debido a que X" Visible="false"></asp:Label>
    </div>
   <div ID="Formulario" class="Bloque">
       
       
       <asp:Label ID="lbCantidadMinima" CssClass="labels LabelAgregarCantidadMinima" runat="server" Text="Cantidad minima(*):" ></asp:Label>
       <asp:TextBox ID="tbCantidadMinima" CssClass="textbox TextboxAgregarCantidadMinima" runat="server"  maxlength="50"></asp:TextBox>
       <asp:RequiredFieldValidator ID="ValidacionCantidadminima1" CssClass="ValidacionCantidadMinima" runat="server"    
            ControlToValidate="tbCantidadMinima" Text="*" ForeColor="Red" ErrorMessage="Cantidad Minima Requerida">

       </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator CssClass="ValidacionCantidadMinima" ID="ValidacionUltima" runat="server" 
                    ControlToValidate="tbCantidadMinima" 
                    Text="*"
                    ErrorMessage="Cantidad debe ser un numero entero, Ejemplo: 10" 
                    ForeColor="Red" 
                    ValidationExpression="(^\d+)">
                </asp:RegularExpressionValidator>
       <asp:Label ID="lbNombre" CssClass="labels LabelAgregarNombre" runat="server" Text="Nombre(*):" ></asp:Label>
       <asp:TextBox ID="Nombre" CssClass="textbox TextboxAgregarNombre" runat="server"  maxlength="50"></asp:TextBox>
      
       <asp:RequiredFieldValidator CssClass="ValidacionNombreAgregar" ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Nombre" Text="*" ForeColor="Red" ErrorMessage="Nombre Requerido">
        </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator CssClass="ValidacionNombreAgregar" ID="Validator9" runat="server"
                    ControlToValidate="Nombre" Text="*" ForeColor="Red" ErrorMessage="El nombre deben ser letras (3-50)"
                    ValidationExpression="[ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú ]{3,50}$">
       </asp:RegularExpressionValidator>
       
        
        <asp:Button ID="Boton1" CssClass="Boton BotonAgregar"  runat="server" Text="Aceptar"  OnClick="Button1_Click" />
   
       
        <asp:Label ID="Label2" CssClass="labels LabelAgregarCantidad"  runat="server" Text="Cantidad(*):" ></asp:Label>
        <asp:TextBox ID="Cantidad" CssClass="textbox TextboxAgregarCantidad"  runat="server"  maxlength="4"></asp:TextBox>
        
       <asp:RequiredFieldValidator CssClass="ValidacionCantidadAgregar" ID="ValidatorReq2" runat="server" 
                    ControlToValidate="Cantidad" Text="*" ForeColor="Red" ErrorMessage="Cantidad Requerida">
        </asp:RequiredFieldValidator>
       
       <asp:RegularExpressionValidator CssClass="ValidacionCantidadAgregar" ID="Validator7" runat="server" 
                    ControlToValidate="Cantidad" 
                    Text="*"
                    ErrorMessage="Cantidad debe ser un numero sin decimales" 
                    ForeColor="Red" 
                    ValidationExpression="(^\d+)">
                </asp:RegularExpressionValidator>
       <asp:RangeValidator ID="Validator11" CssClass="ValidacionCantidadAgregar" runat="server"   
                           MinimumValue="1" MaximumValue="9999" ControlToValidate="Cantidad" Text="*" ForeColor="Red" ErrorMessage="La cantidad excede el rango (1-9999)"
                           Type="Integer" >
       </asp:RangeValidator>

        <asp:Label ID="Label3" CssClass="labels LabelAgregarDescripcion"  runat="server" Text="Descripción:"  ></asp:Label>
        <asp:TextBox ID="tbDescripcion" CssClass="textbox TextboxAgregarDescripcion" runat="server" maxlength="99"></asp:TextBox>
        <asp:RegularExpressionValidator CssClass="ValidacionDescripcionAgregar" ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="tbDescripcion" Text="*" ForeColor="Red" ErrorMessage="Descripcion excede el rango (0-99)"
                    ValidationExpression="[ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú ]{0,99}$">
       </asp:RegularExpressionValidator> 

        <asp:Label ID="Label6" CssClass="labels LabelAgregarPrecioVenta"  runat="server" Text="Precio Venta(*):" ></asp:Label>
        <asp:TextBox ID="tbPrecio" CssClass="textbox TextboxAgregarPrecioVenta"   runat="server" maxlength="8"></asp:TextBox>

        <asp:RequiredFieldValidator ID="Validator3" runat="server" ControlToValidate="tbPrecio" 
            Text="*" ForeColor="Red" CssClass="ValidacionPrecioAgregar" ErrorMessage="Precio de Venta Requerido">

        </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator CssClass="ValidacionPrecioAgregar" ID="ValidacionPrecioVentaFloat" runat="server"
            ControlToValidate="tbPrecio" Text="*" ForeColor="Red" ErrorMessage="Precio Venta debe ser numerico, ejemplo: 12.6"
            ValidationExpression="^\d+(.\d+)?$">
       </asp:RegularExpressionValidator>
       
       
        <asp:Label ID="Label7" CssClass="labels LabelAgregarPrecioCompra"  runat="server" Text="Precio Compra(*):" ></asp:Label>
        <asp:TextBox ID="tbPrecio2" CssClass="textbox TextboxAgregarPrecioCompra"  runat="server" maxlength="8"></asp:TextBox>
       <asp:RequiredFieldValidator ID="Validator4" runat="server" ControlToValidate="tbPrecio2" 
            Text="*" ForeColor="Red" CssClass="ValidacionPrecio2Agregar" ErrorMessage="Precio de Compra Requerido">
        </asp:RequiredFieldValidator>
       
       <asp:RegularExpressionValidator CssClass="ValidacionPrecio2Agregar" ID="ValidacionPrecioCompraFloat" runat="server"
            ControlToValidate="tbPrecio2" Text="*" ForeColor="Red" ErrorMessage="Precio Compra debe ser numerico, ejemplo: 12.6"
            ValidationExpression="^\d+(.\d+)?$">
       </asp:RegularExpressionValidator>

        <asp:Label  ID="Label4" CssClass="labels LabelAgregarProveedor" runat="server"  Text="Proveedor(*): " ></asp:Label>
            <asp:DropDownList ID="Proveedores" CssClass="combo_box ComboProveedor" runat="server"  OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" >
             <asp:ListItem Text="Seleccione un Proveedor"></asp:ListItem>
            </asp:DropDownList>
         <asp:RequiredFieldValidator CssClass="ValidacionProveedorAgregar" ID="Validator5" 
        runat="server" ControlToValidate ="Proveedores"
        ErrorMessage="Seleccionar Proveedor" 
        InitialValue="Seleccione un Proveedor" Text="*" ForeColor="Red">
        </asp:RequiredFieldValidator>
       <asp:ValidationSummary ID="ValidationSummary1" CssClass="avisoMensaje MensajeError "
                style="top:370px;position:absolute;" HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                />
     
       </div>
</asp:Content>
