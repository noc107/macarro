using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Dao.InventarioRestaurante.Recursos;
using BackOffice.FuenteDatos.IDao.InventarioRestaurante;
using BackOffice.FuenteDatos.Dao;
using BackOffice.FuenteDatos.Dao.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.InventarioRestaurante
{
    public class Dao_06_inventarioRestaurante : Dao, IDao_06_inventarioRestaurante
    {

        public bool Agregar(Entidad item)
        {
            bool _exito;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand(RecursosIntem.ProcedimientoAgregar, _cn);
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroNombre, ((Item)item).Nombre));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroCantidad, ((Item)item).Cantidad));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroCantidadMinima, ((Item)item).CantidadMinima));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroDescripcion, ((Item)item).Descripcion));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroProveedor, ((Item)item).Proveedor.RazonSocial));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroPrecioCompra, ((Item)item).PrecioCompra));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroPrecioVenta, ((Item)item).PrecioVenta));
                _comando.Parameters.Add(new SqlParameter(RecursosIntem.parametroFechaCompra, ((Item)item).FechaCompra));
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();
                _exito = true;
            }
            catch (Exception ex)
            {
                _exito = false;
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
            return _exito;
        }

        public DataTable VerRazonesSocialesBD()
        {
            DataTable _dt;
            SqlCommand _cmd;
            SqlDataAdapter _da;

            _dt = new DataTable();
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                _cmd = new SqlCommand(RecursosIntem.ProcedimientoVerRazonesSociales, _cn);
                _da = new SqlDataAdapter(_cmd);

                
                _da.Fill(_dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return _dt;
        }

        public Dominio.Entidad ConsultarXId(int id)
        {

            throw new NotImplementedException();
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        bool IDao.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }


    }
}