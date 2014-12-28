﻿//web_13_ReporteComidaBebida
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ReportesFinancierosExportacion
{
	public partial class web_13_ReporteComidaBebida : System.Web.UI.Page
	{
		DataTable _dataTable = new DataTable ();
		DataTable _dataTable2 = new DataTable ();
		/// <summary>
		/// El metodo Page_Load se encarga de manejar 
		/// el evento de Click en el boton BuscarBoton.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load ( object sender, EventArgs e )
		{
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

            //ComidaPopular.CssClass = "mGrid";

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
        //        _dataTable = back_office.Logica.ReportesFinancierosExportacion.logica_13_ReporteComidaBebida.
        //                     TablaBebidas ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //        _dataTable2 = back_office.Logica.ReportesFinancierosExportacion.logica_13_ReporteComidaBebida.
        //                      TablaPlatos ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
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
        //            _dataTable.Columns["PLA_nombre"].ColumnName = "Nombre";
        //            _dataTable.Columns["ingresos"].ColumnName = "Ingresos";
        //        }

        //        if (_dataTable2.Rows.Count > 0)
        //        {
        //            _dataTable2.Columns["PLA_nombre"].ColumnName = "Nombre";
        //            _dataTable2.Columns["ingresos"].ColumnName = "Ingresos";
        //        }


        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable, "Reporte Bebidas" );
        //        back_office.Logica.ReportesFinancierosExportacion.
        //        logica_13_ExportarExcel.ExportarExcel ( _dataTable2, "Reporte Platos" );
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

        //    try
        //    {
        //        ExportarBoton.Visible = false;

        //        dataTableVaciaBebida.Visible = false;
        //        dataTableVaciaComida.Visible = false;

        //        graficaVaciaComida.Visible = false;
        //        graficaVaciaBebida.Visible = false;

        //        MensajeError.Visible = false;
        //        try
        //        {

        //            if ( back_office.Logica.ReportesFinancierosExportacion.
        //                logica_13_ReporteComidaBebida.ComprobarConexionInternet () )
        //            {

        //                literal.Text = back_office.Logica.ReportesFinancierosExportacion.logica_13_ReporteComidaBebida.
        //                               Bebidas ( this.inputFechaInicio.Text, this.inputFechaFin.Text );

        //                literal2.Text = back_office.Logica.ReportesFinancierosExportacion.logica_13_ReporteComidaBebida.
        //                                Platos ( this.inputFechaInicio.Text, this.inputFechaFin.Text );
        //            }
        //        }
        //        catch ( back_office.Excepciones.ReportesFinancierosExportacion.ExcepcionInternet _excepcion )
        //        {

        //            graficaVaciaComida.Visible = true;
        //            graficaVaciaBebida.Visible = true;

        //            graficaVaciaComida.Text = _excepcion.Message.ToString ();
        //            graficaVaciaBebida.Text = _excepcion.Message.ToString ();

        //            goto ContinuarEjecucion;

        //        }

        //        ContinuarEjecucion:

        //        _dataTable = back_office.Logica.ReportesFinancierosExportacion.logica_13_ReporteComidaBebida.
        //                               TablaBebidas ( this.inputFechaInicio.Text, this.inputFechaFin.Text );

        //        if ( _dataTable.Rows.Count == 0 )
        //        {
        //            dataTableVaciaBebida.Visible = true;
        //            dataTableVaciaBebida.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }


        //        _dataTable2 = back_office.Logica.ReportesFinancierosExportacion.logica_13_ReporteComidaBebida.
        //                                TablaPlatos ( this.inputFechaInicio.Text, this.inputFechaFin.Text );

        //        if ( _dataTable2.Rows.Count == 0 )
        //        {
        //            dataTableVaciaComida.Visible = true;
        //            dataTableVaciaComida.Text = "No Existen Datos en el Intervalo de Fechas Seleccionado";
        //        }

        //        ComidaPopular.DataSource = _dataTable2;
        //        ComidaPopular.DataBind ();

        //        BebidaPopular.DataSource = _dataTable;
        //        BebidaPopular.DataBind ();

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