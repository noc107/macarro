using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoObtenerRolActual : Comando<int, Entidad>
    {
        /// <summary>
        ///  Metodo para ejecutar el comando para obtener el rol actual
        /// </summary>
        /// <param name="parametro">indice del rol</param>
        /// <returns>rol actual</returns>
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                List<Entidad> ListRol = _daoRol.ConsultarTodos();

                Entidad RolActual = ListRol[parametro];
                ((Rol)RolActual).Acciones = _daoRol.ConsultarRol(RolActual).Cast<Accion>().ToList();

                return RolActual;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}