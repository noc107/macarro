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
    public class ComandoCambioPais : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para obtener los estados de un pais
        /// </summary>
        /// <param name="parametro">string que contiene el nombre del pais</param>
        /// <returns>Lista de string con los nombres de los estados del pais</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> _estados;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _estados = _daoProveedor.EstadosDePais(parametro);
                return _estados;
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoCambioPais exComandoCambioPais = new ExcepcionComandoCambioPais
                                         ("RS_08_002",
                                          "Comando Cambio Pais",
                                          "Trae Estados de Pais",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoCambioPais);

                throw exComandoCambioPais;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCambioPais exComandoCambioPais = new ExcepcionComandoCambioPais
                                          ("RS_08_003",
                                          "Comando Cambio Pais",
                                          "Trae Estados de Pais",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoCambioPais);

                throw exComandoCambioPais;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCambioPais exComandoCambioPais = new ExcepcionComandoCambioPais
                                         ("RS_08_004",
                                          "Comando Cambio Pais",
                                          "Trae Estados de Pais",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoCambioPais);

                throw exComandoCambioPais;
            }
            return _estados = null;
        }
    }
}