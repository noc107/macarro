using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Contratos.ConfiguracionEstacionamiento
{
    public interface IContrato_11_gestionarEstacionamiento : IContratoGeneral
    {
        string LabelNombre { get; set; }
        string LabelCapacidad { get; set; }
        string LabelTarifa { get; set; }
        string LabelEstado { get; set; }
        string LabelPerdido { get; set; }
    }
}