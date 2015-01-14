using System;
using System.Collections.Generic;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionPuestosPlaya;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoConsultarEstadosInventario : Comando<int, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int parametro)
        {
            try
            {
                IDaoInventarioPlaya _daoinventarioPlaya;

                _daoinventarioPlaya = FabricaDao.ObtenerDaoInventarioPlaya();

                return _daoinventarioPlaya.ConsultarEstadosInventario();
            }
            catch (ExcepcionDaoInventarioPlaya e)
            {            
                ExcepcionComandoConsultarEstadosInventario exComandoConsultarEstadosInventario =
                    new ExcepcionComandoConsultarEstadosInventario(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
                Logger.EscribirEnLogger(exComandoConsultarEstadosInventario);

                throw exComandoConsultarEstadosInventario;
                
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoConsultarEstadosInventario exComandoConsultarEstadosInventario =
                    new ExcepcionComandoConsultarEstadosInventario(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoConsultarEstadosInventario,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
                Logger.EscribirEnLogger(exComandoConsultarEstadosInventario);

                throw exComandoConsultarEstadosInventario;
            }     
        }
    }
}