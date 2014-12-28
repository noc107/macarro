using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using back_office.Excepciones.RolesSeguridad;
using System.Web;

namespace unit_tests_back_office
{
    [TestFixture]
    class PruebasUnitariasControl
    {
        public back_office.Logica.RolesSeguridad.ControlRolAccion test;

        [SetUp]
        public void Init()
        {
            test = new back_office.Logica.RolesSeguridad.ControlRolAccion();
        }

        /// <summary>
        /// prueba unitaria del metodo llenarGridAcciones
        /// </summary>
        [Test]
        public void completarGridAccion()
        {
            DataTable _t = test.llenarGridAcciones();
            Assert.AreEqual(72, _t.Rows.Count);
        }

        /// <summary>
        /// prueba unitaria del metodo llenarGridRoles
        /// </summary>
        [Test]
        public void completarGridRol()
        {
            DataTable _t = test.llenarGridRoles();
            Assert.AreEqual(10, _t.Rows.Count);
        }

        /// <summary>
        /// prueba unitaria del metodo setRolActual
        /// </summary>
        [Test]
        public void setRol()
        {
            back_office.Logica.RolesSeguridad.ControlRolAccion.setRolActual(0);
            Assert.AreEqual("Administrador",back_office.Logica.RolesSeguridad.ControlRolAccion.RolActual.Nombre);
        }

        /// <summary>
        /// prueba unitaria del metodo listaGeneralAcciones
        /// </summary>
        [Test]
        public void listaGeneralAccion()
        {
            List<back_office.Dominio.Accion> acciones = back_office.Logica.RolesSeguridad.ControlRolAccion.listaGeneralAcciones();
            Assert.AreEqual(72, acciones.Count);
        }

        /// <summary>
        /// prueba unitaria del metodo agregarRol
        /// </summary>
        [Test]
        public void agregarRol()
        {
            System.Web.UI.WebControls.ListBox lB = new System.Web.UI.WebControls.ListBox();
            lB.Items.Add("Agregar rol");
            lB.Items.Add("Gestionar rol");
            lB.Items.Add("Consultar rol");
            lB.Items.Add("Modificar rol");
            lB.Items.Add("Eliminar rol");
            lB.Items.Add("Consultar accion");
            back_office.Logica.RolesSeguridad.ControlRolAccion.agregarRol("Prueba", "Esto es una prueba", lB);
            back_office.Datos.RolesSeguridad.RolBD rBD = new back_office.Datos.RolesSeguridad.RolBD();
            List<back_office.Dominio.Rol> lista = rBD.ConsultarRolesGeneral();
            
            Assert.AreEqual("Prueba",lista[lista.Count-1].Nombre);
        }

        /// <summary>
        /// prueba unitaria del metodo modificarRol
        /// </summary>
        [Test]
        public void editarRol()
        {
            System.Web.UI.WebControls.ListBox lB = new System.Web.UI.WebControls.ListBox();
            lB.Items.Add("Agregar rol");
            lB.Items.Add("Gestionar rol");
            lB.Items.Add("Consultar rol");
            lB.Items.Add("Modificar rol");
            lB.Items.Add("Eliminar rol");
            lB.Items.Add("Consultar accion");
            back_office.Datos.RolesSeguridad.RolBD rBD = new back_office.Datos.RolesSeguridad.RolBD();
            List<back_office.Dominio.Rol> lista = rBD.ConsultarRolesGeneral();
            back_office.Logica.RolesSeguridad.ControlRolAccion.setRolActual(lista.Count - 1);
            back_office.Logica.RolesSeguridad.ControlRolAccion.modificarRol("Prueba", "Esto es una prueba exitosa", lB);
            lista = rBD.ConsultarRolesGeneral();
        
            Assert.AreEqual("Esto es una prueba exitosa", lista[lista.Count - 1].Descripcion);
        }

        /// <summary>
        /// prueba unitaria del metodo eliminarRol
        /// </summary>
        [Test]
        public void eliminarRol()
        {
            back_office.Datos.RolesSeguridad.RolBD rBD = new back_office.Datos.RolesSeguridad.RolBD();
            List<back_office.Dominio.Rol> lista = rBD.ConsultarRolesGeneral();
            back_office.Logica.RolesSeguridad.ControlRolAccion.setRolActual(lista.Count - 1);
            back_office.Logica.RolesSeguridad.ControlRolAccion.eliminarRol();
            lista = rBD.ConsultarRolesGeneral();

            Assert.AreNotEqual("Prueba", lista[lista.Count - 1].Nombre);
        }

        /// <summary>
        /// prueba unitaria del metodo verificarRol
        /// </summary>
        [Test]
        public void verificarRolExiste()
        {
            Assert.AreEqual(true, back_office.Logica.RolesSeguridad.ControlRolAccion.verificarRol("Administrador"));
        }

        /// <summary>
        /// prueba unitaria del metodo listaIdMenu
        /// </summary>
        [Test]
        public void consultarIdsMenu()
        {
            Assert.AreEqual("167,168,169,170,171", back_office.Logica.RolesSeguridad.ControlRolAccion.listaIdMenu("lapomash@gmail.com"));
        }

