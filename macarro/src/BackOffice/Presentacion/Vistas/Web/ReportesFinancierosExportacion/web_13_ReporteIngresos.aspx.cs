//web_13_ReporteIngresos
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;
using BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion;


namespace BackOffice.Presentacion.Vistas.Web.ReportesFinancierosExportacion
{

	public partial class web_13_ReporteIngresos : System.Web.UI.Page, IContrato_13_ReporteIngresos
	{
		DataTable _dataTable1 = new DataTable ();
		DataTable _dataTable2 = new DataTable ();
		DataTable _dataTable3 = new DataTable ();
		DataTable _dataTable4 = new DataTable ();

        private Presentador_13_ReporteIngresos _presentador;

        public web_13_ReporteIngresos()
        {
            _presentador = new Presentador_13_ReporteIngresos(this);
        }

		/// <summary>
		/// El metodo Page_Load se encarga de manejar 
		/// el evento de Click en el boton BuscarBoton.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load ( object sender, EventArgs e )
		{
            _presentador.CargarReporte(TextBoxFechaInicio.Text, TextBoxFechaFin.Text);
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

        public TextBox TextBoxFechaInicio
        {
            get { return inputFechaInicio; }
        }

        public TextBox TextBoxFechaFin
        {
            get { return inputFechaFin; }
        }

        public Label LabelGraficaSombrilla
        {
            get { return graficaVaciaSombrilla; }
            set { graficaVaciaSombrilla = value; }
        }

        public GridView GridViewSombrilla
        {
            get { return Sombrilla; }
            set { Sombrilla = value; }
        }

        public Label LabelGraficaRestaurant
        {
            get { return graficaVaciaRestaurant; }
            set { graficaVaciaRestaurant = value; }
        }

        public GridView GridViewRestaurant
        {
            get { return Restaurant; }
            set { Restaurant = value; }
        }

        public Label LabelGraficaServicio
        {
            get { return graficaVaciaServicio; }
            set { graficaVaciaServicio = value; }
        }

        public GridView GridViewServicio
        {
            get { return Servicio; }
            set { Servicio = value; }
        }

        public Label LabelGraficaEstacionamiento
        {
            get { return graficaVaciaEstacionamiento; }
            set { graficaVaciaEstacionamiento = value; }
        }

        public GridView GridViewEstacionamiento
        {
            get { return Estacionamiento; }
            set { Estacionamiento = value; }
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
        //        _dataTable1 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaSombrilla ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //        _dataTable2 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaRestaurante ( this.inputFechaInicio.Text, this.inputFechaFin.Text ); ;
        //        _dataTable3 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaServicio ( this.inputFechaInicio.Text, this.inputFechaFin.Text ); ;
        //        _dataTable4 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaEstacionamiento ( this.inputFechaInicio.Text, this.inputFechaFin.Text );

        //    }
        //    catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionBaseDatos _excepcion )
        //    {
        //        MensajeError.Text = _excepcion.Message.ToString ();
        //        MensajeError.Visible = true;
        //    }

        //    try
        //    {
        //        if (_dataTable1.Rows.Count > 0)
        //        {
        //            _dataTable1.Columns["ingreso"].ColumnName = "Ingresos";
        //            _dataTable1.Columns["fecha"].ColumnName = "Fecha";
        //        }

        //        if (_dataTable2.Rows.Count > 0)
        //        {
        //            _dataTable2.Columns["ingreso"].ColumnName = "Ingresos";
        //            _dataTable2.Columns["fecha"].ColumnName = "Fecha";
        //        }

        //        if (_dataTable3.Rows.Count > 0)
        //        {
        //            _dataTable3.Columns["ingreso"].ColumnName = "Ingresos";
        //            _dataTable3.Columns["fecha"].ColumnName = "Fecha";
        //        }

        //        if (_dataTable4.Rows.Count > 0)
        //        {

        //            _dataTable4.Columns["ingreso"].ColumnName = "Ingresos";
        //            _dataTable4.Columns["fecha"].ColumnName = "Fecha";
        //        }

        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable1, "Reporte Sombrillas" );
        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable2, "Reporte Restaurante" );
        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable3, "Reporte Servicios" );
        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable4, "Reporte Estacionamiento" );
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
        //    MensajeError.Visible = false;

        //    graficaVaciaEstacionamiento.Visible = false;
        //    graficaVaciaRestaurant.Visible = false;
        //    graficaVaciaServicio.Visible = false;
        //    graficaVaciaSombrilla.Visible = false;

        //    dataTableVaciaSombrilla.Visible = false;
        //    dataTableVaciaRestaurant.Visible = false;
        //    dataTableVaciaServicio.Visible = false;
        //    dataTableVaciaEstacionamiento.Visible = false;

        //    try
        //    {
        //        try
        //        {

        //            if ( back_office.Logica.ReportesFinancierosExportacion.
        //                     logica_13_ReporteComidaBebida.ComprobarConexionInternet () )
        //            {

        //                literal.Text = back_office.Logica.ReportesFinancierosExportacion.
        //                               logica_13_ReporteIngresos.
        //                               Sombrilla ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //                literal1.Text = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                Restaurante ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //                literal2.Text = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                Servicio ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //                literal3.Text = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                Estacionamiento ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //            }
        //        }
        //        catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionInternet _excepcion )
        //        {
        //            graficaVaciaEstacionamiento.Visible = true;
        //            graficaVaciaRestaurant.Visible = true;
        //            graficaVaciaServicio.Visible = true;
        //            graficaVaciaSombrilla.Visible = true;


        //            graficaVaciaEstacionamiento.Text = _excepcion.Message.ToString ();
        //            graficaVaciaEstacionamiento.Text = _excepcion.Message.ToString ();

        //            graficaVaciaRestaurant.Text = _excepcion.Message.ToString ();
        //            graficaVaciaRestaurant.Text = _excepcion.Message.ToString ();

        //            graficaVaciaServicio.Text = _excepcion.Message.ToString ();
        //            graficaVaciaServicio.Text = _excepcion.Message.ToString ();

        //            graficaVaciaSombrilla.Text = _excepcion.Message.ToString ();
        //            graficaVaciaSombrilla.Text = _excepcion.Message.ToString ();

        //            goto ContinuarEjecucion;
        //        }

        //        ContinuarEjecucion:
        //        _dataTable1 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaSombrilla ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //        if ( _dataTable1.Rows.Count == 0 )
        //        {
        //            dataTableVaciaSombrilla.Visible = true;
        //            dataTableVaciaSombrilla.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }

        //        _dataTable2 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaRestaurante ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //        if ( _dataTable2.Rows.Count == 0 )
        //        {
        //            dataTableVaciaRestaurant.Visible = true;
        //            dataTableVaciaRestaurant.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }

        //        _dataTable3 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaServicio ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //        if ( _dataTable3.Rows.Count == 0 )
        //        {
        //            dataTableVaciaServicio.Visible = true;
        //            dataTableVaciaServicio.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }

        //        _dataTable4 = back_office.Logica.ReportesFinancierosExportacion.
        //                                logica_13_ReporteIngresos.
        //                                TablaEstacionamiento ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //        if ( _dataTable4.Rows.Count == 0 )
        //        {
        //            dataTableVaciaEstacionamiento.Visible = true;
        //            dataTableVaciaEstacionamiento.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }

        //        Sombrilla.DataSource = _dataTable1;
        //        Sombrilla.DataBind ();

        //        Restaurant.DataSource = _dataTable2;
        //        Restaurant.DataBind ();

        //        Servico.DataSource = _dataTable3;
        //        Servico.DataBind ();

        //        Estacionamiento.DataSource = _dataTable4;
        //        Estacionamiento.DataBind ();

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
