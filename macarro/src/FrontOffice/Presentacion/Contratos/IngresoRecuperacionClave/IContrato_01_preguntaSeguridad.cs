using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    public interface IContrato_01_preguntaSeguridad : IContratoGeneral
    {
        string Respuesta { get; set; }
        string Lpregunta { get; set; }
    }
}