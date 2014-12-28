using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.VentaCierreCaja
{
    public interface IContrato_07_Facturacion : IContratoGeneral    
    {
        DropDownList listaFiltroBuscador { get; }
        GridView gridServicio { get; }
        GridView gridFactura { get; }
        string labelTotal { set; }
        string labelNombreCliente { set; }
        string labelDocumento { set; }
        TextBox textBoxCorreoCliente { get; }
        TextBox textBoxBuscador { get;  }
        Panel panelBloques { get; }
        Panel panelBloqueNuevo { get; }

    }
}