        /// <summary>
        /// prueba unitaria del metodo listaUrlMenu
        /// </summary>
        [Test]
        public void consultarURLMenu()
        {
            List<string> lista = new List<string>();
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_agregarVenta.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_gestionarVenta.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_imprimirFactura.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_cerrarCajaDiario.aspx");
            lista.Add("/Interfaz/web/VentaCierreCaja/web_07_cerrarCajaMensual.aspx");
            lista.Add("/Interfaz/web/inicio.aspx");
            Assert.AreEqual(lista, back_office.Logica.RolesSeguridad.ControlRolAccion.listaUrlMenu("lapomash@gmail.com"));
        }

        /// <summary>
        /// prueba unitaria del metodo listaAcciones
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
            Assert.AreEqual(lista, back_office.Logica.RolesSeguridad.ControlRolAccion.listaAcciones("lapomash@gmail.com"));
        }

        /// <summary>
        /// prueba unitaria de la excepcion ExcepcionListAccionVacia
        /// </summary>
        [Test]
        [ExpectedException (typeof(ExcepcionListAccionVacia))]
        public void pruebaExcepcionListAccionVacia()
        {
            System.Web.UI.WebControls.ListBox lB = new System.Web.UI.WebControls.ListBox();
            lB.Items.Add("Agregar rol");
            lB.Items.Add("Gestionar rol");
            lB.Items.Add("Consultar rol");
            lB.Items.Add("Modificar rol");
            lB.Items.Add("Eliminar rol");
            lB.Items.Add("Consultar accion");
            lB.Items.Add("Configurar la playa");
            lB.Items.Add("Agregar puesto");
            lB.Items.Add("Modificar puesto");
            lB.Items.Add("Eliminar puesto playa");
            lB.Items.Add("Agregar item de playa");
            lB.Items.Add("Consultar item de playa");
            lB.Items.Add("Consultar puesto");
            lB.Items.Add("Modificar inventario playa");
            lB.Items.Add("Eliminar inventario playa");
            lB.Items.Add("Agregar usuario interno");
            lB.Items.Add("Consultar usuario interno");
            lB.Items.Add("Modificar usuario interno");
            lB.Items.Add("Eliminar usuario interno");
            lB.Items.Add("Gestionar usuarios");
            lB.Items.Add("Modificar datos");
            lB.Items.Add("Agregar servicio de playa");
            lB.Items.Add("Gestionar servicio de playa");
            lB.Items.Add("Consultar servicio de playa");
            lB.Items.Add("Modificar servicio de playa");
            lB.Items.Add("Eliminar servicio de playa");
            lB.Items.Add("Agregar proveedor");
            lB.Items.Add("Consultar proveedor");
            lB.Items.Add("Modificar proveedor");
            lB.Items.Add("Eliminar proveedor");
            lB.Items.Add("Gestionar proveedor");
            lB.Items.Add("Confirmar reserva");
            lB.Items.Add("Modificar reserva");
            lB.Items.Add("Eliminar reserva");
            lB.Items.Add("Gestionar reserva");
            lB.Items.Add("Listar reserva cliente");
            lB.Items.Add("Agregar estacionamiento");
            lB.Items.Add("Gestionar estacionamiento");
            lB.Items.Add("Consultar ticket");
            lB.Items.Add("Detalle ticket");
            lB.Items.Add("Consultar estacionamiento");
            lB.Items.Add("Editar estacionamiento");
            lB.Items.Add("Agregar seccion");
            lB.Items.Add("Agregar producto");
            lB.Items.Add("Modificar seccion");
            lB.Items.Add("Eliminar seccion");
            lB.Items.Add("Modificar producto");
            lB.Items.Add("Eliminar producto");
            lB.Items.Add("Gestionar producto");
            lB.Items.Add("Gestionar seccion");
            lB.Items.Add("Agregar item de inventario");
            lB.Items.Add("Gestionar Inventario");
            lB.Items.Add("Consultar un item de inventario");
            lB.Items.Add("Modificar un item de inventario");
            lB.Items.Add("Eliminar un item de inventario");
            lB.Items.Add("Buscar membresia");
            lB.Items.Add("consultar membresia");
            lB.Items.Add("Modificar membresia");
            lB.Items.Add("Gestion Precio Membresia");
            lB.Items.Add("Reporte de ingresos");
            lB.Items.Add("Reporte de productos");
            lB.Items.Add("Reporte de proveedores");
            lB.Items.Add("Reporte de restaurant");
            lB.Items.Add("Reporte de usuarios");
            lB.Items.Add("Reporte de membresia");
            lB.Items.Add("Reporte de Roles");
            lB.Items.Add("Agregar una venta");
            lB.Items.Add("Gestionar venta");
            lB.Items.Add("Imprimir factura");
            lB.Items.Add("Cerrar Caja Diario");
            lB.Items.Add("Cerrar Caja Mensual");
            lB.Items.Add("Eliminar estacionamiento");

            back_office.Logica.RolesSeguridad.ControlRolAccion.agregarRol("Prueba", "Esto es una prueba", lB);
        }

        [TearDown]
        public void clean()
        {
            test = null;
        }
    }
}