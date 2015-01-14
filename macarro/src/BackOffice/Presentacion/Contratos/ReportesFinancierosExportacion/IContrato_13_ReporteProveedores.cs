using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion
{
    public interface IContrato_13_ReporteProveedores : IContratoGeneral
    {
        Label LabelGrafica { set; get; }
        GridView GridViewProveedores { set; get; }
    }
}
