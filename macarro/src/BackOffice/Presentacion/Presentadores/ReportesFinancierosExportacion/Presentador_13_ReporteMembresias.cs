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
    public class Presentador_13_ReporteMembresias : PresentadorGeneral
    {
        private IContrato_13_ReporteMembresias _vista;

        public Presentador_13_ReporteMembresias(IContrato_13_ReporteMembresias web_13_ReporteMembresias)
            : base(web_13_ReporteMembresias)
        {
            _vista = web_13_ReporteMembresias;

        }

        public void CargarReporte(string _fechaini, string _fechafin)
        {
            var _fechas = new string[] {"1",_fechaini,_fechafin};
            Comando<string[], string> comandoGrafica = FabricaComando.ObtenerComandoReporteMembresiasGrafica();
            _vista.LabelGrafica.Text = comandoGrafica.Ejecutar(_fechas);
            _vista.LabelGrafica.Visible = true;

            Comando<string[], DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTablaConParametros();
            _vista.GridViewMembresia.DataSource = comandoTabla.Ejecutar(_fechas);
            _vista.GridViewMembresia.DataBind();
        }

    }
}