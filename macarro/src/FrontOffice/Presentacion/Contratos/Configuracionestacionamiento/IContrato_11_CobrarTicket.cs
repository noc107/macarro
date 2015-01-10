using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Estacionamiento
{
    public interface IContrato_11_CobrarTicket : IContratoGeneral
    {
        TextBox Ticket { get; set; }
        DropDownList Perdido { get; set; }
        Button Cobrar { get; }
        Label LabelTicket { get; set; }
        Label LabelPlaca { get; set; }
        TextBox Placa { get; set; }
    }
}