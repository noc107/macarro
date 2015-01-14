using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.Proveedores
{
    public interface IContrato_02_agregarProveedores : IContratoGeneral
    {
        TextBox Rif { get; }
        TextBox RazonSocial { get; }
        TextBox Correo { get; }
        TextBox PaginaWeb { get; }
        TextBox Telefono { get; }
        TextBox FechaContrato { get; }
        DropDownList Pais { get; }
        DropDownList Estado { get; }
        DropDownList Ciudad { get; }
        TextBox Direccion { get; }
        //GridView Items { get; }
    }
}