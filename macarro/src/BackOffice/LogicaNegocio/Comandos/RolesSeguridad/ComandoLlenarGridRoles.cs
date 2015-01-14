using BackOffice.Dominio;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.RolesSeguridad;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using BackOffice.LogicaNegocio.Comandos.RolesSeguridad.Recursos;
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
            catch (NullReferenceException e)
            {
                ExcepcionComandoLlenarGridRoles exComandoLlenarGridRoles = new ExcepcionComandoLlenarGridRoles
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoLlenarGridRoles,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoLlenarGridRoles);

                throw exComandoLlenarGridRoles;
            }
            catch (ExcepcionDaoRol e)
            {
                ExcepcionComandoLlenarGridRoles exComandoLlenarGridRoles = new ExcepcionComandoLlenarGridRoles
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoLlenarGridRoles);

                throw exComandoLlenarGridRoles;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoLlenarGridRoles exComandoLlenarGridRoles = new ExcepcionComandoLlenarGridRoles
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoLlenarGridRoles,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoLlenarGridRoles);

                throw exComandoLlenarGridRoles;
            }
        }
    
    }
}