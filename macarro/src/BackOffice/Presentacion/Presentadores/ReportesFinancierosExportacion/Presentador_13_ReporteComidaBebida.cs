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
    public class Presentador_13_ReporteComidaBebida : PresentadorGeneral
    {
        private IContrato_13_ReporteComidaBebida _vista;

        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();

        public Presentador_13_ReporteComidaBebida (IContrato_13_ReporteComidaBebida web_13_ReporteComidaBebida)
            : base(web_13_ReporteComidaBebida)
        {
            _vista = web_13_ReporteComidaBebida;            
        }

        public void CargarReporte(string _fechaini, string _fechafin)
        {
            var _fechas = new string[] { "6", _fechaini, _fechafin };
            Comando<string[], string> comandoGraficaComida = FabricaComando.ObtenerComandoReporteComidaGrafica();
            _vista.LabelGraficaComida.Text = comandoGraficaComida.Ejecutar(_fechas);
            _vista.LabelGraficaComida.Visible = true;
            Comando<string[], DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTablaConParametros();
            _vista.GridViewComidaPopular.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewComidaPopular.DataBind();

            Comando<string[], string> comandoGraficaBebida = FabricaComando.ObtenerComandoReporteBebidaGrafica();
            _vista.LabelGraficaBebida.Text = comandoGraficaBebida.Ejecutar(_fechas);
            _vista.LabelGraficaBebida.Visible = true;
            _fechas[0] = "7";
            _vista.GridViewBebidaPopular.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewBebidaPopular.DataBind();
        }
    }
}