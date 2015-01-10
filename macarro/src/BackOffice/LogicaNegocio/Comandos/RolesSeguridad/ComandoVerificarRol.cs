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
    public class ComandoVerificarRol : Comando<string, bool>
    {
        /// <summary>
        ///  Metodo para ejecutar el comando para verificar el rol
        /// </summary>
        /// <param name="parametro">nombre del rol</param>
        /// <returns>si el rol existe</returns>
        public override bool Ejecutar(string parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                foreach (Rol r in _daoRol.ConsultarTodos())
                {
                    if (r.Nombre.Equals(parametro, StringComparison.OrdinalIgnoreCase))
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}