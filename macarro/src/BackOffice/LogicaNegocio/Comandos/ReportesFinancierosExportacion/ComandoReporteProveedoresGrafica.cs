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
    public class ComandoReporteProveedoresGrafica : Comando <int,string>
    {
        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();
        
        /// <summary>
        /// El metodo se encarga de obtener por referencia los datos
        /// necesarios para realizar el reporte de que productos y que cantidad dichos
        /// proveedores venden, el metodo crea un string builder que 
        /// contendrá el codigo scrip html
        /// para la realización de un grafico de barra.
        /// 
        /// El codigo html dentro de el string builder utiliza
        /// google chart para realizar el grafico.
        /// 
        /// La función drawChart dentro de el string builder declara 
        /// las columnas necesarias para representar los datos requeridos
        /// del reporte y luego inserta tantas filas como datos se obtengan 
        /// al utilizar el metodo GetDatosProveedores.
        /// </summary>
        /// <returns>
        /// Este metodo regresa un string que contiene codigo html
        /// donde se crea el grafico para el reporte.
        /// </returns>
        public override string Ejecutar(int n)
        {
            DataTable _tablaDatos = new DataTable();
            StringBuilder _stringBuilder = new StringBuilder();
            try
            {
                _tablaDatos = _dao.GetDatosProveedores();
                _stringBuilder.Append(@"<script type=*text/javascript*> 
                                    google.load( *visualization*, *1*, {packages:[*corechart*]});
                                    google.setOnLoadCallback(drawChart);
                                    function drawChart() {
                                    var data = new google.visualization.DataTable()
                                    data.addColumn('string', 'Nombre');
                                    data.addColumn('number', 'Ventas');");

                for (int i = 0; i <= _tablaDatos.Rows.Count - 1; i++)
                {
                    _stringBuilder.Append(@" data.addRows([
                                        [ '" + _tablaDatos.Rows[i]["nombre"].ToString() +
                                            " (" + _tablaDatos.Rows[i]["ITE_nombre"].ToString() + ")" +
                                            "'," + _tablaDatos.Rows[i]["cantidad"].ToString() + " ]]);");
                }

                _stringBuilder.Append(@" var chart = new google.visualization.
                                    ColumnChart(document.getElementById('proveedores'));");
                _stringBuilder.Append(@"var options = {width: 620, height: 300,title: 'Proveedores',
                                    vAxis: { title: 'Ventas', titleTextStyle: { color: 'red' } }}; ");
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