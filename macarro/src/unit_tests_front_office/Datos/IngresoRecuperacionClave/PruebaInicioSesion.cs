using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office;
using NUnit.Framework;
using front_office.Datos.IngresoRecuperacionClave;

namespace unit_tests_front_office.Datos.IngresoRecuperacionClave
{
    [TestFixture]
    class PruebaInicioSesion
    {
        private Cliente _cliente1;
        private Cliente _cliente2;
        private Cliente _cliente3;
        private Cliente _cliente4;
        private Cliente _cliente5;
        private Cliente _cliente6;

        [SetUp]
        public void Inicializar()
        {
            _cliente1 = new Cliente();
            _cliente2 = new Cliente("ybucherenick@gmail.com", "19851946", "Yolymar", "Bucherenick");
            _cliente3 = new Cliente("dulce_ort@hotmail.com", "Dulce123", "Cliente", "Activado",
                "¿Cuál era su caricatura favorita en su infancia?", "Vaca y Pollito", "6369043", "6369043", "Cedula",
                "Dulce", null, "Ortuno", null, Convert.ToDateTime("25/04/1964"), 14);
            _cliente4 = new Cliente("Caricuao UD 3", "19851946", "Cedula", "Dulce", null, "Ortuno", null, "04/25/1964",
                "dulce_ort@hotmail.com", "Dulce123", "¿Cuál era su caricatura favorita en su infancia?", "Vaca y Pollito");
            _cliente5 = new Cliente("dulce_ort@hotmail.com", "Dulce123");
            _cliente6 = new Cliente("dulce_ort@hotmail.com");
        }

        [Test]
        public void PruebaRegistrarCliente()
        {
            InicioSesion _inicio = new InicioSesion();
            bool _respuesta;

            _respuesta = _inicio.registrarCliente("Caricuao ud 3, bloque 6", "6369043", "Cedula", "Dulce", "Mireya", "Ortuno", "Atacho", "1964-04-25", "dulce_ort@hotmail.com",
                "Dulce123", "¿Cuál era su caricatura favorita en su infancia?", "Vaca y Pollito");

            Assert.IsTrue(_respuesta);
        }

        [Test]
        public void PruebaCambiarContrasena()
        {
            InicioSesion _inicio = new InicioSesion();
            bool _respuesta;
            string _correo = "dulce_ort@hotmail.com";
            string _nuevaContrasena = "123Dulce";

            _respuesta = _inicio.cambiarContrasena(_correo, _nuevaContrasena);

            Assert.IsTrue(_respuesta);
        }

        [Test]
        public void PruebaObtenerPregunta()
        {
            InicioSesion _inicio = new InicioSesion();
            string _respuesta;
            string _correo = "dulce_ort@hotmail.com";
            string _pregunta = "¿Cuál era su caricatura favorita en su infancia?";

            _respuesta = _inicio.obtenerPregunta(_correo);

            Assert.AreEqual(_respuesta, _pregunta);
        }

        [Test]
        public void PruebaObtenerRespuesta()
        {
            InicioSesion _inicio = new InicioSesion();
            string _respuestaP;
            string _correo = "dulce_ort@hotmail.com";
            string _respuesta = "Vaca y Pollito";

            _respuestaP = _inicio.obtenerRespuesta(_correo);

            Assert.AreEqual(_respuestaP, _respuesta);
        }

        [Test]
        public void PruebaValidarCorreo()
        {
            InicioSesion _inicio = new InicioSesion();
            string _respuesta;
            string _correo = "dulce_ort@hotmail.com";

            _respuesta = _inicio.validarCorreo(_correo);

            Assert.AreEqual(_correo, _respuesta);
        }

        [Test]
        public void PruebaValidarDocIdentidad()
        {
            InicioSesion _inicio = new InicioSesion();
            string _respuesta;
            string _docIdentidad = "6369043";
            string _tipoDocIdentidad = "Cedula";

            _respuesta = _inicio.validarDocIdentidad(_docIdentidad, _tipoDocIdentidad);

            Assert.AreEqual(_docIdentidad, _respuesta);
        }

        [Test]
        public void PruebaInicio()
        {
            InicioSesion _inicio = new InicioSesion();
            Cliente _cliente = new Cliente();
            string _correo = "dulce_ort@hotmail.com";
            string _contrasena = "123Dulce";

            _cliente = _inicio.inicio(_correo, _contrasena);

            Assert.AreEqual(_cliente.Correo, _correo);
        }
    }
}
