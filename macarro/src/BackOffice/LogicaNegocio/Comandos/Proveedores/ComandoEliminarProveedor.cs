using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones.ExcepcionesDao.Proveedores;
using BackOffice.Excepciones;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoEliminarProveedor : Comando<int, bool>
    {
        /// <summary>
        /// Metodo que se utiliza para eliminar un proveedor
        /// </summary>
        /// <param name="parametro">Integer que contiene el id del proveedor a eliminar</param>
        /// <returns>Boolean que indica el exito de la operacion</returns>
        public override bool Ejecutar(int parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();

                return _daoProveedor.eliminarProveedor(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoEliminarProveedor exComandoEliminarProveedor = new ExcepcionComandoEliminarProveedor
                                         ("RS_08_002",
                                          "Comando Eliminar Proveedor",
                                          "Eliminar Proveedor",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoEliminarProveedor);

                throw exComandoEliminarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoEliminarProveedor exComandoEliminarProveedor = new ExcepcionComandoEliminarProveedor
                                          ("RS_08_003",
                                          "Comando Eliminar Proveedor",
                                          "Eliminar Proveedor",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoEliminarProveedor);

                throw exComandoEliminarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoEliminarProveedor exComandoEliminarProveedor = new ExcepcionComandoEliminarProveedor
                                         ("RS_08_004",
                                          "Comando Eliminar Proveedor",
                                          "Eliminar Proveedor",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoEliminarProveedor);

                throw exComandoEliminarProveedor;
            }
            return false;
        }
    }
}