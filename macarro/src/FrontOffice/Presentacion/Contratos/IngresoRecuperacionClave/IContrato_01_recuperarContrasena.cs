using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    //  Contrato Recuperar Contraseña
    public interface IContrato_01_recuperarContrasena : IContratoGeneral
    {
        TextBox Ncontrasena { get; }
        TextBox Ccontrasena { get; }
    }

}