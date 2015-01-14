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
    public class ComandoConsultarInventarioXId : Comando<int, Entidad>
    {
        public override Entidad Ejecutar(int parametro)
        {
            try 
            {
                IDaoInventarioPlaya _daoinventarioPlaya;

                _daoinventarioPlaya = FabricaDao.ObtenerDaoInventarioPlaya();

                return _daoinventarioPlaya.ConsultarXId(parametro);
            }
            catch (ExcepcionDaoInventarioPlaya e)
            {
                ExcepcionComandoConsultarInventarioXId exComandoConsultarInventarioXId =
                    new ExcepcionComandoConsultarInventarioXId(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
                Logger.EscribirEnLogger(exComandoConsultarInventarioXId);

                throw exComandoConsultarInventarioXId;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoConsultarInventarioXId exComandoConsultarInventarioXId =
                    new ExcepcionComandoConsultarInventarioXId(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoConsultarInventarioXId,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
                Logger.EscribirEnLogger(exComandoConsultarInventarioXId);

                throw exComandoConsultarInventarioXId;
            }   
            
        }
    }
}