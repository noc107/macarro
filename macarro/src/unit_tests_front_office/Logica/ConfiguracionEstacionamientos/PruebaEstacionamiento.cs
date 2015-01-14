using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Dominio;
using front_office.Logica.ConfiguracionEstacionamientos;
using NUnit.Framework;

namespace unit_tests_front_office.Logica.ConfiguracionEstacionamientos
{
    [TestFixture]
    class PruebaEstacionamiento
    {
        private LogicaEstacionamiento _logicaEstacionamiento;
        private Estacionamiento _estacionamiento;
        private List<Estacionamiento> listaDePrueba;

        [SetUp]
        public void inicializaEstacionamiento()
        {
            _logicaEstacionamiento = new LogicaEstacionamiento();
            _estacionamiento = new Estacionamiento("Tolon", 50, 20, 15, "Activado");
            listaDePrueba = new List<Estacionamiento>();
            listaDePrueba = _logicaEstacionamiento.solicitarServicio_ConsultarEstacionamiento();
        }

        [Test]
        public void prueba_logicaAgregarEstacionamiento()
        {
            bool respuesta = false;

            respuesta = _logicaEstacionamiento.solicitarServicio_AgregarEstacionamiento(_estacionamiento.Nombre, _estacionamiento.Capacidad, _estacionamiento.Tarifa, _estacionamiento.Tarifa_ticketPerdido, _estacionamiento.Estado);

            Assert.IsTrue(respuesta);
        }

        [Test]
        public void prueba_logicaModificarEstacionamiento()
        {
            bool respuesta = false;

            bool confirmacion = false;

            List<Estacionamiento> _estacionamientos = new List<Estacionamiento>();

            respuesta = _logicaEstacionamiento.solicitarServicio_modificarEstacionamiento(1, "Nombre Modificado", 12, 12, 12, "Activado");

            _estacionamientos = _logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorNombre("Nombre Modificado");

            if (_estacionamientos.Count > 0)
            {
                confirmacion = true;
            }

            Assert.IsNotNull(_estacionamientos);

            Assert.IsTrue(respuesta);

            Assert.IsTrue(confirmacion);
        }

        [Test]
        public void prueba_ConsultarEstacionamiento()
        {

            Assert.NotNull(listaDePrueba);

            Assert.AreEqual(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamiento().Count, listaDePrueba.Count);

        }

        [Test]
        public void prueba_ConsultarEstacionamientoPorNombre()
        {
            bool respuesta = false;

            List<Estacionamiento> listaDeConsulta = new List<Estacionamiento>();

            listaDeConsulta = _logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorNombre("Tolon");

            if (_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorNombre("Tolon").Count > 0)
            {
                respuesta = true;
            }

            Assert.NotNull(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorNombre("Tolon"));

            Assert.AreEqual(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorNombre("Tolon").Count, listaDeConsulta.Count);

            Assert.True(respuesta);

        }

        [Test]
        public void prueba_ConsultarEstacionamientosPorEstatus()
        {
            List<Estacionamiento> listaDeActivados = new List<Estacionamiento>();

            List<Estacionamiento> listaDeDesactivados = new List<Estacionamiento>();

            listaDeActivados = _logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorEstatus("Activado");

            listaDeDesactivados = _logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorEstatus("Desactivado");

            Assert.NotNull(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorEstatus("Desactivado"));

            Assert.AreEqual(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorEstatus("Desactivado").Count, listaDeDesactivados.Count);

            Assert.NotNull(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorEstatus("Activado"));

            Assert.AreEqual(_logicaEstacionamiento.solicitarServicio_ConsultarEstacionamientoPorEstatus("Activado").Count, listaDeActivados.Count);

        }

        [Test]
        public void prueba_CambiarEstadoEstacionamiento()
        {
            List<Estacionamiento> listaActivados = new List<Estacionamiento>();

            bool respuesta = false;

            respuesta = _logicaEstacionamiento.solicitarServicio_cambiarEstadoEstacionamiento(1, "Desactivado");

            Assert.True(respuesta);
        }

        [TearDown]
        public void recolectarBasuraDePruebas()
        {
            _estacionamiento = null;

            listaDePrueba = null;

            _logicaEstacionamiento = null;

        }


    }
}
