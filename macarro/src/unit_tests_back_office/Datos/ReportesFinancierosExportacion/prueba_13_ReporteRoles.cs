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
	class prueba_13_ReporteRoles
	{
		DataTable _tablaPrueba;

		[SetUp]
		public void Inicializar ()
		{

		}

		[Test]
		public void GetDatosRolesPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteRoles.GetDatosRoles ();
			Assert.AreEqual ( 2, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "cantidad" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "rol" ) );
		}
	}
}
