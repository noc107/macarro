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
    public class ComandoConsultarProveedor:Comando<int, Entidad>
    {
        /// <summary>
        /// Metodo que se utiliza para consultar un proveedor
        /// </summary>
        /// <param name="parametro">Integer con el id del proveedor</param>
        /// <returns>Proveedor con toda su informacion</returns>
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();

                return _daoProveedor.ConsultarXId(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoConsultarProveedor exComandoConsultarProveedor = new ExcepcionComandoConsultarProveedor
                                         ("RS_08_002",
                                          "Comando Consultar Proveedor",
                                          "Consulta Proveedor",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          e);
                Logger.EscribirEnLogger(exComandoConsultarProveedor);

                throw exComandoConsultarProveedor;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoConsultarProveedor exComandoConsultarProveedor = new ExcepcionComandoConsultarProveedor
                                          ("RS_08_003",
                                          "Comando Consultar Proveedor",
                                          "Consulta Proveedor",
                                          "Error ocurrido en DaoProveedor",
                                          e);
                Logger.EscribirEnLogger(exComandoConsultarProveedor);

                throw exComandoConsultarProveedor;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoConsultarProveedor exComandoConsultarProveedor = new ExcepcionComandoConsultarProveedor
                                         ("RS_08_004",
                                          "Comando Consultar Proveedor",
                                          "Consulta Proveedor",
                                          "No se han podido cargar los datos debido a un error en el sistema",
                                          e);
                Logger.EscribirEnLogger(exComandoConsultarProveedor);

                throw exComandoConsultarProveedor;
            }
            return null;
        }
    }
}