using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion
{
    public interface IContrato_13_ReporteIngresos : IContratoGeneral
    {
        TextBox TextBoxFechaInicio { get; }
        TextBox TextBoxFechaFin { get; }
        Label LabelGraficaSombrilla { set; get; }
        GridView GridViewSombrilla { set; get; }
        Label LabelGraficaRestaurant { set; get; }
        GridView GridViewRestaurant { set; get; }
        Label LabelGraficaServicio { set; get; }
        GridView GridViewServicio { set; get; }
        Label LabelGraficaEstacionamiento { set; get; }
        GridView GridViewEstacionamiento { set; get; }
    }
}
