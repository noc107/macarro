using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Logica.Membresia;
using front_office.Dominio;
using front_office.Excepciones.GestionMembresia;


namespace unit_tests_front_office.Logica.GestionVentaMembresia
{
    class pruebaLogicaInsertarMembresia
    {

        private bool _respuestaMembresia;
        private LogicaInsertarMembresia _insertarMembresia;
        private Membre _membresiaPrueba;
        private string _correo;
        private string _telefono;
        private float _costo;


        [SetUp]
        public void inicio()
        {
            _respuestaMembresia = false;
            _insertarMembresia = new LogicaInsertarMembresia();
            _membresiaPrueba = new Membre();
            
            _costo = 30000;
            _telefono = "5752346";
            _correo = "alejandroVieira@gmail.com";
        }

        [Test]
        public void pruebaInsertarMembresia()
        {
            _respuestaMembresia = _insertarMembresia.InsertarMembresia(_telefono, _costo, _correo);
            Assert.IsTrue(_respuestaMembresia);
        }

        [Test]
        public void pruebasolicitarMembresia()
        {
            _membresiaPrueba =_insertarMembresia.solicitarMembresia(_correo);
            Assert.True(_membresiaPrueba.Codigo >= 0);
        }

        [TearDown]
        public void clean()
        {
            _membresiaPrueba = null;
            _insertarMembresia = null;
            _respuestaMembresia = false;
        }



    }
}
