using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Dominio;
using back_office.Logica.ConfiguracionEstacionamientos;
using back_office.Datos.ConfiguracionEstacionamientos;

namespace unit_tests_back_office.Datos.ConfiguracionEstacionamientos
{
    [TestFixture]
    class PruebaTickets_Datos
    {
        private TicketBD serviciosDatosTickes;
        private List<Ticket> listaDePrueba;

        [SetUp]
        public void inicializaTicket()
        {
            serviciosDatosTickes = new TicketBD();
            listaDePrueba = new List<Ticket>();
            listaDePrueba = serviciosDatosTickes.ConsultarTickets();
        }

        [Test]
        public void prueba_datosConsultarTickets()
        {
            Assert.NotNull(serviciosDatosTickes.ConsultarTickets());

            Assert.AreEqual(serviciosDatosTickes.ConsultarTickets().Count,listaDePrueba.Count);
        }

        [Test]
        public void prueba_datosConsultarTicketsPorPlaca()
        {
            String placaInicial = "";
            List<Ticket> listaDePruebaPlaca = new List<Ticket>();

            placaInicial = listaDePrueba[0].Placa;

            listaDePruebaPlaca = serviciosDatosTickes.ConsultarTicketsPorPlaca(placaInicial);

            Assert.NotNull(listaDePruebaPlaca);

            Assert.AreEqual(listaDePruebaPlaca[0].Placa, placaInicial);

        }

        [Test]
        public void prueba_datosConsultarTicketsPorFechas()
        {
            List<Ticket> listaDePruebaFecha = new List<Ticket>();
            String fechaInicio = "";
            String fechaSalida = "";
            fechaInicio = listaDePrueba[1].HoraEntrada.ToString();
            fechaSalida = listaDePrueba[1].HoraSalida.ToString();



            listaDePruebaFecha = serviciosDatosTickes.ConsultarTicketsPorFecha("01-01-14 10:34:09 PM", "12-12-14 10:34:09 PM");

            Assert.NotNull(listaDePruebaFecha);
        }

    }
}
