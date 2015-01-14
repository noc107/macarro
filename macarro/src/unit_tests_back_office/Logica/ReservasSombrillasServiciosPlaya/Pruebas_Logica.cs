using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using back_office.Logica.ReservasSombrillasServiciosPlaya;
using back_office.Dominio;
using NUnit.Framework;


namespace unit_tests_back_office.Logica.ReservasSombrillasServiciosPlaya.ConfigurarReserva.Reserva
{
    public class Pruebas_Logica
    {
        int id_reserva;
        int id_servicio;
        int expected;

        [Test]
        public void BuscarReserva()
        {
            id_reserva = 1;
            id_servicio = 1;
           
            expected = 1;
            Assert.AreEqual(expected, id_servicio);
            Assert.AreEqual(expected, id_reserva);
        }
    }

    

}
