using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Datos.IngresoRecuperacionClave;

namespace unit_tests_back_office.Datos.IngresoRecuperacionClave
{
    class PruebaInicioSesion
    {
        [Test]
        public void PruebaInicio()
        {
            InicioSesion _inicio = new InicioSesion();
            EmpleadoRC _empleado = new EmpleadoRC();
            string _correo = "amandaRodriguez@gmail.com";
            string _contrasena = "21232f297a57a5a743894a0e4a801fc3";

            _empleado = _inicio.inicio(_correo, _contrasena);

            Assert.AreEqual(_empleado.Correo, _correo);
        }

        [Test]
        public void PruebaValidarCorreo()
        {
            InicioSesion _inicio = new InicioSesion();
            string _respuesta;
            string _correo = "amandaRodriguez@gmail.com";

            _respuesta = _inicio.validarCorreo(_correo);

            Assert.AreEqual(_correo, _respuesta);
        }  
    }
}
