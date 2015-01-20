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
    public class ComandoObtenerTodosLosEstados : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para obtener todos los estados
        /// </summary>
        /// <param name="parametro">String que contiene el parametro de busqueda</param>
        /// <returns>Lista de string con los nombres de los estados</returns>
        public override List<string> Ejecutar(string parametro)
        {
            
            List<string> _estados;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _estados = _daoProveedor.ConsultarTodosEstados(parametro);
                return _estados;

            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoObtenerTodosLosEstados exComandoObtenerEstados = new ExcepcionComandoObtenerTodosLosEstados
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdObtenerEstados,
                                          RecursosComandoProveedor.ObtenerEstados,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerEstados);

                throw exComandoObtenerEstados;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoObtenerTodosLosEstados exComandoObtenerEstados = new ExcepcionComandoObtenerTodosLosEstados
                                          (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdObtenerEstados,
                                          RecursosComandoProveedor.ObtenerEstados,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerEstados);

                throw exComandoObtenerEstados;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoObtenerTodosLosEstados exComandoObtenerEstados = new ExcepcionComandoObtenerTodosLosEstados
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdObtenerEstados,
                                          RecursosComandoProveedor.ObtenerEstados,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerEstados);

                throw exComandoObtenerEstados;
            }

        } 
        
    }
}