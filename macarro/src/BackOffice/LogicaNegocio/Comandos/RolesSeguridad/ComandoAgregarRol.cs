using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoAgregarRol : Comando<Entidad, bool>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para agregar un rol
        /// </summary>
        /// <param name="parametro">rol a agregar</param>
        /// <returns>bool si agrego</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                return _daoRol.Agregar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}