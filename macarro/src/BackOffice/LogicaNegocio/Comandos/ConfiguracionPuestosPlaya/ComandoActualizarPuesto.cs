using System;
using System.Collections.Generic;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionPuestosPlaya;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoActualizarPuesto : Comando<Entidad, bool>

    {
        
        public  override bool Ejecutar(Entidad Puesto2)
        {
            try
            {
                IDaoPuestoPlaya _daoPuestoPlaya;

                _daoPuestoPlaya = FabricaDao.ObtenerDaoPuestoPlaya();

                Puesto Puesto;
                Puesto = (Puesto)Puesto2;
               
                string monto;
                if (Puesto.Precio == 0)
                    monto = string.Empty;
                else
                    monto = Puesto.Precio.ToString();


                string filar;
                if (Puesto.Fila == 0)
                    filar = string.Empty;
                else
                    filar = Puesto.Fila.ToString();

                string columnar;
                if (Puesto.Columna == 0)
                    columnar = string.Empty;
                else
                    columnar = Puesto.Columna.ToString();
                
                return _daoPuestoPlaya.ActualizacionPuesto(filar,columnar,Puesto.Descripcion,monto,Puesto.Estado);
            }
            catch (ExcepcionDaoPuestoPlaya e)
            {
                throw new ExcepcionComandoActualizarPuesto(e.Codigo,
                                                                   e.Clase,
                                                                   e.Metodo,
                                                                   e.Mensaje,
                                                                   e);
            }
            catch (ExcepcionDao e)
            {
                throw new ExcepcionComandoActualizarPuesto(RecursosComando.CodigoErrorGeneral,
                                                                   RecursosComando.ClaseComandoActualizarPuesto,
                                                                   RecursosComando.MetodoEjecutar,
                                                                   RecursosComando.MensajeErrorExcepcion,
                                                                   e);
            }
        }
    }
}