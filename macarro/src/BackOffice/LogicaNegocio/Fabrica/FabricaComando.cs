using BackOffice.Dominio;
using BackOffice.LogicaNegocio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Fabrica
{
    public class FabricaComando
    {
        #region EjemploComandoAgregarPersona

        public static Comando<Entidad, Boolean> ObtenerComandoAgregarPersona()
        {
            return new ComandoAgregarPersona();
        }

        #endregion
    }
}