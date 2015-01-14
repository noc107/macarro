using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.IngresoRecuperacionClave
{
    //  Contrato inicio de sesion
    public interface IContrato_01_inicioSesionA : IContratoGeneral
    {
        TextBox correo { get; }
        TextBox Contrasena { get; }
    }
}