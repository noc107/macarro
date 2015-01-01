using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Reservas
{
    public interface IContratoConsultaSombrilla : IContratoGeneral
    {

        GridView _tabla { get; set; }

    }
}