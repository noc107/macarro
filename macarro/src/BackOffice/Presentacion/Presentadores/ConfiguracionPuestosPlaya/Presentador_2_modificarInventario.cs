using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya
{
    public class Presentador_2_modificarInventario: PresentadorGeneral
    {
        private IContrato_2_modificarInventario _vista;
        private InventarioPlaya InventarioXId;

        public Presentador_2_modificarInventario(IContrato_2_modificarInventario vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;
        }

        public void CargarDropEstados() 
        {
            List<Entidad> lista;
            try
            {
                Comando<int, List<Entidad>> ComandoConsultarEstadosInventario = FabricaComando.ObtenerComandoConsultarEstadosInventario();
                lista = ComandoConsultarEstadosInventario.Ejecutar(0);
                foreach (Entidad entidad in lista)
                {
                    Estado valor = entidad as Estado;
                    ListItem oItem = new ListItem(valor.Titulo, Convert.ToString(valor.Id));
                    _vista.DropEstado.Items.Add(oItem);
                }
                _vista.DropEstado.ClearSelection();
            }
            catch (ExcepcionComandoConsultarEstadosInventario e)
            {
                Logger.EscribirEnLogger(e);
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
            }
            catch (ExcepcionComando e)
            {
                Logger.EscribirEnLogger(e);
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
            }           
        }

        public void EventoClickAceptar(object _parametroId,object _parametroTipo)
        {
            try
            {
                _vista.LabelMensajeExito.Visible = false;
                _vista.LabelMensajeError.Visible = false;
                ActualizarInventario(_parametroId, _parametroTipo);
            }
            catch (ExcepcionComandoActualizarInventarioTipo e)
            {
                Logger.EscribirEnLogger(e);
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
            }
            catch (ExcepcionComandoActualizarItemSeleccionado e)
            {
                Logger.EscribirEnLogger(e);
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
            }
            catch (ExcepcionComando e)
            {
                Logger.EscribirEnLogger(e);
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
            }   
        }

        public string EventoClickCancelar()
        {
            return RecursosPresentador.PaginaConsultarInventario;
        }

        public void Inicio(object _parametroId)
        {
            _vista.LabelMensajeExito.Visible = false;
            _vista.LabelMensajeError.Visible = false;

            if (_parametroId != null)
            {
                try
                {
                    int parametro = (int)_parametroId;

                    Comando<int, Entidad> ComandoConsultarInventarioXId = FabricaComando.ObtenerComandoConsultarInventarioXId();
                    InventarioXId = ComandoConsultarInventarioXId.Ejecutar(parametro) as InventarioPlaya;

                   // _vista.CampoPrecio.Text = Convert.ToString(InventarioXId.Precio);
                   // _vista.CampoDescripcion.Text = InventarioXId.Descripcion;
                    //_vista.DropEstado.Text = InventarioXId.Estado;
                  //  DropdownList1.SelectedIndex = DropdownList1.Items.IndexOf(DropdownList1.Items.FindByValue(strText));
                    //_vista.DropEstado.SelectedIndex = _vista.DropEstado.Items.IndexOf(_vista.DropEstado.Items.FindByText(InventarioXId.Estado));
                    //_vista.DropEstado.Items.FindByText(InventarioXId.Estado).Selected = true;                    
                    //_vista.DropEstado.selec = InventarioXId.Estado;
                    //_vista.DropEstado.Text = InventarioXId.Estado;
                    _vista.CampoDescripcion.Enabled = true;
                    _vista.DropEstado.Enabled = true;
                }
                catch (ExcepcionComandoConsultarInventarioXId e)
                {
                    Logger.EscribirEnLogger(e);
                    _vista.LabelMensajeError.Visible = true;
                    MostrarMensajeError(e.Mensaje);
                }
                catch (ExcepcionComando e)
                {
                    Logger.EscribirEnLogger(e);
                    _vista.LabelMensajeError.Visible = true;
                    MostrarMensajeError(e.Mensaje);
                }                                  
               
            }
            else
            {
                _vista.CampoDescripcion.Enabled = false;
                _vista.DropEstado.Enabled = false;
            }            
        }


        /// <summary>
        /// Funcion para realizar la actualizacion del inventario solicitado
        /// </summary>
        private void ActualizarInventario(object _parametroId, object _parametroTipo)
        {
            if (_parametroId != null)
            {
                ActualizarInventarioEspecifico();
            }
            else
            {
                ActualizarInventarioTodos(_parametroTipo);
            }
        }

        /// <summary>
        /// Funcion para Actualizar un item especifico del inventario consultado
        /// </summary>
        private void ActualizarInventarioEspecifico()
        {            
            InventarioXId.Precio = float.Parse(_vista.CampoPrecio.Text);
            InventarioXId.Estado = _vista.DropEstado.SelectedItem.Value;
            InventarioXId.Descripcion = _vista.CampoDescripcion.Text;

           
            Comando<Entidad, bool> ComandoActualizarItemSeleccionado = FabricaComando.ObtenerComandoActualizarItemSeleccionado();

            if (ComandoActualizarItemSeleccionado.Ejecutar(InventarioXId))
            {
                _vista.LabelMensajeExito.Visible = true;
                MostrarMensajeExito(RecursosPresentador.MensajeDeExitoModificarInventarioSeleccionado);
            }
            else
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(RecursosPresentador.MensajeDeErrorModificarInventarioSeleccionado);
            }
            
        }

        /// <summary>
        /// Funcion para Actualizar todos los item de un tipo en especifico del inventario consultado
        /// </summary>
        private void ActualizarInventarioTodos(object _parametroTipo)
        {
            Entidad Inventario = FabricaEntidad.ObtenerInventarioPlaya(float.Parse(_vista.CampoPrecio.Text), (string)_parametroTipo);

            Comando<Entidad, bool> ComandoActualizarInventarioTipo = FabricaComando.ObtenerComandoActualizarInventarioTipo();

            if (ComandoActualizarInventarioTipo.Ejecutar(Inventario))
            {
                _vista.LabelMensajeExito.Visible = true;
                MostrarMensajeExito(RecursosPresentador.MensajeDeExitoModificarInventarioTipo);
            }
            else
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(RecursosPresentador.MensajeDeErrorModificarInventarioTipo);
            }            
        }
    }
}