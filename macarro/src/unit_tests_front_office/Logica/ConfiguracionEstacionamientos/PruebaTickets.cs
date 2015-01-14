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
    class PruebaTickets
    {
        private LogicaTicket _logicaTicket;

        [SetUp]
        public void inicializaTicket()
        {
            _logicaTicket = new LogicaTicket();
        }

        [Test]
        public void pruebaAgregarTicketSinSalida()
        {
            bool respuesta = true;

            respuesta = _logicaTicket.solicitarServicio_agregarTicketSinSalida("08-03-14 11:11:11 AM", "MAV91V", 1);

            Assert.IsTrue(respuesta);
        }

        [TearDown]
        public void recolectarBasuraTickets()
        {
            _logicaTicket = null;
        }
    }
}
