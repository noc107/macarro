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
    public class ComandoAgregarRol : Comando<Entidad, bool>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para agregar un rol
        /// </summary>
        /// <param name="parametro">rol a agregar</param>
        /// <returns>bool si agrego</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoRol _daoRol;
                _daoRol = FabricaDao.ObtenerDaoRol();

                return _daoRol.Agregar(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoAgregarRol exComandoAgregarRol = new ExcepcionComandoAgregarRol
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoAgregarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoAgregarRol);

                throw exComandoAgregarRol;
            }
            catch (ExcepcionDaoRol e)
            {
                ExcepcionComandoAgregarRol exComandoAgregarRol = new ExcepcionComandoAgregarRol
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoAgregarRol);

                throw exComandoAgregarRol;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoAgregarRol exComandoAgregarRol = new ExcepcionComandoAgregarRol
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoAgregarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoAgregarRol);

                throw exComandoAgregarRol;
            }
        }
    }
}