using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using System.Web.UI.WebControls;
using back_office.Logica.ConfiguracionServiciosPlaya;

namespace unit_tests_back_office.Logica.ConfiguracionServiciosPlaya
{
    [TestFixture]
    class PruebasLogicaConsultarServicio
    {
        [Test]
        public void incializar()
        {
            
        }


        [Test]
        public void pruebaEliminarBuscarServicio()
        {
            Label _l = new Label();
            _l.Visible = false;
            logicaConsultaServicio _logicaConsulta = new logicaConsultaServicio();
            DataTable _dt = new DataTable();

            _logicaConsulta.eliminarServicio("Mensajes1", _l);
            _dt = _logicaConsulta.buscarServicio("Mensajes1", "2", _l);
            Assert.AreEqual(0, _dt.Rows.Count);
            
        }

        [TearDown]
        public void limpiar()
        {
            
        }


    }
}
