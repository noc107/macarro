using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.RolesSeguridad
{
    public interface IContrato_08_ConsultarRol : IContratoGeneral
    {
        Label LNombre { get; set; }
        Label LDescripcion { get; set; }
        ListBox LBAcciones { get; set; }
    }
}
