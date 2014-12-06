using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using back_office.Datos.InventarioRestaurante;
using System.Data.SqlClient;
using System.Collections;

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
        /// <summary>
        /// Funcion que devuelve los datos del item
        /// </summary>
        /// <param name="_codigo">Integer con el codigo del item para buscar</param>
        /// <returns>Cadena de string con los datos del item</returns>
        public string [] verItem(int _codigo)
        {
            ItemBD _operacionVer = new ItemBD();
            string _nombre = _operacionVer.VerItemNombreBD(_codigo);
            string [] _datos = _operacionVer.VerItemInventarioBD(_codigo);
            ArrayList _actualizar = _operacionVer.VerItemCantidadBD(_codigo);
            string _preciocompra = _operacionVer.VerProveedorInventarioBD(_codigo);
            string _nombreProveedor = _operacionVer.VerProveedorBD(_codigo);
            string[] _respuesta = new string[_actualizar.Count+6];

            string[] _paraVer = new string[_actualizar.Count];
            int _contar = 6;

             _respuesta[0] = _nombre; //Nombre del item
             _respuesta[1] = _preciocompra; //Precio Compra
             _respuesta[2] = _nombreProveedor; //Nombre proveedor
             _respuesta[3] = _datos[0]; //Cantidad
             _respuesta[4] = _datos[1]; //Descripcion
             _respuesta[5] = _datos[2]; //Precio venta

             for (int _contador = 0; _contador < _actualizar.Count; _contador++)
             {
                 _respuesta[_contar] = (string)_actualizar[_contador];
                 _contar++;
             }
            return _respuesta;

        }
        /// <summary>
        /// Funcion que devuelve los proveedores
        /// </summary>
        /// <returns>Cadena de string con la razon social de los proveedores</returns>
        public string[] verProveedor()
        {
            ItemBD _operacionProveedor = new ItemBD();
            ArrayList _respuesta = _operacionProveedor.VerRazonesSocialesBD();
            string[] _datos = new string[_respuesta.Count];

            for (int _contador = 0; _contador < _respuesta.Count; _contador++)
            {
                _datos[_contador] = (string)_respuesta[_contador];
            }

            return _datos;
        }
        /// <summary>
        /// Funcion que modifica los datos de un item en la base de datos
        /// </summary>
        /// <param name="_id">Integer con el Codigo del item</param>
        /// <param name="_nombre">String con el nombre del item</param>
        /// <param name="_cantidad">Integer con la cantidad del item</param>
        /// <param name="_descripcion">String con la descripcion del item</param>
        /// <param name="_proveedor">string con la razon social del proveedor</param>
        /// <param name="_precioVenta">Float con el precio de venta</param>
        /// <param name="_precioCompra">Float con el precio de compra</param>
        /// <returns></returns>
        public bool modificarItem(int _id, string _nombre, int _cantidad, string _descripcion, string _proveedor, float _precioVenta,float _precioCompra)
        {
            ItemBD _itemDatos = new ItemBD();
            Proveedor _proveedorItem = new Proveedor();
            _proveedorItem.RazonSocial = _proveedor;
            Item _itemModificar = new Item(_id,_descripcion,_cantidad,_nombre,_precioCompra,_precioVenta,System.DateTime.Now,10,_proveedorItem);
            if (_itemDatos.ModificarItem(_itemModificar))
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