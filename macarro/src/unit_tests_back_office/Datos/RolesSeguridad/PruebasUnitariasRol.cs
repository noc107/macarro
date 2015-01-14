using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Excepciones.RolesSeguridad;

namespace unit_tests_back_office
{
    [TestFixture]
    class PruebasUnitariasRol
    {
        public back_office.Datos.RolesSeguridad.RolBD test;

        [SetUp]
        public void Init()
        {
            test = new back_office.Datos.RolesSeguridad.RolBD();
        }

        /// <summary>
        /// prueba unitaria del metodo consultarSecuencia
        /// </summary>
        [Test]
        public void consultarSecuencia()
        {
            Int64 secuencia = test.consultarSecuencia();
            Assert.AreEqual(11, secuencia);
        }

        /// <summary>
        /// prueba unitaria del metodo agregarRol
        /// </summary>
        [Test]
        public void agregarRol()
        {
            List<back_office.Dominio.Accion> acciones = new List<back_office.Dominio.Accion>();
            acciones.Add(new back_office.Dominio.Accion(1, "Agregar rol", "Con esta accion podra agregar un nuevo rol con su descripcion"));
            Assert.AreEqual(true, test.agregarRol(new back_office.Dominio.Rol(0, "prueba", "prueba", acciones)));
        }

        /// <summary>
        /// prueba unitaria del metodo consultarRolesGeneral
        /// </summary>
        [Test]
        public void consultarGeneralRol()
        {
            Assert.AreEqual(10, test.ConsultarRolesGeneral().Count);
        }

        /// <summary>
        /// prueba unitaria del metodo consultarRol
        /// </summary>
        [Test]
        public void consultarRol()
        {
            List<back_office.Dominio.Accion> acciones = new List<back_office.Dominio.Accion>();
            acciones = test.ConsultarRol(new back_office.Dominio.Rol(11, "prueba", "prueba", acciones));
            Assert.AreEqual(1, acciones[0].Id);
            Assert.AreEqual("Agregar rol", acciones[0].Nombre);
        }

        /// <summary>
        /// prueba unitaria del metodo modificarRol
        /// </summary>
        [Test]
        public void editarRol()
        {
            List<back_office.Dominio.Accion> acciones = new List<back_office.Dominio.Accion>();
            acciones.Add(new back_office.Dominio.Accion(3, "Modificar rol", "Con esta accion podra modificar un rol"));
            Assert.AreEqual(true, test.modificarRol(new back_office.Dominio.Rol(11, "pT", "pT", acciones)));
        }

        /// <summary>
        /// prueba unitaria del metodo eliminarRol
        /// </summary>
        [Test]
        public void eliminarRol()
        {
            Assert.AreEqual(true, test.eliminarRol(new back_office.Dominio.Rol(10, "pT", "pT", null)));
        }

        /// <summary>
        /// prueba unitaria del metodo listaIdsAccionesUsuario
        /// </summary>
        [Test]
        public void consultarIdsAcciones()
        {
            Assert.AreEqual("167,168,169,170,171", test.listaIdsAccionesUsuario("lapomash@gmail.com"));
        }

        /// <summary>
        /// prueba unitaria del metodo listaUrlAccionesUsuario
        /// </summary>
        [Test]
        public void consultarURLAcciones()
        {
            List<string> lista = new List<string>();
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_agregarVenta.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_gestionarVenta.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_imprimirFactura.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_cerrarCajaDiario.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_cerrarCajaMensual.aspx");
            lista.Add("/Interfaz/web/inicio.aspx");
            Assert.AreEqual(lista, test.listaUrlAccionesUsuario("lapomash@gmail.com"));
        }

        /// <summary>
        /// prueba unitaria del metodo listaAccionesUsuario
        /// </summary>
        [Test]
        public void consultarAcciones()
        {
            List<string> lista = new List<string>();
            lista.Add("Agregar una venta");
            lista.Add("Gestionar venta");
            lista.Add("Imprimir factura");
            lista.Add("Cerrar Caja Diario");
            lista.Add("Cerrar Caja Mensual");
            Assert.AreEqual(lista, test.listaAccionesUsuario("lapomash@gmail.com"));
        }

        /// <summary>
        /// prueba unitaria de la excepcion ExcepcionFKRol
        /// </summary>
        [Test]
        [ExpectedException(typeof(ExcepcionFKRol))]
        public void pruebaExcepcionFKRol()
        {
            test.eliminarRol(test.ConsultarRolesGeneral()[0]);
        }

        [TearDown]
        public void clean()
        {
            test = null;
        }
    }
}
