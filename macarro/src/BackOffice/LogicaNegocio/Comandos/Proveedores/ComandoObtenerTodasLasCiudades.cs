using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.Proveedores;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoObtenerTodasLasCiudades : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para obtener todas las ciudades
        /// </summary>
        /// <param name="parametro">String que contiene el parametro de busqueda</param>
        /// <returns>Lista de string que contiene los nombres de las ciudades</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> _ciudades;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _ciudades = _daoProveedor.ConsultarTodasCiudades(parametro);
                return _ciudades;

            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoObtenerTodasLasCiudades exComandoObtenerCiudades = new ExcepcionComandoObtenerTodasLasCiudades
                                         ("RS_08_002",
                                          "Comando Obtener Todas Las Ciudades",
                                          "Obtener Ciudades",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerCiudades);

                throw exComandoObtenerCiudades;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoObtenerTodasLasCiudades exComandoObtenerCiudades = new ExcepcionComandoObtenerTodasLasCiudades
                                          ("RS_08_003",
                                          "Comando Obtener Todas Las Ciudades",
                                          "Obtener Ciudades",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerCiudades);

                throw exComandoObtenerCiudades;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoObtenerTodasLasCiudades exComandoObtenerCiudades = new ExcepcionComandoObtenerTodasLasCiudades
                                         ("RS_08_004",
                                          "Comando Obtener Todas Las Ciudades",
                                          "Obtener Ciudades",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerCiudades);

                throw exComandoObtenerCiudades;
            }
        }
    }
}