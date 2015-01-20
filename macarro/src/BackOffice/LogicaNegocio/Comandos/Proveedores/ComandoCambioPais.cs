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
    public class ComandoCambioPais : Comando<string,List<string>>
    {
        /// <summary>
        /// Metodo que se utiliza para obtener los estados de un pais
        /// </summary>
        /// <param name="parametro">string que contiene el nombre del pais</param>
        /// <returns>Lista de string con los nombres de los estados del pais</returns>
        public override List<string> Ejecutar(string parametro)
        {
            List<string> _estados;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _estados = _daoProveedor.EstadosDePais(parametro);
                return _estados;
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoCambioPais exComandoCambioPais = new ExcepcionComandoCambioPais
                                         (RecursosComandoProveedor.rs02,
                                          RecursosComandoProveedor.CmdCambioPais,
                                          RecursosComandoProveedor.TraeEstadosPais,
                                          RecursosComandoProveedor.ex02,
                                          e);
                Logger.EscribirEnLogger(exComandoCambioPais);

                throw exComandoCambioPais;
            }
            catch (ExcepcionDaoProveedor e)
            {
                ExcepcionComandoCambioPais exComandoCambioPais = new ExcepcionComandoCambioPais
                                         (RecursosComandoProveedor.rs03,
                                          RecursosComandoProveedor.CmdCambioPais,
                                          RecursosComandoProveedor.TraeEstadosPais,
                                          RecursosComandoProveedor.ex03,
                                          e);
                Logger.EscribirEnLogger(exComandoCambioPais);

                throw exComandoCambioPais;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoCambioPais exComandoCambioPais = new ExcepcionComandoCambioPais
                                         (RecursosComandoProveedor.rs04,
                                          RecursosComandoProveedor.CmdCambioPais,
                                          RecursosComandoProveedor.TraeEstadosPais,
                                          RecursosComandoProveedor.ex04,
                                          e);
                Logger.EscribirEnLogger(exComandoCambioPais);

                throw exComandoCambioPais;
            }
            return _estados = null;
        }
    }
}