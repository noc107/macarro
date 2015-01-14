using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Dao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.Dao;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.LogicaNegocio;

namespace BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion
{
    public class Presentador_13_ReporteIngresos : PresentadorGeneral
    {
        private IContrato_13_ReporteIngresos _vista;

        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();

        public Presentador_13_ReporteIngresos(IContrato_13_ReporteIngresos vista_ReporteIngresos): base(vista_ReporteIngresos)
        {
            _vista = vista_ReporteIngresos;
        }

        public void CargarReporte(string _fechaini, string _fechafin)
        {
            var _fechas = new string[] { "2", _fechaini, _fechafin };
            Comando<string[], string> comandoGraficaSombrilla = FabricaComando.ObtenerComandoReporteSombrillaGrafica();
            _vista.LabelGraficaSombrilla.Text = comandoGraficaSombrilla.Ejecutar(_fechas);
            _vista.LabelGraficaSombrilla.Visible = true;
            Comando<string[], DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTablaConParametros();
            _vista.GridViewSombrilla.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewSombrilla.DataBind();

            Comando<string[], string> comandoGraficaRestaurante = FabricaComando.ObtenerComandoReporteRestauranteGrafica();
            _vista.LabelGraficaRestaurant.Text = comandoGraficaRestaurante.Ejecutar(_fechas);
            _vista.LabelGraficaRestaurant.Visible = true;
            _fechas[0] = "3";
            _vista.GridViewRestaurant.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewRestaurant.DataBind();

            Comando<string[], string> comandoGraficaServicio = FabricaComando.ObtenerComandoReporteServicioGrafica();
            _vista.LabelGraficaServicio.Text = comandoGraficaServicio.Ejecutar(_fechas);
            _vista.LabelGraficaServicio.Visible = true;
            _fechas[0] = "4";
            _vista.GridViewServicio.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewServicio.DataBind();

            Comando<string[], string> comandoGraficaEstacionamiento = FabricaComando.ObtenerComandoReporteEstacionamientoGrafica();
            _vista.LabelGraficaEstacionamiento.Text = comandoGraficaEstacionamiento.Ejecutar(_fechas);
            _vista.LabelGraficaEstacionamiento.Visible = true;
            _fechas[0] = "5";
            _vista.GridViewEstacionamiento.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewEstacionamiento.DataBind();

        }
    }
}