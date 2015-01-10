using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace FrontOffice.Presentacion.Contratos.Membresia
{
    public interface IContrato_12_consultarMembresia : IContratoGeneral
    {
        //carnet
        Label nombre { get; set; }
        Label apellido { get; set; }
        Label fechaNacimiento { get; set; }
        Label fechaVencimiento { get; set; }
        Label tipoDocumentoIdentidad { get; set; }
        Label numeroDocumentoIdentidad { get; set; }
        Label numeroTelefono { get; set; }
        Label numeroCarnet { get; set; }
        Image foto { get; set; }
        Button descargarPDF { get; }
        Button verPagos { get; }
        Panel carnet { get; set; }
        Image logo { get; set; }
    }
}