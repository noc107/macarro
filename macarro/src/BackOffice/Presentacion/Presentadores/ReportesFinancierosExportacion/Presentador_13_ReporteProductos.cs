using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

namespace BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion
{
    public class Presentador_13_ReporteProductos : PresentadorGeneral
    {
        private IContrato_13_ReporteProductos _vista;

        public Presentador_13_ReporteProductos(IContrato_13_ReporteProductos web_13_ReporteProductos)
            : base(web_13_ReporteProductos)
        {
            _vista = web_13_ReporteProductos;
        }
    }
}