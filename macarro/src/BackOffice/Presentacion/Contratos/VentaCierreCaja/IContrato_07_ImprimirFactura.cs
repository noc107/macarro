using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.VentaCierreCaja
{
    public interface IContrato_07_ImprimirFactura : IContratoGeneral
    {
        GridView GridFactura { get; }
        string LabelFechaFactura { set; }
        string LabelDocIdentidadCliente { set; }
        string LabelNombreCliente { set; }
        string LabelApellidoCliente { set; }
        string LabelMiembroClub { set; }
        string LabelSubTotal { set; }
        string LabelMontoIVA { set; }
        string LabelDescuento { set; }
        string LabelTotal { set; }

    }
}
