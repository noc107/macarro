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
    public class PruebasConfigurarPlaya
    {
        private ConfigurarPlaya capaLogica;
        private Playa playaNueva;
        private int idPlaya;
        private int fila;
        private int columna;

        [SetUp]
        public void inicio()
        {
            capaLogica = new ConfigurarPlaya();
            idPlaya = 1;
            fila = 10;
            columna = 10;
            playaNueva = new Playa(idPlaya, fila, columna);
        }

        #region solicitarConfiguracionActualDeLaPlaya
        [Test]
        public void PruebaLogicaConsultarConfiguracionDePlaya()
        {
            Playa playa = null;
            playa = capaLogica.solicitarConfiguracionActualDeLaPlaya();
            Assert.IsNotNull(playa);
            Assert.AreEqual(1, playa.Id);
        }
        #endregion

        #region ModificarConfiguracionDePlaya
        [Test]
        public void PruebaLogicaIngresarNuevaConfiguracionDePlaya()
        {
            //se deben cambiar los valores de fila y columna en Setup 
            //en caso que la prueba no sea exitosa para obtener la prueba exitosa
            Playa playaActual = capaLogica.solicitarConfiguracionActualDeLaPlaya();
            bool respuesta = capaLogica.ModificarConfiguracionDePlaya(playaNueva);
            Playa playaActualizada = capaLogica.solicitarConfiguracionActualDeLaPlaya();
            Assert.IsTrue(respuesta);
            Assert.AreEqual(playaActual.Id, playaActualizada.Id);
            Assert.AreNotEqual(playaActual.Filas, playaActualizada.Filas);
            Assert.AreNotEqual(playaActual.Columnas, playaActualizada.Columnas);
        }

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaLogicaIngresarNuevaConfiguracionDePlayaException()
        {
            //se deben cambiar los valores de fila y columna en Setup 
            //en caso que la prueba no sea exitosa para obtener la prueba exitosa
            Playa playaActual = capaLogica.solicitarConfiguracionActualDeLaPlaya();
            bool respuesta = capaLogica.ModificarConfiguracionDePlaya(null);
            Playa playaActualizada = capaLogica.solicitarConfiguracionActualDeLaPlaya();
          
        }
        #endregion


        [TearDown]
        public void Final()
        {
            capaLogica = null;
            idPlaya = 0;
            fila = 0;
            columna = 0;
            playaNueva = null;
        }
    }
}
