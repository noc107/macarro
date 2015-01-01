using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya
{
    public interface IContrato_03_consultaServicio : IContratoGeneral
    {
        TextBox servicioABuscar { get; }
        DropDownList estadoDelServicio { get; }
        GridView tablaDeServicios { get; set; }
        ImageButton imagenBoton { get; }
    }
}