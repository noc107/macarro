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
    public class ComandoObtenerPaisesTodos : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para obtener todos los paises
        /// </summary>
        /// <param name="parametro">String que contiene el parametro de busqueda</param>
        /// <returns>Lista de string con los nombres de los paises</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> Paises;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                Paises = _daoProveedor.ConsultarTodosPaises(parametro);
                return Paises;
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoObtenerPaisesTodos exComandoObtenerPaises = new ExcepcionComandoObtenerPaisesTodos
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdObtenerPaises,
                                          RecursosComandoProveedor.ObtenerPaises,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerPaises);

                throw exComandoObtenerPaises;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoObtenerPaisesTodos exComandoObtenerPaises = new ExcepcionComandoObtenerPaisesTodos
                                         (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdObtenerPaises,
                                          RecursosComandoProveedor.ObtenerPaises,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerPaises);

                throw exComandoObtenerPaises;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoObtenerPaisesTodos exComandoObtenerPaises = new ExcepcionComandoObtenerPaisesTodos
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdObtenerPaises,
                                          RecursosComandoProveedor.ObtenerPaises,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoObtenerPaises);

                throw exComandoObtenerPaises;
            }
        }
    }
}