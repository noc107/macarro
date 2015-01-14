using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.GestionVentaMembresia
{
    public interface IContrato_10_gestionarCosto : IContratoGeneral
    {        
        TextBox Costo { get; set; }
    }
}