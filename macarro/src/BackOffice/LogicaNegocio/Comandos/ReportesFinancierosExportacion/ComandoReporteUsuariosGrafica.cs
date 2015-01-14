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
    public class ComandoReporteUsuariosGrafica : Comando<int, string>
    {
        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();

        /// <summary>
        /// El metodo se encarga de obtener por referencia los datos
        /// necesarios para realizar el reporte de cuantos usuarios
        /// estan activos y cuantos estan inactivos, 
        /// el metodo crea un string builder que 
        /// contendrá el codigo scrip html
        /// para la realización de un grafico de pastel.
        /// 
        /// El codigo html dentro de el string builder utiliza
        /// google chart para realizar el grafico.
        /// 
        /// La función drawChart dentro de el string builder declara 
        /// las columnas necesarias para representar los datos requeridos
        /// del reporte y luego inserta tantas filas como datos se obtengan 
        /// al utilizar el metodo GetDatosActivos.
        /// </summary>
        /// <returns>
        /// Este metodo regresa un string que contiene codigo html
        /// donde se crea el grafico para el reporte.
        /// </returns>
        public override string Ejecutar(int i)
        {
            DataTable _tablaDatos = new DataTable();
            StringBuilder _stringBuilder = new StringBuilder();

            try
            {
                _tablaDatos = _dao.GetDatosActivos();
                _stringBuilder.Append(@"<script type=*text/javascript*> 
                                    google.load( *visualization*, *1*, {packages:[*corechart*]});
                                    google.setOnLoadCallback(drawChart);
                                    function drawChart() {
                                    var data = new google.visualization.DataTable()
                                    data.addColumn('string', 'Tipo');
                                    data.addColumn('number', 'Cantidad');");
                _stringBuilder.Append(@" data.addRows([
                                    [ 'Activo'," + _tablaDatos.Rows[0]["Activos"].ToString()
                                        + " ]]);");
                _stringBuilder.Append(@" data.addRows([
                                    [ 'Inactivos'," + _tablaDatos.Rows[0]["Inactivos"].ToString()
                                        + " ]]);");
                _stringBuilder.Append(@" var chart = new google.visualization.
                                    PieChart(document.getElementById('activos'));");
                _stringBuilder.Append("var options = {width: 600, height: 300,title: 'Usuarios'}; ");
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