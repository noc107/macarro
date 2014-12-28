using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Logica.VentaCierreCaja;
using back_office.Dominio;
using back_office.Datos.VentaCierreCaja;

namespace unit_tests_back_office.Logica.VentaCierreCaja
{
    [TestFixture]
    class PruebasLogicaVentaCierreCaja
    {
        private LogicaLineaFactura _logicaLineaFactura;
        private LogicaFactura _logicaFactura;
        private LogicaCaja _logicaCaja;

        [SetUp]
        public void init()
        {
            _logicaLineaFactura = new LogicaLineaFactura();
            _logicaFactura = new LogicaFactura();
            _logicaCaja = new LogicaCaja();
        }


        //---------INICIO LOGICA FACTURA
        [Test]
        public void pruebaCalcularSubTotal() 
        {
            List<LineaFactura> lineas = new List<LineaFactura>();
            LineaFactura linea1 = new LineaFactura();
            LineaFactura linea2 = new LineaFactura();

            linea1.Precio = 100;
            linea2.Precio = 200;

            lineas.Add(linea1);
            lineas.Add(linea2);

            Assert.AreEqual(300,_logicaFactura.CalcularSubTotal(lineas));
        }

        [Test]
        public void pruebaCalcularMontoIva() 
        {
            float subTotal = 100;
            float total = float.Parse((100 + (100 * 0.12)).ToString());

            Assert.AreEqual(12, _logicaFactura.CalcularMontoIva(subTotal, total));
        }

        [Test]
        public void pruebaConsultarFacturas()
        {
            List<Factura> facturas = new List<Factura>();
            facturas = _logicaFactura.ConsultarFacturas();

            Assert.AreEqual(10,facturas.Count);
        }

        [Test]
        public void pruebaConsultarDatosPersonaNoMiembro()
        {
            List<string> datos = new List<string>();
            datos = _logicaFactura.consultarDatosPersona("rubenalej@gmail.com");

            Assert.AreEqual(3, datos.Count);
        }

        [Test]
        public void pruebaConsultarDatosPersonaMiembro()
        {
            List<string> datos = new List<string>();
            datos = _logicaFactura.consultarDatosPersona("alejandroVieira@gmail.com");

            Assert.AreEqual(5, datos.Count);
        }

        [Test]
        public void pruebaConsultarUltimaFactura()
        {
            Factura factura = new Factura();
            factura = _logicaFactura.consultarUltimaFactura();

            Assert.AreEqual(10, factura.Codigo);
        }
        //---------FIN LOGICA FACTURA
        //---------INICIO LOGICA LINEA_FACTURA

        [Test]
        public void pruebaCalcularMontoLinea()
        {
            int cant = 2;
            float precio = 178.033f;

            Assert.AreEqual(356.06601f, _logicaLineaFactura.CalcularMontoLinea(cant, precio));
        }

        [Test]
        public void pruebaConsultarLineasFactura()
        {
            List<LineaFactura> lineas = new List<LineaFactura>();
            lineas = _logicaLineaFactura.consultarLineas(1);

            Assert.AreEqual(5, lineas.Count);
        }

        [Test]
        public void pruebaGenerarLineas()
        {
            List<LineaFactura> lineas = new List<LineaFactura>();
            List<string> items = new List<string>();
            string ticket = "0";

            items.Add("Servicio-Algo"); //Nombre servicio
            items.Add("1"); //Cantidad
            items.Add("200"); //precio
            items.Add("Servicio-Algo2"); //Nombre servicio
            items.Add("2"); //Cantidad
            items.Add("200"); //precio

            lineas = _logicaLineaFactura.generarLineas(items, ticket);

            Assert.AreEqual(2, lineas.Count);

        }

