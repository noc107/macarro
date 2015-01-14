using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Datos.Membresia;
using front_office.Dominio;
using front_office.Excepciones.GestionMembresia;

namespace unit_tests_front_office.Datos.Membresia
{
    class pruebasInsertarPagoBD
    {
        private bool _respuestaPago;
        private InsertarPagoBD _insertarPago;
        private string _correoPrueba;
        private Pago _pago;
        private float _costo;
        private DateTime _fpago;
        private int codigoPrueba;


        [SetUp]
        public void inicio()
        {
            _respuestaPago = false;
            _insertarPago = new InsertarPagoBD();
            _pago = new Pago();
            _costo = 20000;
            _fpago = DateTime.Parse("01/02/2015");
            codigoPrueba = 1;

        }

        [Test]
        public void pruebainsertarMembresia()
        {
            _respuestaPago = _insertarPago.InsertarPago(_pago, _costo, codigoPrueba);
            Assert.IsTrue(_respuestaPago);

        }

        [TearDown]
        public void clean()
        {
            _insertarPago = null;
            _pago = null;

        }

    }
}