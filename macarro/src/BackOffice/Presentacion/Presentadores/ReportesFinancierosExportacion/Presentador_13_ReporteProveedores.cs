using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

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
    }
}