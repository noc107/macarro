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
    public class ComandoListaUrlAccionesUsuario : Comando<string, List<string>>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para consultar la lista de URL de acciones de usuario
        /// </summary>
        /// <param name="parametro">correo del usuario</param>
        /// <returns>lista de string URL</returns>
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                IDaoMenu _daoMenu;
                _daoMenu = FabricaDao.ObtenerDaoMenu();

                return _daoMenu.ListaUrlAccionesUsuario(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoListaUrlAccionesUsuario exComandoListaUrlAccionesUsuario = new ExcepcionComandoListaUrlAccionesUsuario
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoListaUrlAccionesUsuario,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoListaUrlAccionesUsuario);

                throw exComandoListaUrlAccionesUsuario;
            }
            catch (ExcepcionDaoMenu e)
            {
                ExcepcionComandoListaUrlAccionesUsuario exComandoListaUrlAccionesUsuario = new ExcepcionComandoListaUrlAccionesUsuario
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoListaUrlAccionesUsuario);

                throw exComandoListaUrlAccionesUsuario;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoListaUrlAccionesUsuario exComandoListaUrlAccionesUsuario = new ExcepcionComandoListaUrlAccionesUsuario
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoListaUrlAccionesUsuario,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoListaUrlAccionesUsuario);

                throw exComandoListaUrlAccionesUsuario;
            }
        }
    }
}