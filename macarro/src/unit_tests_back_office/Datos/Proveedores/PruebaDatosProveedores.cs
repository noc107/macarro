using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Datos.Proveedores;
using back_office.Dominio;
using back_office.Logica.Proveedores;

namespace unit_tests_back_office.Datos.Proveedores
{
    [TestFixture]
    class PruebaDatosProveedores
    {
        ProveedorBD _proveedorBD;
        Proveedor _proveedor1;
        Proveedor _proveedor2;
        Proveedor _proveedor;
        LogicaProveedor _procedimiento;
        ProveedorBD _procedimientoBD;

        Item _item1;
        Item _item2;
        int i;

        string _rif;
        string _razonSocial;
        string _correo;
        string _paginaWeb;
        DateTime _fechaContrato;
        string _telefono;
        int _direccion;

        [SetUp]
        public void init()
        {
            int i = 1;
            _proveedorBD = new ProveedorBD();
            _proveedor1 = new Proveedor();
            _proveedor2 = new Proveedor();
            _procedimiento = new LogicaProveedor();
            _proveedor = new Proveedor();
            _procedimientoBD = new ProveedorBD();
            _item1 = new Item();
            _item2 = new Item();

            _rif = "J-30167643-2";
            _razonSocial = "Sacos y Envases Canarven C.A";
            _correo = "canarvenca@gmail.com";
            _paginaWeb = "www.canarven.com";
            _fechaContrato = DateTime.Parse("12-02-2014");
            _telefono = "021297529750";
            _direccion = 14;

            _proveedor1.Rif = "J-30298252-9";
            _proveedor1.RazonSocial = "Distribuidora La Llanisca C.A";
            _proveedor1.Correo = "lallanisca@gmail.com";
            _proveedor1.PaginaWeb = "www.lallanisca.com";
            _proveedor1.FechaContrato = DateTime.Parse("01/11/2014");
            _proveedor1.Telefono = "02126811075";

            _proveedor2.Rif = "J-30167643-2";
            _proveedor2.RazonSocial = "Sacos y Envases Canarven C.A";
            _proveedor2.Correo = "canarvenca@gmail.com";
            _proveedor2.PaginaWeb = "www.canarven.com";
            _proveedor2.FechaContrato = DateTime.Parse("12-02-2014");
            _proveedor2.Telefono = "021297529750";

        }
        
        [Test]
        public void pruebaConsultarItemProveedor()
        {
            _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono, _fechaContrato);
            _procedimiento.AgregarItemLista(_proveedor, 5);
            _procedimientoBD.consultarItemsBD();
            var actual = new List<int>();
            actual.Add(5);
            Assert.AreEqual(_proveedor.Items, actual);
        }

        [Test]
        public void PruebaConsultarTodosProveedoresBD()
        {
            _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono, _fechaContrato);
            var actual = new List<String>();
            actual.Add("J-30167643-2");
            _procedimientoBD.consultarTodosProveedoresBD();
            Assert.AreSame(_proveedor.Rif,"J-30167643-2");
        }
 
    }
}
