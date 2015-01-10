using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoLlenarGridAcciones : Comando<bool,List<Entidad>>
    {

        /// <summary>
        ///  Metodo para ejecutar el comando para llenar el grid de acciones
        /// </summary>
        /// <param name="parametro">bool ejecucion</param>
        /// <returns>lista de acciones</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                IDaoAccion _daoAccion;
                _daoAccion = FabricaDao.ObtenerDaoAccion();

                return _daoAccion.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}