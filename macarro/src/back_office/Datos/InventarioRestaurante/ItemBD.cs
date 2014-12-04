using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using System.Data.SqlClient;
using System.Data;

namespace back_office.Datos.InventarioRestaurante
{
    public class ItemBD
    {
        OperacionesBD _baseDatos = new OperacionesBD();
        

        public bool guardarItemBD(Item _item)
        {
            SqlCommand _comando = new SqlCommand("Procedure_guardarItem",_baseDatos._cn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add("@_guardarItemNombre", SqlDbType.VarChar).Value = _item.Nombre;
            _comando.Parameters.Add("@_guardarItemCantidad",SqlDbType.Int).Value = _item.Cantidad;
            _comando.Parameters.Add("@_guardarItemCantidadMinima", SqlDbType.Int).Value = _item.CantidadMinima;
            _comando.Parameters.Add("@_guardarItemDescripcion", SqlDbType.VarChar).Value = _item.Descripcion;
            _comando.Parameters.Add("@_guardarItemProveedor", SqlDbType.VarChar).Value = _item.Proveedor.RazonSocial;
            _comando.Parameters.Add("@_guardarItemPrecioCompra", SqlDbType.Float).Value = _item.PrecioCompra;
            _comando.Parameters.Add("@_guardarItemPrecioVenta", SqlDbType.VarChar).Value = _item.PrecioVenta;
            _comando.Parameters.Add("@_guardarItemFechaCompra", SqlDbType.DateTime).Value = _item.FechaCompra;
            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
              //Excepcion
            }
        }



    }
}