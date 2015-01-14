using System;
using System.Collections.Generic;
using System.Linq;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionServiciosPlaya
{
    public class ComandoEliminarServicio : Comando<string, bool>
    {
        public override bool Ejecutar(string parametro)
        {
            try
            {
                IDaoServiciosPlaya _daoServicioPlaya;
                _daoServicioPlaya = FabricaDao.ObtenerDaoServiciosPlaya();
                return _daoServicioPlaya.EliminarServicioPlaya(parametro);
            }
            catch (NullReferenceException e)
            {
                ExcepcionComandoConsultarServicios exComandoConsultarServicios = new ExcepcionComandoConsultarServicios(
                                                                                    RecursosExcepcionesComandoServiciosPlaya.codigoNullReference,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.claseComandoEliminarServicio,
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
                                                                                    RecursosExcepcionesComandoServiciosPlaya.claseComandoEliminarServicio,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.metodoEjecutar,
                                                                                    RecursosExcepcionesComandoServiciosPlaya.mensajeErrorGeneral, e);
                Logger.EscribirEnLogger(exComandoConsultarServicios);
                throw exComandoConsultarServicios;
            }
        }
    }
}