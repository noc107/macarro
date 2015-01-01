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

        public Presentador_07_CierreCaja(IContrato_07_CierreCaja vistaCierreCaja) 
        {
            this._vista = vistaCierreCaja;
            
        }

        public void EventoButtonGenerarDia_Click()
        {
            // pruebas estaticas
            if (this._vista.contenedorConsultaMesVisibilidad)
                this._vista.contenedorConsultaMesVisibilidadAsignar = !this._vista.contenedorConsultaMesVisibilidad;
            this._vista.contenedorConsultaDiaVisibilidadAsignar = true;
            this._vista.hiddenValoresDiasGrafica = "300543$225230$311286$289453$x$x$14441";
            this._vista.hiddenFechaDiaGrafica = this._vista.textBoxDiaSeleccionado;

            this._vista.labelTituloReporteDia = this._vista.tipoIngresoDia.SelectedItem.Text;
            this._vista.labelInformacionFechaDia = this._vista.textBoxDiaSeleccionado;
            this._vista.labelInformacionFacturasDia = "17";
            this._vista.labelInformacionSaldoAnteriorDia = "74241$";
            this._vista.labelInformacionIngresoDia = "14441$";
            this._vista.labelInformacionTotalDia = "88682$";
            this._vista.generarGraficaSemanal();
        }

        public void EventoButtonGenerarMes_Click()
        {
            // pruebas estaticas
            if (this._vista.contenedorConsultaDiaVisibilidad)
                this._vista.contenedorConsultaDiaVisibilidadAsignar = !this._vista.contenedorConsultaDiaVisibilidad;
            this._vista.contenedorConsultaMesVisibilidadAsignar = true;
            this._vista.hiddenValoresMesGrafica = "30543$25230$31186$29453$x$x$1441$x$x$x$54532$46352";
            this._vista.hiddenFechaMesGrafica = this._vista.dropDownListMesSeleccionado + " " + this._vista.dropDownListAñoSeleccionado;

            this._vista.labelTituloReporteMes = this._vista.tipoIngresoMes.SelectedItem.Text;
            this._vista.labelInformacionFechaMes = this._vista.dropDownListMesSeleccionado + " " + this._vista.dropDownListAñoSeleccionado;
            this._vista.labelInformacionFacturasMes = "47";
            this._vista.labelInformacionSaldoAnteriorMes = "742241$";
            this._vista.labelInformacionIngresoMes = "46352$";
            this._vista.labelInformacionTotalMes = "788593$";
            this._vista.generarGraficaMensual();
        }

    }
}