using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Configuracionestacionamiento
{
    public interface IContrato_11_consultar_Estacionamiento : IContratoGeneral

    {
        Label LabelNombreEstacionamienot { get; set; }
        Label LabelCapacidad { get; set; }
        Label LabelTarifa { get; set; }
        Label LabelEstado { get; set; }
        Label LabelPerdido { get; set; }
        Label LabelDisponible { get; set; }

    }
}