using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using System.Data;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Excepciones.VentaCierreCaja;
using System.Web.UI.WebControls;
using System.Web.UI;
using BackOffice.Presentacion.Presentadores.VentaCierreCaja.Recursos;


namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_GestionarVenta : PresentadorGeneral
    {
        private IContrato_07_GestionarVenta _contratoGestionarVenta;
        private DataTable _dt;
        
        public Presentador_07_GestionarVenta(IContrato_07_GestionarVenta _contratoGestionarVenta)
            : base(_contratoGestionarVenta)
        { 
            this._contratoGestionarVenta = _contratoGestionarVenta;
        }

        /// <summary>
        /// Metodo de ocultacion de los mensajes de error o exito
        /// </summary>
        public void OcultarMensajes()
        {
            _contratoGestionarVenta.LabelMensajeError.Visible = false;
            _contratoGestionarVenta.LabelMensajeExito.Visible = false;
        
        }


        /// <summary>
        /// Metodo de consulta de las facturas del sistema de acuerdo a la busqueda realizada por el usuario
        /// </summary>
        public void ConsultarFacturas()
        {

            Comando<string[], DataTable> _comandoConsultarFactura = FabricaComando.ObtenerComandoConsultarFactura();

            string[] parametros = this.asignarParametrosConsulta();

            _dt = new DataTable();
            
            try
            {
                
                _dt = _comandoConsultarFactura.Ejecutar(parametros);

                this._contratoGestionarVenta.GridVentas.DataSource = _dt;
                this._contratoGestionarVenta.GridVentas.DataBind();

            }
            catch (DataNoDisponibleExcepcion ex)
            {
                this.MostrarMensajeError(ex.Message);
            }

        }

        /// <summary>
        /// Metodo de asignacion de parametros de busqueda del usuario a un arreglo
        /// </summary>
        /// <returns>Arreglo con los parametros de busqueda</returns>
        private string[] asignarParametrosConsulta()
        {
            string[] parametrosConsulta = new string[2];

            parametrosConsulta[0] = this._contratoGestionarVenta.TBoxBuscador.Text;
            parametrosConsulta[1] = this._contratoGestionarVenta.listaEstadoBuscador.SelectedValue;

            return parametrosConsulta;
        }

        /// <summary>
        /// Metodo de paginacion del GridView
        /// </summary>
        /// <param name="e">Evento de paginacion GridView</param>
        public void Ventas_PageIndexChanging(GridViewPageEventArgs e)
        {
            this._contratoGestionarVenta.GridVentas.PageIndex = e.NewPageIndex;
            this._contratoGestionarVenta.GridVentas.DataSource = this._dt;
            this._contratoGestionarVenta.GridVentas.DataBind();
        }

        /// <summary>
        /// Metodo para la creacion del botton ver detalle
        /// </summary>
        /// <returns>Imagebutton correspondiente</returns>
        public ImageButton ImageButtonVerDetalle()
        {

            ImageButton _verDetalle = new ImageButton();
            _verDetalle.ID = RecursoVentaCierreCaja.ID_VerDetalle ;
            _verDetalle.ImageUrl = RecursoVentaCierreCaja.ImageVerDetalle;
            _verDetalle.Height = 50;
            _verDetalle.Width = 50;
            return _verDetalle;

        }

        /// <summary>
        /// Metodo para la creacion del botton modificar
        /// </summary>
        /// <returns>Imagebutton correspondiente</returns>
        public ImageButton ImageButtonModificar()
        {

            ImageButton _modificar = new ImageButton();
            _modificar.ID = RecursoVentaCierreCaja.ID_Modificar;
            _modificar.ImageUrl = RecursoVentaCierreCaja.ImageModificar;
            _modificar.Height = 50;
            _modificar.Width = 50;

            if (this._contratoGestionarVenta.listaEstadoBuscador.SelectedValue == "1")
            {
                _modificar.Enabled = false;
                _modificar.ToolTip = RecursoVentaCierreCaja.ToolTip_NoDisponible;
            }
            return _modificar;

        }

        /// <summary>
        /// Metodo para la creacion del botton eliminar
        /// </summary>
        /// <returns>Imagebutton correspondiente</returns>
        public ImageButton ImageButtonEliminar()
        {

            ImageButton _eliminar = new ImageButton();
            _eliminar.ID = RecursoVentaCierreCaja.ID_Eliminar;
            _eliminar.ImageUrl = RecursoVentaCierreCaja.ImageEliminar;
            _eliminar.Height = 50;
            _eliminar.Width = 50;
            _eliminar.OnClientClick = RecursoVentaCierreCaja.ConfirmacionEliminar;

            if (this._contratoGestionarVenta.listaEstadoBuscador.SelectedValue == "1")
            {
                _eliminar.Enabled = false;
                _eliminar.ToolTip = RecursoVentaCierreCaja.ToolTip_NoDisponible;
            }
            return _eliminar;

        }


        /// <summary>
        /// Metodo del evento ver detalle de factura
        /// </summary>
        /// <param name="sender">Objeto enviado</param>
        /// <returns>Numero de la factura seleccionada</returns>
        public string VerDetalle_Click(Object sender)
        {

            ImageButton _img = (ImageButton)sender;
            GridViewRow _row = (GridViewRow)_img.Parent.Parent;

            return _row.Cells[0].Text;

        }

        /// <summary>
        /// Metodo del evento eliminar factura
        /// </summary>
        public void Eliminar_Click(Object sender)
        {
            Comando<string, int> _comandoEliminarFactura = FabricaComando.ObtenerComandoEliminarFactura();

            int _resultado;
        
            ImageButton _img = (ImageButton)sender;
            GridViewRow _row = (GridViewRow)_img.Parent.Parent;
            
            _resultado = _comandoEliminarFactura.Ejecutar(_row.Cells[0].Text);

            if (_resultado == 0)
                MostrarMensajeError(RecursoVentaCierreCaja.ErrorEliminar);
            else
            {
                this._contratoGestionarVenta.TBoxBuscador.Text = "";
                this._contratoGestionarVenta.listaEstadoBuscador.SelectedIndex = 0;

                this.ConsultarFacturas();
            }

            
        }

        /// <summary>
        /// Metodo del evento modificar una factura
        /// </summary>
        /// <returns>Numero de la factura a ser modificada</returns>
        public int Modificar_Click(Object sender)
        {

                ImageButton _img = (ImageButton)sender;
                GridViewRow _row = (GridViewRow)_img.Parent.Parent;

                return Convert.ToInt32(_row.Cells[0].Text);

        }
        



    }
}