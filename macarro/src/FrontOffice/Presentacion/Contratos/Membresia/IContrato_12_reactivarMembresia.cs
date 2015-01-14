using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Contratos.Membresia
{
    public interface IContrato_12_reactivarMembresia : IContratoGeneral
    {
        //Datos de muestra para el carnet
        Label nombre { get; set; }
        Label apellido { get; set; }
        Label fechaNacimiento { get; set; }
        Label tipoDocumentoIdentidad { get; set; }
        Label numeroDocumentoIdentidad { get; set; }
        Label numeroTelefono { get; set; }
        Label fechaVencimiento { get; set; }
        Image foto { get; set; }
        Panel formulariosM { get; set; }
        Label numeroCarnet { get; set; }
        //Dato a llenar para el carnet
       // Button cambiarFoto { get; }
        //TextBox FotoPath { get; }
        //Escoger una tarjeta ya usada
        GridView gridTarjetasUsadas { get; set; }
        Button agregarTarjeta { get; }

        //Datos para llenar con referencia al Pago sera invisible excepto el monto
        TextBox numeroTarjeta { get; set; }
        TextBox nombreImpresoEnTarjeta { get; set; }
        TextBox cvv { get; set; }
        DropDownList mesVencimiento { get; set; }
        DropDownList anoVencimiento { get; set; }

        Label montoTotal { get; set; }

        //Botones
        Button aceptar { get; }
        Button cancelar { get; }

    }
}