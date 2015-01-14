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
    public class Presentador_13_ReporteRoles : PresentadorGeneral
    {
        private IContrato_13_ReporteRoles _vista;

        public Presentador_13_ReporteRoles(IContrato_13_ReporteRoles web_13_ReporteRoles)
            : base(web_13_ReporteRoles)
        {
            _vista = web_13_ReporteRoles;
        }

        public void CargarReporte()
        {
            Comando<int, string> comandoGrafica = FabricaComando.ObtenerComandoReporteRolesGrafica();
            _vista.LabelGrafica.Text = comandoGrafica.Ejecutar(0);
            _vista.LabelGrafica.Visible = true;

            Comando<int, DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTabla();
            _vista.GridViewRoles.DataSource = comandoTabla.Ejecutar(2);
            _vista.GridViewRoles.DataBind();
        }

    }
}