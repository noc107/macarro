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
	class prueba_13_ReporteRoles
	{
		string _stringPrueba;

		[SetUp]
		public void Inicializar ()
		{

		}

		[Test]
		public void RolesPrueba ()
		{
			_stringPrueba = back_office.Logica.ReportesFinancierosExportacion.
				            logica_13_ReporteRoles.Roles ();
			Assert.IsInstanceOf<string> ( _stringPrueba );
		}
	}
}
