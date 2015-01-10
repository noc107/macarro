using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.MenuRestaurante
{
    public interface IContrato_05_ConsultarSeccion : IContratoGeneral
    {
        Label lNombre { get; set; }
        Label lDescripcion { get; set; }
        //TextBox estado { get; set; }
    }
}