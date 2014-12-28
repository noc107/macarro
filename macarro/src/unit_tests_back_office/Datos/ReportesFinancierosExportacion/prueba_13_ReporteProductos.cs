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
	class prueba_13_ReporteProductos
	{
		DataTable _tablaPrueba;

		[SetUp]
		public void Inicializar ()
		{

		}

		[Test]
		public void GetDatosProductoPrueba ()
		{
			_tablaPrueba = back_office.Datos.ReportesFinancierosExportacion.
						   datos_13_ReporteProductos.GetDatosProducto ();
			Assert.AreEqual ( 3, _tablaPrueba.Columns.Count );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ite_nombre" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ite_inv_cantidad" ) );
			Assert.IsTrue ( _tablaPrueba.Columns.Contains ( "ite_inv_cantidadmin" ) );
		}
	}
}
