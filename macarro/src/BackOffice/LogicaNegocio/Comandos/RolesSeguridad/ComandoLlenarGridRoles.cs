using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoLlenarGridRoles : Comando<bool, List<Entidad>>
    {
        
        /// <summary>
        ///  Metodo para ejecutar el comando para llenar el grid de roles
        /// </summary>
        /// <param name="parametro">bool de ejecucion</param>
        /// <returns>lista de roles</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                return _daoRol.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}