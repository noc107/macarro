using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Datos.ConfiguracionEstacionamientos;
using NUnit.Framework;

namespace unit_tests_front_office.Datos.ConfiguracionEstacionamientos
{
    [TestFixture]
    class PruebaTickets_Datos
    {
        private TicketBD serviciosDatosTickes;

        [SetUp]
        public void inicializaTicket()
        {
            serviciosDatosTickes = new TicketBD();
        }

        [Test]
        public void pruebaAgregarTicketSinSalida()
        {
            bool respuesta = true;

            respuesta = serviciosDatosTickes.agregarTicketSinSalida("08-03-14 11:11:11 AM", "MAV91V", 1);

            Assert.IsTrue(respuesta);
        }

        [TearDown]
        public void recolectarBasuraTickets()
        {
            serviciosDatosTickes = null;
        }
    }
}
