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
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdAgregarProv,
                                          RecursosComandoProveedor.AgregarProv,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoAgregarProveedor);

                throw exComandoAgregarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoAgregarProveedor exComandoAgregarProveedor = new ExcepcionComandoAgregarProveedor
                                          (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdAgregarProv,
                                          RecursosComandoProveedor.AgregarProv,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoAgregarProveedor);

                throw exComandoAgregarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoAgregarProveedor exComandoAgregarProveedor = new ExcepcionComandoAgregarProveedor
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdAgregarProv,
                                          RecursosComandoProveedor.AgregarProv,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoAgregarProveedor);

                throw exComandoAgregarProveedor;
            }

            return false;
        }
    }
}