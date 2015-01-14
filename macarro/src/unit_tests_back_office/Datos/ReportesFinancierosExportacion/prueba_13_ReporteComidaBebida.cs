using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;

namespace unit_tests_back_office.Datos.ReportesFinancierosExportacion
{
	[TestFixture]
	class prueba_13_ReporteComidaBebida
	{
		DataTable _tablaPrueba;
		string _fechaIni;
		string _fechaFin;

		[SetUp]
		public void Inicializar ()
		{
			_fechaIni = "1/1/2000";
			_fechaFin = "1/1/2015";
		}

		[Test]
		public void GetDataBebidasPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
				          datos_13_ReporteComidaBebida.GetDataBebidas ( _fechaIni, _fechaFin );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "PLA_nombre" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ingresos" ) );
		}

		[Test]
		public void GetDataPlatosPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteComidaBebida.GetDataPlatos ( _fechaIni, _fechaFin );
			Assert.AreEqual ( 2, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "PLA_nombre" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ingresos" ) );
		}
	}
}
