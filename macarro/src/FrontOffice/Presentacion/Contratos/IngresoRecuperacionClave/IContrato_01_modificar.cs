using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    public interface IContrato_01_modificar : IContratoGeneral
    {
        string PriNombre { get; set; }
        string SegNombre { get; set; }
        string PriApellido { get; set; }
        string SegApellido { get; set; }
        string TipoDocIdentidad { get; }
        string NumeroDocumento { get; set; }
        string Correo { get; set; }
        DateTime FechaNac { get; set; }
        string Contrasena { get; set; }
        string RContrasena { get; set; }
        string PreSeguridad { get; set; }
        string RespSeguridad { get; set; }
        string Direccion1 { get; set; }
         
    }
}