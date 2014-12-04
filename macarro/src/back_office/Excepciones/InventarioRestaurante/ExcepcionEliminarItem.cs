using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Excepciones.InventarioRestaurante
{
    public class ExcepcionEliminarItem : Exception
    {
        private string _codigoError;

        public ExcepcionEliminarItem()
        {
            _codigoError = string.Empty;
        }

        public ExcepcionEliminarItem(string mensajeExcepcion) : base(mensajeExcepcion) 
        {
            
        }

        public ExcepcionEliminarItem(string _codigoError,string mensajeExcepcion,Exception ex) : base(mensajeExcepcion,ex) 
        {
        
        }

        public string CodigoError 
        {
            get { return _codigoError; }
        }
    }
}