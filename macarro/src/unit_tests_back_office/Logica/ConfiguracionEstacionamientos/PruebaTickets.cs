using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Logica;
using back_office.Dominio;
using back_office.Logica.ConfiguracionEstacionamientos;

namespace unit_tests_back_office.Logica.ConfiguracionEstacionamientos
{
    [TestFixture]
    class PruebaTickets
    {
        private LogicaTicket _logicaTicket;
        private List<Ticket> listaDePrueba;

        [SetUp]
        public void inicializaTicket()
        {
            _logicaTicket = new LogicaTicket();
            //_ticket = new Estacionamiento("Tolon", 50, 20, 15, "Activado");
            listaDePrueba = new List<Ticket>();
            listaDePrueba = _logicaTicket.solicitarServicio_ConsultarTickets();
        }

        [Test]
        public void prueba_ConsultarTickets()
        {
            Assert.NotNull(_logicaTicket.solicitarServicio_ConsultarTickets());

            Assert.AreEqual(_logicaTicket.solicitarServicio_ConsultarTickets().Count,listaDePrueba.Count);
        }

        [Test]
        public void prueba_ConsultarTicketsPorPlaca()
        { 
            String placaInicial ="";
            List<Ticket> listaDePruebaPlaca = new List<Ticket>();

            placaInicial = listaDePrueba[0].Placa;

            listaDePruebaPlaca = _logicaTicket.solicitarServicio_ConsultarTicketsPorPlaca(placaInicial);

            Assert.NotNull(listaDePruebaPlaca);

            Assert.AreEqual(listaDePruebaPlaca[0].Placa,placaInicial);

        }

        [Test]
        public void pruebaConsultarTicketsPorFecha()
        {
            List<Ticket> listaDePruebaFecha = new List<Ticket>();
            String fechaInicio = "";
            String fechaSalida = "";
            fechaInicio = listaDePrueba[1].HoraEntrada.ToString();
            fechaSalida = listaDePrueba[1].HoraSalida.ToString();



            listaDePruebaFecha = _logicaTicket.solicitarServicio_ConsultarEstacionamientoPorFecha("01-01-14 10:34:09 PM", "12-12-14 10:34:09 PM");

            Assert.NotNull(listaDePruebaFecha);
            
        }
    }
}
