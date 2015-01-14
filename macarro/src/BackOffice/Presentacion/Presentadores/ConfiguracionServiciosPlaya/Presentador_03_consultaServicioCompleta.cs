using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;
using BackOffice.Dominio.Entidades;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya
{
    public class Presentador_03_consultaServicioCompleta : PresentadorGeneral
    {
        #region Párametros

        private IContrato_03_consultaServicioCompleta _consultaServicioCompleta;

        #endregion

        #region Constructor

        public Presentador_03_consultaServicioCompleta(IContrato_03_consultaServicioCompleta _consultaServicioCompleta)
            : base(_consultaServicioCompleta)
        {
            this._consultaServicioCompleta = _consultaServicioCompleta;
        }

        #endregion 

        #region Métodos

        /// <summary>
        /// Obtener los datos del servicio solicitado y asignarlo a las variables correspondientes, para posteriormente
        /// ser visualizadas por la interfaz
        /// </summary>
        /// <param name="_servicio">Nombre del servicio a consultar</param>
        public void mostrarDatosServicio(string _servicio)
        {
            Entidad _elServicio;

            try
            {
                Comando<string, Entidad> _comandoConsultarServicioCompleto = FabricaComando.ObtenerComandoConsultarServicioCompleto();
                _elServicio = _comandoConsultarServicioCompleto.Ejecutar(_servicio);

                Servicio _servicioFinal = _elServicio as Servicio;

                _consultaServicioCompleta.nombreServicio.Text = _servicioFinal.Nombre.ToString();
                _consultaServicioCompleta.descripcionServicio.Text = _servicioFinal.Descripcion.ToString();
                _consultaServicioCompleta.categoriaServicio.Text = _servicioFinal.Categoria.ToString();
                _consultaServicioCompleta.lugarRetiroServicio.Text = _servicioFinal.LugarRetiro.ToString();
                _consultaServicioCompleta.cantidadServicio.Text = _servicioFinal.Cantidad.ToString();
                _consultaServicioCompleta.capacidadServicio.Text = _servicioFinal.Capacidad.ToString();
                _consultaServicioCompleta.costoServicio.Text = _servicioFinal.Costo.ToString();
                _consultaServicioCompleta.estadoServicio.Text = _servicioFinal.Estado.ToString();

                mostrarHorarioServicio(_servicioFinal);
            }
            catch (ExcepcionComandoConsultarServicioCompleto ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicioCompleta.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }

            catch (ExcepcionComando ex)
            {
                Logger.EscribirEnLogger(ex);
                _consultaServicioCompleta.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            } 
        }

        /// <summary>
        /// Recorre la lista de horarios para asignarlos a la variable correspondiente y posteriormente ser visualizadas
        /// por la interfaz
        /// </summary>
        /// <param name="_servicio">Servicio del cual se mostraran los horarios</param>
        public void mostrarHorarioServicio(Servicio _servicio)
        {
            string _horario = "";
            bool _primera = true;

            foreach (Horario _itemHora in _servicio.obtenerListaHorario())
            {
                string _horaInicio;
                string _horaFin;

                _horaInicio = this.obtenerHoraString(_itemHora.Inicio);
                _horaFin = this.obtenerHoraString(_itemHora.Fin);

                if (_primera == true)
                {
                    _horario = _horaInicio + " a " + _horaFin;
                    _primera = false;
                }
                else
                {
                    _horario = _horario + "<br />" + _horaInicio + " a " + _horaFin;
                }
            }

            _consultaServicioCompleta.horarioServicio.Text = _horario;
        }

        /// <summary>
        /// Dado un DateTime permite conocer el string de la hora en el formato manejado
        /// </summary>
        /// <param name="_itemHora">El DateTime que se pasará al formato string</param>
        /// <returns>El string con el formato de hora</returns>
        private string obtenerHoraString(DateTime _itemHora)
        {
            int _horaTempInicio = 0;
            string _horaInicio;
            bool _esTarde = false;

            if (_itemHora.Hour >= 12)
            {
                _horaTempInicio = _itemHora.Hour - 12;
                _esTarde = true;
            }
            else
                _horaTempInicio = _itemHora.Hour;

            if (_horaTempInicio <= 9)
                _horaInicio = "0" + _horaTempInicio.ToString();
            else
                _horaInicio = _horaTempInicio.ToString();

            if (_itemHora.Minute <= 9)
                _horaInicio = _horaInicio + ":0" + _itemHora.Minute.ToString();
            else
                _horaInicio = _horaInicio + ":" + _itemHora.Minute.ToString();

            if (_esTarde)
                _horaInicio = _horaInicio + " pm";
            else
                _horaInicio = _horaInicio + " am";

            return _horaInicio;
        }
        
        #endregion
    }
}