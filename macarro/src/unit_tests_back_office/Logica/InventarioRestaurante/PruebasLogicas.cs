using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Logica.InventarioRestaurante;

namespace unit_tests_back_office.Logica.InventarioRestaurante
{   [TestFixture]
    class PruebasLogicas
    {
        int _id1;
        string _nombre1;
        string _descripcion1;
        int _cantidad1;
        int _cantidadMinima1;
        string _proveedor1;
        float _precioCompra1;
        float _precioVenta1;
        ProcedimientosItem _procedimiento;
        

        [SetUp]
        public void init()
        {
            _id1 = 1;
            _nombre1 = "Item";
            _descripcion1 = "Descripcion";
            _cantidad1 = 10;
            _cantidadMinima1 = 5;
            _proveedor1 = "Empresas Polar C.A";
            _precioCompra1 = float.Parse("10.5");
            _precioVenta1 = float.Parse("15.5");
            _id1 = 2;
            _nombre1 = "Item2";
            _descripcion1 = "Descripcion2";
            _cantidad1 = 102;
            _cantidadMinima1 = 52;
            _proveedor1 = "Empresas Polar C.A";
            _precioCompra1 = float.Parse("10.5");
            _precioVenta1 = float.Parse("15.5");
            _procedimiento = new ProcedimientosItem();
        }

        [Test]
        public void pruebaAgregarItem()
        {
            Assert.IsTrue(_procedimiento.guardarItem(_nombre1, _cantidad1, _precioCompra1, _precioVenta1, _descripcion1, _proveedor1, _cantidadMinima1));
        }

        [Test]
        public void pruebaEliminarItem()
        {   
            Assert.IsTrue(_procedimiento.eliminarItem(_id1));
        }
    /*
        [Test]
        public void prueba() 
        {
            Assert.IsTrue(_procedimiento.modificarItem());
        }
   */ 
   }
}
