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
    public class Presentador_13_ReporteProductos : PresentadorGeneral
    {
        private IContrato_13_ReporteProductos _vista;

        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();

        public Presentador_13_ReporteProductos(IContrato_13_ReporteProductos web_13_ReporteProductos)
            : base(web_13_ReporteProductos)
        {
            _vista = web_13_ReporteProductos;
        }

        public void CargarReporte()
        {
            Comando<int, string> comandoGrafica = FabricaComando.ObtenerComandoReporteProveedoresGrafica();
            _vista.LabelGrafica.Text = comandoGrafica.Ejecutar(0);
            _vista.LabelGrafica.Visible = true;

            Comando<int, DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTabla();
            _vista.GridViewProductos.DataSource = comandoTabla.Ejecutar(4);
            _vista.GridViewProductos.DataBind();
        }
    }
}