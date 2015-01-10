using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Excepciones
{
    public class Logger
    {
        public static void EscribirEnLogger(ExcepcionGeneral ex)
        {
            ILog Log = LogManager.GetLogger(ex.Clase);
            Log.Info("************************************************************************************");
            Log.Error("Codigo: " + ex.Codigo);
            Log.Error("Clase: " + ex.Clase);
            Log.Error("Mensaje: " + ex.Mensaje);
            Log.Error("Metodo: " + ex.Metodo);
            Log.Error("StackTrace: " + ex.Excepcion.StackTrace);
            Log.Error("InnerException: " + ex.Excepcion.InnerException);
        }
    }
}