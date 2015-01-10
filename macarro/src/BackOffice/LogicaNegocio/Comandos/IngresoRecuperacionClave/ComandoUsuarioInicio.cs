using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.IngresoRecuperacionClave;

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
            return null; 
        }
    }
}