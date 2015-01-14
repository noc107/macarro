using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionServiciosPlaya;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionServiciosPlaya
{
    public class ComandoConsultarServicios : Comando<Entidad, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoServiciosPlaya _daoServicioPlaya;
                _daoServicioPlaya = FabricaDao.ObtenerDaoServiciosPlaya();
                return _daoServicioPlaya.ConsultarServicios(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoConsultarServicios exComandoConsultarServicios = new ExcepcionComandoConsultarServicios(
                                                                                    RecursosExcepcionesComandoServiciosPlaya.codigoNullReference,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.claseComandoConsultarServicios,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.metodoEjecutar,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exComandoConsultarServicios);
                throw exComandoConsultarServicios;
            }

            catch (ExcepcionDaoServiciosPlaya e)
            {
                ExcepcionComandoConsultarServicios exComandoConsultarServicios = new ExcepcionComandoConsultarServicios(e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoConsultarServicios);
                throw exComandoConsultarServicios;
            }

            catch (ExcepcionDao e)
            {
                ExcepcionComandoConsultarServicios exComandoConsultarServicios = new ExcepcionComandoConsultarServicios(
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeErrorGeneral,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.claseComandoConsultarServicios,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.metodoEjecutar,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeErrorGeneral, e);
                Logger.EscribirEnLogger(exComandoConsultarServicios);
                throw exComandoConsultarServicios;
            }

        }
    }
}