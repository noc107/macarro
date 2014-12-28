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
    public class pruebasPuestoBd
    {
        
        private string filaR;
        private string columnaR;
        private string filaI;
       
        
        private string estado;
        private string descripcion;
        private PuestoBd capaDatos;
      
        private string precioAgregar;
        private string cantidadAgregar;
        private string estadoNuevo;
        private string descripcionNueva;
        private string precioNuevo;
      
        [SetUp]
        public void inicio()
        {
            capaDatos = new PuestoBd();
            filaR = "1";
            columnaR = "1";
            filaI = "3";
           
            estado = "0";
            
            descripcion = "Vista a la playa primera fila";
            precioAgregar = "150";
            cantidadAgregar = "1";
            estadoNuevo = "Desactivado";
            descripcionNueva = "Vista a la picsina";
            precioNuevo = "125";
        }

        #region PRUEBA CONSULTAR Puesto
        //prubea de consultar
        [Test]
        public void PruebaConsultarPuesto()
        {
            Assert.True((capaDatos.ConsultarPuesto(filaR,"")).Count > 0);
        }

        #endregion

       

        #region PRUEBA AGREGAR NUEVO INVENTARIO
        //prueba de agregar
        [Test]
        public void PruebaIngresarNuevoPuesto()
        {
            bool respuesta;
            respuesta = capaDatos.IngresarNuevosPuestos(estado,filaI,columnaR,descripcion,precioAgregar);
            Assert.IsTrue(respuesta);
      }

        //prueba de excepcion
        [Test]
        [ExpectedException(typeof(ExceptionDatos))]
        public void PruebaIngresarNuevoPuestoException()
        {
            bool respuesta;
            List<Puesto> listaPuesto = capaDatos.ConsultarPuesto(filaR, "");
            respuesta = capaDatos.IngresarNuevosPuestos(null, null, null, null, null);
            List<Puesto> listaPuestoDespues = capaDatos.ConsultarPuesto(filaR, "");        
        }
        #endregion

        #region PRUEBA ACTUALIZAR PUESTO
        [Test]
        public void PruebaActualizarPuesto()
        {            
          
            bool flag = capaDatos.ActualizacionPuesto(filaR,columnaR,descripcionNueva,precioNuevo,estadoNuevo);
            Assert.IsTrue(flag);
            
        }      

        #endregion

        [TearDown]
        public void Final()
        {
            filaR = string.Empty;
            columnaR = string.Empty;
            capaDatos = null;
            descripcionNueva = string.Empty;
            precioNuevo = string.Empty;
            precioAgregar = string.Empty;
            cantidadAgregar = string.Empty;
            estadoNuevo = string.Empty;
        }

       
    }
}
