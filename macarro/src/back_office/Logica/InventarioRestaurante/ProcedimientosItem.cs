using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using back_office.Datos.InventarioRestaurante;

namespace back_office.Logica.InventarioRestaurante
{
    public class ProcedimientosItem
    {

        public bool guardarItem(string nombre,int cantidad, float precioCompra, float precioVenta, string descripcion,string proveedor,int cantidadMinima) 
        {   
            ItemBD  _operacionGuardar = new ItemBD();
            Proveedor _proveedorItem = new Proveedor();
            _proveedorItem.RazonSocial = proveedor;
            Item _nuevoItem = new Item(1, descripcion, cantidad, nombre, precioCompra, precioVenta, System.DateTime.Now,cantidadMinima,_proveedorItem);

            if (_operacionGuardar.guardarItemBD(_nuevoItem))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}