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
    public class ComandoAgregarProveedor : Comando<Entidad,bool>
    {   
        /// <summary>
        /// Metodo que se utiliza para agregar un proveedor
        /// </summary>
        /// <param name="parametro">Entidad proveedor que se quiere agregar</param>
        /// <returns>Boolean indicando el exito de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                return _daoProveedor.Agregar(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoAgregarProveedor exComandoAgregarProveedor = new ExcepcionComandoAgregarProveedor
                                         ("RS_08_002",
                                          "Comando Agregar Proveedor",
                                          "Agregar Proveedor",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoAgregarProveedor);

                throw exComandoAgregarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoAgregarProveedor exComandoAgregarProveedor = new ExcepcionComandoAgregarProveedor
                                          ("RS_08_003",
                                          "Comando Agregar Proveedor",
                                          "Agregar Proveedor",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoAgregarProveedor);

                throw exComandoAgregarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoAgregarProveedor exComandoAgregarProveedor = new ExcepcionComandoAgregarProveedor
                                         ("RS_08_004",
                                          "Comando Agregar Proveedor",
                                          "Agregar Proveedor",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoAgregarProveedor);

                throw exComandoAgregarProveedor;
            }

            return false;
        }
    }
}