using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya
{
    public interface IContrato_07_confirmacionReserva : IContratoGeneral
    {

        GridView _tableServicio { get; set; }
        
        GridView _tablePuesto { get; set; }
        
        string _idReserva { get; set; }

        DropDownList _combo { get; set; }

        Label _estadoActual { get; set; }

        Button _aceptar { get; set; }

    }
}