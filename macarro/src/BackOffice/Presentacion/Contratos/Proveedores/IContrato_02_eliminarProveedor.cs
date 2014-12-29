using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.Proveedores
{
    public interface IContrato_02_eliminarProveedor : IContratoGeneral
    {
        Label Rif { set; }
        Label RazonSocial { set; }
        Label Correo { set; }
        Label PaginaWeb { set; }
        Label Telefono { set; }
        Label FechaContrato { set; }
        Label Pais { set; }
        Label Estado { set; }
        Label Ciudad { set; }
        Label Direccion { set; }
        GridView Items { set; }
    }
}