using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos;
using BackOffice.LogicaNegocio.Fabrica;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya
{
    public class Presentador_2_consultarPuesto : PresentadorGeneral
    {
        private IContrato_2_consultarPuesto _vista;

        public Presentador_2_consultarPuesto(IContrato_2_consultarPuesto vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;                       
        }

        public void EventoClickConsultarPuesto()
        {
            _vista.LabelMensajeError.Visible = false;
            AparecerBoton();
           
           
               Buscador();
          
          
        }

        public bool EventoEliminarPuestoSeleccionado(String fila,String Columna)
        {
            
            string estado = RecursosPresentador.EstadoDesactivado;
            string descripcionx = string.Empty;
            float montox=0;

            Entidad Puesto = FabricaEntidad.ObtenerPuestoPlaya(Convert.ToInt32(fila), Convert.ToInt32(Columna), descripcionx, montox, estado);
            Comando<Entidad, bool> ComandoActualizarPuesto = FabricaComando.ObtenerComandoActualizarPuesto();
            bool flag = ComandoActualizarPuesto.Ejecutar(Puesto);
           
            return flag;
        }

        public bool EventoEliminarFilaColumna()
        {

            string _fila = _vista.CampoFila.Text.ToString();
            string _columna = _vista.CampoColumna.Text.ToString();
            string estado = RecursosPresentador.EstadoDesactivado;
            string descripcionx = string.Empty;
            float montox=0;

            if (_fila.Equals(string.Empty))
                _fila = "0";

            if (_columna.Equals(string.Empty))
                _columna = "0";

            
            Entidad Puesto = FabricaEntidad.ObtenerPuestoPlaya(Convert.ToInt32(_fila),Convert.ToInt32(_columna),descripcionx,montox,estado);
            Comando<Entidad, bool> ComandoActualizarPuesto = FabricaComando.ObtenerComandoActualizarPuesto();
            bool flag = ComandoActualizarPuesto.Ejecutar(Puesto);
            
           
              return flag;
           
        }


        public void MostrarMensajeEliminar(bool flag)
        {
            if (flag)
            {
                _vista.LabelMensajeError.Visible = false;
                _vista.LabelMensajeExito.Visible = true;
                MostrarMensajeExito(RecursosPresentador.MensajeExitoEliminarPuesto);

            }
            else
            {
                _vista.LabelMensajeExito.Visible = false;
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(RecursosPresentador.MensajeErrorEliminarPuesto);

            }
        
        }

        public string EventoModificar()
        {
            return RecursosPresentador.PaginaModificarPuesto;
        }

        public string GetFila()
        {
            return _vista.CampoFila.Text.ToString();

        }

        public string GetColumna()
        {
            return _vista.CampoColumna.Text.ToString();
        }





        #region codigoayuda
        protected void AparecerBoton()
        {
            if (_vista.RadioOpciones.SelectedValue.ToString().Equals("1") || _vista.RadioOpciones.SelectedValue.ToString().Equals("2"))
               {
                   _vista.BtnModificar.Visible = true;
                   _vista.BtnEliminar.Visible = true;
               }
               else
               {
                   _vista.BtnModificar.Visible = false;
                   _vista.BtnEliminar.Visible = false;

               }

        }

        ///// <summary>
        ///// Buscador de Puestos a ser mostrados
        ///// </summary>
        private void Buscador()
        {
            string  _fila = _vista.CampoFila.Text.ToString();
             string _columna = _vista.CampoColumna.Text.ToString();

             if (_vista.RadioOpciones.SelectedValue.ToString().Equals("0"))
            {
                cargarTablaPuesto(_fila, _columna);
            }
            else
            {
                if (_vista.RadioOpciones.SelectedValue.ToString().Equals("1"))
                {
                    if (_fila.Equals(string.Empty))
                    {
                        _vista.LabelMensajeError.Visible = true;
                        MostrarMensajeError(RecursosPresentador.ErrorFilaNull);
                    }

                    else
                        cargarTablaPuesto(_fila, _columna);
                }
                else
                {
                    if (_vista.RadioOpciones.SelectedValue.ToString().Equals("2"))
                    {
                        if (_columna.Equals(string.Empty))
                        {
                            _vista.LabelMensajeError.Visible = true;
                            MostrarMensajeError(RecursosPresentador.ErrorColumnaNull);
                        }

                        else
                            cargarTablaPuesto(_fila, _columna);
                    }
                    else
                    {
                        if (_vista.RadioOpciones.SelectedValue.ToString().Equals("3"))
                        {
                            if (_columna.Equals(string.Empty) || _fila.Equals(string.Empty))
                            {
                                _vista.LabelMensajeError.Visible = true;
                                MostrarMensajeError(RecursosPresentador.ErrorColumnaNull + string.Empty + RecursosPresentador.ErrorFilaNull);
                            }
                            else
                                cargarTablaPuesto(_fila, _columna);
                        }
                    }
                }
            }
            }


        ///// <summary>
        ///// Metodo que carga el GV_puestos traido de la bd.
        ///// </summary>
        public void cargarTablaPuesto(string filap, string columnap)
        {
            try
            {

                String Parametro = filap + ":" + columnap;
                

                limpiar();
                Comando<string, List<Entidad>> ComandoConsultarPuesto = FabricaComando.ObtenerComandoConsultarPuesto();
                List<Entidad> listapuesto = ComandoConsultarPuesto.Ejecutar(Parametro);
             _vista.GridPuestos.DataSource = listapuesto;
             _vista.GridPuestos.DataBind();

            }
           
            catch (HttpException)
            {
        //        this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
            }

        }

        ///// <summary>
        ///// Metodo que limpia todo lo que tenga el Gv_puesto.
        ///// </summary>
        public void limpiar()
        {
            _vista.GridPuestos.DataSource = null;
            _vista.GridPuestos.DataBind();
           
        }
        #endregion

    }
}