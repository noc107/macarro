using System;
using System.Collections.Generic;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionPuestosPlaya;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoConsultarInventarioTipo : Comando<string,List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                IDaoInventarioPlaya _daoinventarioPlaya;

                _daoinventarioPlaya = FabricaDao.ObtenerDaoInventarioPlaya();

                return _daoinventarioPlaya.ConsultarInventarioTipo(parametro);
            }
            catch (ExcepcionDaoInventarioPlaya e)
            {
                throw new ExcepcionComandoEliminarItemSeleccionado(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
            }
            catch (ExcepcionDao e)
            {
                throw new ExcepcionComandoEliminarItemSeleccionado(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoConsultarInventarioTipo,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
            }
            
        }
    }
}