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
    public class ComandoActualizarItemSeleccionado : Comando<Entidad, bool>
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
                ExcepcionComandoActualizarItemSeleccionado exComandoActualizarItemSeleccionado =
                    new ExcepcionComandoActualizarItemSeleccionado(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
                Logger.EscribirEnLogger(exComandoActualizarItemSeleccionado);

                throw exComandoActualizarItemSeleccionado;                
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoActualizarItemSeleccionado exComandoActualizarItemSeleccionado =
                    new ExcepcionComandoActualizarItemSeleccionado(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoActualizarItemSeleccionado,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
                Logger.EscribirEnLogger(exComandoActualizarItemSeleccionado);

                throw exComandoActualizarItemSeleccionado; 
                
            }
        }
    }
}