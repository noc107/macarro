using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.Proveedores
{
    public interface IContrato_02_modificarProveedor : IContratoGeneral
    {
        TextBox Rif { get; set; }
        TextBox RazonS { get; set; }
        TextBox Correo { get; set; }
        TextBox PaginaWeb { get; set; }
        TextBox Telefono { get; set; }
        TextBox FechaContrato { get; set; }
        DropDownList Pais { get; set; }
        DropDownList Estado { get; set; }
        DropDownList Ciudad { get; set; }
        TextBox Direccion { get; set; }

    }
}