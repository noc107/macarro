using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Datos.Membresia;
using front_office.Dominio;
using front_office.Excepciones.GestionMembresia;

namespace unit_tests_front_office.Datos.GestionVentaMembresia
{
    class pruebaConsultarCostoBD
    {
       
        private ConsultarCostoBD _costo;

        [SetUp]
        public void inicio()
        {
            _costo = new ConsultarCostoBD();

        }

        [Test]
        public void pruebaobtenerCostoMembresia()
        {
            Assert.True(_costo.obtenerCosto() >= 0);
        }


        [TearDown]
        public void clean()
        {
            _costo = null;
            
        }
    }
}
