using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    public interface IContrato_01_preguntaSeguridad : IContratoGeneral
    {
        TextBox Respuesta { get; set; }
        Label Lpregunta { get; set; }
    }
}