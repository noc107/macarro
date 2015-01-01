using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

namespace BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion
{
    public class Presentador_13_ReporteUsuarios : PresentadorGeneral
    {
        private IContrato_13_ReporteUsuarios _vista;

        public Presentador_13_ReporteUsuarios(IContrato_13_ReporteUsuarios web_13_ReporteUsuarios)
            : base(web_13_ReporteUsuarios)
        {
            _vista = web_13_ReporteUsuarios;
        }
    }
}