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
    class pruebaLogicaConsultarMembresia
    {
        private LogicaConsultarMembresia consultaBD;
        private Membre pruebaMembresia;
        private Persona pruebaPersona;
        private string _correoPrueba;

        [SetUp]
        public void inicio()
        {
            consultaBD = new LogicaConsultarMembresia();
            pruebaMembresia = new Membre();
            pruebaPersona = new Persona();
            _correoPrueba = "alejandroVieira@gmail.com";
        }

        [Test]
        public void pruebasolicitarMembresia()
        {
            pruebaMembresia = consultaBD.solicitarMembresia(_correoPrueba);
            Assert.True(pruebaMembresia.Codigo > 0);
            Assert.NotNull(pruebaMembresia.Telefono);
        }

        [Test]
        public void pruebasolicitarPersona()
        {
            pruebaPersona = consultaBD.solicitarPersona(_correoPrueba);
            Assert.AreEqual("11123456", pruebaPersona.DocIdentidad);
            Assert.AreEqual("Vieira", pruebaPersona.SegundoApellido);
            Assert.AreEqual("Alejandro", pruebaPersona.PrimerNombre);
        }

        [Test]
        public void pruebasolicitarIdMembresia()
        {
            Assert.True(consultaBD.solicitarIdMembresia() >= 0);
        }
        
        [TearDown]
        public void clean()
        {
            pruebaMembresia = null;
            pruebaPersona = null;
            consultaBD = null;

        }


    }
}
