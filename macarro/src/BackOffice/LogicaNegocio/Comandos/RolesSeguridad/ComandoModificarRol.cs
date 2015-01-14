using BackOffice.Dominio;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.RolesSeguridad;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using BackOffice.LogicaNegocio.Comandos.RolesSeguridad.Recursos;
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
            catch (NullReferenceException e)
            {
                ExcepcionComandoModificarRol exComandoModificarRol = new ExcepcionComandoModificarRol
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoModificarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoModificarRol);

                throw exComandoModificarRol;
            }
            catch (ExcepcionDaoRol e)
            {
                ExcepcionComandoModificarRol exComandoModificarRol = new ExcepcionComandoModificarRol
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoModificarRol);

                throw exComandoModificarRol;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoModificarRol exComandoModificarRol = new ExcepcionComandoModificarRol
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoModificarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoModificarRol);

                throw exComandoModificarRol;
            }
        }
    }
}