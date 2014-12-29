using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.Proveedores
{
    public interface IContrato_02_gestionarProveedor : IContratoGeneral
    {
        GridView Items { set; }
    }
}