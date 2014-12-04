using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using back_office.Datos.ConfiguracionPuestosPlaya;
using back_office.Excepciones.ConfiguracionPuestosPlaya.ConfiguracionDePlaya;

namespace back_office.Logica.ConfiguracionPuestosPlaya
{
    public class ConfigurarPlaya
    {
        private Playa _configuracion;

        public Playa Configuracion
        {
            get { return _configuracion; }
            set { _configuracion = value; }
        }
        /// <summary>
        /// constructor de la clase
        /// </summary>
        public ConfigurarPlaya()
        {

        }
        /// <summary>
        /// manda a la capa de datos la informacion a modificar de la playa
        /// </summary>
        /// <param name="configuracion">nuevos parametros de configuracion para la playa</param>
        /// <returns>true en caso de exito; false en caso de error</returns>
        public bool ModificarConfiguracionDePlaya( Playa configuracion )
        {
            try
            {
                return new PlayaBD().IngresarNuevaConfiguracionDePlaya(configuracion);
            }
            catch (ExcepcionConfiguracionPlayaDatos ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionConfiguracionPlayaLogica(ex.Message);
            }
        }
        /// <summary>
        /// solicita a la capa de datos la configuracion actual de la playa
        /// </summary>
        /// <returns>retorna un objeto del tipo playa con la configuracion actual de la playa</returns>
        public Playa solicitarConfiguracionActualDeLaPlaya()
        {
            PlayaBD configuracionActual = new PlayaBD();
            return configuracionActual.ConsultarConfiguracionDePlaya();
        }
    }
}