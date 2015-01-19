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
    public class ComandoCambioEstado : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para cargar las ciudades de un estado
        /// </summary>
        /// <param name="parametro">string que contiene el nombre del estado</param>
        /// <returns>Lista de string que contiene el nombre de las ciudades</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> _ciudades;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _ciudades = _daoProveedor.CiudadesDeEstado(parametro);
                return _ciudades;

            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoCambioEstado exComandoCambioEstado = new ExcepcionComandoCambioEstado
                                         ("RS_08_002",
                                          "Comando Cambio Estado",
                                          "Cambia Estados",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoCambioEstado);

                throw exComandoCambioEstado;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCambioEstado exComandoCambioEstado = new ExcepcionComandoCambioEstado
                                          ("RS_08_003",
                                          "Comando Cambio Estado",
                                          "Cambia Estados",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoCambioEstado);

                throw exComandoCambioEstado;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCambioEstado exComandoCambioEstado = new ExcepcionComandoCambioEstado
                                         ("RS_08_004",
                                          "Comando Cambio Estado",
                                          "Cambia Estados",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoCambioEstado);

                throw exComandoCambioEstado;
            }

        } 

    }
}