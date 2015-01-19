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
    public class ComandoModificarProveedor : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que se utiliza para modificar un proveedor
        /// </summary>
        /// <param name="parametro">Proveedor con la informacion a modificar</param>
        /// <returns>Boolean que indica el exito de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {

                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                return _daoProveedor.Modificar(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoModificarProveedor exComandoModificarProveedor = new ExcepcionComandoModificarProveedor
                                         ("RS_08_002",
                                          "Comando Modificar Proveedor",
                                          "Modifica Proveedor",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoModificarProveedor);

                throw exComandoModificarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoModificarProveedor exComandoModificarProveedor = new ExcepcionComandoModificarProveedor
                                          ("RS_08_003",
                                          "Comando Modificar Proveedor",
                                          "Modifica Proveedor",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoModificarProveedor);

                throw exComandoModificarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoModificarProveedor exComandoModificarProveedor = new ExcepcionComandoModificarProveedor
                                         ("RS_08_004",
                                          "Comando Modificar Proveedor",
                                          "Modifica Proveedor",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoModificarProveedor);

                throw exComandoModificarProveedor;
            }
            return false;
        }
    }
}