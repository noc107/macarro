using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.MenuRestaurante
{
    public interface IContrato_05_ConsultarPlato : IContratoGeneral
    {
        TextBox nombre { get; }
        TextBox descripcion { get; }
        TextBox precio { get;  }
        DropDownList seccion { get; }
        TextBox estado { get; }
    }
}