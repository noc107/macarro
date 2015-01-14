<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_cierreCaja.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.web_07_cierreCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
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

    <script src="../../../../comun/resources/js/ModuloCierreCaja/CierreCaja.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Información del Cierre de Caja</h2>
    
    <div class="contenedorCierreCaja">

        <asp:Label ID="MensajeExito" runat="server" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
        <asp:Label ID="MensajeError" runat="server" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>

        <div class="separador">
            <p class="mensajesAyuda">Seleccione el tipo de consulta que desea realizar</p>
            <asp:Label CssClass="labels labelsCierreCajaRadio" ID="LabelPorDia" runat="server" Text="Label">Por día</asp:Label>
            <asp:RadioButton CssClass="radioDia radioCierreCaja" ID="RadioButton1" runat="server" GroupName="TipoCierre"/>

            <asp:Label CssClass="labels labelsCierreCajaRadio" ID="LabelPorMes" runat="server" Text="Label">Por Mes</asp:Label>
            <asp:RadioButton CssClass="radioMes radioCierreCaja" ID="RadioButton2" runat="server" GroupName="TipoCierre"/>

        </div>
        <p class="mensajesAyuda">Seleccione los parámetros para generar el reporte determinado</p>
        <div class="cierreCajaDia cierreCajaParametros">
            <div class="separador">
                <asp:Label CssClass="labels" ID="LabelTipoDia" runat="server" Text="Label">Tipo de ingreso</asp:Label>
                <asp:DropDownList CssClass="textbox" ID="DropDownListTipoDias" runat="server">
                    <asp:listitem Value="0" text="Seleccione un tipo" Selected="True" />
                    <asp:listitem text="Reserva de servicios" Value="serPlaya" />
                    <asp:listitem text="Reserva de puestos" Value="serPuestos" />
                    <asp:listitem text="Servicios de estacionamiento" Value="serEstacionamiento" />
                    <asp:listitem text="Servicios de restaurante" Value="serRestaurante" />
                    <asp:listitem text="Todos los servicios" Value="serTodos" />
                </asp:DropDownList>
                
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="DropDownListTipoDias"
                    ValidationGroup="validatorDias"
                    Text="*"
                    ForeColor="Red"
                    InitialValue="0">
                </asp:RequiredFieldValidator>

                <asp:Label CssClass="labels" ID="LabelDia" runat="server" Text="Label">Día de consulta</asp:Label>
                <asp:TextBox CssClass="textbox textboxDate" ID="TextBoxDia" runat="server" TextMode="Date"></asp:TextBox>

                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="TextBoxDia"
                    ValidationGroup="validatorDias"
                    Text="*"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </div>

            <asp:Button ValidationGroup="validatorDias" CssClass="Boton botonGenerar" ID="ButtonGenerarDia" runat="server" Text="Generar" OnClick="ButtonGenerarDia_Click"/>            

            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger controlid="ButtonGenerarDia" eventname="Click" />
                </Triggers>
                <ContentTemplate>
                    <div id="contenedorConsultaDia" class="contenedorConsultaDia" runat="server" visible="false">
                        <div class="informacionReporte">
                            <p id="tituloReporteDia" class="tituloReporte" runat="server"></p>
                            <asp:Label CssClass="reporteLabel labels" ID="LabelReporte1" runat="server" Text="Fecha:"></asp:Label>
                            <asp:Label CssClass="informacionLabel reporteFecha labels" ID="informacionFechaDia" runat="server"></asp:Label><br />
                            <p class="mensajesAyuda mensajeResumen">Resumen de ventas:</p>
                            <asp:Label CssClass="reporteLabel labels" ID="LabelReporte3" runat="server" Text="Saldo Anterior:"></asp:Label>
                            <asp:Label CssClass="informacionLabel labels" ID="informacionSaldoAnteriorDia" runat="server" ></asp:Label><br />
                            <asp:Label CssClass="reporteLabel labels" ID="LabelReporte2" runat="server" Text="Facturas Emitidas:"></asp:Label>
                            <asp:Label CssClass="informacionLabel labels" ID="informacionFacturasDia" runat="server" ></asp:Label><br />
                            <asp:Label CssClass="reporteLabel labels" ID="LabelReporte4" runat="server" Text="Ingresos:"></asp:Label>
                            <asp:Label CssClass="informacionLabel labels" ID="informacionIngresoDia" runat="server" ></asp:Label><br /><br />
                            <div class="reporteSaldoTotal">
                                <asp:Label CssClass="reporteLabel labels" ID="LabelReporte5" runat="server" Text="Saldo Actual:"></asp:Label>
                                <asp:Label CssClass="informacionLabel labels" ID="informacionTotalDia" runat="server" ></asp:Label>
                            </div>
                        </div>
                        <div class="informacionGrafica">
                            <p id="tituloGraficaDia" class="tituloReporte" >Reporte Semanal</p>
                            <span class="graficaEjeY">Ingresos</span>
                            <span class="graficaEjeX">Dias de la semana</span>
                            <canvas id="graficoDia" width="600" height="400">
                            </canvas>
                        </div>
                    </div>
                    <input type="hidden" runat="server" class="hiddenValoresDias" id="hiddenValoresDias"/>
                    <input type="hidden" runat="server" class="hiddenFechaDia" id="hiddenFechaDia"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        

        </div>

        <div class="cierreCajaMes cierreCajaParametros">
            <div class="separador">
                <asp:Label CssClass="labels" ID="LabelTipoMes" runat="server" Text="Label">Tipo de ingreso</asp:Label>
                <asp:DropDownList CssClass="textbox" ID="DropDownListTipoMes" runat="server">
                    <asp:listitem Value="0" text="Seleccione un tipo" Selected="True" />
                    <asp:listitem text="Reserva de servicios" Value="serPlaya" />
                    <asp:listitem text="Reserva de puestos" Value="serPuestos" />
                    <asp:listitem text="Servicios de estacionamiento" Value="serEstacionamiento" />
                    <asp:listitem text="Servicios de restaurante" Value="serRestaurante" />
                    <asp:listitem text="Todos los servicios" Value="serTodos" />
                </asp:DropDownList>

                <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="DropDownListTipoMes"
                    ValidationGroup="validatorMes"
                    Text="*"
                    ForeColor="Red"
                    InitialValue="0">
                </asp:RequiredFieldValidator>

                <asp:Label CssClass="labels" ID="LabelMes" runat="server" Text="Label">Mes</asp:Label>
                <asp:DropDownList CssClass="textbox dropdownlistMes" ID="DropDownListMes" runat="server">
                    <asp:listitem Value="0" text="Seleccione un mes" Selected="True" />
                    <asp:listitem Value="01" text="Enero"/>
                    <asp:listitem Value="02" text="Febrero"/>
                    <asp:listitem Value="03" text="Marzo" />
                    <asp:listitem Value="04" text="Abril" />
                    <asp:listitem Value="05" text="Mayo"  />
                    <asp:listitem Value="06" text="Junio"  />
                    <asp:listitem Value="07" text="Julio" />
                    <asp:listitem Value="08" text="Agosto"  />
                    <asp:listitem Value="09" text="Septiembre" />
                    <asp:listitem Value="10" text="Octubre"  />
                    <asp:listitem Value="11" text="Noviembre"  />
                    <asp:listitem Value="12" text="Diciembre" />
                </asp:DropDownList>

                <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="DropDownListMes"
                    ValidationGroup="validatorMes"
                    Text="*"
                    ForeColor="Red"
                    InitialValue="0">
                </asp:RequiredFieldValidator>

                <asp:Label CssClass="labels" ID="Label3" runat="server" Text="Label">Año</asp:Label>
                <asp:DropDownList CssClass="textbox dropdownlistAño" ID="DropDownListAño" runat="server">
                    <asp:listitem Value="0" text="Seleccione un año" Selected="True" />
                    <asp:listitem Value="2015" text="2015" />
                    <asp:listitem Value="2014" text="2014"/>
                    <asp:listitem Value="2013" text="2013" />
                    <asp:listitem Value="2012" text="2012" />
                    <asp:listitem Value="2011" text="2011"  />
                    <asp:listitem Value="2010" text="2010"  />
                    <asp:listitem Value="2009" text="2009" />
                    <asp:listitem Value="2008" text="2008"  />
                    <asp:listitem Value="2007" text="2007" />
                    <asp:listitem Value="2006" text="2006"  />
                    <asp:listitem Value="2005" text="2005"  />
                    <asp:listitem Value="2004" text="2004" />
                    <asp:listitem Value="2003" text="2003" />
                    <asp:listitem Value="2002" text="2002" />
                    <asp:listitem Value="2001" text="2001" />
                    <asp:listitem Value="2000" text="2000" />
                </asp:DropDownList>

                <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                    ControlToValidate="DropDownListAño"
                    ValidationGroup="validatorMes"
                    Text="*"
                    ForeColor="Red"
                    InitialValue="0">
                </asp:RequiredFieldValidator>

            </div>


            <asp:Button ValidationGroup="validatorMes" CssClass="Boton botonGenerar" ID="ButtonGenerarMes" runat="server" Text="Generar" OnClick="ButtonGenerarMes_Click"/>            

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger controlid="ButtonGenerarMes" eventname="Click" />
                </Triggers>
                <ContentTemplate>
                    <div id="contenedorConsultaMes" class="contenedorConsultaDia" runat="server" visible="false">
                        <div class="informacionReporte">
                            <p id="tituloReporteMes" class="tituloReporte" runat="server"></p>
                            <asp:Label CssClass="reporteLabel labels" ID="Label4" runat="server" Text="Mes:"></asp:Label>
                            <asp:Label CssClass="informacionLabel reporteFecha labels" ID="informacionFechaMes" runat="server"></asp:Label><br />
                            <p class="mensajesAyuda mensajeResumen">Resumen de ventas:</p>
                            <asp:Label CssClass="reporteLabel labels" ID="Label10" runat="server" Text="Saldo Anterior:"></asp:Label>
                            <asp:Label CssClass="informacionLabel labels" ID="informacionSaldoAnteriorMes" runat="server"></asp:Label><br />
                            <asp:Label CssClass="reporteLabel labels" ID="Label8" runat="server" Text="Facturas Emitidas:"></asp:Label>
                            <asp:Label CssClass="informacionLabel labels" ID="informacionFacturasMes" runat="server"></asp:Label><br />
                            <asp:Label CssClass="reporteLabel labels" ID="Label12" runat="server" Text="Ingresos:"></asp:Label>
                            <asp:Label CssClass="informacionLabel labels" ID="informacionIngresoMes" runat="server" ></asp:Label><br /><br />
                            <div class="reporteSaldoTotal">
                                <asp:Label CssClass="reporteLabel labels" ID="Label14" runat="server" Text="Saldo Actual:"></asp:Label>
                                <asp:Label CssClass="informacionLabel labels" ID="informacionTotalMes" runat="server" ></asp:Label>
                            </div>
                        </div>
                        <div class="informacionGrafica">
                            <p id="tituloGraficaMes" class="tituloReporte" >Reporte Anual</p>
                            <span class="graficaEjeY">Ingresos</span>
                            <span class="graficaEjeX">Meses</span>
                            <canvas id="graficoMes" width="600" height="400">
                            </canvas>
                        </div>
                    </div>
                    <input type="hidden" runat="server" class="hiddenValoresMes" id="hiddenValoresMes"/>
                    <input type="hidden" runat="server" class="hiddenFechaMes" id="hiddenFechaMes"/>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div class="cierreCajaDefault visible">
            <div class="separador">
                <label class="labels">Tipo de ingreso</label>
                <select class="textbox textboxDefault" disabled="disabled">
                    <option>Seleccione un tipo</option>
                </select>
                <label class="labels" style="margin-left:10px;">Día de consulta</label>
                <input class="textbox textboxDefault textboxDate" type="text" value="dd/mm/aaaa" disabled="disabled"/>
            </div>
                <input class="textboxDefault Boton botonGenerar" type="button" disabled="disabled" value="Generar"/>
            
        </div>


    </div>
</asp:Content>