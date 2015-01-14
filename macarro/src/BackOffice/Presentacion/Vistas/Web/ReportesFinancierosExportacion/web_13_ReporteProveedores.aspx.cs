//web_13_ReporteProveedores
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;
using BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion;

namespace BackOffice.Presentacion.Vistas.Web.ReportesFinancierosExportacion
{
	public partial class web_13_ReporteProveedores : System.Web.UI.Page, IContrato_13_ReporteProveedores
	{
		DataTable _dataTable = new DataTable ();

        private Presentador_13_ReporteProveedores _presentador;

        public web_13_ReporteProveedores()
        {
            _presentador = new Presentador_13_ReporteProveedores(this);
        }

		/// <summary>
		/// El metodo Page_Load se encarga de manejar 
		/// el evento de Click en el boton BuscarBoton.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load ( object sender, EventArgs e )
		{
            _presentador.CargarReporte();
            //BuscarBoton.Click += new EventHandler ( this.BuscarBoton_Click );
            //ExportarBoton.Click += new EventHandler ( this.ExportarBoton_Click );

            //MensajeError.Style.Add ( "display", "block" );
            //MensajeError.Style.Add ( "margin-bottom", "20px" );
            //MensajeError.Style.Add ( "line-height", "30px" );
            //MensajeError.Style.Add ( "text-align", "center" );
            //MensajeError.Style.Add ( "border-radius", "5px" );
            //MensajeError.Style.Add ( "color", "#fff" );
            //MensajeError.Style.Add ( "background-color", "#c40000" );
            //MensajeError.Style.Add ( "font-size", "large" );

            //ResumenValidaciones.Style.Add ( "display", "block" );
            //ResumenValidaciones.Style.Add ( "margin-bottom", "20px" );
            //ResumenValidaciones.Style.Add ( "line-height", "30px" );
            //ResumenValidaciones.Style.Add ( "text-align", "center" );
            //ResumenValidaciones.Style.Add ( "border-radius", "5px" );
            //ResumenValidaciones.Style.Add ( "color", "#FFF" );
            //ResumenValidaciones.Style.Add ( "background-color", "#c40000" );
            //ResumenValidaciones.Style.Add ( "font-size", "large" );

		}

        public Label LabelGrafica
        {
            get { return graficaVaciaProveedores; }
            set { graficaVaciaProveedores = value; }
        }

        public GridView GridViewProveedores
        {
            get { return Proveedores; }
            set { Proveedores = value; }
        }

        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }

		/// <summary>
		/// El metodo ExportarBoton_Click se encarga 
		/// de invocar por referencia los metodos necesarios para 
		/// la creación de una Tabla excel con los datos del 
		/// reporte y mostrarla ante el usuario.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        //private void ExportarBoton_Click ( object sender, EventArgs e )
        //{
        //    try
        //    {
        //        _dataTable = back_office.Logica.ReportesFinancierosExportacion.
        //                               logica_13_ReporteProveedores.TablaProveedores ();
        //    }
        //    catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionBaseDatos _excepcion )
        //    {
        //        MensajeError.Text = _excepcion.Message.ToString ();
        //        MensajeError.Visible = true;
        //    }

        //    try
        //    {
        //        if (_dataTable.Rows.Count > 0)
        //        {
        //            _dataTable.Columns["nombre"].ColumnName = "Nombre";
        //            _dataTable.Columns["cantidad"].ColumnName = "Cantidad";
        //            _dataTable.Columns["ITE_nombre"].ColumnName = "Nombre Item";
        //        }

        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable, "Reporte Proveedores" );
        //    }
        //    catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionExcel _excepcion )
        //    {
        //        MensajeError.Text = _excepcion.Message.ToString ();
        //        MensajeError.Visible = true;
        //    }
        //}

		/// <summary>
		/// El metodo BuscarBoton_Click se encarga de 
		/// ejecutar por referencia los metodos necesarios para crear los graficos
		/// y las tablas correspondientes al reporte
		/// y asignalos a elementos dentro de la pagina web para su visualización.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        //void BuscarBoton_Click ( object sender, EventArgs e )
        //{
        //    ExportarBoton.Visible = false;
        //    dataTableVaciaProveedores.Visible = false;
        //    graficaVaciaProveedores.Visible = false;
        //    MensajeError.Visible = false;

        //    try
        //    {
        //        try
        //        {

        //            if ( back_office.Logica.ReportesFinancierosExportacion.
        //                logica_13_ReporteComidaBebida.ComprobarConexionInternet () )
        //            {
        //                literal.Text = back_office.Logica.ReportesFinancierosExportacion.
        //               logica_13_ReporteProveedores.Proveedores ();
        //            }
        //        }

        //        catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionInternet _excepcion )
        //        {
        //            graficaVaciaProveedores.Visible = true;
        //            graficaVaciaProveedores.Text = _excepcion.Message.ToString ();
        //            goto ContinuarEjecucion;
        //        }

        //        ContinuarEjecucion:
        //        _dataTable = back_office.Logica.ReportesFinancierosExportacion.
        //                               logica_13_ReporteProveedores.TablaProveedores ();

        //        if ( _dataTable.Rows.Count == 0 )
        //        {
        //            dataTableVaciaProveedores.Visible = true;
        //            dataTableVaciaProveedores.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }

        //        Proveedores.DataSource = _dataTable;
        //        Proveedores.DataBind ();
        //        ExportarBoton.Visible = true;
        //    }
        //    catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionBaseDatos _excepcion )
        //    {
        //        MensajeError.Text = _excepcion.Message.ToString ();
        //        MensajeError.Visible = true;
        //    }
        //}
	}
}