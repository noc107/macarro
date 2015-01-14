using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Logica.Proveedores;
using back_office.Dominio;

namespace unit_tests_back_office.Logica.Proveedores
{
    [TestFixture]
    class PruebaLogicaProveedor
    {
        string _rif;
        string _razonSocial;
        string _correo;
        string _paginaWeb;
        DateTime _fechaContrato;
        string _telefono;
        int _direccion;
        int _item;
        LogicaProveedor _procedimiento;
        Proveedor _proveedor;

        [SetUp]
        public void init()
        {
            _rif = "J-30167643-2";
            _razonSocial = "Sacos y Envases Canarven C.A";
            _correo = "canarvenca@gmail.com";
            _paginaWeb = "www.canarven.com";
            _fechaContrato = DateTime.Parse("12-02-2014");
            _telefono = "021297529750";
            _direccion = 14;
            _item = 5;
            _procedimiento = new LogicaProveedor();
            _proveedor = new Proveedor();

        }
        [Test]
        public void PruebaCrearProveedor()
        {
            _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono, _fechaContrato);
            Assert.AreSame(_proveedor.Rif, "J-30167643-2");
            Assert.AreSame(_proveedor.RazonSocial, "Sacos y Envases Canarven C.A");
            Assert.AreSame(_proveedor.Correo, "canarvenca@gmail.com");
            Assert.AreSame(_proveedor.PaginaWeb, "www.canarven.com");
            Assert.AreSame(_proveedor.Telefono, "021297529750");

        }
        [Test]
        public void PruebaCrearProveedor1()
        {
            _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono);
            Assert.AreSame(_proveedor.Rif,"J-30167643-2");
            Assert.AreSame(_proveedor.RazonSocial,"Sacos y Envases Canarven C.A");
            Assert.AreSame(_proveedor.Correo,"canarvenca@gmail.com");
            Assert.AreSame(_proveedor.PaginaWeb,"www.canarven.com");
            Assert.AreSame(_proveedor.Telefono,"021297529750");
            
        }
        [Test]
        public void PruebaCrearProveedor2()
        {
            _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono, _fechaContrato, _direccion);
            Assert.AreSame(_proveedor.Rif, "J-30167643-2");
            Assert.AreSame(_proveedor.RazonSocial, "Sacos y Envases Canarven C.A");
            Assert.AreSame(_proveedor.Correo, "canarvenca@gmail.com");
            Assert.AreSame(_proveedor.PaginaWeb, "www.canarven.com");
            Assert.AreSame(_proveedor.Telefono, "021297529750");
            Assert.AreEqual(_proveedor.Lugar, 14);
        }

        [Test]
        public void PruebaAgregarItemLista()
        {

           _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono, _fechaContrato);
           _procedimiento.AgregarItemLista(_proveedor, 5);
           var actual = new List<int>();
           actual.Add(5);
           Assert.AreEqual(_proveedor.Items,actual);

        }
        [Test]
        public void PruebaEliminarLista()
        {
            _proveedor = _procedimiento.CrearProveedor(_rif, _razonSocial, _correo, _paginaWeb, _telefono, _fechaContrato);
            _procedimiento.EliminarItemLista(_proveedor,_item);
            Assert.AreNotEqual(_proveedor.Items,5);
        }
    }
}
