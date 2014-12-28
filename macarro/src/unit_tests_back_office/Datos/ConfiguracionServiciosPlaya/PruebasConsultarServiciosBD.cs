using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using unit_tests_back_office.Logica.ConfiguracionServiciosPlaya;
using System.Data;
using back_office.Datos.ConfiguracionServiciosPlaya;
using back_office.Excepciones;

namespace unit_tests_back_office.Datos.ConfiguracionServiciosPlaya
{
    [TestFixture]
    class PruebasConsultarServiciosBD
    {
        [Test]
        public void pruebaEliminarServicio()
        {
            ConsultarServiciosBD _elimnar = new ConsultarServiciosBD();
            Assert.AreEqual(1,_elimnar.eliminarServicio("ServicioPruebaInsertarC"));        
        }

        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void pruebaEliminarServicioExcepcion()
        {
            ConsultarServiciosBD _elimnar = new ConsultarServiciosBD();
            _elimnar.eliminarServicio(null);
        }

        [Test]
        public void pruebaBuscarServicio()
        {
            DataTable _dt = new DataTable();
            ConsultarServiciosBD buscar = new ConsultarServiciosBD();
            
            _dt = buscar.buscarServicio("Tabla de Surf", "1");

            Assert.AreEqual(1, _dt.Rows.Count);

        }


    }
}
