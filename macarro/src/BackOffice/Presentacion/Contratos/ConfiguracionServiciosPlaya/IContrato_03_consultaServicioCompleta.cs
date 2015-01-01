using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya
{
    public interface IContrato_03_consultaServicioCompleta : IContratoGeneral
    {
        Label nombreServicio { set; }
        Label descripcionServicio { set; }
        Label categoriaServicio { set; }
        Label lugarRetiroServicio { set; }
        Label cantidadServicio { set; }
        Label capacidadServicio { set; }
        Label costoServicio { set; }
        Label horarioServicio { set; }
        Label estadoServicio { set; }
        Button volver { get; }
    }
}