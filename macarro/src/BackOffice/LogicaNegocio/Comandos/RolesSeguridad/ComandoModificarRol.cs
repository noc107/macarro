using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using BackOffice.LogicaNegocio.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoModificarRol : Comando<Entidad, bool>
    {
        /// <summary>
        ///  Metodo para ejecutar el comando para modificar un rol
        /// </summary>
        /// <param name="parametro">entidad a modificar</param>
        /// <returns>bool si se modofico</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                return _daoRol.Modificar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}