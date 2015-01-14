using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Dao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.Dao;
using System.Data;
using System.Text;

namespace BackOffice.LogicaNegocio.Comandos.ReportesFinancierosExportacion
{
    public class ComandoReporteComidaGrafica : Comando<string[], string>
    {
        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();
        /// <summary>
        /// El metodo se encarga de obtener por referencia los datos
        /// necesarios para realizar el reporte de los platos mas vendidos,
        /// el metodo crea un string builder que contendrá el codigo scrip html
        /// para la realización de un grafico de barras.
        /// 
        /// El codigo html dentro de el string builder utiliza
        /// google chart para realizar el grafico.
        /// 
        /// La función drawChart dentro de el string builder declara 
        /// las columnas necesarias para representar los datos requeridos
        /// del reporte y luego inserta tantas filas como datos se obtengan 
        /// al utilizar el metodo GetDataPlatos.
        /// </summary>
        /// <param name="_fechaini">
        /// Es una variable que se pasa por referencia a un metodo 
        /// en la capa datos.
        /// </param>
        /// <param name="_fechafin">
        /// Es una variable que se pasa por referencia a un metodo 
        /// en la capa datos.
        /// </param>
        /// <returns>
        /// Este metodo regresa un string que contiene codigo html
        /// donde se crea el grafico para el reporte.
        /// </returns>
        public override string Ejecutar(string[] n)
        {
            DataTable _dataTable = new DataTable();
            StringBuilder _stringBuilder = new StringBuilder();
            string _fi = n[1];
            string _ff = n[2];
            try
            {
                _dataTable = _dao.GetDatosComidas(_fi, _ff);
                _stringBuilder.Append(@"<script type=*text/javascript*> 
                                    google.load( *visualization*, *1*, {packages:[*corechart*]});
                                    google.setOnLoadCallback(drawChart);
                                    function drawChart() {
                                    var data = new google.visualization.DataTable()
                                    data.addColumn('string', 'Plato');
                                    data.addColumn('number', 'Platos');");

                for (int i = 0; i <= _dataTable.Rows.Count - 1; i++)
                {
                    _stringBuilder.Append(@" data.addRows([
                [ '" + _dataTable.Rows[i]["PLA_nombre"].ToString() +
                    "'," + _dataTable.Rows[i]["ingresos"].ToString() + " ]    ]);");
                }

                _stringBuilder.Append(@" var chart = new google.visualization.
                                    ColumnChart(document.getElementById('graficoplatos'));");
                _stringBuilder.Append(@"var options = {width: 600, height: 300,title: 'Platos mas vendidos',
                                    vAxis: { title: 'Ingresos', titleTextStyle: { color: 'red' } }}; ");
                _stringBuilder.Append(" chart.draw(data, options");
                _stringBuilder.Append("); }");
                _stringBuilder.Append("</script>");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _stringBuilder.ToString().Replace('*', '"');
        }
 
    }
}