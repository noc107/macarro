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
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya
{
    public class Presentador_2_consultarInventario : PresentadorGeneral
    {
        private IContrato_2_consultarInventario _vista;
   
        public Presentador_2_consultarInventario(IContrato_2_consultarInventario vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;                       
        }

        public void EventoClickConsultarInventario()
        {
            try
            {
                _vista.LabelMensajeExito.Visible = false;
                _vista.LabelMensajeError.Visible = false;
                Buscardor();
            }
            catch (ExcepcionComandoConsultarInventarioTipo e)
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

        public void EventoEliminarItemSeleccionado(int idInventario)
        {
            try
            {
                if (EliminarInventario(idInventario))
                {
                    _vista.LabelMensajeExito.Visible = true;
                    _vista.LabelMensajeError.Visible = false;
                    MostrarMensajeExito(RecursosPresentador.MensajeDeExitoEliminarInventario);
                    Buscardor();
                }
                else
                {
                    _vista.LabelMensajeExito.Visible = false;
                    _vista.LabelMensajeError.Visible = true;
                    MostrarMensajeError(RecursosPresentador.MensajeDeErrorEliminarInventario);
                }
            }
            catch (ExcepcionComandoEliminarItemSeleccionado e)
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

        public string EventoModificar()
        {
            return RecursosPresentador.PaginaModificarInventario;            
        }

        /// <summary>
        /// Buscador de Inventario según tipo de Inventario
        /// </summary>
        private void Buscardor()
        {
            string tipo = _vista.DropTipoItem.Text;            
            LlenarGVInventario(ConsultarInventario(tipo));
        }

        /// <summary>
        /// Busqueda de inventario segun tipo específico
        /// </summary>
        /// <param name="parametro">Parametro a buscar</param>
        /// <returns>Lista de inventario bajo cierto parametro</returns>
        private List<InventarioPlaya> ConsultarInventario(string parametro)
        {
            Comando<string, List<Entidad>> ComandoConsultarInventarioTipo = FabricaComando.ObtenerComandoConsultarInventarioTipo();
            List<Entidad> _listaDesdeComando = ComandoConsultarInventarioTipo.Ejecutar(parametro);
           
            return ConvertirLista(_listaDesdeComando);
        }

        /// <summary>
        /// Método que llena el GridView con el Inventario consultado
        /// </summary>
        private void LlenarGVInventario(List<InventarioPlaya> lista)
        {
            LiberarGVInventario();
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    _vista.GridTablaInventario.DataSource = lista;
                    _vista.GridTablaInventario.DataBind();
                    _vista.BtnModificarTodo.Visible = true;
                }
                else
                {
                    _vista.BtnModificarTodo.Visible = false;
                    _vista.LabelMensajeError.Visible = true;
                    MostrarMensajeError(RecursosPresentador.RegistrosVacios);
                }

            }
            else
            {
                _vista.BtnModificarTodo.Visible = false;
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(RecursosPresentador.RegistrosVacios);
            }
        }

        /// <summary>
        /// Método que libera el GridView del ConsultarTours.aspx
        /// </summary>
        private void LiberarGVInventario()
        {
            _vista.GridTablaInventario.DataSource = null;
            _vista.GridTablaInventario.DataBind();
        }

        /// <summary>
        /// Transforma la lista obtenida en el comando en una lista de inventario
        /// para ser usada en el gridview
        /// </summary>
        /// <param name="lista">Lista del tipo Entidad</param>
        /// <returns>Lista de inventario</returns>
        private List<InventarioPlaya> ConvertirLista(List<Entidad> lista) 
        {
            List<InventarioPlaya> _listaInventario = new List<InventarioPlaya>();
            foreach (Entidad entidad in lista)
            {
                _listaInventario.Add(entidad as InventarioPlaya);
            }
            return _listaInventario;
        }

        /// <summary>
        /// Elimina o bloquea un inventario seleccionado
        /// </summary>
        /// <param name="e">El evento de seleccion dentro del GridView</param>
        /// <returns>True en caso de exito o false en caso de error</returns>
        private bool EliminarInventario(int idInventario)
        {

            Comando<int, bool> ComandoEliminarItemSeleccionado = FabricaComando.ObtenerComandoEliminarItemSeleccionado();

            return ComandoEliminarItemSeleccionado.Ejecutar(idInventario);
        }

    }
}