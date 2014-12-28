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
	class prueba_13_ReporteComidaBebida
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
		public void BebidasPrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
							logica_13_ReporteComidaBebida.Bebidas ( _fechaIni, _fechaFin );
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}

		[Test]
		public void PlatosPrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
							logica_13_ReporteComidaBebida.Platos ( _fechaIni, _fechaFin );
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}
	}
}
