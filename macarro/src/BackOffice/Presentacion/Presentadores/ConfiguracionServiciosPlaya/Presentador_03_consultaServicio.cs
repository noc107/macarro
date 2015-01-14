using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;
using BackOffice.Presentacion.Presentadores;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya
{
    public class Presentador_03_consultaServicio : PresentadorGeneral
    {
        #region Parámetros

        private IContrato_03_consultaServicio _consultaServicio;

        #endregion

        #region Constructor

        public Presentador_03_consultaServicio(IContrato_03_consultaServicio _consultaServicio)
            : base(_consultaServicio)
        {
            this._consultaServicio = _consultaServicio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Metodo que se llama al cargar la pagina
        /// </summary>
        public void cargarPagina()
        {
            BuscardorServicios();
        }

        /// <summary>
        /// Metodo que se llama para eliminar un servicio
        /// </summary>
        /// <param name="nombreServicio">nombre del servicio</param>
        public void EventoEliminarServicio(string nombreServicio)
        {
            try
            {
                if (EliminarServicio(nombreServicio))
                {
                    _consultaServicio.LabelMensajeExito.Visible = true;
                    _consultaServicio.LabelMensajeError.Visible = false;
                    MostrarMensajeExito(RecursosServicioPresentador._msgEliminarExito);
                    BuscardorServicios();
                }
                else
                {
                    _consultaServicio.LabelMensajeExito.Visible = false;
                    _consultaServicio.LabelMensajeError.Visible = true;
                    MostrarMensajeError(RecursosServicioPresentador._msgEliminarFallo);
                }
            }
            catch (ExcepcionComandoEliminarServicio ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }
        }

        /// <summary>
        /// Metodo que llama al comando que elimina los servicios
        /// </summary>
        /// <param name="nombreServicio"></param>
        /// <returns></returns>
        private bool EliminarServicio(string nombreServicio)
        {
            bool resultado = false;
            try
            {
                Comando<string, bool> ComandoEliminarServicio = FabricaComando.ObtenerComandoEliminarServicio();
                resultado = ComandoEliminarServicio.Ejecutar(nombreServicio);
            }
            catch (ExcepcionComandoEliminarServicio ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }
            return resultado;
        }

        /// <summary>
        /// Metodo para redireccionar a la pagina modificar servicio
        /// </summary>
        /// <param name="_nombreServicio">nombre del servicio</param>
        /// <returns>la direccionde de la pagina</returns>
        public string RedireccionarPaginaEditar(string _nombreServicio)
        {
            return RecursosServicioPresentador._pagModificar + _nombreServicio;
        }

        /// <summary>
        /// Metodo para redireccionar a la pagina Consulatr todos los datos de un servicio
        /// </summary>
        /// <param name="_nombreServicio">nombre del servicio</param>
        /// <returns>la direccion de la pagina</returns>
        public string RedireccionarPaginaConsultar(string _nombreServicio)
        {
            return RecursosServicioPresentador._pagConsultar + _nombreServicio;
        }

        /// <summary>
        /// Medoto que se invoca al presionar el boton de buscar servicios
        /// </summary>
        public void imgBuscar_Click()
        {
            try
            {
                _consultaServicio.LabelMensajeExito.Visible = false;
                _consultaServicio.LabelMensajeError.Visible = false;
                BuscardorServicios();
            }

            catch (ExcepcionComandoConsultarServicios ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }
        }

        /// <summary>
        /// Metodo que busca los servicos
        /// </summary>
        private void BuscardorServicios()
        {
            try
            {
                Servicio _servicio = new Servicio(_consultaServicio.servicioABuscar.Text, _consultaServicio.estadoDelServicio.SelectedValue);
                LlenarServicios(ConsultarServicio(_servicio));
            }
            catch (ExcepcionComandoConsultarServicios ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }
        }

        /// <summary>
        /// Metodo que llama al comando para consultar los servicios
        /// </summary>
        /// <param name="parametro">servicio. nombre (este nombre sirve para buscar alguna coincidencia con el nombre o descripcion de 
        ///                                            los servicios almacenado) y estado del servicio</param>
        /// <returns>lista de servicios</returns>
        private List<Servicio> ConsultarServicio(Servicio parametro)
        {
            List<Servicio> _listaServicio = new List<Servicio>();
            try
            {
                Comando<Entidad, List<Entidad>> ComandoConsultarServicio = FabricaComando.ObtenerComandoConsultarServicios();
                List<Entidad> _listaDesdeComando = ComandoConsultarServicio.Ejecutar(parametro);

                _listaServicio = ConvertirLista(_listaDesdeComando);
            }
            catch (ExcepcionComandoConsultarServicios ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            return _listaServicio;
        }

        /// <summary>
        /// Metodo para llenar el gridview con los servicios
        /// </summary>
        /// <param name="lista">Lista de servicios</param>
        private void LlenarServicios(List<Servicio> lista)
        {
            try
            {
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        _consultaServicio.tablaDeServicios.DataSource = lista;
                        _consultaServicio.tablaDeServicios.DataBind();
                    }
                    else
                    {
                        _consultaServicio.LabelMensajeError.Visible = true;
                        MostrarMensajeError(RecursosServicioPresentador._msgConsultaBuscarFallo);
                    }

                }
                /*else
                {
                    _consultaServicio.LabelMensajeError.Visible = true;
                    MostrarMensajeError(RecursosServicioPresentador._msgConsultaBuscarFallo);
                    _consultaServicio.tablaDeServicios.DataSource = null;
                }*/
                _consultaServicio.tablaDeServicios.DataBind();
            }
            catch (ExcepcionComandoConsultarServicios ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Mensaje);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Mensaje);
            }
        }

        /// <summary>
        /// Metodo para convertir una lista de Entidad en una lista de servicios
        /// </summary>
        /// <param name="_listaServ">Lista de entidad</param>
        /// <returns>Lista de servicios</returns>
        private List<Servicio> ConvertirLista(List<Entidad> _listaServ)
        {
            List<Servicio> _listaServicio = new List<Servicio>();
            try
            {
                //List<Servicio> _listaServicio = new List<Servicio>();
                foreach (Entidad entidad in _listaServ)
                {
                    _listaServicio.Add(entidad as Servicio);
                }
                return _listaServicio;
            }
            catch (ExcepcionComandoConsultarServicios ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);

            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicio.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }
            return _listaServicio;
        }

        #endregion
    }
}