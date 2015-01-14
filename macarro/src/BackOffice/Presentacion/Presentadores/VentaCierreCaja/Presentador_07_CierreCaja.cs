using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_CierreCaja
    {

        private IContrato_07_CierreCaja _vista;
        private CierreCaja _cc;
        private char unidadMonetaria = '$';

        public Presentador_07_CierreCaja(IContrato_07_CierreCaja vistaCierreCaja)
        {
            this._vista = vistaCierreCaja;
        }

        public void EventoButtonGenerarDia_Click()
        {

            Entidad _cierreCaja;
            Comando<string[], Entidad> comandoCerrarCajaDiario;
            string[] parametros = this.asignarParametrosDia();

            _cierreCaja = FabricaEntidad.ObtenerCierreCaja();
            comandoCerrarCajaDiario = FabricaComando.ObtenerComandoCerrarCajaDiario();

            _cierreCaja = comandoCerrarCajaDiario.Ejecutar(parametros);

            if (_cierreCaja != null)
            {
                this._cc = (CierreCaja)_cierreCaja;
                this.llenarDatosCierreCajaDia(this._cc);
            }

        }

        public void EventoButtonGenerarMes_Click()
        {

            Entidad _cierreCaja;
            Comando<string[], Entidad> comandoCerrarCajaMensual;
            string[] parametros = this.asigarParametrosMes();

            _cierreCaja = FabricaEntidad.ObtenerCierreCaja();
            comandoCerrarCajaMensual = FabricaComando.ObtenerComandoCerrarCajaMensual();

            _cierreCaja = comandoCerrarCajaMensual.Ejecutar(parametros);

            if (_cierreCaja != null)
            {
                this._cc = (CierreCaja)_cierreCaja;
                this.llenarDatosCierreCajaMes(this._cc);
            }
        }

        private string[] asignarParametrosDia()
        {
            string[] parametrosVista = new string[2];
            
            parametrosVista[0] = this._vista.tipoIngresoDia.SelectedValue;
            parametrosVista[1] = this._vista.textBoxDiaSeleccionado.ToString("dd-mm-yyyy");

            return parametrosVista;
        }

        private string[] asigarParametrosMes()
        {
            string[] parametrosVista = new string[3];

            parametrosVista[0] = this._vista.tipoIngresoMes.SelectedValue;
            parametrosVista[1] = this._vista.cierreCajaMes.SelectedValue;
            parametrosVista[2] = this._vista.dropDownListAñoSeleccionado;

            return parametrosVista;
        }

        private void llenarDatosCierreCajaDia(CierreCaja cierreCaja)
        {

            if (this._vista.contenedorConsultaMesVisibilidad)
            {
                this._vista.contenedorConsultaMesVisibilidadAsignar = !this._vista.contenedorConsultaMesVisibilidad;
            }

            this._vista.contenedorConsultaDiaVisibilidadAsignar = true;
            this._vista.labelTituloReporteDia = this._vista.tipoIngresoDia.SelectedItem.Text;

            this._vista.labelInformacionFechaDia = this._vista.textBoxDiaSeleccionado.ToString("dd-mm-yyyy");
            this._vista.labelInformacionFacturasDia = cierreCaja.NumeroFacturas.ToString();
            this._vista.labelInformacionSaldoAnteriorDia = cierreCaja.SaldoAnterior.ToString() + this.unidadMonetaria;
            this._vista.labelInformacionIngresoDia = cierreCaja.Ingresos.ToString() + this.unidadMonetaria;
            this._vista.labelInformacionTotalDia = cierreCaja.SaldoTotal.ToString() + this.unidadMonetaria;

            this._vista.hiddenValoresDiasGrafica = cierreCaja.ValoresGrafica + cierreCaja.Ingresos.ToString();
            this._vista.hiddenFechaDiaGrafica = this._vista.textBoxDiaSeleccionado.ToString("dd-mm-yyyy");

            this._vista.generarGraficaSemanal();

        }

        private void llenarDatosCierreCajaMes(CierreCaja cierreCaja)
        {
            
            if (this._vista.contenedorConsultaDiaVisibilidad)
            {
               this._vista.contenedorConsultaDiaVisibilidadAsignar = !this._vista.contenedorConsultaDiaVisibilidad;
            }

            this._vista.contenedorConsultaMesVisibilidadAsignar = true;
            this._vista.labelTituloReporteMes = this._vista.tipoIngresoMes.SelectedItem.Text;

            this._vista.labelInformacionFechaMes = this._vista.cierreCajaMes.SelectedItem.Text + " " + this._vista.dropDownListAñoSeleccionado;
            this._vista.labelInformacionFacturasMes = cierreCaja.NumeroFacturas.ToString();
            this._vista.labelInformacionSaldoAnteriorMes = cierreCaja.SaldoAnterior.ToString() + this.unidadMonetaria;
            this._vista.labelInformacionIngresoMes = cierreCaja.Ingresos.ToString() + this.unidadMonetaria;
            this._vista.labelInformacionTotalMes = cierreCaja.SaldoTotal.ToString() + this.unidadMonetaria;

            this._vista.hiddenValoresMesGrafica = cierreCaja.ValoresGrafica + cierreCaja.Ingresos.ToString();
            this._vista.hiddenFechaMesGrafica = this._vista.cierreCajaMes.SelectedItem.Text + " " + this._vista.dropDownListAñoSeleccionado;
            this._vista.generarGraficaMensual();
        }
    }
}