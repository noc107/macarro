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
    public class ComandoCambioEstado : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para cargar las ciudades de un estado
        /// </summary>
        /// <param name="parametro">string que contiene el nombre del estado</param>
        /// <returns>Lista de string que contiene el nombre de las ciudades</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> _ciudades;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _ciudades = _daoProveedor.CiudadesDeEstado(parametro);
                return _ciudades;

            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoCambioEstado exComandoCambioEstado = new ExcepcionComandoCambioEstado
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdCambioEstados,
                                          RecursosComandoProveedor.CambioEstados,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoCambioEstado);

                throw exComandoCambioEstado;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCambioEstado exComandoCambioEstado = new ExcepcionComandoCambioEstado
                                         (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdCambioEstados,
                                          RecursosComandoProveedor.CambioEstados,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoCambioEstado);

                throw exComandoCambioEstado;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCambioEstado exComandoCambioEstado = new ExcepcionComandoCambioEstado
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdCambioEstados,
                                          RecursosComandoProveedor.CambioEstados,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoCambioEstado);

                throw exComandoCambioEstado;
            }

        } 

    }
}