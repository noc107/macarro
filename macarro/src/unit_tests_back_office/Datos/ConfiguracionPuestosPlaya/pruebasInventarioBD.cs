using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Datos.ConfiguracionPuestosPlaya;
using back_office.Dominio;
using back_office.Excepciones.ConfiguracionPuestosPlaya;

namespace unit_tests_back_office.Datos.ConfiguracionPuestosPlaya
{
    

    [TestFixture]
    public class pruebasInventarioBD
    {
        private int idInventario;
        private string tipoInventario;
        private InventarioBD capaDatos;
        private object _parametroId;
        private float valorNuevo;
        private int idInventarioDiferente;
        private string precioAgregar;
        private string cantidadAgregar;
      
        [SetUp]
        public void inicio()
        {
            capaDatos = new InventarioBD();
            idInventario= 88;
            tipoInventario = "MESA";
            valorNuevo = 5000;
            idInventarioDiferente = 85;            
            precioAgregar = "100";
            cantidadAgregar = "10";
        }

        #region PRUEBA CONSULTAR INVENTARIO
        [Test]
        public void PruebaDatosConsultarInventario()
        {
            Assert.True((capaDatos.ConsultarInventario(tipoInventario)).Count > 0);
        }

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaDatosConsultarInventarioException()
        {
            List<Inventario> consulta = capaDatos.ConsultarInventario(null);
        }
        #endregion

        #region PRUEBA CONSULTAR INVENTARIO POR ID
        [Test]
        public void PruebaDatosConsultarInventarioId()
        {
            Inventario consulta = capaDatos.ConsultarInventarioId(idInventario);
            Assert.AreEqual(idInventario, consulta.Id);
            Assert.AreEqual(tipoInventario, consulta.Tipo);
            Assert.AreEqual(tipoInventario + "-" + idInventario, consulta.Codigo);           
        }
        #endregion

        #region PRUEBA AGREGAR NUEVO INVENTARIO
        [Test]
        public void PruebaDatosIngresarNuevoInventario()
        {
            bool respuesta;
            List<Inventario> listainventarioAntes = capaDatos.ConsultarInventario(tipoInventario);
            respuesta = capaDatos.IngresarNuevoInventario(tipoInventario, precioAgregar, cantidadAgregar);
            List<Inventario> listainventarioDespues = capaDatos.ConsultarInventario(tipoInventario);           
            Assert.IsTrue(respuesta);
            Assert.IsTrue(listainventarioAntes.Count < listainventarioDespues.Count);
            Assert.AreEqual(listainventarioAntes.Count + int.Parse(cantidadAgregar),listainventarioDespues.Count);
        }

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaDatosIngresarNuevoInventarioException()
        {
            bool respuesta;
            List<Inventario> listainventarioAntes = capaDatos.ConsultarInventario(tipoInventario);
            respuesta = capaDatos.IngresarNuevoInventario(null, null, null);
            List<Inventario> listainventarioDespues = capaDatos.ConsultarInventario(tipoInventario);           
        }
        #endregion

        #region PRUEBA ACTUALIZAR INVENTARIO PRECIO DEL MISMO TIPO
        [Test]
        public void PruebaDatosaActualizarInventarioTodosMismoTipo()
        {            
            bool respuesta;
            _parametroId = null;
            Inventario consultaAntesActualizar = capaDatos.ConsultarInventarioId(idInventario);
            Inventario _inventario = new Inventario();
            _inventario.Precio = valorNuevo;
            _inventario.Tipo = consultaAntesActualizar.Tipo;            
            respuesta = capaDatos.ActualizarInventario(_inventario, _parametroId);
            Inventario consultaDespuesActualizar = capaDatos.ConsultarInventarioId(idInventarioDiferente);
            Assert.IsTrue(respuesta);
            Assert.AreEqual(consultaAntesActualizar.Tipo, consultaDespuesActualizar.Tipo);
            Assert.AreEqual(valorNuevo, consultaDespuesActualizar.Precio);    
        }      

        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaDatosActualizarInventarioTodosMismoTipoException()
        {
            bool respuesta;
            _parametroId = null;
            Inventario consultaAntesActualizar = capaDatos.ConsultarInventarioId(idInventario);
            Inventario _inventario = new Inventario();
            _inventario.Precio = valorNuevo;
            _inventario.Tipo = null;
            respuesta = capaDatos.ActualizarInventario(_inventario, _parametroId);
        }
        #endregion

        #region PRUEBA ELIMINAR INVENTARIO
        [Test]
        public void PruebaDatosEliminarInventario()
        {
            bool respuesta;
            _parametroId = idInventario;
            Inventario consultaAntesEliminar = capaDatos.ConsultarInventarioId(idInventario);
            respuesta = capaDatos.EliminarInventario(idInventario);
            Inventario consultaDespuesEliminar = capaDatos.ConsultarInventarioId(idInventario);
            Assert.IsTrue(respuesta);
            Assert.AreEqual(consultaAntesEliminar.Tipo, consultaDespuesEliminar.Tipo);
            Assert.AreEqual("Bloqueado", consultaDespuesEliminar.Estado);
        }
        #endregion

        [TearDown]
        public void Final()
        {
            idInventario = 0;
            tipoInventario = string.Empty;
            capaDatos = null;
            valorNuevo = 0;
            idInventarioDiferente = 0;
            precioAgregar = string.Empty;
            cantidadAgregar = string.Empty;
        }

       
    }
}
