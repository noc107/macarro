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
	class prueba_13_ReporteIngresos
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
		public void GetDatosIngresosSombrillaPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteIngresos.GetDatosIngresosSombrilla ( _fechaIni, _fechaFin );
			Assert.AreEqual ( 2, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "fecha" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ingreso" ) );
		}

		[Test]
		public void GetDatosIngresosRestaurantePrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteIngresos.GetDatosIngresosRestaurante ( _fechaIni, _fechaFin );
			Assert.AreEqual ( 2, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "fecha" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ingreso" ) );
		}

		[Test]
		public void GetDatosIngresosServicioPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteIngresos.GetDatosIngresosServicio ( _fechaIni, _fechaFin );
			Assert.AreEqual ( 2, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "fecha" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ingreso" ) );
		}

		[Test]
		public void GetDatosEstacionamientoPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteIngresos.GetDatosEstacionamiento ( _fechaIni, _fechaFin );
			Assert.AreEqual ( 2, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "fecha" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ingreso" ) );
		}
	}
}
