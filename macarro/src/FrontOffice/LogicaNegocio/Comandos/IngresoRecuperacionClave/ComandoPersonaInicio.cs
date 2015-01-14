using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Dominio;
using FrontOffice.Excepciones.ExcepcionesComando.IngresoRecuperacionClave;
using FrontOffice.Excepciones.ExcepcionesDao;
using FrontOffice.Excepciones.ExcepcionesDao.IngresoRecuperacionClave;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.IngresoRecuperacionClave;
using FrontOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave.Recursos;

namespace FrontOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave
{
    public class ComandoPersonaInicio : Comando<Entidad, Entidad> 
    {
        /// <summary>
        /// Metodo para recuperar los datos de persona en el inicio de un usuario
        /// </summary>
        /// <param name="parametro">Usuario a buscar</param>
        /// <returns>Persona (si es encontrada)</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                // Me conecto enviando el "usuario", devuelvo a la persona real (si existe).

                IDaoIniciarSesion _daoIniciarSesion;
                _daoIniciarSesion = FabricaDao.ObtenerDaoIniciarSesion();

                return _daoIniciarSesion.verificarDatosPersona(parametro);

            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionComandoPersona(RecursosComandoInicioRecuperacionClave.CodigoNullReferenceException,
                                                     RecursosComandoInicioRecuperacionClave.ClaseComandoPersonaInicio,
                                                     RecursosComandoInicioRecuperacionClave.MetodoEjecutar,
                                                     RecursosComandoInicioRecuperacionClave.MensajeNullReferenceException,
                                                     e);
            }
            catch (ExcepcionDaoInicio e)
            {
                throw new ExcepcionComandoPersona(e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
            }
            catch (ExcepcionDao e)
            {
                throw new ExcepcionComandoPersona(RecursosComandoInicioRecuperacionClave.CodigoGeneralError,
                                                     RecursosComandoInicioRecuperacionClave.ClaseComandoPersonaInicio,
                                                     RecursosComandoInicioRecuperacionClave.MetodoEjecutar,
                                                     RecursosComandoInicioRecuperacionClave.MensajeGeneralError,
                                                     e);
            }
            //return null;
        }
    }
}