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
    public class Presentador_13_ReporteProveedores : PresentadorGeneral
    {
        private IContrato_13_ReporteProveedores _vista;

        public Presentador_13_ReporteProveedores(IContrato_13_ReporteProveedores web_13_ReporteProveedores)
            : base(web_13_ReporteProveedores)
        {
            _vista = web_13_ReporteProveedores;
        }

        public void CargarReporte()
        {
            Comando<int, string> comandoGrafica = FabricaComando.ObtenerComandoReporteProveedoresGrafica();
            _vista.LabelGrafica.Text = comandoGrafica.Ejecutar(0);
            _vista.LabelGrafica.Visible = true;

            Comando<int, DataTable> comandoTabla = FabricaComando.ObtenerComandoReporteTabla();
            _vista.GridViewProveedores.DataSource = comandoTabla.Ejecutar(3);
            _vista.GridViewProveedores.DataBind();
        }
    }
}