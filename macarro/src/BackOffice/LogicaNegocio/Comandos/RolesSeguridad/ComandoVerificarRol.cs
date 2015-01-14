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
            catch (NullReferenceException e)
            {
                ExcepcionComandoVerificarRol exComandoVerificarRol = new ExcepcionComandoVerificarRol
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoVerificarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoVerificarRol);

                throw exComandoVerificarRol;
            }
            catch (ExcepcionDaoRol e)
            {
                ExcepcionComandoVerificarRol exComandoVerificarRol = new ExcepcionComandoVerificarRol
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoVerificarRol);

                throw exComandoVerificarRol;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoVerificarRol exComandoVerificarRol = new ExcepcionComandoVerificarRol
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoVerificarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoVerificarRol);

                throw exComandoVerificarRol;
            }
        }
    }
}