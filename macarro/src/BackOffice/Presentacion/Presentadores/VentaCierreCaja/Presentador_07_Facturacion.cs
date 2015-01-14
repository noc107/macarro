using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.Excepciones;
using BackOffice.Excepciones.VentaCierreCaja;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_Facturacion : PresentadorGeneral
    {
        private IContrato_07_Facturacion _contratoFacturacion;
        private DataTable _dt;
        private DataTable _datatableServicio;
        private DataTable _datatableFacturacion;

        private List<LineaFactura> _servicioGrid;
        private List<LineaFactura> _lineaFactura;
        

        public Presentador_07_Facturacion(IContrato_07_Facturacion _contratoFacturacion)
            : base(_contratoFacturacion)
        { 
            this._lineaFactura = new List<LineaFactura>();           

            this._contratoFacturacion = _contratoFacturacion;

        }

        public void CargarDatatable(DataTable _tablaFactura, DataTable _tablaServicio) 
        {
            if (_tablaServicio != null)
                this._datatableServicio = _tablaServicio;
            if (_tablaFactura != null)
                this._datatableFacturacion = _tablaFactura;
        }

        public string CargarBuscadorCorreos()
        {
            
            Comando<int, string> comandoObtenerCorreos = FabricaComando.ObtenerComandoConsultarCorreos();

            return comandoObtenerCorreos.Ejecutar(0);

        }

        public DataTable Page_Load(String solicitudModificar)
        {
            if (solicitudModificar == null) //Se creara una nueva factura
            {
                this._lineaFactura = new List<LineaFactura>();
                this._contratoFacturacion.panelBloques.Visible = false;
                this._contratoFacturacion.panelBloqueNuevo.Visible = true;
                this._dt = new DataTable();
                this._contratoFacturacion.gridServicio.DataSource = this._dt;
                this._contratoFacturacion.gridServicio.DataBind();

                this._dt = new DataTable();
                this._dt.Columns.AddRange(new DataColumn[5] { 
                            new DataColumn("IdLineaFactura", typeof(int)),
                            new DataColumn("ServicioFactura", typeof(string)),
                            new DataColumn("Tipo", typeof(string)),
                            new DataColumn("Cantidad",typeof(int)),
                            new DataColumn("Precio", typeof(float)) });
                /*this._dt.Rows.Add(100,"Prueba1", "Restaurant", 11, 12);
                this._dt.Rows.Add(101, "Prueba2", "Servicio", 15, 14);
                this._dt.Rows.Add(102, "Prueba3", "Restaurant", 13, 23);
                this._dt.Rows.Add(103, "Prueba4", "Servicio", 16, 45);*/

                this._contratoFacturacion.gridFactura.DataSource = this._dt;
                this._contratoFacturacion.gridFactura.DataBind();
                this._contratoFacturacion.labelTotal = "Total";

                return this._dt;
            }
            return null;
        }

        public DataTable ActualizarDataTableFactura() {

            return this._datatableFacturacion;

        }

        public DataTable ActualizarDataTableServicio()
        {

            return this._datatableServicio;

        }

        public void AgregarLineaFactura() 
        {
            GridView _gridServicio;
            this._contratoFacturacion.gridFactura.DataSource = this._datatableFacturacion;
            this._contratoFacturacion.gridFactura.DataBind();
            _gridServicio = this._contratoFacturacion.gridServicio;
            foreach (GridViewRow row in this._contratoFacturacion.gridServicio.Rows)
            {
                CheckBox check = row.FindControl("checkServicios") as CheckBox;

                if (check.Checked)
                {

                    int _idServicio = Convert.ToInt32(_gridServicio.DataKeys[row.RowIndex].Value);
                    string _servicio = row.Cells[2].Text;
                    string _tipo = row.Cells[3].Text;
                    int _cantidad = 10;//Convert.ToInt32(row.Cells[2].Text);
                    float _precioSer = float.Parse(row.Cells[4].Text, CultureInfo.InvariantCulture.NumberFormat);

                    this._datatableFacturacion.Rows.Add(_idServicio, _servicio, _tipo, _cantidad, _precioSer);           

                    DataRow[] rowdelete = this._datatableServicio.Select(string.Format("IdLineaFactura={0}", _idServicio));
                    this._datatableServicio.Rows.Remove(rowdelete[0]);

                }
            }

            this._contratoFacturacion.gridServicio.DataSource = this._datatableServicio;
            this._contratoFacturacion.gridServicio.DataBind();

            this._contratoFacturacion.gridFactura.DataSource = this._datatableFacturacion;
            this._contratoFacturacion.gridFactura.DataBind();
      

        }

        public void QuitarLineaFactura()
        {
            GridView _gridFactura;
            /*this._contratoFacturacion.gridFactura.DataSource = this._datatableFacturacion;
            this._contratoFacturacion.gridFactura.DataBind();*/
            _gridFactura = this._contratoFacturacion.gridFactura;
            foreach (GridViewRow row in this._contratoFacturacion.gridFactura.Rows)
            {
                CheckBox check = row.FindControl("checkFactura") as CheckBox;

                if (check.Checked)
                {

                    int _idFactura = Convert.ToInt32(_gridFactura.DataKeys[row.RowIndex].Value);
                    string _servicio = row.Cells[2].Text;
                    string _tipo = row.Cells[3].Text;
                    //int _cantidad = Convert.ToInt32(row.Cells[2].Text);
                    float _precioSer = float.Parse(row.Cells[5].Text, CultureInfo.InvariantCulture.NumberFormat);

                    this._datatableServicio.Rows.Add(_idFactura, _servicio, _tipo, _precioSer);

                    DataRow[] rowdelete = this._datatableFacturacion.Select(string.Format("IdLineaFactura={0}", _idFactura));
                    this._datatableFacturacion.Rows.Remove(rowdelete[0]);

                }
            }

            this._contratoFacturacion.gridServicio.DataSource = this._datatableServicio;
            this._contratoFacturacion.gridServicio.DataBind();

            this._contratoFacturacion.gridFactura.DataSource = this._datatableFacturacion;
            this._contratoFacturacion.gridFactura.DataBind();


        }

        private DataTable cargarDatosServicios(List<Entidad> _listaServicios)
        {
            LineaFactura _lineaServicio;
            this._datatableServicio = new DataTable();
            this._datatableServicio.Columns.AddRange(new DataColumn[4] { 
                            new DataColumn("IdLineaFactura", typeof(int)),
                            new DataColumn("ServicioFactura", typeof(string)),
                            new DataColumn("Tipo",typeof(string)),
                            new DataColumn("Precio", typeof(float)) });

            foreach (Entidad entidad in _listaServicios)
            {
                _lineaServicio = entidad as LineaFactura;
                this._datatableServicio.Rows.Add(_lineaServicio.IdLineaFactura, _lineaServicio.ServicioFactura, _lineaServicio.Tipo, _lineaServicio.Precio);               
            }
            this._servicioGrid = _lineaFactura;
            this._contratoFacturacion.gridServicio.DataSource = null;
            this._contratoFacturacion.gridServicio.DataBind();
            this._contratoFacturacion.gridServicio.DataSource = this._datatableServicio;
            this._contratoFacturacion.gridServicio.DataBind();

            return this._datatableServicio;

        }

        public void Servicios_PageIndexChanging(GridViewPageEventArgs e)
        {
            this._contratoFacturacion.gridServicio.PageIndex = e.NewPageIndex;
            this._contratoFacturacion.gridServicio.DataSource = this._servicioGrid;
            this._contratoFacturacion.gridServicio.DataBind();
        }

        public void Factura_PageIndexChanging(GridViewPageEventArgs e)
        {
            this._contratoFacturacion.gridFactura.PageIndex = e.NewPageIndex;
            this._contratoFacturacion.gridFactura.DataSource = this._datatableFacturacion;
            this._contratoFacturacion.gridFactura.DataBind();
        }


        public DataTable botonCrearFactura()
        {
            Comando<string, Entidad> _comandoValidarCorreo = FabricaComando.ObtenerComandoVerificarCorreo();
            Comando<string, List<Entidad>> _comandoObtenerServicio = FabricaComando.ObtenerComandoObtenerServicio();
            Persona _persona;
            try
            {
                _persona = _comandoValidarCorreo.Ejecutar(this._contratoFacturacion.textBoxCorreoCliente.Text) as Persona;

                this.MostrarMensajeError("");
                this._contratoFacturacion.labelNombreCliente = _persona.Nombre + " " + _persona.Apellido;
                this._contratoFacturacion.labelDocumento = _persona.Documento;
                this._contratoFacturacion.textBoxCorreoCliente.Enabled = false;
                this._contratoFacturacion.panelBloqueNuevo.Visible = false;
                this._contratoFacturacion.panelBloques.Visible = true;

                return cargarDatosServicios(_comandoObtenerServicio.Ejecutar(this._contratoFacturacion.textBoxCorreoCliente.Text));

            }
            catch (UserNotFoundExcepcion ex)
            {
                this.MostrarMensajeError(ex.Message);
            }
            catch (DataNoDisponibleExcepcion ex)
            {
                this.MostrarMensajeError(ex.Message);
            }

            return null;
            
        }
        
    }
}