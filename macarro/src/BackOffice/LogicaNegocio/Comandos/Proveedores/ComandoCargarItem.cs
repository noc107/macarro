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
using BackOffice.LogicaNegocio.Comandos.Proveedores.Recursos;

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
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdCargarItem,
                                          RecursosComandoProveedor.CargaItemProv,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoCargarItem);

                throw exComandoCargarItem;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCargarItem exComandoCargarItem = new ExcepcionComandoCargarItem
                                         (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdCargarItem,
                                          RecursosComandoProveedor.CargaItemProv,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoCargarItem);

                throw exComandoCargarItem;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCargarItem exComandoCargarItem = new ExcepcionComandoCargarItem
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdCargarItem,
                                          RecursosComandoProveedor.CargaItemProv,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoCargarItem);

                throw exComandoCargarItem;
            }

        }
    }
}