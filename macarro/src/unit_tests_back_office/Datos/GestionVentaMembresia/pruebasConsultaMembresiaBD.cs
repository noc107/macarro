using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Datos.GestionVentaMembresia;
using back_office.Dominio;
using back_office.Excepciones.GestionVentaMembresia;
using System.Data;

namespace unit_tests_back_office.Datos.GestionVentaMembresia
{

    [TestFixture]
    class pruebasConsultaMembresiaBD
    {
        private ConsultaMembresiaBD consultaBD;
        private Membresia pruebaMembresia;
        private Persona pruebaPersona;
        private int _codigoPrueba;
        private DataTable _t;

        [SetUp]
        public void inicio()
        {
            consultaBD = new ConsultaMembresiaBD();
            pruebaMembresia = new Membresia();
            pruebaPersona = new Persona();
            _codigoPrueba = 1;
            _t = new DataTable();
        }


        [Test]
        public void pruebaconsultarMembresias()
        {
            _t = consultaBD.consultarMembresias();
            Assert.True(_t.Rows.Count > 0);    

        }

        [Test]
        public void pruebaobtenerMembresia()
        {
            pruebaMembresia = consultaBD.obtenerMembresia(_codigoPrueba);
            Assert.AreEqual(1,pruebaMembresia.Codigo);
            Assert.AreEqual("04264058285", pruebaMembresia.Telefono);

        }

        [Test]
        public void pruebaobtenerPersona()
        {
            pruebaPersona = consultaBD.obtenerPersona(_codigoPrueba);
            Assert.AreEqual("11123456", pruebaPersona.DocIdentidad);
            Assert.AreEqual("Vieira", pruebaPersona.PrimerApellido);
            Assert.AreEqual("Alejandro", pruebaPersona.PrimerNombre);
        }

        [TearDown]
        public void clean()
        {
            pruebaMembresia = null;
            pruebaPersona = null;
            consultaBD = null;
            _t = null;
        }

    }
}
