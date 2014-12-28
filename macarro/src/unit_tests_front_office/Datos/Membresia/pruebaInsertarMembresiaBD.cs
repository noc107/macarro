using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_office.Datos.Membresia;
using front_office.Dominio;
using front_office.Excepciones.GestionMembresia;

namespace unit_tests_front_office.Datos.Membresia
{
    class pruebaInsertarPagoBD
    {
        private bool _respuestaMembresia;
        private InsertarMembresiaBD _insertarMembresia;
        private Membre _membresiaPrueba;
        private string _correo;

        [SetUp]
        public void inicio()
        {
            _respuestaMembresia = false;
            _insertarMembresia = new InsertarMembresiaBD();
            _membresiaPrueba = new Membre();
            _membresiaPrueba.Codigo = 28;
            _membresiaPrueba.DescAplicado = 78;
            _membresiaPrueba.Estado = "Activado";
            _membresiaPrueba.FechaAdmision = DateTime.Parse("01/02/2015");
            _membresiaPrueba.FechaVencimiento = DateTime.Parse("01/02/2016");
            _membresiaPrueba.Foto = "www";
            _membresiaPrueba.Costo = 30000;
            _membresiaPrueba.Telefono = "5752346";
            _correo = "alejandroVieira@gmail.com";
        }

        [Test]
        public void pruebainsertarMembresia()
        {
            _respuestaMembresia = _insertarMembresia.insertarMembresia(_membresiaPrueba, _correo);
            Assert.IsTrue(_respuestaMembresia);

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
