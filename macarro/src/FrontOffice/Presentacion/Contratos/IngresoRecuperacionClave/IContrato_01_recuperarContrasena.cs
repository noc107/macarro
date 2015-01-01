using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    //  Contrato Recuperar Contraseña
    public interface IContrato_01_recuperarContrasena : IContratoGeneral
    {
       string Ncontrasena { get; }
       string Ccontrasena { get; }
    }

}