using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.VentaCierreCaja
{
    public interface IContrato_07_GestionarVenta : IContratoGeneral
    {

        DropDownList listaEstadoBuscador { get; }
        TextBox TBoxBuscador { get; }
        GridView GridVentas { get; }
       
    }
}
