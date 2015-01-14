using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Datos.InventarioRestaurante;
using back_office.Excepciones.InventarioRestaurante;
using back_office.Dominio;
using System.Collections;

namespace unit_tests_back_office.Datos.InventarioRestaurante
{
    class PruebasDatos
    {
        ItemBD _itemBd;
        Proveedor _proveedor1;
        Proveedor _proveedor2;
        int _consultaEspecifica;
        Item _item1;
        Item _item2;

        [SetUp]
        public void init()
        {
            _consultaEspecifica = 1;

            _itemBd = new ItemBD();
            _proveedor1 = new Proveedor();
            _proveedor2 = new Proveedor();
            _item1 = new Item();
            _item2 = new Item();

            _proveedor1.RazonSocial = "Empresas Polar C.A";
            _item1.Cantidad = 10;
            _item1.CantidadMinima = 5;
            _item1.Codigo = 16;
            _item1.Descripcion = "Descripcion1";
            _item1.Nombre = "Item 1";
            _item1.PrecioCompra = float.Parse("10.5");
            _item1.PrecioVenta = float.Parse("15.5");
            _item1.Proveedor = _proveedor1;
            _item1.FechaCompra = DateTime.Now;

            _proveedor2.RazonSocial = "Empresas Polar C.A";
            _item2.Cantidad = 102;
            _item2.CantidadMinima = 52;
            _item2.Codigo = 2;
            _item2.Descripcion = "Descripcion2";
            _item2.Nombre = "Item 2";
            _item2.PrecioCompra = float.Parse("102.5");
            _item2.PrecioVenta = float.Parse("152.5");
            _item2.Proveedor = _proveedor2;
            _item2.FechaCompra = DateTime.Now;

        }

        [Test]
        public void pruebaGuardarItemBD()
        {
            Assert.IsTrue(_itemBd.guardarItemBD(_item1));
            Assert.IsTrue(_itemBd.guardarItemBD(_item2));
        }

        [Test]
        public void pruebaEliminarItemBD()
        {
            Assert.IsTrue(_itemBd.eliminarItemBD(_item1.Codigo));
        }

        [Test]
        public void pruebaVerItemNombreBD()
        {
            string _resultados = _itemBd.VerItemNombreBD(_consultaEspecifica);
            Assert.AreEqual("Lechuga",_resultados);
        }

        [Test]
        public void pruebaVerItemCantidadBD()
        {
            string _cantidad = "100";
            string fecha = "07-02-2014";
            ArrayList _resultados = _itemBd.VerItemCantidadBD(_consultaEspecifica);
            Assert.AreEqual(_resultados[0], _cantidad);
            Assert.AreEqual(_resultados[1], fecha);  
        }

        [Test]
        public void pruebaVerItemInventarioBD()
        {
            string[] _resultados = _itemBd.VerItemInventarioBD(_consultaEspecifica);
            string _cantidadResultado = _resultados[0];
            string _precioDescripcionResultado = _resultados[1];
            string _precioVentaResultado = _resultados[2];
            Assert.AreEqual(_precioVentaResultado, "135");
            Assert.AreEqual(_cantidadResultado, "32");
            Assert.AreEqual(_precioDescripcionResultado, "Lechuga");
        }

        [Test]
        public void pruebaVerProveedorInventarioBD()
        {
            string _resultados = _itemBd.VerProveedorInventarioBD(_consultaEspecifica);
            string _precioComprarResultado = _resultados;
            Assert.AreEqual(_precioComprarResultado, "99");
        }

        [Test]
        public void pruebaVerProveedorBD()
        {
            string _resultados = _itemBd.VerProveedorBD(_consultaEspecifica);
            string _proveedorResultado = _resultados;
            Assert.AreEqual(_proveedorResultado, "Distribuidora La Llanisca C.A");
        }

        [Test]
        public void pruebaVerRazonesSocialesBD()
        {

            ArrayList _resultados = _itemBd.VerRazonesSocialesBD();
    //        string[] _razonSocialResultado = new string[_resultados.Count];
            string _proveedor1 = (string)_resultados[0];
            string _proveedor2 = (string)_resultados[1];
            string _proveedor3 = (string)_resultados[2];
            string _proveedor4 = (string)_resultados[3];
            string _proveedor5 = (string)_resultados[4];
            Assert.AreEqual(_proveedor1, "Sacos y Envases Canarven C.A");
            Assert.AreEqual(_proveedor2, "Distribuidora La Llanisca C.A");
            Assert.AreEqual(_proveedor3, "Empresas Polar C.A");
            Assert.AreEqual(_proveedor4, "Cordeles y Mecates El Asturcon C.A");
            Assert.AreEqual(_proveedor5, "Pepsico de Venezuela C.A");


        }
        
        [TearDown]
        public void clear()
        {
            _itemBd = null;
            _proveedor1 = null;
            _proveedor2 = null;
            _consultaEspecifica = 0;
            _item1 = null;
            _item2 = null;
        }

    }
}
