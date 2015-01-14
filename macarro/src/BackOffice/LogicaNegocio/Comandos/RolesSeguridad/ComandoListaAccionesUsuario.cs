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
    public class ComandoListaAccionesUsuario : Comando<string, List<string>>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para consultar la lista de acciones de un usuario
        /// </summary>
        /// <param name="parametro">correo del usuario</param>
        /// <returns>lista de string con las acciones del usuario</returns>
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                IDaoMenu _daoMenu;
                _daoMenu = FabricaDao.ObtenerDaoMenu();

                return _daoMenu.ListaAccionesUsuario(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoListaAccionesUsuario exComandoListaAccionesUsuario = new ExcepcionComandoListaAccionesUsuario
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoListaAccionesUsuario,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoListaAccionesUsuario);

                throw exComandoListaAccionesUsuario;
            }
            catch (ExcepcionDaoMenu e)
            {
                ExcepcionComandoListaAccionesUsuario exComandoListaAccionesUsuario = new ExcepcionComandoListaAccionesUsuario
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoListaAccionesUsuario);

                throw exComandoListaAccionesUsuario;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoListaAccionesUsuario exComandoListaAccionesUsuario = new ExcepcionComandoListaAccionesUsuario
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoListaAccionesUsuario,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoListaAccionesUsuario);

                throw exComandoListaAccionesUsuario;
            }
        }
    }
}