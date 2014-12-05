using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Excepciones.InventarioRestaurante 
{
    public class ExcepcionVerItem : Exception
    {
        private string _codigoError;
        /// <summary>
        /// Constructor por defecto de la clase ExcepcionVerItem
        /// </summary>
        public ExcepcionVerItem()
        {
            _codigoError = string.Empty;
        }
        /// <summary>
        /// Constructor con una excepcion referente a la base de datos
        /// </summary>
        /// <param name="mensajeExcepcion">Mensaje de error de la base de datos</param>
        public ExcepcionVerItem (string mensajeExcepcion) : base(mensajeExcepcion)
        {
            
        }
        /// <summary>
        /// Constructor con una excepcion capturada de la base de datos
        /// </summary>
        /// <param name="_codigoError">String del codigo de error</param>
        /// <param name="mensajeExcepcion">String con el mensaje de la excepcion</param>
        /// <param name="ex">Excepcion con la excepcion de la base de datos</param>
        public ExcepcionVerItem(string _codigoError, string mensajeExcepcion, Exception ex) : base(mensajeExcepcion, ex) 
        {
        
        }

        public string CodigoError {
            get { return _codigoError; }
        }

    }
}