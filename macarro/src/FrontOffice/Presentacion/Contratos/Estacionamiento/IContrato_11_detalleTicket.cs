using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Contratos.Estacionamiento
{
    public interface IContrato_11_detalleTicket : IContratoGeneral

    {

        string LabelEntrada { get; set; }
        string LabelSalida { get; set; }
        string LabelPlaca { get; set; }
        string LabelPerdido { get; set; }
        string LabelMonto { get; set; }
    }
}