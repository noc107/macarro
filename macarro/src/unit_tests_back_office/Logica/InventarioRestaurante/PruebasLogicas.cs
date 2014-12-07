﻿using System;
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
        int _id2;
        string _nombre2;
        string _descripcion2;
        int _cantidad2;
        int _cantidadMinima2;
        string _proveedor2;
        float _precioCompra2;
        float _precioVenta2;
        int _consultaEspecifica;
        
        [SetUp]
        public void init()
        {
            _consultaEspecifica = 1;
            _id1 = 16;
            _nombre1 = "Item";
            _descripcion1 = "Descripcion";
            _cantidad1 = 10;
            _cantidadMinima1 = 5;
            _proveedor1 = "Empresas Polar C.A";
            _precioCompra1 = float.Parse("10.5");
            _precioVenta1 = float.Parse("15.5");
            _id2 = 2;
            _nombre2 = "Item2";
            _descripcion2 = "Descripcion2";
            _cantidad2 = 102;
            _cantidadMinima2 = 52;
            _proveedor2 = "Empresas Polar C.A";
            _precioCompra2 = float.Parse("102.5");
            _precioVenta2 = float.Parse("152.5");
            _procedimiento = new ProcedimientosItem();
        }

        [Test]
        public void pruebaAgregarItem()
        {
            Assert.IsTrue(_procedimiento.guardarItem(_nombre1, _cantidad1, _precioCompra1, _precioVenta1, _descripcion1, _proveedor1, _cantidadMinima1));
            Assert.IsTrue(_procedimiento.guardarItem(_nombre2, _cantidad2, _precioCompra2, _precioVenta2, _descripcion2, _proveedor2, _cantidadMinima2));
          
        }

        [Test]
        public void pruebaEliminarItem()
        {   
            Assert.IsTrue(_procedimiento.eliminarItem(_id1));
        }
    
        [Test]
        public void pruebaModificarItem() 
        {
            Assert.IsTrue(_procedimiento.modificarItem(_id2,_nombre2,_cantidad2,_descripcion2,_proveedor2,_precioVenta2,_precioCompra2));
        }

        [Test]
        public void pruebaVerItem() 
        {
            string[] _resultados = _procedimiento.verItem(_consultaEspecifica);
            string _nombreVer = _resultados[0];
            string _precioCompraVer = _resultados[1];
            string _precioVentaVer = _resultados[5];
            string _proveedorVer = _resultados[2];
            string _cantidadVer = _resultados[3];
            string _descripcionVer = _resultados[4];
            Assert.AreSame(_nombreVer,"Lechuga");
            Assert.AreSame(_precioCompraVer,"80");
            Assert.AreSame(_precioVentaVer,"135");
            Assert.AreSame(_proveedorVer,"Distribuidora La LLanisa C.A");
            Assert.AreSame(_cantidadVer,"100");
            Assert.AreSame(_descripcionVer,"Granos y frijoles");

        }
   }
}