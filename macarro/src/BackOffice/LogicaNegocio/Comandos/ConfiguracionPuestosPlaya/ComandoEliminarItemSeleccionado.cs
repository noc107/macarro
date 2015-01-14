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
    public class ComandoEliminarItemSeleccionado : Comando<int, bool>
    {
        public override bool Ejecutar(int parametro)
        {
            try
            {
                 IDaoInventarioPlaya _daoinventarioPlaya;

                _daoinventarioPlaya = FabricaDao.ObtenerDaoInventarioPlaya();

                return _daoinventarioPlaya.EliminarItemSeleccionado(parametro);
            }           
            catch (ExcepcionDaoInventarioPlaya e)
            {
                ExcepcionComandoEliminarItemSeleccionado exComandoEliminarItemSeleccionado = 
                    new ExcepcionComandoEliminarItemSeleccionado(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
                Logger.EscribirEnLogger(exComandoEliminarItemSeleccionado);

                throw exComandoEliminarItemSeleccionado;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoEliminarItemSeleccionado exComandoEliminarItemSeleccionado =
                    new ExcepcionComandoEliminarItemSeleccionado(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoEliminarItemSeleccionado,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
                Logger.EscribirEnLogger(exComandoEliminarItemSeleccionado);

                throw exComandoEliminarItemSeleccionado;
            }           
        }
    }
}