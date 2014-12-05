using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using back_office.Datos.InventarioRestaurante;
using System.Data.SqlClient;

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
        /// <returns>Boolean que indica si la operacion ha sido exitosa</returns>
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
        /// <summary>
        /// Funcion para eliminar el item de la bd
        /// </summary>
        /// <param name="id">Integer con el codigo del item</param>
        /// <returns>Boolean que indica si la operacion fue exitosa</returns>
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

        public string [] verItem(int _codigo)
        {
            ItemBD _operacionVer = new ItemBD();
            string []_respuesta = new string[1000];
            string _nombre = _operacionVer.VerItemNombreBD(_codigo);
            string [] _datos = _operacionVer.VerItemInventarioBD(_codigo);
            string [] _actualizar = _operacionVer.VerItemCantidadBD(_codigo);
            string _preciocompra = _operacionVer.VerProveedorInventarioBD(_codigo);
            string _nombreProveedor = _operacionVer.VerProveedorBD(_codigo);
            int contador = 0;
            int contador2= 6;

             _respuesta[0] = _nombre; //Nombre del item
             _respuesta[1] = _preciocompra; //Precio Compra
             _respuesta[2] = _nombreProveedor; //Nombre proveedor
             _respuesta[3] = _datos[0]; //Cantidad
             _respuesta[4] = _datos[1]; //Descripcion
             _respuesta[5] = _datos[2]; //Precio venta
    
             //while (_reader3.Read())
             //{
          
             _respuesta[6] = _actualizar[0]; //Cantidad actualizacion
             _respuesta[7] = _actualizar[1]; //Fecha actualizacion
             //}
            return _respuesta;

        }


    }
}