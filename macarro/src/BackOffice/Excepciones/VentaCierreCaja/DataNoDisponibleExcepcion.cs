using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.VentaCierreCaja
{
    public class DataNoDisponibleExcepcion : Exception
    {
        public DataNoDisponibleExcepcion()
        { 
        }

        public DataNoDisponibleExcepcion(string _mensaje)
            : base(_mensaje)
        { 
        }

        public DataNoDisponibleExcepcion(string _mensaje, Exception _inner)
            : base(_mensaje, _inner)
        { 
        }
    }
}