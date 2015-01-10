using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones
{
    public class UserNotFoundExcepcion : Exception
    {
        public UserNotFoundExcepcion()
        { 
        }

        public UserNotFoundExcepcion(string _mensaje)
            : base(_mensaje)
        { 
        }

        public UserNotFoundExcepcion(string _mensaje, Exception _inner)
            : base(_mensaje, _inner)
        { 
        }

    }
}