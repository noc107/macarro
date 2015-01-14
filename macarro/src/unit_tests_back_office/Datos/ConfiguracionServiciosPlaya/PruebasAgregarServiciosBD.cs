using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using unit_tests_back_office.Logica.ConfiguracionServiciosPlaya;
using back_office.Datos.ConfiguracionServiciosPlaya;
using back_office.Dominio;
using back_office.Excepciones;

namespace unit_tests_back_office.Datos.ConfiguracionServiciosPlaya
{
    [TestFixture]
    class PruebaAgregarServiciosBD
    {

        private AgregarServiciosBD _validar;
        private Servicio _ser;


        [SetUp]
        public void iniciar()
        {
            this._validar = new AgregarServiciosBD();
            
            string[] _datos = new string[] { "ServicioPruebaInsertarD", "Descripcion de Prueba", "5", "10", "15.99", "Categoria de Prueba", "Lugar de Prueba" };

            HorarioServicio[] _hor = new HorarioServicio[2];
            _hor[0] = new HorarioServicio((DateTime.Parse("07:30 am")), DateTime.Parse("11:00 am"));
            _hor[1] = new HorarioServicio((DateTime.Parse("01:30 pm")), DateTime.Parse("05:00 pm"));

            this._ser = new Servicio(_datos, _hor);
        }



        [Test]
        public void pruebaValidarNombre()
        {
            Assert.AreEqual(true, this._validar.validarNombre("ServicioPrueba"));
            Assert.AreEqual(false, this._validar.validarNombre("Tabla de Surf"));
        }



        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void pruebaValidarNombreExcepcion()
        {
            this._validar.validarNombre(null);
        }



        [Test]
        public void pruebaIngresarServicio()
        {  
            _validar.insertarServicio(this._ser);
            Assert.AreEqual(false, this._validar.validarNombre("ServicioPruebaInsertarD"));

        }



        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void pruebaIngresarServicioExcepcion()
        {
            Servicio _serPrueba = new Servicio();
            _validar.insertarServicio(_serPrueba);
        }

        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void purebaIngresarServicioSinHorarioExcepcion()
        {
            Servicio _serPrueba = new Servicio("ServicioPruebaInsertarSinHorario", "Descripcion de Prueba", 5, 10, 15, "Categoria de Prueba", "Lugar de Prueba");
            _validar.insertarServicio(_serPrueba);
        }


        [TearDown]
        public void limpiar()
        {
            _ser = null;
        }

    }
}
