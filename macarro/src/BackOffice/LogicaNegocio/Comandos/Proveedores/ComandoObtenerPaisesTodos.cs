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
    public class ComandoObtenerPaisesTodos : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para obtener todos los paises
        /// </summary>
        /// <param name="parametro">String que contiene el parametro de busqueda</param>
        /// <returns>Lista de string con los nombres de los paises</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> Paises;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                Paises = _daoProveedor.ConsultarTodosPaises(parametro);
                return Paises;
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoObtenerPaisesTodos exComandoObtenerPaises = new ExcepcionComandoObtenerPaisesTodos
                                         ("RS_08_002",
                                          "Comando Obtener Paises",
                                          "Obtener Paises",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerPaises);

                throw exComandoObtenerPaises;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoObtenerPaisesTodos exComandoObtenerPaises = new ExcepcionComandoObtenerPaisesTodos
                                          ("RS_08_003",
                                          "Comando Obtener Paises",
                                          "Obtener Paises",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerPaises);

                throw exComandoObtenerPaises;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoObtenerPaisesTodos exComandoObtenerPaises = new ExcepcionComandoObtenerPaisesTodos
                                         ("RS_08_004",
                                          "Comando Obtener Paises",
                                          "Obtener Paises",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerPaises);

                throw exComandoObtenerPaises;
            }
        }
    }
}