using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion
{
    public interface IContrato_13_ReporteComidaBebida : IContratoGeneral
    {
        TextBox TextBoxFechaInicio { get; }
        TextBox TextBoxFechaFin { get; }
        Label LabelGraficaComida { set; get; }
        GridView GridViewComidaPopular { set; get; }
        Label LabelGraficaBebida { set; get; }
        GridView GridViewBebidaPopular { set; get; }
    }
}
