using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao.Proveedores;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.LogicaNegocio.Comandos.Proveedores.Recursos;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoCargarGVProveedores : Comando<string, List<Entidad>>
    {
        /// <summary>
        /// Metodo que se utiliza para consultar todos los proveedores
        /// </summary>
        /// <param name="parametro">String con el parametro de busqueda</param>
        /// <returns>Lista de proveedores con todos los proveedores</returns>
        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();

                return _daoProveedor.ConsultarTodosBusq(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoCargarGVProveedores exComandoCargarGVProveedores = new ExcepcionComandoCargarGVProveedores
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdCargarGVProv,
                                          RecursosComandoProveedor.CargarDatosGV,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoCargarGVProveedores);

                throw exComandoCargarGVProveedores;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCargarGVProveedores exComandoCargarGVProveedores = new ExcepcionComandoCargarGVProveedores
                                          (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdCargarGVProv,
                                          RecursosComandoProveedor.CargarDatosGV,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoCargarGVProveedores);

                throw exComandoCargarGVProveedores;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCargarGVProveedores exComandoCargarGVProveedores = new ExcepcionComandoCargarGVProveedores
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdCargarGVProv,
                                          RecursosComandoProveedor.CargarDatosGV,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoCargarGVProveedores);

                throw exComandoCargarGVProveedores;
            }
        }
    }
}