using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Logica.GestionVentaMembresia;
using back_office.Dominio;
using back_office.Excepciones.GestionVentaMembresia;


namespace unit_tests_back_office.Logica.GestionVentaMembresia
{
    class pruebaLogicaMembresia
    {
        private bool _respuesta;
        private LogicaMembresia _modificarMembresia;
        private int _codigo;
        private float _descAplicado;
        private string _estado;

        [SetUp]
        public void inicio()
        {
            _respuesta = false;
            _modificarMembresia = new LogicaMembresia();
            _codigo = 1;
            _descAplicado = 78;
            _estado = "Activado";
        }

        [Test]
        public void pruebaModificarMembresia()
        {
            
            _respuesta = _modificarMembresia.ModificarMembresia(_codigo,_estado,_descAplicado);
            Assert.IsTrue(_respuesta);
        }

        [TearDown]
        public void clean()
        {
            
            _modificarMembresia = null;
            _respuesta = false;
        }


    }
}
