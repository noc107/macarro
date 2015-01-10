using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Membresia
{

    public interface IContrato_12_detallePago : IContratoGeneral
    {
        // Esta en veremos hay q preguntarle a maguca 
        Image tipoTarjeta { get; set; }
        Label numeroTarjeta { get; set; }
        Label nombreImpresoEnTarjeta { get; set; }
        Label fechaPago { get; set; }
        Label montoTotal { get; set; }
        Button volver { get; }
        
    }

}