using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Presentacion.Contratos.ConfiguracionEstacionamiento
{
    public interface IContrato_5_editarEstacionamiento : IContratoGeneral
    {
        string TextboxNombre { get; set; }
        string TextboxCapacidad { get; set; }
        string TextboxTarifa { get; set; }
        int TextboxEstado { get; set; }
        string TextboxPerdido { get; set; }
    }
}
