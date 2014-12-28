using back_office.Dominio;
using back_office.Logica.ConfiguracionServiciosPlaya;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace unit_tests_back_office.Logica.ConfiguracionServiciosPlaya
{
    [TestFixture]
    class PruebasLogicaAgregarServicio
    {

        private Servicio _ser;

        [SetUp]
        public void inicializar()
        {
            string[] _datos = new string[] { "ServicioPruebaLogicaUNO", "Descripcion de Prueba", "5", "10", "15.99", "Categoria de Prueba", "Lugar de Prueba" };
            
            HorarioServicio[] _hor = new HorarioServicio[2];
            _hor[0] = new HorarioServicio((DateTime.Parse("07:30 am")), DateTime.Parse("11:00 am"));
            _hor[1] = new HorarioServicio((DateTime.Parse("01:30 pm")), DateTime.Parse("05:00 pm"));

            this._ser = new Servicio(_datos, _hor);

        }


        [Test]
        public void instancionDeServicio()
        {
            Assert.AreEqual("ServicioPruebaLogicaUNO", this._ser.Nombre);
            Assert.AreEqual("Descripcion de Prueba", this._ser.Descripcion );
            Assert.AreEqual(5, this._ser.Capacidad);
            Assert.AreEqual(10, this._ser.Cantidad);
            Assert.AreEqual(float.Parse("15.99", CultureInfo.InvariantCulture.NumberFormat), this._ser.Costo);
            Assert.AreEqual("Categoria de Prueba", this._ser.Categoria);
            Assert.AreEqual("Lugar de Prueba", this._ser.LugarRetiro);
        }


        [Test]
        public void pruebaAgregarServicio()
        {
            Label _label = new Label();
            _label.Visible = false;

            LogicaAgregarServicio _logica = new LogicaAgregarServicio();

            Assert.AreEqual(true,_logica.agregarServicio(this._ser, _label));
        }


        [TearDown]
        public void limpiar()
        {
            _ser = null;
        }


    }
}
