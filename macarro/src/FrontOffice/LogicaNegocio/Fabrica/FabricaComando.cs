using FrontOffice.Dominio;
using FrontOffice.LogicaNegocio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Fabrica
{
    public class FabricaComando
    {
        #region EjemploComandoAgregarPersona

        public static Comando<Entidad, Boolean> ObtenerComandoAgregarPersona()
        {
            return new ComandoAgregarPersona();
        }

        #endregion

        #region ConfiguracionEstacionamientos

        #endregion

        #region Estacionamiento

        #endregion

        #region IngresoRecuperacionClave

        #endregion

        #region Membresia

        #endregion

        #region Menu

        #endregion

        #region Reservas

        #endregion

    }
}