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
    class pruebaConsultarMembresiaBD
    {
        private ConsultarMembresiaBD consultaBD;
        private Membre pruebaMembresia;
        private Persona pruebaPersona;
        private string _correoPrueba;
     
        [SetUp]
        public void inicio()
        {
            consultaBD = new ConsultarMembresiaBD();
            pruebaMembresia = new Membre();
            pruebaPersona = new Persona();
            _correoPrueba = "alejandroVieira@gmail.com";
        }

        [Test]
        public void pruebaobtenerMembresia()
        {
            pruebaMembresia = consultaBD.obtenerMembresia(_correoPrueba);
            Assert.True(pruebaMembresia.Codigo > 0);
            Assert.NotNull(pruebaMembresia.Telefono);
        }

        [Test]
        public void pruebaobtenerPersona()
        {
            pruebaPersona = consultaBD.obtenerPersona(_correoPrueba);
            Assert.AreEqual("11123456", pruebaPersona.DocIdentidad);
            Assert.AreEqual("Vieira", pruebaPersona.SegundoApellido);
            Assert.AreEqual("Alejandro", pruebaPersona.PrimerNombre);
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
