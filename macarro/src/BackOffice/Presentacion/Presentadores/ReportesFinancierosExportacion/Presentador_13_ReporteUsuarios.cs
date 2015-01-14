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
    public class Presentador_13_ReporteUsuarios : PresentadorGeneral
    {
        private IContrato_13_ReporteUsuarios _vista;

        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();

        public Presentador_13_ReporteUsuarios(IContrato_13_ReporteUsuarios web_13_ReporteUsuarios)
            : base(web_13_ReporteUsuarios)
        {
            _vista = web_13_ReporteUsuarios;
        }

        public void CargarReporte()
        {
            Comando<int, string> comandoGrafica = FabricaComando.ObtenerComandoReporteUsuariosGrafica();
            _vista.LabelGrafica.Text = comandoGrafica.Ejecutar(0);
            _vista.LabelGrafica.Visible = true;

            Comando<int, DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTabla();
            _vista.GridViewActivos.DataSource = comandoTabla.Ejecutar(1);
            _vista.GridViewActivos.DataBind();
        }   
    }
}