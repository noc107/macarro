using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Logica.GestionVentaMembresia;
using back_office.Dominio;
using back_office.Excepciones.GestionVentaMembresia;
using System.Data;


namespace unit_tests_back_office.Logica.GestionVentaMembresia
{
    class pruebaLogicaBuscarMembresia
    {
        private LogicaBuscarMembresia _buscarMembresia;
        private DataTable _t;
        
        [SetUp]
        public void inicio()
        {
            _buscarMembresia = new LogicaBuscarMembresia();
            _t = new DataTable();
        }



        [Test]
        public void pruebaconsultarMembresias()
        {
            _t = _buscarMembresia.consultarMembresias(); 
            Assert.True(_t.Rows.Count > 0);
        }

        [TearDown]
        public void clean()
        {
            _buscarMembresia = null;
            _t = null;
        }


    }
}
