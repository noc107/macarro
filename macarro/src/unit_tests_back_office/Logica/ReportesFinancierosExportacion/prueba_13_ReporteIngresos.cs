using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;


namespace unit_tests_back_office.Logica.ReportesFinancierosExportacion
{
	[TestFixture]
	class prueba_13_ReporteIngresos
	{
		string _stringPrueba;
		string _fechaIni;
		string _fechaFin;

		[SetUp]
		public void Inicializar ()
		{
			_fechaIni = "1/1/2000";
			_fechaFin = "1/1/2015";
		}

		[Test]
		public void SombrillaPrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
							logica_13_ReporteIngresos.Sombrilla ( _fechaIni, _fechaFin );
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}

		[Test]
		public void RestaurantePrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
							logica_13_ReporteIngresos.Restaurante ( _fechaIni, _fechaFin );
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}

		[Test]
		public void ServicioPrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
							logica_13_ReporteIngresos.Servicio ( _fechaIni, _fechaFin );
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}

		[Test]
		public void EstacionamientoPrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
							logica_13_ReporteIngresos.Estacionamiento ( _fechaIni, _fechaFin );
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}
	}
}
