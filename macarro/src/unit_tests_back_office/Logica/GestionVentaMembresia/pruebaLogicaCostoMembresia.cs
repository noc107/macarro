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
    class pruebaLogicaCostoMembresia
    {

        private int _codigoPrueba;
        private LogicaCostoMembresia _costo;
        private bool _respuesta;
        private float _costoPrueba;

        [SetUp]
        public void inicio()
        {
            _costo = new LogicaCostoMembresia();
            _codigoPrueba = 1;
            _costoPrueba = 20000;
            _respuesta = false;

        }

        [Test]
        public void pruebasolicitarCostoMembresia()
        {
            Assert.True(_costo.solicitarCostoMembresia(_codigoPrueba) >= 0);
        }

        [Test]
        public void pruebaModificarCostoMembresia()
        {
            _respuesta = _costo.ModificarCostoMembresia(_codigoPrueba, _costoPrueba);
            Assert.IsTrue(_respuesta);
        }

        [TearDown]
        public void clean()
        {
            _costo = null;
            _codigoPrueba = 0;
            _costoPrueba = 0;
            _respuesta = false;
        }


    }
}
