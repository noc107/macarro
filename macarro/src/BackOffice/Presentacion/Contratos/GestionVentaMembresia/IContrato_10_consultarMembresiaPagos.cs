using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.GestionVentaMembresia
{
    public interface IContrato_10_consultarMembresiaPagos:IContratoGeneral
    {
        Label ID { get; set; }
        Label FAdmision { get; set; }
        Label Descuento { get; set; }
        Label Estado { get; set; }
        Label FVencimiento { get; set; }
        Label Costo { get; set; }
        Label Nombre1 { get; set; }
        Label Nombre2 { get; set; }
        Label Apellido1 { get; set; }
        Label Apellido2 { get; set; }
        Label Documento { get; set; }
        Label Telefono { get; set; }
        GridView GVPagos { get; set; }
    }
}