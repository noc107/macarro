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
        /// <summary>
        /// Funcion para guardar los datos del item de la interfaz en la bd
        /// </summary>
        /// <param name="nombre">String con el nombre del item</param>
        /// <param name="cantidad">Integer con la cantidad del item a agregar</param>
        /// <param name="precioCompra">Float con el precio de Compra del item</param>
        /// <param name="precioVenta">Float con el precio de Venta del item</param>
        /// <param name="descripcion">String con la descripcion del item</param>
        /// <param name="proveedor">String con la razon social del proveedor</param>
        /// <param name="cantidadMinima">Integer con la cantidad minima del item en el inventario</param>
        /// <returns>Boolean que senala si la operacion ha sido exitosa</returns>
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

        public bool eliminarItem(int id)
        {
            ItemBD _operacionEliminar = new ItemBD();
            Proveedor _proveedorItem = new Proveedor();

            if (_operacionEliminar.eliminarItemBD(id))
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