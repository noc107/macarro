using BackOffice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Fabrica
{
    public class FabricaEntidad
    {
        #region Ejemplo

        public static Entidad ObtenerPersona(string nombre, string apellido)
        {
            return new Persona(nombre, apellido);
        }

        #endregion
    }
}