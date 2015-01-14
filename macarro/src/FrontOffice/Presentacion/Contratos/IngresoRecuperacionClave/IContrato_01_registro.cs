using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    public interface IContrato_01_registro :IContratoGeneral
    {
        TextBox PriNombre { get; set; }
        TextBox SegNombre { get; set; }
        TextBox PriApellido { get; set; }
        TextBox SegApellido { get; set; }
        DropDownList TipoDocIdentidad { get; set; }
        TextBox NumeroDocumento { get; set; }
        TextBox Correo { get; set; }
        TextBox FechaNac { get; set; }
        TextBox Contrasena { get; set; }
        TextBox RContrasena { get; set; }
        DropDownList PreSeguridad { get; set; }
        TextBox RespSeguridad { get; set; }
        TextBox Direccion1 { get; set; }
     }

}
