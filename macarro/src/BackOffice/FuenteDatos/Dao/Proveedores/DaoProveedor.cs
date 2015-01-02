using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.Proveedores
{
    public class DaoProveedor: Dao, IDaoProveedor
    {
        private Entidad _proveedor = FabricaEntidad.ObtenerProveedor();

        public Dominio.Entidad ConsultarXId(int id)
        {
            //SqlCommand comando = new SqlCommand("Procedure_consultarProveedorGeneral", IniciarConexion());
            SqlCommand comando = new SqlCommand("Procedure_consultarProveedorGeneral", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_proId", id));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _proveedor = ObtenerBDReader(_lectura);
                    if (_proveedor != null)
                    {
                        return _proveedor;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return null;   
        }

        private Proveedor ObtenerBDReader(SqlDataReader objetoBD)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                proveedor.Id = objetoBD.GetInt32(0);
                proveedor.Rif = objetoBD.GetString(1).ToString();
                proveedor.RazonSocial = objetoBD.GetString(2).ToString();
                proveedor.Correo = objetoBD.GetString(3).ToString();
                proveedor.PagWeb = objetoBD.GetString(4).ToString();
                proveedor.FechaContrato = objetoBD.GetDateTime(5).ToString();
                proveedor.Telefono = objetoBD.GetString(6).ToString();
                proveedor.IdLugar = objetoBD.GetInt32(7);
            }
            catch (Exception ex)
            {

            }
            return proveedor;
        }



        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


        bool IDao.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        bool IDao.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
    }
