using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Reservas
{
    public interface IContratoReservacionSombrilla : IContratoGeneral
    {
        Table _tabla { get; set; }
        Label _fechaReserva { get; set; }
        Label _monto { get; set; }
    }
}