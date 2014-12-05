<%@ Page Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_06_modificarItem.aspx.cs" Inherits="back_office.Interfaz.web.InventarioRestaurante.web_06_modificarItem" %>



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
    <h2>Modificar Item</h2>
    <div id="Mensajes" class="BloqueMensaje">
        <asp:Label ID="MensajeFallo" CssClass="LabelMensajeFallo" runat="server" Text="El item no ha podido ser modificado debido a que X" Visible="false"></asp:Label>
    </div>
   <div ID="Formulario1" class="Bloque">

        <script src="../../../comun/resources/js/jquery-1.11.1.js"></script>
    <script src="../../../comun/resources/js/ModuloInventarioRestaurante/bootstrap.min.js"></script>
 <link href="../../../comun/resources/css/InventarioRestaurante/modalWindow.css" rel="stylesheet" type="text/css" />

           <span id="error" style="color: Red; display: none"></span>
    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>
       
       
       <asp:Label ID="lbNombre" CssClass="labels LabelAgregarNombre" runat="server" Text="Nombre (*):" ></asp:Label>
       <asp:TextBox ID="tbNombre" CssClass="textbox TextboxAgregarNombre" runat="server" Text="Pasta" maxlength="50"></asp:TextBox>

       <asp:RequiredFieldValidator CssClass="ValidacionNombreAgregar" ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbNombre" Text="*" ForeColor="Red" ErrorMessage="Nombre Requerido">
        </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator CssClass="ValidacionNombreAgregar" ID="Validator9" runat="server"
                    ControlToValidate="tbNombre" Text="*" ForeColor="Red" ErrorMessage="El nombre deben ser letras (3-50)"
                    ValidationExpression="[ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú]{3,50}$">
       </asp:RegularExpressionValidator>
       

        <asp:Button ID="Boton1" CssClass="Boton BotonAceptarModificar"  runat="server" Text="Aceptar" OnClientClick="if (confirm('Está accion modificara el item en el sistema ¿Desea continuar?')) return alert('Los datos se han modificado satisfactoriamente.');" OnClick="Button1_Click" />
        <asp:Button ID="Boton2" CssClass="Boton BotonCancelarModificar"  runat="server" Text="Cancelar"  OnClick="Button2_Click" />
       
        <asp:Label ID="Label2" CssClass="labels LabelAgregarCantidad"  runat="server" Text="Cantidad (*):"></asp:Label>
        <asp:TextBox ID="tbCantidad" CssClass="textbox TextboxAgregarCantidad"  
            runat="server"  Text="20" maxlength="4" onblur="javascript: if(this.value==''){this.value='0';}"
            onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="ValidacionCantidadAgregar" ID="ValidatorReq2" runat="server" 
                    ControlToValidate="tbCantidad" Text="*" ForeColor="Red" ErrorMessage="Cantidad Requerida">
        </asp:RequiredFieldValidator>
       
       <asp:RegularExpressionValidator CssClass="ValidacionCantidadAgregar" ID="Validator7" runat="server" 
                    ControlToValidate="tbCantidad" 
                    Text="*"
                    ErrorMessage="Cantidad debe ser un numero sin decimales" 
                    ForeColor="Red" 
                    ValidationExpression="(^\d+)">
                </asp:RegularExpressionValidator>
       <asp:RangeValidator ID="Validator11" CssClass="ValidacionCantidadAgregar" runat="server"   
                           MinimumValue="0" MaximumValue="9999" ControlToValidate="tbCantidad" Text="*" ForeColor="Red" ErrorMessage="La cantidad excede el rango (0-9999)"
                           Type="Integer" >
       </asp:RangeValidator>

       
        <asp:Label ID="Label3" CssClass="labels LabelAgregarDescripcion"  runat="server" Text="Descripción:"  ></asp:Label>
        <asp:TextBox ID="tbDescripcion" CssClass="textbox TextboxAgregarDescripcion"   runat="server" Text="Este es un item" maxlength="99"></asp:TextBox>
        <asp:RegularExpressionValidator CssClass="ValidacionDescripcionAgregar" ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="tbDescripcion" Text="*" ForeColor="Red" ErrorMessage="Descripcion excede el rango (0-99)"
                    ValidationExpression="[ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú]">
       </asp:RegularExpressionValidator>
        <asp:Label ID="Label6" CssClass="labels LabelAgregarPrecioVenta"  runat="server" Text="Precio Venta (*):" ></asp:Label>
        <asp:TextBox ID="tbPrecio" CssClass="textbox TextboxAgregarPrecioVenta"  runat="server" Text="500" maxlength="8"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="Validator3" runat="server" ControlToValidate="tbPrecio" 
            Text="*" ForeColor="Red" CssClass="ValidacionPrecioAgregar" ErrorMessage="Precio de Venta Requerido">

        </asp:RequiredFieldValidator>

       <asp:RegularExpressionValidator CssClass="ValidacionPrecioAgregar" ID="Validator6" runat="server" 
                    ControlToValidate="tbPrecio" 
                    Text="*"
                    ErrorMessage="Precio Venta debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.\d+)?$">
                </asp:RegularExpressionValidator>

        
        <asp:Label ID="Label7" CssClass="labels LabelAgregarPrecioCompra" runat="server" Text="Precio Compra (*):" ></asp:Label>
        <asp:TextBox ID="tbPrecio2" CssClass="textbox TextboxAgregarPrecioCompra" runat="server" Text="400" maxlength="8" ></asp:TextBox>

       <asp:RequiredFieldValidator ID="Validator4" runat="server" ControlToValidate="tbPrecio2" 
            Text="*" ForeColor="Red" CssClass="ValidacionPrecio2Agregar" ErrorMessage="Precio de Compra Requerido">
        </asp:RequiredFieldValidator>
       
       
       <asp:RegularExpressionValidator CssClass="ValidacionPrecio2Agregar" ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tbPrecio2" 
                    Text="*"
                    ErrorMessage="Precio Compra debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.\d+)?$">
                </asp:RegularExpressionValidator>

        <asp:Label ID="Label4" CssClass="labels LabelAgregarProveedor"  runat="server"  Text="Proveedor (*): " ></asp:Label>
            <asp:DropDownList ID="Proveedores" CssClass="combo_box ComboProveedor" runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" >
             <asp:ListItem Text="Proveedor 1" Selected="True"></asp:ListItem>
             <asp:ListItem Text="Proovedor 2"></asp:ListItem>
            </asp:DropDownList>
     
   <asp:ValidationSummary ID="ValidationSummary1" CssClass="avisoMensaje MensajeError"
                style="top:370px;position:absolute;" HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
               />


       
  <!-- Modal Window Agregar -->
        <div id="modalAgregar" class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm modal-dialog-center">
                 <div class="modal-content">

                <div class="modal-header">
                   <h4 class="modal-title" id="myModalLabel">Aumentar Cantidad</h4>
                </div>
                <div class="modal-body">
                

                    <asp:Label ID="Label1" CssClass="labels"  runat="server" Text="Agregar:"></asp:Label>
        <asp:TextBox ID="TextBoxAumentarCantidad" CssClass="textbox"  Width="180" Height="30"  runat="server" maxlength="4"></asp:TextBox>


                </div>
                <div class="modal-footer">
                     <asp:Button ID="Button1"   runat="server" CssClass="Boton" Text="Aceptar" OnClick="ButtonAceptarModalAumentar_Click"/>
        <asp:Button ID="Button2"   runat="server" Text="Cancelar" CssClass="Boton" OnClick="ButtonCancelarModalAumentar_Click" />
       
                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <!-- Modal Window Restar -->
        <div id="modalEliminar" class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm modal-dialog-center">
                 <div class="modal-content">

                <div class="modal-header">
                    
                    <h4 class="modal-title" id="H1">Restar Cantidad</h4>
                </div>
                <div class="modal-body">
                

                    <asp:Label ID="Label5"  runat="server" CssClass="labels" Text="Restar:"></asp:Label>
        <asp:TextBox ID="TextBoxRestarCantidad" CssClass="textbox" Width="190" Height="30" runat="server" maxlength="4"></asp:TextBox>


                </div>
                <div class="modal-footer">
                     <asp:Button ID="botonAceptarResta"  runat="server" CssClass="Boton" Text="Aceptar" OnClick="ButtonAceptarModalRestar_Click" />
        <asp:Button ID="botonCancelarModalRestar"  runat="server" Text="Cancelar" CssClass="Boton"  OnClick="ButtonCancelarModalRestar_Click"/>
       
                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


        <asp:ImageButton id="ImageButton1" runat="server" data-target="#modalAgregar" cssclass="mas_menos_info BotonMas"
              data-toggle="modal" ImageUrl="../../../comun/resources/img/Agregar.png"  OnClientClick="javascript: return false;"/>

     <asp:ImageButton id="ImageButton2" runat="server" data-target="#modalEliminar" cssclass="mas_menos_info BotonMenos"
              data-toggle="modal" ImageUrl="../../../comun/resources/img/menos.png" OnClientClick="javascript:return false;" />






       </div>
</asp:Content>
