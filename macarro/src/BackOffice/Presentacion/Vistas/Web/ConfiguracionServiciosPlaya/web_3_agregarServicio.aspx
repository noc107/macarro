<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" CodeBehind="web_3_agregarServicio.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya.web_3_agregarServicio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

    <link href="../../../comun/resources/css/ModuloServiciosPlaya/agregarServicioPlaya.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Servicios de playa
</asp:Content>

<asp:Content ID="contenido1" ContentPlaceHolderID="middle_place_holder" runat="Server">

    <script src="../../../comun/resources/js/ModuloServiciosPlaya/moduloServicioPlaya.js"></script>

    <h2 class="centrado subtitulo">Agregar Servicios de Playa</h2>
    <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label CssClass="avisoMensaje MensajeExito" ID="_mensajeError" runat="server" Text="" Visible="false" ></asp:Label>
    <br />
         <div class="formulario">
            <div class="formulario-izq">
                <div class="formulario-labels-textbox">

                    <asp:Label CssClass="labels labelsNombres" ID="labelNombreServicio" runat="server" Text="Label">Nombre del Servicio(*):</asp:Label>
                    
                    <asp:TextBox CssClass="textbox inputTextbox" ID="inputNombreServcio" MaxLength="20" runat="server" ></asp:TextBox>                   
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                        ControlToValidate="inputNombreServcio"
                        Text="*"
                        ErrorMessage="Nombre del Servicio Requerido."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="expresionRegularNombreServicio" runat="server" 
                        ControlToValidate="inputNombreServcio"
                        Text="*"
                        ErrorMessage="La longitud del nombre del servicio debe ser mayor a 5 sin caracteres especiales."
                        ValidationExpression="[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ ,.]{5,20}"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>



                    <br/>

                    <asp:Label CssClass="labels labelsNombres labelDescripcion" ID="labelDescripcion" runat="server" Text="Label">Descripción(*):</asp:Label>
                    
                    <asp:TextBox CssClass="textbox inputTextbox inputTextarea" ID="inputDescripcion" Rows="5" runat="server" TextMode="multiline"  onKeyUp="javascript:Check(this, 100);"
        onChange="javascript:Check(this, 100);"></asp:TextBox>

                    <asp:RequiredFieldValidator id="validatorDescripcion" runat="server"
                        ControlToValidate="inputDescripcion"
                        Text="*"
                        ErrorMessage="Descripción del Servicio Requerido."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regularExpresionDescripcion" runat="server" 
                        ControlToValidate="inputDescripcion"
                        Text="*"
                        ErrorMessage="La longitud de la descripción debe ser mayor a 10 sin caracteres especiales."
                        ValidationExpression="[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ ,.]{10,100}"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
         
                    
                    <br/>

                    <asp:Label CssClass="labels labelsNombres" ID="labelCategoria" runat="server" Text="Label">Categoría(*):</asp:Label>                 
                    <asp:dropdownlist CssClass="comboEstilo combo_box marginDropdownlist cambioCategoria inputTextbox" ID="dropdownlistCategoria" runat="server">
                            <asp:listitem Value="0" text="Seleccione una categoría" Selected="True" />
                            <asp:listitem text="Otro..." Value="Otro" />
                    </asp:dropdownlist>
                  
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                        ControlToValidate="dropdownlistCategoria"
                        Text="*"
                        ErrorMessage="Debe seleccionar al menos una categoría."
                        ForeColor="Red"
                        InitialValue="0">
                    </asp:RequiredFieldValidator>
                           
                  
                    <br/>

                    <div class="divCategoriaOtro">
                        <asp:Label CssClass="categoriaOtroLabel" ID="LabelCategoriaOtro"  runat="server" Text="Label">Indique otra categoría(*):</asp:Label>
                        
                        <asp:TextBox CssClass="textbox inputTextbox"  ID="inputCategoriaOtro"  MaxLength="20" runat="server"></asp:TextBox>       
                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ControlToValidate="dropdownlistCategoria"
                            ClientValidationFunction="validateCategoria"
                            Text="*"
                            ForeColor="Red"
                            ErrorMessage="Debe indicar una categoría.">
                        </asp:CustomValidator>    
                        <asp:RegularExpressionValidator ID="regularExpressionCategoriaOtro" runat="server" 
                            ControlToValidate="inputCategoriaOtro"
                            Text="*"
                            ErrorMessage="No se permite carácteres especiales en la categoría."
                            ValidationExpression="[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ ,.]{0,20}"
                            ForeColor="Red">
                        </asp:RegularExpressionValidator>
                        <br />
                    </div>

                    <asp:Label CssClass="labels labelsNombres" ID="labelLugarRetiro" runat="server" Text="Label">Lugar de retiro(*):</asp:Label>
                    
                    <asp:TextBox CssClass="textbox inputTextbox" ID="inputLugarRetiro"  MaxLength="20" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                        ControlToValidate="inputLugarRetiro"
                        Text="*"
                        ErrorMessage="Lugar de Retiro Requerido."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regularExpressionLugarRetiro" runat="server" 
                        ControlToValidate="inputLugarRetiro"
                        Text="*"
                        ErrorMessage="La longitud del lugar de retiro debe ser mayor a 5 sin caracteres especiales."
                        ValidationExpression="[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ ,.]{5,20}"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                    <br />

                    <asp:Label CssClass="labels labelsNombres" ID="labelCantidad" runat="server" Text="Label">Cantidad(*):</asp:Label>
                    
                    <asp:TextBox CssClass="textbox inputTextbox" ID="inputCantidad"  MaxLength="5"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                        ControlToValidate="inputCantidad"
                        Text="*"
                        ErrorMessage="Debe ingresar la cantidad."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regularExpressionCantidad" runat="server" 
                        ControlToValidate="inputCantidad"
                        Text="*"
                        ErrorMessage="La cantidad debe ser un valor numérico mayor a cero (0)."
                        ValidationExpression="[0-9]{1,5}"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>

                    <br />

                    <asp:Label CssClass="labels labelsNombres" ID="labelCapacidad" runat="server" Text="Label">Capacidad(*):</asp:Label>
                    
                    <asp:TextBox CssClass="textbox inputTextbox" ID="inputCapacidad"  MaxLength="5" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                        ControlToValidate="inputCapacidad"
                        Text="*"
                        ErrorMessage="Debe ingresar la capacidad."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regularExpressionCapacidad" runat="server" 
                        ControlToValidate="inputCapacidad"
                        Text="*"
                        ErrorMessage="La capacidad debe ser un valor numérico mayor a cero (0)."
                        ValidationExpression="[0-9]{1,5}"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                    <br />

                    <asp:Label CssClass="labels labelsNombres" ID="labelCosto" runat="server" Text="Label">Costo(*):</asp:Label>
                    
                    <asp:TextBox CssClass="textbox inputTextbox" ID="inputCosto"  MaxLength="5"  runat="server" ></asp:TextBox>
                    <span class="labels">$</span>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
                        ControlToValidate="inputCosto"
                        Text="*"
                        ErrorMessage="Debe ingresar el costo del servicio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>          
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="inputCosto"
                        Text="*"
                        ErrorMessage="Debe ingresar un monto adecuado."
                        ValidationExpression="(?=.*[1-9])\d*(?:\.\d{1,2})?"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>          
                    <br />
                </div>   
            </div>
            
            <div class="formualrio-der">
                <div class="formulario-labels-textbox">
                        <asp:Label CssClass="labels labelsNombres labelHorario" ID="labelTituloHorario" runat="server" Text="Label"><h3 class="tituloHorario">Insertar <br /> Horarios:</h3></asp:Label>
                        <asp:Label CssClass="notaHorario labels" ID="labeNotaHorario" runat="server" Text="Label">
                            En horarios aparece la lista de horarios ya agregados.<br />
                            En <span class="fuenteMenos">-</span> elimina el horario seleccionado.<br />
                            En <span class="fuenteMenos">+</span> permite agregar un horario a la lista.
                        </asp:Label>               
                    <br/><br/><br/>

                   <asp:Label CssClass="labels labelsNombres labelHoras" ID="labelHoraInicio" runat="server" Text="Label">Hora Inicio:</asp:Label>
                   <asp:TextBox CssClass="timePicker textbox combo_box comboBoxHoras inputTextbox dropdownlistHoraIni"  ID="timePickerInicio" runat="server"></asp:TextBox>                   
                   <img class="reloj relojIni" src="../../../comun/resources/img/ModuloServiciosPlaya/reloj.png" height="18"  />
                   <div class="containerCalendario listaHorasIni" id="calendario">
                        <span class="tituloHora">Hora de Inicio</span>
                        <ul>
                            <li>06:00 am</li>
                            <li>06:30 am</li>
                            <li>07:00 am</li>
                            <li>07:30 am</li>
                            <li>08:00 am</li>
                            <li>08:30 am</li>
                            <li>09:00 am</li>
                            <li>09:30 am</li>
                            <li>10:00 am</li>
                            <li>10:30 am</li>
                            <li>11:00 am</li>
                            <li>11:30 am</li>
                            <li>12:00 pm</li>
                            <li>12:30 pm</li>
                            <li>01:00 pm</li>
                            <li>01:30 pm</li>
                            <li>02:00 pm</li>
                            <li>02:30 pm</li>
                            <li>03:00 pm</li>
                            <li>03:30 pm</li>
                            <li>04:00 pm</li>
                            <li>04:30 pm</li>
                            <li>05:00 pm</li>
                            <li>05:30 pm</li>
                            <li>06:00 pm</li>             
                        </ul>
                   </div>                  
                    <br/><br />

                    <asp:Label CssClass="labelMensajeErrorAgregar labels labelsNombres labelHoras" ID="mensajeErrorAgregarHorario" runat="server" Text="Label">Para agregar un horario debes llenar los <br /> campos Hora Inicio  y Hora Fin </asp:Label>
                    <asp:Label CssClass="labels labelsNombres labelHoras" ID="labelHoraFin" runat="server" Text="Label">Hora Fin:</asp:Label>
                    <asp:TextBox CssClass="timePicker textbox combo_box comboBoxHoras inputTextbox dropdownlistHoraFin" ID="timePickerFin" runat="server"></asp:TextBox>                   
                    <img class="reloj relojFin" src="../../../comun/resources/img/ModuloServiciosPlaya/reloj.png" height="18" alt="" />
                    <div class="containerCalendario listaHorasFin" id="calendario2">
                        <span class="tituloHora">Hora Final</span>
                        <ul>  
                        </ul>
                    </div>
                    <br/><br />

                    <asp:Label CssClass="labelMensajeErrorEliminar labels labelsNombres labelHoras" ID="mensajeErrorEliminarHorario" runat="server" Text="Label">Para eliminar un horario debes <br /> seleccionar alguno de la lista de Horarios </asp:Label>
                    <asp:Label CssClass="labelMensajeErrorEliminar labels labelsNombres labelHoras" ID="mensajeHorarioRepetido" runat="server" Text="Label">Alguna de las horas coinciden con algún <br /> horario ya insertado </asp:Label>
                    <asp:Label CssClass="labels labelsNombres labelHoras labelSeleccionarHorario" ID="labelHorario" runat="server" Text="Label">Horarios(*):</asp:Label>
                    
                    <asp:listbox CssClass="listBoxMargen listboxEstilo textbox inputTextbox horasListbox" ID="listboxHorario" runat="server">                                        
                    </asp:listbox>
                    <asp:CustomValidator ID="validatorListaHorario" runat="server" 
                        ControlToValidate="dropdownlistCategoria"
                        ClientValidationFunction="validateLength"
                        Text="*"
                        ForeColor="Red"
                        ErrorMessage="Debe agregar al menos un horario.">
                    </asp:CustomValidator>                                                  
                     <asp:ImageButton CssClass="imgBotonAgregar botonMas" ID="agregarHorarioListbox" runat="server" CausesValidation="false" title="Permite agregar un horario a la lista" src="../../../comun/resources/img/ModuloServiciosPlaya/agregar.png"  OnClick="agregarHorarioListbox_Click"/>
                     <asp:ImageButton CssClass="imgBoton botonMenos" ID="removerHorarioListbox" runat="server" CausesValidation="false"  title="Elimina el horario seleccionado" src="../../../comun/resources/img/ModuloServiciosPlaya/menos.png" OnClick="removerHorarioListbox_Click"/>
                    <br />
                </div>       
            </div>
        </div>
        <table>
            <tr>
                <td>
                   <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="validarCampos"
                    HeaderText=""
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server" 
                 />
                </td>
            </tr>
        </table>
        
        <div class="botonesFormulario">
            <asp:Button CssClass="Boton botonAgregar" ID="ButtonAgregar" runat="server" Text="Aceptar" OnClick="ButtonAgregar_Click" />
        </div>
</asp:Content>
