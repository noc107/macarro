using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.RolesSeguridad
{

    public interface IContrato_08_GestionarRoles : IContratoGeneral
    {

        GridView GVRoles { get; set; }

    }
}