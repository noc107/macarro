using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

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
    }
}