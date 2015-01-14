using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.Proveedores
{
    public interface IContrato_02_consultarProveedor : IContratoGeneral
    {
        Label Rif { get; set; }
        Label RazonSocial { get; set; }
        Label Correo { get; set; }
        Label PaginaWeb { get; set; }
        Label Telefono { get; set; }
        Label FechaContrato { get; set; }
        Label Pais { get; set; }
        Label Estado { get; set; }
        //Label Estado { get; set; }
        //Label Ciudad { get; set; }
        //Label Direccion { get; set; }
        GridView Items { set; }

        //Label Rif { get; set; }
        //Label RazonSocial { set; }
        //Label Correo { set; }
        //Label PaginaWeb { set; }
        //Label Telefono { set; }
        //Label FechaContrato { set; }
        //Label Pais { set; }
        //Label Estado { set; }
        //Label Ciudad { set; }
        //Label Direccion { set; }
        //GridView Items { set; }
    }
}