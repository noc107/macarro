using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office;
using NUnit.Framework;
using front_office.Logica.IngresoRecuperacionClave;
using front_office.Dominio;
using front_office.Datos.IngresoRecuperacionClave;

namespace unit_tests_front_office.Logica.IngresoRecuperacionClave
{
    class PruebaLogicaLogin
    {
        private LogicaCliente _cliente1;
        private LogicaCliente _cliente2;
        private LogicaCliente _cliente3;
        private LogicaCliente _cliente4;
        private LogicaCliente _cliente5;

        private Persona _persona2;
        private Usuario _usuario2;
        private Lugar _lugar2;
        private ClienteCM _clienteOp;

        [SetUp]
        public void Inicializar()
        {
            _cliente1 = new LogicaCliente();
            _cliente2 = new LogicaCliente("ybucherenick@gmail.com", "19851946", "Yolymar", "Bucherenick");
            _cliente3 = new LogicaCliente("dulce_ort@hotmail.com", "Dulce123", "Cliente", "Activado",
                "¿Cuál era su caricatura favorita en su infancia?", "Vaca y Pollito", "6369043", "6369043", "Cedula",
                "Dulce", null, "Ortuno", null, Convert.ToDateTime("25/04/1964"), 14);
            _cliente4 = new LogicaCliente("dulce_ort@hotmail.com", "Dulce123");
            _cliente5 = new LogicaCliente("dulce_ort@hotmail.com");

            _persona2 = new Persona("092583247", "Pasaporte", "Yoly", "Alejan", "Carrera", "Hernandez", "09/19/1990");
            _usuario2 = new Usuario("ybucherenick@gmail.com", "Hola1.", "Activado", "¿Cuál es la ciudad de nacimiento su madre?", "Guatire");
            _lugar2 = new Lugar(12, "Zona industrial de Cloris Urb. Terrazas del Este.", "Direccion", 0);

            _clienteOp = new ClienteCM(_persona2, _usuario2, _lugar2);
        }

        [Test]
        public void PruebaRegistrarCliente()
        {
            LogicaLogin _inicio = new LogicaLogin();
            Hash _hash = new Hash();
            string _contrasena = _hash.ObtenerMd5Hash("Kike123");
            bool _respuesta;

            _respuesta = _inicio.registroCliente("Caricuao ud 3, bloque 6", "7369043", "Cedula", "Enrique", "Humberto",
                "Bucherenick", "Canales", "1965-04-28", "kike_buch@hotmail.com",_contrasena,
                "¿Cuál era su caricatura favorita en su infancia?", "Vaca y Pollito");

            Assert.IsTrue(_respuesta);
        }

        [Test]
        public void PruebaCambiarClave()
        {
            LogicaLogin _inicio = new LogicaLogin();
            Hash _hash = new Hash();

            string _correo = "kike_buch@hotmail.com";
            string _nuevaContrasena = "123Kike";
            bool _respuesta;

            _respuesta = _inicio.cambiarClave(_correo,_hash.ObtenerMd5Hash(_nuevaContrasena));

            Assert.IsTrue(_respuesta);
        }

        [Test]
        public void PruebaObtenerPregunta()
        {
            LogicaLogin _inicio = new LogicaLogin();
            string _respuesta;
            string _correo = "kike_buch@hotmail.com";
            string _pregunta = "¿Cuál era su caricatura favorita en su infancia?";

            _respuesta = _inicio.obtenerPreguntaL(_correo);
            
            Assert.AreEqual(_respuesta, _pregunta);
        }

        [Test]
        public void PruebaComparar()
        {
            LogicaLogin _inicio = new LogicaLogin();

            bool _respuestaP;
            string _correo = "kike_buch@hotmail.com";
            string _respuestaTB = "Vaca y Pollito";
            
            _respuestaP = _inicio.comparar(_correo, _respuestaTB);

            Assert.IsTrue(_respuestaP);
        }

        [Test]
        public void PruebaVerificoCorreo()
        {
            LogicaLogin _inicio = new LogicaLogin();

            string _respuesta;
            string _correo = "kike_buch@hotmail.com";

            _respuesta = _inicio.verificoCorreo(_correo);

            Assert.AreEqual(_correo, _respuesta);
        }

        [Test]
        public void PruebaVerificoDocIdentificacion()
        {
            LogicaLogin _inicio = new LogicaLogin();

            string _respuesta;
            string _docIdentidad = "7369043";
            string _tipoDocIdentidad = "Cedula";

            _respuesta = _inicio.verificoDocIdentificacion(_docIdentidad, _tipoDocIdentidad);

            Assert.AreEqual(_docIdentidad, _respuesta);
        }

        [Test]
        public void PruebaInicio()
        {
            LogicaLogin _inicio = new LogicaLogin();
            LogicaCliente _cliente = new LogicaCliente();
            string _correo = "kike_buch@hotmail.com";
            string _contrasena = "123Kike";
            Hash _hash = new Hash();

            _cliente = _inicio.inicio(_correo, _hash.ObtenerMd5Hash(_contrasena));

            Assert.AreEqual(_cliente.Correo, _correo);
        }

        [Test]
        public void pruebaObtenerContrasenaC()
        {
            LogicaLogin _inicio = new LogicaLogin();
            string _contrasena = "fb7dc6bad8bf0d5ce32566783cd43dd8";
            string _correo = "kike_buch@hotmail.com";
            string _resultado = _inicio.obtenerContrasenaC(_correo);

            Assert.AreEqual(_resultado, _contrasena);
        }

        [Test]
        public void pruebaObtenerDirecionC()
        {
            LogicaLogin _inicio = new LogicaLogin();
            string _docIdentidad = "6369043";
            int _resultado = _inicio.obtenerDirecionC(_docIdentidad);

            Assert.AreEqual(_resultado,31);
        }

        [Test]
        public void pruebaModificarCliente()
        {
            LogicaLogin _inicio = new LogicaLogin();
            bool _resultado = _inicio.modificarCliente(_clienteOp);

            Assert.IsTrue(_resultado);
        }
    }
}
