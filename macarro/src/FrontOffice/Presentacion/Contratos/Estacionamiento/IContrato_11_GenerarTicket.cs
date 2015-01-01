using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Estacionamiento
{
    public interface IContrato_11_GenerarTicket : IContratoGeneral
    {

        TextBox Placa { get; set; }
        Button Aceptar { get; }
    }
}