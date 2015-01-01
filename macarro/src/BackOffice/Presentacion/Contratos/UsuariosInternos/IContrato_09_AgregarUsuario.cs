using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web;

namespace BackOffice.Presentacion.Contratos.UsuariosInternos
{
   public interface IContrato_09_AgregarUsuario: IContratoGeneral
    {

        TextBox PrimerNombre { get; set; }
        TextBox SegundoNombre { get; set; }
        TextBox PrimerApellido { get; set; }
        TextBox SegundoApellido { get; set; }
        DropDownList TipoDocumentacion { get; set; }
        TextBox Cedula { get; set; }
        TextBox FechaNacimiento { get; set; }
        TextBox Telefono { get; set; }
        TextBox Correo { get; set; }
        DropDownList Pais { get; set; }        
        DropDownList Estado { get; set; }
        DropDownList Ciudad { get; set; }
        TextBox Direccion { get; set; }


    }
}