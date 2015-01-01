using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion
{
    public interface IContrato_13_ReporteIngresos : IContratoGeneral
    {
        TextBox inputFechaInicio { get; }
        TextBox inputFechaFin { get; }
    }
}
