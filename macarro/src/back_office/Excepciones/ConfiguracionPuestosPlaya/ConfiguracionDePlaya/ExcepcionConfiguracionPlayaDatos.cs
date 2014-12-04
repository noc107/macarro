using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Excepciones.ConfiguracionPuestosPlaya.ConfiguracionDePlaya
{
    public class ExcepcionConfiguracionPlayaDatos : Exception
    {
        private string _codigoError;

        /// <summary>
        /// Constructor por defecto de esta clase
        /// </summary>
        public ExcepcionConfiguracionPlayaDatos() 
        {
            _codigoError = String.Empty;
        }

        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>
        public ExcepcionConfiguracionPlayaDatos(string mensajeExcepcion) : base(mensajeExcepcion) 
        {
        
        }
        
        
        /// <summary>
        /// Instancia una excepcion capturada en BD
        /// </summary>
        /// <param name="mensajeExcepcion">Mensaje que describe la excepcion </param>
        /// <param name="inner">La excepcion del sistema que genero la excepción </param>
        public ExcepcionConfiguracionPlayaDatos(string _codigoError, string mensajeExcepcion, Exception inner) : base(mensajeExcepcion, inner) { }

        public string CodigoError
        {
            get { return _codigoError; }
            
        }
    }
}