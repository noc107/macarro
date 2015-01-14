using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    //  Contrato inicio de sesion
    public interface IContrato_01_inicioSesion : IContratoGeneral
    {
        TextBox correo { get; }
        TextBox Contrasena { get; }
    }
}