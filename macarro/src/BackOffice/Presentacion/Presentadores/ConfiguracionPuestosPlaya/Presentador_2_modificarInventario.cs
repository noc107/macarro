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
    public class Presentador_2_modificarInventario: PresentadorGeneral
    {
        private IContrato_2_modificarInventario _vista;
        private InventarioPlaya InventarioXId;

        public Presentador_2_modificarInventario(IContrato_2_modificarInventario vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;
        }

        public void EventoClickAceptar(object _parametroId,object _parametroTipo)
        {
            try
            {
                _vista.LabelMensajeExito.Visible = false;
                _vista.LabelMensajeError.Visible = false;
                ActualizarInventario(_parametroId, _parametroTipo);
            }
            catch (Exception ex)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
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

                    _vista.CampoPrecio.Text = Convert.ToString(InventarioXId.Precio);
                    _vista.CampoDescripcion.Text = InventarioXId.Descripcion;
                    _vista.DropEstado.Text = InventarioXId.Estado;
                    _vista.CampoDescripcion.Enabled = true;
                    _vista.DropEstado.Enabled = true;
                }                                
                catch (Exception ex)
                {
                    _vista.LabelMensajeError.Visible = true;
                    MostrarMensajeError(ex.Message);
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
            InventarioXId.Estado = _vista.DropEstado.Text;
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