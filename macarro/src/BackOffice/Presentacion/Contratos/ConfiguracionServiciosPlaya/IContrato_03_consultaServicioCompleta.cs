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
        Label nombreServicio { get; set; }
        Label descripcionServicio { get; set; }
        Label categoriaServicio { get; set; }
        Label lugarRetiroServicio { get; set; }
        Label cantidadServicio { get; set; }
        Label capacidadServicio { get; set; }
        Label costoServicio { get; set; }
        Label horarioServicio { get; set; }
        Label estadoServicio { get; set; }
        Button volver { get; }
    }
}