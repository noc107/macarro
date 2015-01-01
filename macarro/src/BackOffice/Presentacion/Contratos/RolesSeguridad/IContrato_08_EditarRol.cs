using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.RolesSeguridad
{
    public interface IContrato_08_EditarRol : IContratoGeneral
    {
        TextBox TBNombre { get; set; }
        TextBox TBDescripcion { get; set; }
        ListBox LBAccionesDisponibles { get; set; }
        ListBox LBAccionesAsignadas { get; set; }
    }
}
