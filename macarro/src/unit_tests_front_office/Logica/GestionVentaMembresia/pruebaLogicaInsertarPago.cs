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
    class pruebaLogicaInsertarPago
    {
        private bool _respuestaPago;
        private LogicaInsertarPago _insertarPago;
        private string _correoPrueba;
       
        private float _costo;
       
        private int codigoPrueba;


        [SetUp]
        public void inicio()
        {
            _respuestaPago = false;
            _insertarPago = new LogicaInsertarPago();
            
            _costo = 20000;
            
            codigoPrueba = 1;

        }

        [Test]
        public void pruebaInsertarPago()
        {
            _respuestaPago = _insertarPago.InsertarPago(_costo, codigoPrueba);
            Assert.IsTrue(_respuestaPago);

        }

        [TearDown]
        public void clean()
        {
            _insertarPago = null;
        }

    }
}