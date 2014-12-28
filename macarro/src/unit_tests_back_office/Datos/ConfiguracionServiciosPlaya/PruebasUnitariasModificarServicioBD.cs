using back_office.Datos.ConfiguracionServiciosPlaya;
using back_office.Dominio;
using back_office.Excepciones;
using back_office.Logica.ConfiguracionServiciosPlaya;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_tests_back_office.Datos.ConfiguracionServiciosPlaya
{
    [TestFixture]
    class PruebasUnitariasModificarServicioBD
    {
        Servicio _servicio;
        ModificarServiciosBD _modificarServicios;

        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void obtenerServicio()
        {
            this._modificarServicios = new ModificarServiciosBD();
            this._servicio = new Servicio();
            this._servicio.Nombre = "Tabla de Surf";

            this._servicio = _modificarServicios.obtenerServicio(this._servicio);

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
            this._modificarServicios = new ModificarServiciosBD();                        

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
            
            _listaCategoriaRetorno = this._modificarServicios.obtenerCategoriasServicios();

            for (int i = 0; i <= 3; i++)
            {

                Assert.AreEqual(_listaCategorias.ElementAt(i).IdCategoria, _listaCategoriaRetorno.ElementAt(i).IdCategoria);
                Assert.AreEqual(_listaCategorias.ElementAt(i).NombreCategoria, _listaCategoriaRetorno.ElementAt(i).NombreCategoria);

            }          
          
        }


        [Test]
        public void testObtenerHorarios()
        {

            Servicio _servicioPrueba = new Servicio();
            Servicio _servicioRetorno = new Servicio();
            HorarioServicio _horarioServicio;
            int _idServicio;

            this._modificarServicios = new ModificarServiciosBD();            
            _idServicio = 6;
            _servicioPrueba.Nombre = "Kayak";

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 9;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 07:00:00 a.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 11:30:00 a.m.");

            _servicioPrueba.agregarHorario(_horarioServicio);

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 10;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 02:30:00 p.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 05:00:00 p.m.");

            _servicioPrueba.agregarHorario(_horarioServicio);

            this._modificarServicios.ConexionBD._cn.Open();
            _servicioRetorno = this._modificarServicios.obtenerHorarios(_servicioRetorno, _idServicio);
            this._modificarServicios.ConexionBD.DesconectarBD();

            for (int i = 0; i<=1 ; i++)
            {

                Assert.AreEqual(_servicioPrueba.obtenerListaHorario().ElementAt(i).IdHorario, _servicioRetorno.obtenerListaHorario().ElementAt(i).IdHorario); ;
                Assert.AreEqual(_servicioPrueba.obtenerListaHorario().ElementAt(i).HoraInicio, _servicioRetorno.obtenerListaHorario().ElementAt(i).HoraInicio); ;
                Assert.AreEqual(_servicioPrueba.obtenerListaHorario().ElementAt(i).HoraFin, _servicioRetorno.obtenerListaHorario().ElementAt(i).HoraFin);

            }


        }

        [Test]
        public void validarNombreExista()
        {

            string _nombreServicio = "Kayak";
            bool _valorRetorno;

            this._modificarServicios = new ModificarServiciosBD();
            _valorRetorno= this._modificarServicios.validarNombre(_nombreServicio);

            Assert.AreEqual(false,_valorRetorno);

        }

        [Test]
        public void validarNombreNoExista()
        {

            string _nombreServicio = "Kayakasds";
            bool _valorRetorno;

            this._modificarServicios = new ModificarServiciosBD();
            _valorRetorno = this._modificarServicios.validarNombre(_nombreServicio);

            Assert.AreEqual(true, _valorRetorno);

        }

        [Test]
        public void testActualizarServicio()
        {
            HorarioServicio[] _horarios = new HorarioServicio[3];                
            HorarioServicio _horarioServicio;
            string[] _datos = new string[7];
            
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
            this._modificarServicios = new ModificarServiciosBD();
            _datos[0] = "Kayak";
            _datos[1] = "Hola descripcion";
            _datos[5] = "Recreativo";
            _datos[6] = "Nuevo";
            _datos[2] = "15";
            _datos[3] ="12";
            _datos[4] = "100";
            Servicio _servicioPrueba = new Servicio(_datos, _horarios);
                        
            //_servicioPrueba.agregarHorario(_horarioServicio);

            Assert.AreEqual(true,this._modificarServicios.actualizarServicio(_servicioPrueba,_datos[0]));
           
        }

        [Test]
        public void testVerificarEliminacionHorario() {
            HorarioServicio _horarioServicio;
            Servicio _servicio;

            this._modificarServicios = new ModificarServiciosBD();
            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 8;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 08:30:00 a.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 01:00:00 p.m.");
            _servicio = new Servicio();
            _servicio.Nombre = "Snorkel";
            
            Assert.AreEqual(true, this._modificarServicios.verificarEliminacionHorarioServicio(_servicio, _horarioServicio));

            _horarioServicio = new HorarioServicio();
            _horarioServicio.IdHorario = 8;
            _horarioServicio.HoraInicio = DateTime.Parse("01-01-1900 02:30:00 a.m.");
            _horarioServicio.HoraFin = DateTime.Parse("01-01-1900 05:00:00 p.m.");

            Assert.AreEqual(false, this._modificarServicios.verificarEliminacionHorarioServicio(_servicio, _horarioServicio));
        }

        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void testExcepcionActualizarServicio()
        {
            this._modificarServicios = new ModificarServiciosBD();
            Servicio _serPrueba = new Servicio();
            this._modificarServicios.actualizarServicio(_serPrueba, "Snorkel");
        }

        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void testVerificarEliminacionHorarioExcepcion()
        {
            this._modificarServicios = new ModificarServiciosBD();
            Servicio _serPrueba = new Servicio();
            this._modificarServicios.verificarEliminacionHorarioServicio(_serPrueba,null);
        }

        [Test]
        [ExpectedException(typeof(ExcepcionServicioBaseDatos))]
        public void testValidarNombreException()
        {
            this._modificarServicios = new ModificarServiciosBD();
            this._modificarServicios.validarNombre(null);
        }

        
    }
}
