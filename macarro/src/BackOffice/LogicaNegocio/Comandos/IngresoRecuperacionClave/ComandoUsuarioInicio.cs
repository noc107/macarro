using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Excepciones.ExcepcionesComando.IngresoRecuperacionClave;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.IngresoRecuperacionClave;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.IngresoRecuperacionClave;
using BackOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave.Recursos;

namespace BackOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave
{
    public class ComandoUsuarioInicio : Comando<Entidad, Entidad> 
    {
        /// <summary>
        /// Metodo para ejecutar el comando de inicio de un usuario
        /// </summary>
        /// <param name="parametro">Usuario a buscar</param>
        /// <returns>Usuario (si es encontrado)</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                // Me conecto enviando el "usuario" y devuelvo el usuario real (si existe), e inicializo las variables de sesión en el presentador

                IDaoIniciarSesion _daoIniciarSesion;
                _daoIniciarSesion = FabricaDao.ObtenerDaoIniciarSesion();

                return _daoIniciarSesion.verificarDatos(parametro);

            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionComandoUsuario(RecursosComandoInicioRecuperacionClave.CodigoNullReferenceException,
                                                     RecursosComandoInicioRecuperacionClave.ClaseComandoUsuarioInicio,
                                                     RecursosComandoInicioRecuperacionClave.MetodoEjecutar,
                                                     RecursosComandoInicioRecuperacionClave.MensajeNullReferenceException,
                                                     e);
            }
            catch (ExcepcionDaoInicio e)
            {
                throw new ExcepcionComandoUsuario(e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
            }
            catch (ExcepcionDao e)
            {
                throw new ExcepcionComandoUsuario(RecursosComandoInicioRecuperacionClave.CodigoGeneralError,
                                                     RecursosComandoInicioRecuperacionClave.ClaseComandoUsuarioInicio,
                                                     RecursosComandoInicioRecuperacionClave.MetodoEjecutar,
                                                     RecursosComandoInicioRecuperacionClave.MensajeGeneralError,
                                                     e);
            }
            return null; 
        }
    }
}