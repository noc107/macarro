using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Logica.ConfiguracionPuestosPlaya;
using back_office.Dominio;
using back_office.Excepciones.ConfiguracionPuestosPlaya;

namespace unit_tests_back_office.Logica.ConfiguracionPuestosPlaya
{
    [TestFixture]
    public class PruebasLogicaInventario
    {
        private LogicaInventario capaLogica;
        private string tipoInv;
        private string precioInv;
        private string cantidadInv;
        private int idInventario;
        private object _parametroId;
        private float valorNuevo;
        private int idInventarioDiferente;

        [SetUp]
        public void inicio()
        {
            capaLogica = new LogicaInventario();  
            tipoInv="MESA";
            precioInv = "10";
            cantidadInv = "10";
            idInventario = 88;
            valorNuevo = 5000;
            idInventarioDiferente = 85;    
        }

        #region AgregarInventarioNuevoAplaya
        [Test]
        public void PruebaLogicaAgregarInventarioNuevoAplaya()
        {
            bool respuesta;
            respuesta = capaLogica.AgregarInventarioNuevoAplaya(tipoInv, precioInv, cantidadInv);
            Assert.IsTrue(respuesta);
        }

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaLogicaAgregarInventarioNuevoAplayaException()
        {
            bool respuesta;
            respuesta = capaLogica.AgregarInventarioNuevoAplaya(tipoInv, precioInv, null);
        }

        #endregion

        #region ConsultarInventario
        [Test]
        public void PruebaLogicaConsultarInventario()
        {           
            Assert.IsTrue(capaLogica.ConsultarInventario(tipoInv).Count > 0);
        }

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaLogicaConsultarInventarioException()
        {
            List<Inventario> consulta = capaLogica.ConsultarInventario(null);
        }
        #endregion

        #region ConsultarInventarioId
        [Test]
        public void PruebaLogicaConsultarInventarioId()
        {
            Inventario consulta = capaLogica.ConsultarInventarioId(idInventario);
            Assert.AreEqual(idInventario, consulta.Id);
            Assert.AreEqual(tipoInv, consulta.Tipo);
            Assert.AreEqual(tipoInv + "-" + idInventario, consulta.Codigo);
        }
        #endregion

        #region ActualizarInventario
        [Test]
        public void PruebaLogicaActualizarInventarioTodosMismoTipo()
        {
            bool respuesta;
            _parametroId = null;
            Inventario consultaAntesActualizar = capaLogica.ConsultarInventarioId(idInventario);
            Inventario _inventario = new Inventario();
            _inventario.Precio = valorNuevo;
            _inventario.Tipo = consultaAntesActualizar.Tipo;
            respuesta = capaLogica.ActualizarInventario(_inventario, _parametroId);
            Inventario consultaDespuesActualizar = capaLogica.ConsultarInventarioId(idInventarioDiferente);
            Assert.IsTrue(respuesta);
            Assert.AreEqual(consultaAntesActualizar.Tipo, consultaDespuesActualizar.Tipo);
            Assert.AreEqual(valorNuevo, consultaDespuesActualizar.Precio);
        }

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaLogicaActualizarInventarioTodosMismoTipoException()
        {
            bool respuesta;
            _parametroId = null;
            Inventario consultaAntesActualizar = capaLogica.ConsultarInventarioId(idInventario);
            Inventario _inventario = new Inventario();
            _inventario.Precio = valorNuevo;
            _inventario.Tipo = null;
            respuesta = capaLogica.ActualizarInventario(_inventario, _parametroId);
        }
        #endregion

        #region EliminatInventario
        [Test]
        public void PruebaLogicaEliminarInventario()
        {
            bool respuesta;
            _parametroId = idInventario;
            Inventario consultaAntesEliminar = capaLogica.ConsultarInventarioId(idInventario);
            respuesta = capaLogica.EliminatInventario(idInventario);
            Inventario consultaDespuesEliminar = capaLogica.ConsultarInventarioId(idInventario);
            Assert.IsTrue(respuesta);
            Assert.AreEqual(consultaAntesEliminar.Tipo, consultaDespuesEliminar.Tipo);
            Assert.AreEqual("Bloqueado", consultaDespuesEliminar.Estado);
        }
        #endregion


        [TearDown]
        public void Final()
        {
            capaLogica = null;
            tipoInv = string.Empty;
            precioInv = string.Empty;
            cantidadInv = string.Empty;
            idInventario = 0;
            valorNuevo = 0;
            idInventarioDiferente = 0;    
        }
    }
}
