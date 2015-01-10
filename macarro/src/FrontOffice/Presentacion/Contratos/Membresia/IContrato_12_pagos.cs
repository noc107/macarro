using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Membresia
{

    public interface IContrato_12_pagos : IContratoGeneral
    {
        TextBox fechabusqueda { get; }
        ImageButton buscar { get; }
        GridView gridPagosHechos { get; }
        Button volver { get; }

    }

}