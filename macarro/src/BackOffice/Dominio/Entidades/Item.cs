using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
 public class Item : Entidad
    {
        private int _codigo;
        private string _descripcion;
        private int _cantidad;
        private string _nombre;
        private float _precioCompra;
        private float _precioVenta;
        private DateTime _fechaCompra;
        private int _cantidadMinima;
   //     private Proveedor _proveedor;

        public Item()
        {
            _codigo = 0;
            _descripcion = null;
            _cantidad = 0;
            _nombre = null;
            _precioCompra = 0;
            _precioVenta = 0;
            _fechaCompra = System.DateTime.Now;
            _cantidadMinima = 0;
        //    _proveedor = null;
        }


      
        public Item(int codigo, string descripcion, int cantidad, string nombre, float precioCompra, float precioVenta, DateTime fecha, int cantidadMinima/*, Proveedor proveedor*/)
        {
            _codigo = codigo;
            _descripcion = descripcion;
            _cantidad = cantidad;
            _nombre = nombre;
            _precioCompra = precioCompra;
            _precioVenta = precioVenta;
            _fechaCompra = fecha;
            _cantidadMinima = cantidadMinima;
      //      _proveedor = proveedor;
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public float PrecioCompra
        {
            get { return _precioCompra; }
            set { _precioCompra = value; }
        }

        public float PrecioVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }

        public DateTime FechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }

        public int CantidadMinima 
        {
            get { return _cantidadMinima; }
            set { _cantidadMinima = value; }
        }

    //    public Proveedor Proveedor 
    //    {
    //        get { return _proveedor; }
    //        set { _proveedor = value; }
    //    }
    }
    
}