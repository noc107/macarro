using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya
{
    public interface IContrato_07_listaReserva : IContratoGeneral
    {

        GridView _table { get; set; }
        string _idReserva { get; set; }
       
    }
}