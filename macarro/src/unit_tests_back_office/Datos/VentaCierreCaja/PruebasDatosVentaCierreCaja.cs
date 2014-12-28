using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Datos.VentaCierreCaja;
using back_office.Dominio;

namespace unit_tests_back_office.Datos.VentaCierreCaja
{
    [TestFixture]
    class PruebasDatosVentaCierreCaja
    {
        private CajaBD _datosCaja;
        private FacturaBD _datosFactura;
        private LineaFacturaBD _datosLineaFactura;

        [SetUp]
        public void Init()
        {
            _datosCaja = new CajaBD();
            _datosFactura = new FacturaBD();
            _datosLineaFactura = new LineaFacturaBD();
        }

        //---------INICIO DATOS CAJA
        // <summary>
        /// Prueba del metodo CalcularEntradas de CajaBD
        /// </summary>
        [Test]
        public void pruebaCalcularEntradasDiario()
        {
            Caja _prueba = new Caja();
            _prueba = _datosCaja.CalcularEntradas();

            Assert.AreEqual(0, _prueba.Entrada);
        }

        // <summary>
        /// Prueba del metodo CalcularEntradasMensual de CajaBD
        /// </summary>
        [Test]
        public void pruebaCalcularEntradasMensual()
        {
            Caja _prueba = new Caja();
            _prueba = _datosCaja.CalcularEntradasMes();

            Assert.AreEqual(Math.Round(1975.68), Math.Round(_prueba.Entrada));
        }

        // <summary>
        /// Prueba del metodo CalcularSaldoAnteriorDiario de CajaBD
        /// </summary>
        [Test]
        public void pruebaCalcularSaldoAnteriorDiario()
        {
            Caja _prueba = new Caja();
            _prueba = _datosCaja.CalcularSaldoInicial();

            Assert.AreEqual(Math.Round(1975.68), Math.Round(_prueba.SaldoInicial));
        }

        // <summary>
        /// Prueba del metodo CalcularSaldoAnteriorMensual de CajaBD
        /// </summary>
        [Test]
        public void pruebaCalcularSaldoAnteriorMensual()
        {
            Caja _prueba = new Caja();
            _prueba = _datosCaja.CalcularSaldoInicialMes();

            Assert.AreEqual(0, _prueba.SaldoInicial);
        }

        // <summary>
        /// Prueba del metodo ConsultarPlatos de CajaBD
        /// </summary>
        [Test]
        public void pruebaConsultarPlatos()
        {
            List<PlatoBD> _prueba = new List<PlatoBD>();
            _prueba = _datosCaja.ConsultarPlatos();

            Assert.AreEqual(25, _prueba.Count);
        }
        //---------FIN DATOS CAJA

        //---------INICIO DATOS FACTURA
        // <summary>
        /// Prueba del metodo ConsultarServicios de FacturaBD
        /// </summary>
        [Test]
        public void pruebaConsultarServicios()
        {
            List<ServicioBD> _prueba = new List<ServicioBD>();
            _prueba = _datosCaja.ConsultarServicios();

            Assert.AreEqual(10, _prueba.Count);
        }

        // <summary>
        /// Prueba del metodo ConsultarFacturas de FacturaBD
        /// </summary>
        [Test]
        public void pruebaConsultarFacturas()
        {
            List<Factura> _prueba = new List<Factura>();
            _prueba = _datosFactura.ConsultarFacturas();

            Assert.AreEqual(10, _prueba.Count);
        }

        // <summary>
        /// Prueba del metodo ConsultarUltimaFactura de FacturaBD
        /// </summary>
        [Test]
        public void pruebaConsultarUltimaFactura()
        {
            Factura _prueba = new Factura();
            _prueba = _datosFactura.consultarUltimaFactura();

            Assert.AreEqual(10, _prueba.Codigo);
        }

        // <summary>
        /// Prueba del metodo ConsultarPersona de FacturaBD para MIEMBRO
        /// </summary>
        [Test]
        public void pruebaConsultarPersonaMiembro()
        {
            List<string> _prueba = new List<string>();
            _prueba = _datosFactura.consultarPersona("rubenalej@gmail.com");

            Assert.AreEqual(3, _prueba.Count);
        }

        // <summary>
        /// Prueba del metodo ConsultarPersona de FacturaBD para NO MIEMBRO
        /// </summary>
        [Test]
        public void pruebaConsultarPersonaNoMiembro()
        {
            List<string> _prueba = new List<string>();
            _prueba = _datosFactura.consultarPersona("alejandroVieira@gmail.com");

            Assert.AreEqual(5, _prueba.Count);
        }
        //---------FIN DATOS FACTURA

        //---------INICIO DATOS LINEAFACTURA
        // <summary>
        /// Prueba del metodo ConsultarLineaFacturas de LineaFacturaBD
        /// </summary>
        [Test]
        public void pruebaConsultarLineaFactura()
        {
            List<LineaFactura> _prueba = new List<LineaFactura>();
            _prueba = _datosLineaFactura.ConsultarLineasFactura(1);

            Assert.AreEqual(5, _prueba.Count);
        }
        //---------FIN DATOS LINEAFACTURA

        [TearDown]
        public void limpiar()
        {
            _datosCaja = null;
            _datosFactura = null;
            _datosLineaFactura = null;
        }
    }
}
