using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Datos.ReservasSombrillasServiciosPlaya;
using back_office.Dominio;


namespace unit_tests_back_office.Datos.ReservasSombrillasServiciosPlaya.GestionarReservaBD
{

    public class PruebaBuscarServicio
    {
        int _idReserva;
        int IdServicio;

        public void inicio()
        {
            _idReserva = 1;
            IdServicio = 1;

        }

        [Test]
        public void PruebaConsultarServicio()
        {
            Assert.True(GestionarReservaBD.PruebaBuscarServicio.Equals(_idReserva, IdServicio));
        }
  }


    public class PruebaConsultarReserva
    {
       
        string cedula;
      
        
        public void prueba()
        {

            cedula = "20304050";

        }

        [Test]
        public void ConsultarReserva()
        {
            Assert.True(GestionarReservaBD.PruebaConsultarReserva.Equals(cedula, null));
        }
    }

    public class PruebaConsultarServicio
    {

        string id_Reserva;

        public void ConsultarServicio()
        {
            id_Reserva = "2";
        }
        [Test]
        public void ConsultarReserva()
        {
            Assert.True(GestionarReservaBD.PruebaConsultarServicio.Equals(id_Reserva, null));
        }
    }

}

