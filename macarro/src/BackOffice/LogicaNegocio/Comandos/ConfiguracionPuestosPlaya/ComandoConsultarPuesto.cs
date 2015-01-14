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
    public class ComandoConsultarPuesto: Comando<string,List<Entidad>>
    {
       

        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                string[] para = parametro.Split(':');
                string parametroFila = para[0];
                string parametroColumna = para[1];
                IDaoPuestoPlaya _daoPuestoPlaya;

                _daoPuestoPlaya = FabricaDao.ObtenerDaoPuestoPlaya();

                

                return _daoPuestoPlaya.ConsultarPuesto(parametroFila,parametroColumna);
            }
            catch (ExcepcionDaoPuestoPlaya e)
            {
                throw new ExcepcionComandoConsultarPuesto(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
            }
            catch (ExcepcionDao e)
            {
                throw new ExcepcionComandoConsultarPuesto(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoConsultarPuesto,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
            }
            
        }
    }
}