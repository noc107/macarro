using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionServiciosPlaya
{
    public class ComandoConsultarServicioCompleto : Comando<string, Entidad>
    {
        public override Entidad Ejecutar(string parametro)
        {
            try
            {
                IDaoServiciosPlaya _daoServiciosPlaya;
                _daoServiciosPlaya = FabricaDao.ObtenerDaoServiciosPlaya();
                return _daoServiciosPlaya.ConsultarServicioCompleto(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoConsultarServicioCompleto exComandoConsultarServicioCompleto = new ExcepcionComandoConsultarServicioCompleto(
                                                                                    RecursosExcepcionesComandoServiciosPlaya.codigoNullReference,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.claseComandoConsultarServicios,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.metodoEjecutar,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exComandoConsultarServicioCompleto);
                throw exComandoConsultarServicioCompleto;
            }

            catch (ExcepcionDaoServiciosPlaya e)
            {
                ExcepcionComandoConsultarServicioCompleto exComandoConsultarServicioCompleto = new ExcepcionComandoConsultarServicioCompleto(e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoConsultarServicioCompleto);
                throw exComandoConsultarServicioCompleto;
            }

            catch (ExcepcionDao e)
            {
                ExcepcionComandoConsultarServicioCompleto exComandoConsultarServicioCompleto = new ExcepcionComandoConsultarServicioCompleto(
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeErrorGeneral,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.claseComandoConsultarServicios,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.metodoEjecutar,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeErrorGeneral, e);
                Logger.EscribirEnLogger(exComandoConsultarServicioCompleto);
                throw exComandoConsultarServicioCompleto;
            }
        }
    }
}