using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
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
            catch (NullReferenceException e)
            {
                ExcepcionComandoObtenerRolActual exComandoObtenerRolActual = new ExcepcionComandoObtenerRolActual
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoObtenerRolActual,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoObtenerRolActual);

                throw exComandoObtenerRolActual;
            }
            catch (ExcepcionDaoRol e)
            {
                ExcepcionComandoObtenerRolActual exComandoObtenerRolActual = new ExcepcionComandoObtenerRolActual
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoObtenerRolActual);

                throw exComandoObtenerRolActual;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoObtenerRolActual exComandoObtenerRolActual = new ExcepcionComandoObtenerRolActual
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoObtenerRolActual,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoObtenerRolActual);

                throw exComandoObtenerRolActual;
            }
        

        }
    }
}