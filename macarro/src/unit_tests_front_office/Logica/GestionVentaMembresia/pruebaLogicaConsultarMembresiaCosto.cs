using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Logica.Membresia;
using front_office.Dominio;
using front_office.Excepciones.GestionMembresia;

namespace unit_tests_front_office.Logica.GestionVentaMembresia
{
    class pruebaLogicaConsultarMembresiaCosto
    {
        private LogicaConsultarMembresiaCosto consultaBD;

        [SetUp]
        public void inicio()
        {
            consultaBD = new LogicaConsultarMembresiaCosto();
        }

        [Test]
        public void pruebassolicitarCosto()
        {
            Assert.True(consultaBD.solicitarCosto() >= 0);
        }

        [TearDown]
        public void clean()
        {
            consultaBD = null;
        }


    }
}
