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
using System.Web.UI.WebControls;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoObtenerMenuMaster : Comando<string, Menu>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para consultar los ids de acciones de usuario
        /// </summary>
        /// <param name="parametro">correo del usuario</param>
        /// <returns>string con los ids de acciones para usar en la consulta SQL</returns>
        public override Menu Ejecutar(string parametro)
        {
            try
            {
                IDaoMenu _daoMenu;
                _daoMenu = FabricaDao.ObtenerDaoMenu();

                return _daoMenu.ConsultarMenuMaster(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoObtenerMenuMaster exComandoObtenerMenuMaster = new ExcepcionComandoObtenerMenuMaster
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoObtenerMenuMaster,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoObtenerMenuMaster);

                throw exComandoObtenerMenuMaster;
            }
            catch (ExcepcionDaoMenu e)
            {
                ExcepcionComandoObtenerMenuMaster exComandoObtenerMenuMaster = new ExcepcionComandoObtenerMenuMaster
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoObtenerMenuMaster);

                throw exComandoObtenerMenuMaster;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoObtenerMenuMaster exComandoObtenerMenuMaster = new ExcepcionComandoObtenerMenuMaster
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoObtenerMenuMaster,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoObtenerMenuMaster);

                throw exComandoObtenerMenuMaster;
            }
        }
    }
}