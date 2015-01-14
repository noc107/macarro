using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Datos.ConfiguracionPuestosPlaya;
using back_office.Dominio;
using back_office.Excepciones.ConfiguracionPuestosPlaya;

namespace unit_tests_back_office.Datos.ConfiguracionPuestosPlaya
{
    [TestFixture]
    public class pruebasPlayaBD
    {
        private PlayaBD capaDatos;
        private Playa playaNueva;
        private int idPlaya;
        private int fila;
        private int columna;

        [SetUp]
        public void inicio()
        {
            capaDatos = new PlayaBD();
            idPlaya = 1;
            fila = 10;
            columna = 10;
            playaNueva = new Playa(idPlaya, fila, columna);
        }

        #region Consultar Configuracion De Playa
        [Test]
        public void PruebaDatosConsultarConfiguracionDePlaya()
        {
            Playa playa = null;
            playa = capaDatos.ConsultarConfiguracionDePlaya();
            Assert.IsNotNull(playa);
            Assert.AreEqual(1, playa.Id);
        }
        #endregion

        #region Ingresar Nueva Configuracion De Playa
        [Test]
        public void PruebaDatosIngresarNuevaConfiguracionDePlaya()
        {
            //se deben cambiar los valores de fila y columna en Setup 
            //en caso que la prueba no sea exitosa para obtener la prueba exitosa
            Playa playaActual = capaDatos.ConsultarConfiguracionDePlaya();            
            bool respuesta = capaDatos.IngresarNuevaConfiguracionDePlaya(playaNueva);
            Playa playaActualizada = capaDatos.ConsultarConfiguracionDePlaya();
            Assert.IsTrue(respuesta);
            Assert.AreEqual(playaActual.Id, playaActualizada.Id);
            Assert.AreNotEqual(playaActual.Filas, playaActualizada.Filas);
            Assert.AreNotEqual(playaActual.Columnas, playaActualizada.Columnas);
        }
        #endregion

        [TearDown]
        public void Final()
        {
            capaDatos = null;
            idPlaya = 0;
            fila = 0;
            columna = 0;
            playaNueva = null;
        }
    }
}
