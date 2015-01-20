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
using BackOffice.LogicaNegocio.Comandos.Proveedores.Recursos;

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
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdEliminarProv,
                                          RecursosComandoProveedor.EliminarProv,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoEliminarProveedor);

                throw exComandoEliminarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoEliminarProveedor exComandoEliminarProveedor = new ExcepcionComandoEliminarProveedor
                                         (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdEliminarProv,
                                          RecursosComandoProveedor.EliminarProv,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoEliminarProveedor);

                throw exComandoEliminarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoEliminarProveedor exComandoEliminarProveedor = new ExcepcionComandoEliminarProveedor
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdEliminarProv,
                                          RecursosComandoProveedor.EliminarProv,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoEliminarProveedor);

                throw exComandoEliminarProveedor;
            }
            return false;
        }
    }
}