        [Test]
        public void pruebaGenerarLineasConTicket()
        {
            List<LineaFactura> lineas = new List<LineaFactura>();
            List<string> items = new List<string>();
            string ticket = "25"; //ticket debe existir

            items.Add("Servicio-Algo"); //Nombre servicio
            items.Add("1"); //Cantidad
            items.Add("200"); //precio
            items.Add("Servicio-Algo2"); //Nombre servicio
            items.Add("2"); //Cantidad
            items.Add("200"); //precio

            lineas = _logicaLineaFactura.generarLineas(items, ticket);

            Assert.AreEqual(3, lineas.Count);

        }

        //---------FIN LOGICA LINEA_FACTURA
        //---------INICIO LOGICA CAJA

        [Test]
        public void pruebaCalcularEntradas()
        {
            Caja caja = new Caja();
            caja = _logicaCaja.CalcularEntradas();

            Assert.AreEqual(0, caja.Entrada);
        }

        [Test]
        public void pruebaCalcularEntradasMes()
        {
            Caja caja = new Caja();
            caja = _logicaCaja.CalcularEntradasMes();

            Assert.AreNotEqual(0, caja.Entrada);
        }

        [Test]
        public void pruebaCalcularSaldoInicialMes()
        {
            Caja caja = new Caja();
            caja = _logicaCaja.CalcularEntradasMes();

            Assert.AreEqual(0, caja.SaldoInicial);
        }

        [Test]
        public void pruebaCalcularSaldoActual()
        {
            Caja caja = new Caja();
            caja = _logicaCaja.CalcularSaldoActual(100, 250);

            Assert.AreEqual(350, caja.SaldoActual);
        }

        [Test]
        public void pruebaAbrirCuentaCliente()
        {
            string usuario = "rubenalej@gmail.com";
            List<string> items = new List<string>();
            string ticket = "0";

            items.Add("Servicio-Tabla de Surf"); //Nombre servicio
            items.Add("1"); //Cantidad
            items.Add("45"); //precio
            items.Add("Servicio-Caña de Pesca"); //Nombre servicio
            items.Add("2"); //Cantidad
            items.Add("30"); //precio

            Assert.AreEqual(true, _logicaCaja.AbrirCuentaCliente(usuario, items, ticket));
        }

        [Test]
        public void pruebaCerrarCuentaCliente()
        {
            string usuario = "rubenalej@gmail.com";
            List<string> items = new List<string>();
            string ticket = "0";

            items.Add("Servicio-Tabla de Surf"); //Nombre servicio
            items.Add("1"); //Cantidad
            items.Add("45"); //precio
            items.Add("Servicio-Caña de Pesca"); //Nombre servicio
            items.Add("2"); //Cantidad
            items.Add("30"); //precio

            Assert.AreEqual(true, _logicaCaja.CerrarCuentaCliente(usuario, items, ticket));
        }

        [Test]
        public void pruebaConsultarServicios()
        {
            List<ServicioBD> servicios = new List<ServicioBD>();
            servicios = _logicaCaja.ConsultarServicios();

            Assert.AreEqual(10, servicios.Count);
        }

        [Test]
        public void pruebaConsultarPlatos()
        {
            List<PlatoBD> platos = new List<PlatoBD>();
            platos = _logicaCaja.ConsultarPlatos();

            Assert.AreEqual(25, platos.Count);
        }

        [Test]
        public void pruebaValidarUsuarioExiste()
        {
            string usuario = "rubenalej@gmail.com";

            Assert.AreEqual(true, _logicaCaja.validarUsuarioExiste(usuario));
        }

        [Test]
        [ExpectedException( typeof(NotImplementedException))]
        public void pruebaValidarTicketExiste()
        {
            string ticket = "1";

            Assert.AreEqual(true, _logicaCaja.validarTicketExiste(ticket));
        }

        //---------FIN LOGICA CAJA

        [TearDown]
        public void limpiar() 
        {
            _logicaLineaFactura = null;
            _logicaFactura = null;
            _logicaCaja = null;
        }

    }
}
