using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Logica.IngresoRecuperacionClave;
using NUnit.Framework;
using back_office.Dominio;

namespace unit_tests_back_office.Logica.IngresoRecuperacionClave
{
    class PruebaLogicaLogin
    {
        [Test]
        public void PruebaInicio()
        {
            LogicaLogin _inicio = new LogicaLogin();
            LogicaEmpleado _empleado = new LogicaEmpleado();
            string _correo = "andreaPaola@gmail.com";
            string _contrasena = "21232f297a57a5a743894a0e4a801fc3";
            Hash _hash = new Hash();

            _empleado = _inicio.inicio(_correo, _hash.ObtenerMd5Hash(_contrasena));

            Assert.AreEqual(_empleado.Correo, _correo);
        }

        [Test]
        public void PruebaVerificoCorreo()
        {
            LogicaLogin _inicio = new LogicaLogin();

            string _respuesta;
            string _correo = "andreaPaola@gmail.com";

            _respuesta = _inicio.verificoCorreo(_correo);

            Assert.AreEqual(_correo, _respuesta);
        }
    }
}
