using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Dominio;
using back_office.Datos.ConfiguracionServiciosPlaya;
using back_office.Logica.ConfiguracionServiciosPlaya;
using System.Web.UI.WebControls;

namespace unit_tests_back_office.Logica.ConfiguracionServiciosPlaya
{
    [TestFixture]
    class PruebasLogicaModificarServicio
    {

        Servicio _servicio;
        LogicaModificarServicio _logicaServicio;

        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void testSolicitarServicio()
        {
            this._logicaServicio = new LogicaModificarServicio();
            this._servicio = new Servicio();
            this._servicio.Nombre = "Tabla de Surf";
            Label _label = new Label();
            this._servicio = _logicaServicio.solicitarServicio(this._servicio, _label);

            Assert.AreEqual(this._servicio.Nombre, "Tabla de Surf");
            Assert.AreEqual(this._servicio.Estado, true);
            Assert.AreEqual(this._servicio.Descripcion, "Aférrate y disfruta de las olas del mar");
            Assert.AreEqual(this._servicio.Categoria, "Deporte");
            Assert.AreEqual(this._servicio.Capacidad, 1);
            Assert.AreEqual(this._servicio.Cantidad, 10);
            Assert.AreEqual(this._servicio.Costo, 45);
            Assert.AreEqual(this._servicio.LugarRetiro, "Puesto de articulos");

        }

        [Test]
        public void testObtenerCategoriasServicios()
        {

            List<Categoria> _listaCategorias = new List<Categoria>();
            Categoria _categoria = new Categoria();
            List<Categoria> _listaCategoriaRetorno;
            Label _label = new Label();

            this._logicaServicio = new LogicaModificarServicio();

            _categoria = new Categoria();
            _categoria.IdCategoria = 1;
            _categoria.NombreCategoria = "Deporte";
            _listaCategorias.Add(_categoria);

            _categoria = new Categoria();
            _categoria.IdCategoria = 2;
            _categoria.NombreCategoria = "Recreativo";
            _listaCategorias.Add(_categoria);

            _categoria = new Categoria();
            _categoria.IdCategoria = 3;
            _categoria.NombreCategoria = "Familiar";
            _listaCategorias.Add(_categoria);

            _categoria = new Categoria();
            _categoria.IdCategoria = 4;
            _categoria.NombreCategoria = "Infantil";
            _listaCategorias.Add(_categoria);

            _listaCategoriaRetorno = this._logicaServicio.obtenerCategorias(_label);

            for (int i = 0; i <= 3; i++)
            {

                Assert.AreEqual(_listaCategorias.ElementAt(i).IdCategoria, _listaCategoriaRetorno.ElementAt(i).IdCategoria);
                Assert.AreEqual(_listaCategorias.ElementAt(i).NombreCategoria, _listaCategoriaRetorno.ElementAt(i).NombreCategoria);

            }

        }

        [Test]
        public void testActualizarServicio()
        {
            HorarioServicio[] _horarios = new HorarioServicio[3];
            HorarioServicio _horarioServicio;
            string[] _datos = new string[7];
            Label _label = new Label();

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 9;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 07:00:00 a.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 11:30:00 a.m.");
            _horarios[0] = _horarioServicio;

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 10;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 02:30:00 p.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 05:00:00 p.m.");
            _horarios[1] = _horarioServicio;

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 11;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 06:30:00 p.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 07:00:00 p.m.");
            _horarios[2] = _horarioServicio;
            this._logicaServicio = new LogicaModificarServicio();
            _datos[0] = "Kayak";
            _datos[1] = "Hola descripcion";
            _datos[5] = "Recreativo";
            _datos[6] = "Nuevo";
            _datos[2] = "15";
            _datos[3] = "12";
            _datos[4] = "100";
            Servicio _servicioPrueba = new Servicio(_datos, _horarios);

            //_servicioPrueba.agregarHorario(_horarioServicio);

            Assert.AreEqual(true, this._logicaServicio.actualizarServicio(_servicioPrueba, false, _datos[0], _label));

        }

        [Test]
        public void testVerificarEliminacionHorario()
        {
            HorarioServicio _horarioServicio;
            Servicio _servicio;
            Label _label = new Label();

            this._logicaServicio = new LogicaModificarServicio();
            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 8;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 08:30:00 a.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 01:00:00 p.m.");
            _servicio = new Servicio();
            _servicio.Nombre = "Snorkel";

            Assert.AreEqual(true, this._logicaServicio.validarEliminarServicio(_servicio, _horarioServicio,_label));

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 8;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 02:30:00 a.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 05:00:00 p.m.");

            Assert.AreEqual(false, this._logicaServicio.validarEliminarServicio(_servicio, _horarioServicio,_label));
        }
    }
}
