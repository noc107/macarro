using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using BackOffice.LogicaNegocio.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoEliminarRol : Comando<int, bool>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para eliminar un rol
        /// </summary>
        /// <param name="parametro">indice del rol</param>
        /// <returns>si elimino</returns>
        public override bool Ejecutar(int parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                Comando<int, Entidad> ComandoObtenerRolActual;
                ComandoObtenerRolActual = FabricaComando.ObtenerComandoObtenerRolActual();
                Entidad RolActual = ComandoObtenerRolActual.Ejecutar(parametro);

                return _daoRol.EliminarRol(RolActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}