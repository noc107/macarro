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
    public class ComandoActualizarInventarioTipo : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoInventarioPlaya _daoinventarioPlaya;

                _daoinventarioPlaya = FabricaDao.ObtenerDaoInventarioPlaya();

                return _daoinventarioPlaya.Modificar(parametro);
            }
            catch (ExcepcionDaoInventarioPlaya e)
            {
                ExcepcionComandoActualizarInventarioTipo exComandoActualizarInventarioTipo =
                    new ExcepcionComandoActualizarInventarioTipo(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
                Logger.EscribirEnLogger(exComandoActualizarInventarioTipo);

                throw exComandoActualizarInventarioTipo; 
                
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoActualizarInventarioTipo exComandoActualizarInventarioTipo =
                    new ExcepcionComandoActualizarInventarioTipo(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoActualizarInventarioTipo,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
                Logger.EscribirEnLogger(exComandoActualizarInventarioTipo);

                throw exComandoActualizarInventarioTipo; 
                
            }
        }
    }
}