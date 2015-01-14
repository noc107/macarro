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
            catch (NullReferenceException e)
            {
                ExcepcionComandoLlenarGridAcciones exComandoLlenarGridAcciones = new ExcepcionComandoLlenarGridAcciones
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoLlenarGridAcciones,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoLlenarGridAcciones);

                throw exComandoLlenarGridAcciones;
            }
            catch (ExcepcionDaoAccion e)
            {
                ExcepcionComandoLlenarGridAcciones exComandoLlenarGridAcciones = new ExcepcionComandoLlenarGridAcciones
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoLlenarGridAcciones);

                throw exComandoLlenarGridAcciones;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoLlenarGridAcciones exComandoLlenarGridAcciones = new ExcepcionComandoLlenarGridAcciones
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoLlenarGridAcciones,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoLlenarGridAcciones);

                throw exComandoLlenarGridAcciones;
            }
        }
    
    }
}