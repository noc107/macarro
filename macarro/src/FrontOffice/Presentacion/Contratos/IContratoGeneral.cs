using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos
{
    public interface IContratoGeneral
    {
        Label LabelMensajeExito { get; set; }

        Label LabelMensajeError { get; set; }
    }
}
