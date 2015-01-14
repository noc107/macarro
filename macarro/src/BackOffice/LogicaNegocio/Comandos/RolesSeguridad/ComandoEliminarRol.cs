using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
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
            catch (ExcepcionFKRol e) 
            {
                ExcepcionComandoEliminarRol exComandoEliminarRol = new ExcepcionComandoEliminarRol
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoEliminarRol);

                throw exComandoEliminarRol;
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoEliminarRol exComandoEliminarRol = new ExcepcionComandoEliminarRol
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoEliminarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoEliminarRol);

                throw exComandoEliminarRol;
            }
            catch (ExcepcionDaoRol e)
            {
                ExcepcionComandoEliminarRol exComandoEliminarRol = new ExcepcionComandoEliminarRol
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoEliminarRol);

                throw exComandoEliminarRol;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoEliminarRol exComandoEliminarRol = new ExcepcionComandoEliminarRol
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoEliminarRol,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoEliminarRol);

                throw exComandoEliminarRol;
            }
        }
    
    }
}