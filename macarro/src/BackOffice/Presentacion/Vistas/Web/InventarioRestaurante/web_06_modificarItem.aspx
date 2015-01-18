﻿<%@ Page Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_06_modificarItem.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.InventarioRestaurante.web_06_modificarItem" %>



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
    <link href="../../../../comun/resources/css/InventarioRestaurante/Estilos.css" rel="stylesheet" />
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

          <asp:Label ID="_mensajeExito" CssClass="avisoMensaje MensajeExito"   runat="server" Text="El item ha sido creado satisfactoriamente" Visible="false" ></asp:Label>
        <asp:Label ID="_mensajeError" CssClass="avisoMensaje MensajeError" runat="server" Text="El item no ha podido ser modificado debido a que X" Visible="false"></asp:Label>
    </div>
   <div id="Formulario1" class="Bloque">

        <script src="../../../../comun/resources/js/jquery-1.11.1.js"></script>
    <script src="../../../../comun/resources/js/ModuloInventarioRestaurante/bootstrap.min.js"></script>
 <link href="../../../../comun/resources/css/InventarioRestaurante/modalWindow.css" rel="stylesheet" type="text/css" />

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

       <script>
           function validacionesOk() {
               if (Page_ClientValidate() == true) {
                   confirm("Está a punto de modificar el Item. ¿Desea continuar?");
               }
           }
    </script>
       
       
       <asp:Label ID="lbNombre" CssClass="labels LabelAgregarNombre" runat="server" Text="Nombre (*):" ></asp:Label>
       <asp:TextBox ID="_nombre" CssClass="textbox TextboxAgregarNombre" runat="server" maxlength="50"></asp:TextBox>

       <asp:RequiredFieldValidator CssClass="ValidacionNombreAgregar" ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="_nombre" Text="*" ForeColor="Red" ErrorMessage="Nombre Requerido">
        </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator CssClass="ValidacionNombreAgregar" ID="Validator9" runat="server"
                    ControlToValidate="_nombre" Text="*" ForeColor="Red" ErrorMessage="El nombre deben ser letras (3-50)"
                    ValidationExpression="[ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú ]{3,50}$">
       </asp:RegularExpressionValidator>
       

   

       
        <asp:Label ID="Label2" CssClass="labels LabelAgregarCantidad"  runat="server" Text="Cantidad (*):"></asp:Label>
        <asp:TextBox ID="_cantidad" CssClass="textbox TextboxAgregarCantidad"  
            runat="server" maxlength="4" onblur="javascript: if(this.value==''){this.value='0';}"
            onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="ValidacionCantidadAgregar" ID="ValidatorReq2" runat="server" 
                    ControlToValidate="_cantidad" Text="*" ForeColor="Red" ErrorMessage="Cantidad Requerida">
        </asp:RequiredFieldValidator>
       
       <asp:RegularExpressionValidator CssClass="ValidacionCantidadAgregar" ID="Validator7" runat="server" 
                    ControlToValidate="_cantidad" 
                    Text="*"
                    ErrorMessage="Cantidad debe ser un numero sin decimales" 
                    ForeColor="Red" 
                    ValidationExpression="(^\d+)">
                </asp:RegularExpressionValidator>
       <asp:RangeValidator ID="Validator11" CssClass="ValidacionCantidadAgregar" runat="server"   
                           MinimumValue="0" MaximumValue="9999" ControlToValidate="_cantidad" Text="*" ForeColor="Red" ErrorMessage="La cantidad excede el rango (0-9999)"
                           Type="Integer" >
       </asp:RangeValidator>

       
        <asp:Label ID="Label3" CssClass="labels LabelAgregarDescripcion"  runat="server" Text="Descripción:"  ></asp:Label>
        <asp:TextBox ID="_descripcion" CssClass="textbox TextboxAgregarDescripcion"   runat="server" maxlength="99"></asp:TextBox>
        <asp:RegularExpressionValidator CssClass="ValidacionDescripcionAgregar" ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="_descripcion" Text="*" ForeColor="Red" ErrorMessage="Descripcion excede el rango (0-99)"
                    ValidationExpression="[,.1234567890ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú ]{0,99}$">
       </asp:RegularExpressionValidator> 

        <asp:Label ID="Label6" CssClass="labels LabelAgregarPrecioVenta"  runat="server" Text="Precio Venta (*):" ></asp:Label>
        <asp:TextBox ID="_precioVenta" CssClass="textbox TextboxAgregarPrecioVenta"  runat="server" maxlength="8"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="Validator3" runat="server" ControlToValidate="_precioVenta" 
            Text="*" ForeColor="Red" CssClass="ValidacionPrecioAgregar" ErrorMessage="Precio de Venta Requerido">

        </asp:RequiredFieldValidator>

       <asp:RegularExpressionValidator CssClass="ValidacionPrecioAgregar" ID="Validator6" runat="server" 
                    ControlToValidate="_precioVenta" 
                    Text="*"
                    ErrorMessage="Precio Venta debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.\d+)?$">
                </asp:RegularExpressionValidator>

        
        <asp:Label ID="Label7" CssClass="labels LabelAgregarPrecioCompra" runat="server" Text="Precio Compra (*):" ></asp:Label>
        <asp:TextBox ID="_precioCompra" CssClass="textbox TextboxAgregarPrecioCompra" runat="server" maxlength="8" ></asp:TextBox>

       <asp:RequiredFieldValidator ID="Validator4" runat="server" ControlToValidate="_precioCompra" 
            Text="*" ForeColor="Red" CssClass="ValidacionPrecio2Agregar" ErrorMessage="Precio de Compra Requerido">
        </asp:RequiredFieldValidator>
       
       
       <asp:RegularExpressionValidator CssClass="ValidacionPrecio2Agregar" ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="_precioCompra" 
                    Text="*"
                    ErrorMessage="Precio Compra debe ser numerico" 
                    ForeColor="Red" 
                    ValidationExpression="^\d+(.\d+)?$">
                </asp:RegularExpressionValidator>

        <asp:Label ID="Label4" CssClass="labels LabelAgregarProveedor"  runat="server"  Text="Proveedor (*): " ></asp:Label>
            <asp:DropDownList ID="_proveedor" CssClass="combo_box ComboProveedor" runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" >
            </asp:DropDownList>

       <asp:Label ID="Label8" CssClass="labels LabelAgregarEstado"  runat="server"  Text="Estado (*): " ></asp:Label>
            <asp:DropDownList ID="_estado" CssClass="combo_box ComboEstado" runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" >
                  <asp:listitem Value="true" text="Activado"/>
                  <asp:listitem text="Desactivado" Value="false" />
            </asp:DropDownList>


            <asp:Button ID="Boton1" CssClass="Boton BotonAceptarModificar"  runat="server" Text="Aceptar"   OnClick="Button1_Click" />

        <asp:Button ID="Boton2" CssClass="Boton BotonCancelarModificar" CausesValidation="false" runat="server" Text="Cancelar"  OnClick="Button2_Click" />
     
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
        <asp:TextBox ID="_aumentarCantidad" CssClass="textbox"  Width="180" Height="30"  runat="server" maxlength="4"></asp:TextBox>


                </div>
                <div class="modal-footer" >
                     <asp:Button ID="Button1"   runat="server" CausesValidation="false" CssClass="Boton" Text="Aceptar" OnClick="ButtonAceptarModalAumentar_Click"/>
        <asp:Button ID="Button2"   runat="server" Text="Cancelar"  CausesValidation="false" CssClass="Boton" OnClick="ButtonCancelarModalAumentar_Click" />
       
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
        <asp:TextBox ID="_restarCantidad" CssClass="textbox" Width="190" Height="30" runat="server" maxlength="4"></asp:TextBox>


                </div>
                <div class="modal-footer">
                     <asp:Button ID="botonAceptarResta" CausesValidation="false" runat="server" CssClass="Boton" Text="Aceptar" OnClick="ButtonAceptarModalRestar_Click" />
        <asp:Button ID="botonCancelarModalRestar" CausesValidation="false" runat="server" Text="Cancelar" CssClass="Boton"  OnClick="ButtonCancelarModalRestar_Click"/>
       
                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


   


        <asp:ImageButton id="ImageButton1" runat="server" data-target="#modalAgregar" cssclass="mas_menos_info BotonMas"
              data-toggle="modal" ImageUrl="../../../../comun/resources/img/Agregar.png"  OnClientClick="javascript:return false;" OnClick="ButtonMasoMenos_Click"/>

     <asp:ImageButton id="ImageButton2" runat="server" data-target="#modalEliminar" cssclass="mas_menos_info BotonMenos"
              data-toggle="modal" ImageUrl="../../../../comun/resources/img/menos.png" OnClientClick="javascript:return false;" />






       </div>
</asp:Content>