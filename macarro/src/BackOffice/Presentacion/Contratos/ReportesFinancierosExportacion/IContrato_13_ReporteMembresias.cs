using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion
{
    public interface IContrato_13_ReporteMembresias : IContratoGeneral
    {
        TextBox TextBoxFechaInicio { get; }
        TextBox TextBoxFechaFin { get; }
        Label LabelGrafica { set; get; }
        GridView GridViewMembresia { set; get; }
    }
}
