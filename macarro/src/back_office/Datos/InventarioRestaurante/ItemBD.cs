using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using System.Data.SqlClient;
using System.Data;
using back_office.Excepciones.InventarioRestaurante;
using System.Collections;

namespace back_office.Datos.InventarioRestaurante
{
    public class ItemBD
    {
        OperacionesBD _baseDatos = new OperacionesBD();
        
        /// <summary>
        /// Metodo que abre conexion con la base de datos y guarda los datos
        /// </summary>
        /// <param name="_item">Item que se desea guardar en la base de datos</param>
        /// <returns>Boolean indicando si la operacion fue exitosa</returns>
        public bool guardarItemBD(Item _item)
        {
            bool _exito;
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
                _exito = true;
            }
            catch (Exception ex)
            {
                _exito = false;
                throw new ExcepcionAgregarItem(ex.Message); //ExcepcionCreada
                
            }
            finally 
            {
                _baseDatos._cn.Close();
                
            }
            return _exito;
        }
        /// <summary>
        /// Funcion que abre la conexion a la base de datos y elimina los datos relacionados con el id del item
        /// </summary>
        /// <param name="id">Integer del codigo del item</param>
        /// <returns>Boolean que indica si la operacion fue exitosa</returns>
        public bool eliminarItemBD(int id)
        {
            bool _exito;
            SqlCommand _comando = new SqlCommand("Procedure_eliminarItem", _baseDatos._cn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add("@_itemId", SqlDbType.Int).Value = id;
            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                _exito = true;
            }
            catch (Exception ex)
            {
                _exito = false;
                throw new ExcepcionEliminarItem(ex.Message);
                //Excepcion
            }
            finally 
            {
                _baseDatos._cn.Close();
            }
            return _exito;
        }
        /// <summary>
        /// Funcion que devuelve el nombre del item
        /// </summary>
        /// <param name="_codigo">Integer con el codigo del item a buscar</param>
        /// <returns>String con el nombre del item</returns>
        public string VerItemNombreBD(int _codigo)
        {
            string _nombre = null;
            SqlCommand _comando = Conexiones("Procedure_verItemNombre", _codigo);

            try
            {
                _baseDatos._cn.Open();
                SqlDataReader _reader = _comando.ExecuteReader();
                _reader.Read();
                _nombre = _reader["ITE_nombre"].ToString();
                    
                return _nombre;
            }
            catch (Exception ex)
            {
                throw new ExcepcionVerItem(ex.Message);
                //Excepcion
            }
            finally 
            {
                _baseDatos._cn.Close();
            
            }
        }
        /// <summary>
        /// Funcion que devuelve una lista con las actualizaciones
        /// </summary>
        /// <param name="_codigo">Integer con el codigo</param>
        /// <returns>Arraylist con las actualizaciones</returns>
        public ArrayList VerItemCantidadBD(int _codigo)
        {
            ArrayList _coman = new ArrayList(); 
            SqlCommand _comando = Conexiones("Procedure_verItemCantidad", _codigo);
            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                SqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _coman.Add(_reader["ACT_cantidad"].ToString());
                    _coman.Add(_reader["ACT_fecha"].ToString());
                }
               return _coman;

            }
            catch (Exception ex)
            {
                throw new ExcepcionVerItem(ex.Message);
                //Excepcion
            }
            finally
            {
                _baseDatos._cn.Close();

            }

        }
        /// <summary>
        /// Funcion que devuelve la cantidad, descripcion y precio de venta
        /// </summary>
        /// <param name="_codigo">Integer con el codigo del item a buscar</param>
        /// <returns>Una cadena de strings con la cantidad, descripcion y precio venta</returns>
        public string[] VerItemInventarioBD(int _codigo)
        {
            string [] _iteinv = new string [3];
            SqlCommand _comando = Conexiones("Procedure_verItemInventario", _codigo);

            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                SqlDataReader _reader1 = _comando.ExecuteReader();
                _reader1.Read();
               
                    _iteinv[0] = _reader1["ITE_INV_cantidad"].ToString();
                    _iteinv[1] = _reader1["ITE_INV_descripcion"].ToString();
                    _iteinv[2] = _reader1["ITE_INV_precioVenta"].ToString();
               
                return _iteinv;
            }
            catch (Exception ex)
            {
                throw new ExcepcionVerItem(ex.Message);
                //Excepcion
            }

            finally
            {
                _baseDatos._cn.Close();

            }
        }
        /// <summary>
        /// Funcion que devuelve el precio de compra
        /// </summary>
        /// <param name="_codigo">Integer con el codigo del item a buscar</param>
        /// <returns>String con el precio de compra</returns>
        public string VerProveedorInventarioBD(int _codigo)
        {
            string _prove;
            SqlCommand _comando = Conexiones("Procedure_verProveedorInventario", _codigo);

            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                SqlDataReader _reader = _comando.ExecuteReader();
                _reader.Read();
                _prove = _reader["PRO_INV_precioCompra"].ToString();
                return _prove;
            }
            catch (Exception ex)
            {
                throw new ExcepcionVerItem(ex.Message);
                //Excepcion
            }
            finally
            {
                _baseDatos._cn.Close();

            }


        }
        /// <summary>
        /// Funcion que devuelve la razon social del proveedor
        /// </summary>
        /// <param name="_codigo">Integer con el codigo del item a buscar</param>
        /// <returns>String con la razon social del proveedor</returns>
        public string VerProveedorBD(int _codigo)
        {
            string _prove;
            SqlCommand _comando = Conexiones("Procedure_verProveedor", _codigo);
            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                SqlDataReader _reader = _comando.ExecuteReader();
                _reader.Read();
                _prove = _reader["PRO_razonSocial"].ToString();
                return _prove;
            }
            catch (Exception ex)
            {
                throw new ExcepcionVerItem(ex.Message);
                //Excepcion
            }
            finally
            {
                _baseDatos._cn.Close();

            }
        }
        /// <summary>
        /// Funcion que devuelve todos los provedores
        /// </summary>
        /// <returns>ArrayList con las razon social de todos los proveedores</returns>
            public ArrayList VerRazonesSocialesBD()
            {
            ArrayList _prove = new ArrayList(); 
            SqlCommand _comando = ConexionProveedor("Procedure_consultaDeGestionarProveedor");
            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                SqlDataReader _reader = _comando.ExecuteReader();
               
                while (_reader.Read())
                {   
                    _prove.Add(_reader["PRO_razonSocial"].ToString());
                }
                return _prove;
            }
            catch (Exception ex)
            {
                throw new ExcepcionVerItem(ex.Message);
                //Excepcion
            }
            finally
            {
                _baseDatos._cn.Close();
            }


        }

        /// <summary>
        /// Funcion que retorna un comando
        /// </summary>
        /// <param name="_procedimiento">String con el nombre del procedimiento en la base de datos</param>
        /// <param name="_codigo">Integer con el codigo del item a buscar</param>
        /// <returns>Comando de Sql</returns>
        protected SqlCommand Conexiones(string _procedimiento,int _codigo)
        {
            SqlCommand _comando = new SqlCommand(_procedimiento, _baseDatos._cn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add("@_verItemId", SqlDbType.Int).Value = _codigo;

            return _comando;

        }
        /// <summary>
        /// Funcion que retorna un comando
        /// </summary>
        /// <param name="_procedimiento">String con el nombre del procedimiento</param>
        /// <returns>Comando de sql</returns>
        protected SqlCommand ConexionProveedor(string _procedimiento)
        {
            SqlCommand _comando = new SqlCommand(_procedimiento, _baseDatos._cn);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

 

    }
}