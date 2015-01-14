using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Datos.ConfiguracionEstacionamientos;
using back_office.Dominio;
using back_office.Logica.ConfiguracionEstacionamientos;

namespace unit_tests_back_office.Datos.ConfiguracionEstacionamientos
{
    [TestFixture]
    class PruebaEstacionamiento_Datos
    {
        private EstacionamientoBD serviciosdeDatosEstacionamiento;
        private Estacionamiento _estacionamiento;
        private List<Estacionamiento> listaDePrueba;

        [SetUp]
        public void inicializaEstacionamiento()
        {
            serviciosdeDatosEstacionamiento = new EstacionamientoBD();
            _estacionamiento = new Estacionamiento("Tolon", 50, 20, 15, "Activado");
            listaDePrueba = new List<Estacionamiento>();
            listaDePrueba = serviciosdeDatosEstacionamiento.ConsultarEstacionamientos();
        }

        [Test]
        public void prueba_datosAgregarEstacionamiento()
        {
            bool respuesta = false;

            respuesta = serviciosdeDatosEstacionamiento.agregarEstacionamiento(_estacionamiento.Nombre, _estacionamiento.Capacidad, _estacionamiento.Tarifa, _estacionamiento.Tarifa_ticketPerdido, _estacionamiento.Estado);
                
            Assert.IsTrue(respuesta);
        }

        [Test]
        public void prueba_datosModificarEstacionamiento()
        {
            bool respuesta = false;

            bool confirmacion = false;

            List<Estacionamiento> _estacionamientos = new List<Estacionamiento>();

            respuesta = serviciosdeDatosEstacionamiento.modificarEstacionamiento(1, "Nombre Modificado", 12, 12, 12, "Activado");

            _estacionamientos = serviciosdeDatosEstacionamiento.ConsultarEstacionamientosNombre("Nombre Modificado");

            if (_estacionamientos.Count > 0)
            {
                confirmacion = true;
            }

            Assert.IsNotNull(_estacionamientos);

            Assert.IsTrue(respuesta);

            Assert.IsTrue(confirmacion);
        }

        [Test]
        public void prueba_datosConsultarEstacionamiento()
        {
            Assert.NotNull(listaDePrueba);

            Assert.AreEqual(serviciosdeDatosEstacionamiento.ConsultarEstacionamientos().Count, listaDePrueba.Count);
        }

        [Test]
        public void prueba_datosConsultarEstacionamientoPorNombre()
        {
            bool respuesta = false;

            List<Estacionamiento> listaDeConsulta = new List<Estacionamiento>();

            listaDeConsulta = serviciosdeDatosEstacionamiento.ConsultarEstacionamientosNombre("Tolon");

            if (serviciosdeDatosEstacionamiento.ConsultarEstacionamientosNombre("Tolon").Count > 0)
            {
                respuesta = true;
            }

            Assert.NotNull(serviciosdeDatosEstacionamiento.ConsultarEstacionamientosNombre("Tolon"));

            Assert.AreEqual(serviciosdeDatosEstacionamiento.ConsultarEstacionamientosNombre("Tolon").Count, listaDeConsulta.Count);

            Assert.True(respuesta);
        }

        [Test]
        public void prueba_datosConsultarEstacionamientoPorEstatus()
        {
            List<Estacionamiento> listaDeActivados = new List<Estacionamiento>();

            List<Estacionamiento> listaDeDesactivados = new List<Estacionamiento>();

            listaDeActivados = serviciosdeDatosEstacionamiento.ConsultarEstacionamientosEstatus("Activado");

            listaDeDesactivados = serviciosdeDatosEstacionamiento.ConsultarEstacionamientosEstatus("Desactivado");

            Assert.NotNull(serviciosdeDatosEstacionamiento.ConsultarEstacionamientosEstatus("Desactivado"));

            Assert.AreEqual(serviciosdeDatosEstacionamiento.ConsultarEstacionamientosEstatus("Desactivado").Count, listaDeDesactivados.Count);

            Assert.NotNull(serviciosdeDatosEstacionamiento.ConsultarEstacionamientosEstatus("Activado"));

            Assert.AreEqual(serviciosdeDatosEstacionamiento.ConsultarEstacionamientosEstatus("Activado").Count, listaDeActivados.Count);

        }

        [Test]
        public void prueba_datosCambiarEstadoEstacionamiento()
        {
            List<Estacionamiento> listaActivados = new List<Estacionamiento>();

            bool respuesta = false;

            respuesta = serviciosdeDatosEstacionamiento.cambiarEstadoEstacionamiento(1, "Desactivado");

            Assert.True(respuesta);
        }

        [TearDown]
        public void recolectarBasuraDePruebas()
        {
            _estacionamiento = null;

            listaDePrueba = null;

            serviciosdeDatosEstacionamiento = null;

        }

    }
}
