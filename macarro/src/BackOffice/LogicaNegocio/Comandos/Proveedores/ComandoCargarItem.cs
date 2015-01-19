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

    public class ComandoCargarItem : Comando<int, List<string>>
    {
        /// <summary>
        /// Metodo que se usa para obtener todos los items de un proveedor
        /// </summary>
        /// <param name="parametro">Integer que contiene el id del proveedor</param>
        /// <returns>Lista de string con los nombres de los items</returns>
        public override List<string> Ejecutar(int parametro)
        {
            List<string> _item;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _item = _daoProveedor.CargarItemLt(parametro);
                return _item;
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoCargarItem exComandoCargarItem = new ExcepcionComandoCargarItem
                                         ("RS_08_002",
                                          "Comando Cargar Item",
                                          "Carga Item en Proveedor",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoCargarItem);

                throw exComandoCargarItem;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCargarItem exComandoCargarItem = new ExcepcionComandoCargarItem
                                          ("RS_08_003",
                                          "Comando Cargar Item",
                                          "Carga Item en Proveedor",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoCargarItem);

                throw exComandoCargarItem;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCargarItem exComandoCargarItem = new ExcepcionComandoCargarItem
                                         ("RS_08_004",
                                          "Comando Cargar Item",
                                          "Carga Item en Proveedor",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoCargarItem);

                throw exComandoCargarItem;
            }

        }
    }
}