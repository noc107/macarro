using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using front_office.Logica.IngresoRecuperacionClave;

namespace unit_tests_front_office.Logica.IngresoRecuperacionClave
{
    [TestFixture]
    class PruebaHash
    {
        private Hash _hash;

        [SetUp]
        public void inicializador()
        {
            _hash = new Hash();
        }

        [Test]
        public void probarHash()
        {
            string _clave = "1234567";
            string _claveHash = "fcea920f7412b5da7be0cf42b8c93759";
            string resultado = _hash.ObtenerMd5Hash(_clave);

            Assert.AreEqual(resultado, _claveHash);

        }

        [Test]
        public void probarVerificarMd5Hash()
        {
            string _clave = "1234567";
            string _claveHash = "fcea920f7412b5da7be0cf42b8c93759";
            bool resultado = _hash.VerificarMd5Hash(_clave, _claveHash);

            Assert.IsTrue(resultado);

        }
    }
}

