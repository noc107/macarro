using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.IngresoRecuperacionClave;

namespace BackOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}