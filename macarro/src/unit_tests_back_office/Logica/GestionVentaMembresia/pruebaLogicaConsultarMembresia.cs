using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Logica.GestionVentaMembresia;
using back_office.Dominio;
using back_office.Excepciones.GestionVentaMembresia;


namespace unit_tests_back_office.Logica.GestionVentaMembresia
{
    class pruebaLogicaConsultarMembresia
    {
        private LogicaConsultarMembresia _consultarMembresia;
        private Membresia pruebaMembresia;
        private Persona pruebaPersona;
        private int _codigoPrueba;

        [SetUp]
        public void inicio()
        {
            _consultarMembresia = new LogicaConsultarMembresia();
            pruebaMembresia = new Membresia();
            pruebaPersona = new Persona();
            _codigoPrueba = 1;
        }

        [Test]
        public void pruebaSolicitarMembresia()
        {
            pruebaMembresia = _consultarMembresia.solicitarMembresia(_codigoPrueba);
            Assert.AreEqual(1, pruebaMembresia.Codigo);
            Assert.AreEqual("04264058285", pruebaMembresia.Telefono);

        }

        [Test]
        public void pruebaobtenerPersona()
        {
            pruebaPersona = _consultarMembresia.solicitarPersona(_codigoPrueba);
            Assert.AreEqual("11123456", pruebaPersona.DocIdentidad);
            Assert.AreEqual("Vieira", pruebaPersona.PrimerApellido);
            Assert.AreEqual("Alejandro", pruebaPersona.PrimerNombre);
        }


        [TearDown]
        public void clean()
        {
            _consultarMembresia = null;
            pruebaMembresia = null;
            pruebaPersona = null;
        }






    }
}
