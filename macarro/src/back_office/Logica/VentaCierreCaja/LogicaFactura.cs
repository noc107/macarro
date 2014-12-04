using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;

namespace back_office.Logica.VentaCierreCaja
{
    public class LogicaFactura
    {
        /// <summary>
        /// Calcular el total de la factura sin IVA
        /// </summary>
        public float CalcularSubTotal()
        {
            return 0;
        }
        /// <summary>
        /// Calcular el total con el IVA.
        /// </summary>
        public float CalcularMontoIva()
        {
            return 0;
        }
        /// <summary>
        /// Agregar linea de ticket, plato o servicio a la factura
        /// </summary>
        /// <param name="linea"> linea </param>
        /// <returns></returns>  
        public bool AgrregarLineaFactura(LineaFactura linea)
        {
            return false;
        }
        /// <summary>
        /// Generar un PDF con la factura
        /// </summary>
        public void ImprimirFactura()
        {

        }
    }
}