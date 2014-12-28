using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using front_office.Datos.IngresoRecuperacionClave;
using front_office.Dominio;
using front_office.Logica.IngresoRecuperacionClave;

namespace unit_tests_front_office.Datos.IngresoRecuperacionClave
{
    [TestFixture]
    class PruebaOperaciones
    {
        private InicioSesion _inicioSesion;
        private ClienteCM _cliente1;
        private ClienteCM _cliente2;
        private Operaciones _operaciones;
        private Persona _persona1;
        private Usuario _usuario1;
        private Lugar _lugar1;
        private Persona _persona2;
        private Usuario _usuario2;
        private Lugar _lugar2;

        [SetUp]
        public void inicializador()
        {
            _inicioSesion = new InicioSesion();

           _persona1 = new Persona("6369043", "Cedula", "Dulce", "Mireya", "Ortuno", "Atacho", "25/04/1964");
            _usuario1 = new Usuario("dulce_ort@hotmail.com", "123Dulce", "Activado", "¿Cuál era su caricatura favorita en su infancia?", "Vaca y Pollito");
            _lugar1 = new Lugar(31, "Caricuao ud 3, bloque 6", "Direccion", 0);

            _persona2 = new Persona("092583247", "Pasaporte", "Roxana", "Joselyn", "Carrera", "Hernandez", "09/19/1990");
            _usuario2 = new Usuario("ybucherenick@gmail.com", "Hola1.", "Activado", "¿Cuál es la ciudad de nacimiento su madre?", "Guatire");
            _lugar2 = new Lugar(12, "Zona industrial de Cloris Urb. Terrazas del Este.", "Direccion", 0);

            _cliente1 = new ClienteCM(_persona1, _usuario1, _lugar1);
            _cliente2 = new ClienteCM(_persona2, _usuario2, _lugar2);

            _operaciones = new Operaciones();
        }
        /*private Persona _persona = new Persona();
        private Usuario _usuario = new Usuario();
        private Lugar _direccion = new Lugar();*/
        //Usuario(string correo, string contrasena, string estado,string preguntaSeguridad, string respuestaSeguridad)
        //Persona(string docIdentidad, string tipoDocIdentidad, string primerNombre, string segundoNombre,string primerApellido, string segundoApellido, string fechaNacimiento)

        [Test]
        public void PruebaObtenerContrasena()
        {
            string _contrasena = "123Dulce";
            string _correo = "dulce_ort@hotmail.com";
            string resultado = _inicioSesion.obtenerContrasena(_correo);
            Assert.AreEqual(_contrasena, resultado);
        }

        [Test]
        public void PruebaObtenerLugar()
        {
            string _docIdentidad = "092583247";
            int resultado = _inicioSesion.obtenerLugar(_docIdentidad);
            Assert.AreEqual(resultado, 12);
        }

   

        [Test]
        public void PruebaModificacion()
        {

            bool resultado = _operaciones.modificarDatos(_cliente2);

            Assert.IsTrue(resultado);
        }

    }
}