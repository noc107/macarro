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
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdModificarProv,
                                          RecursosComandoProveedor.ModificaProv,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoModificarProveedor);

                throw exComandoModificarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoModificarProveedor exComandoModificarProveedor = new ExcepcionComandoModificarProveedor
                                         (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdModificarProv,
                                          RecursosComandoProveedor.ModificaProv,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoModificarProveedor);

                throw exComandoModificarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoModificarProveedor exComandoModificarProveedor = new ExcepcionComandoModificarProveedor
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdModificarProv,
                                          RecursosComandoProveedor.ModificaProv,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoModificarProveedor);

                throw exComandoModificarProveedor;
            }
            return false;
        }
    }
}