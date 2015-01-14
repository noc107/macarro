using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Datos.GestionVentaMembresia;
using back_office.Dominio;
using back_office.Excepciones.GestionVentaMembresia;

namespace unit_tests_back_office.Datos.GestionVentaMembresia
{
    class pruebasMembresiaBD
    {
        private bool _respuesta;
        private MembresiaBD _modificarMembresia;
        private Membresia _membresia;

        [SetUp]
        public void inicio()
        {
            _respuesta = false;
            _modificarMembresia = new MembresiaBD();
            _membresia = new Membresia();
        }

        [Test]
        public void pruebaModificarCostoMembresia()
        {
            _membresia.Codigo = 1;
            _membresia.DescAplicado = 78;
            _membresia.Estado = "Activado";
            _respuesta = _modificarMembresia.ModificarMembresia(_membresia);
            Assert.IsTrue(_respuesta);
        }

        [TearDown]
        public void clean()
        {
            _membresia = null;
            _modificarMembresia = null;
            _respuesta = false;
        }





    }
}
