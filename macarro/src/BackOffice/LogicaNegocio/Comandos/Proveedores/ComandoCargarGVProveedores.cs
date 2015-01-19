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
                                         ("RS_08_002",
                                          "Comando Cargar GV Proveedores",
                                          "Carga Datos en GV",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoCargarGVProveedores);

                throw exComandoCargarGVProveedores;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCargarGVProveedores exComandoCargarGVProveedores = new ExcepcionComandoCargarGVProveedores
                                          ("RS_08_003",
                                          "Comando Cargar GV Proveedores",
                                          "Carga Datos en GV",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoCargarGVProveedores);

                throw exComandoCargarGVProveedores;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCargarGVProveedores exComandoCargarGVProveedores = new ExcepcionComandoCargarGVProveedores
                                         ("RS_08_004",
                                          "Comando Cargar GV Proveedores",
                                          "Carga Datos en GV",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoCargarGVProveedores);

                throw exComandoCargarGVProveedores;
            }
        }
    }
}