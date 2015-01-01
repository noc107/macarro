using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Reservas
{
    public interface IContratoModificarReservaServicio : IContratoGeneral
    {
        DropDownList _nombreServicio { get; set; }
        TextBox _cantidadServicio { get; set; }
        TextBox _horaInicio { get; set; }
        TextBox _horaFin { get; set; }
        TextBox _fecha { get; set; }
        Button _aceptar { get; set; }
        Button _cancelar { get; set; }
        string reservaID { get; set; }
        int cantidadReserva { get; set; }
        string servicio { get; set; }

    }
}