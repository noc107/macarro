using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Logica.ConfiguracionPuestosPlaya;
using back_office.Dominio;
using back_office.Excepciones.ConfiguracionPuestosPlaya;

namespace unit_tests_back_office.Logica.ConfiguracionPuestosPlaya
{
    [TestFixture]
    public class pruebasLogicaPuesto
    {
        private LogicaPuesto capaLogica;
        private string filaR;
        private string columnaR;
        private string descripcion;
        private string precio;
        private string estado;

        [SetUp]
        public void inicio()
        {
            capaLogica = new LogicaPuesto();
            filaR ="1";
            columnaR = "1";
            descripcion = "Vista al oceano";
            precio = "90";
            estado = "Desactivado";
        }

        //prueba de busqueda de puesto
        [Test]
        public void busquedaPuesto()
        {
            Assert.True((capaLogica.busquedaPuesto(filaR, "")).Count > 0);
        }
       
        //prueba unitaria de prueba actualizacion
        [Test]
        public void pruebactualizacionPuesto()
        {
            bool flag;
            flag = capaLogica.actualizacionPuesto(filaR,columnaR,descripcion,precio,estado);
            Assert.IsTrue(flag);
        }






        [TearDown]
        public void Final()
        {
            capaLogica = null;
            filaR = string.Empty;
        }
    }
}
