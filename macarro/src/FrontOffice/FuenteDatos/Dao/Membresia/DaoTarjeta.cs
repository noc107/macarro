using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.FuenteDatos.IDao.Membresia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.Dao.Membresia
{
    public class DaoTarjeta : Dao, IDaoTarjeta
    {

        public List<Entidad> ConsultarTarjetaXIdUsuario(int Id)
        {
            List<Entidad> Resultado;
            Resultado = FabricaEntidad.ObtenerListaEntidad();

            try
            {
                
                SqlCommand comando = new SqlCommand("Procedure_membresiaTarjetaxIdUsuario", IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@_usuId", Id));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Tarjeta Tarjetax;

                    Tarjetax = FabricaEntidad.ObtenerTarjetaMembresia(lector.GetInt32(0), lector.GetString(1), lector.GetInt32(2).ToString() + "/" + lector.GetInt32(3).ToString(),lector.GetInt32(4));
                    
                    Resultado.Add(Tarjetax);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            finally
            {
                CerrarConexion();
            }

            return Resultado;
        }


        public Boolean Agregar(Entidad parametro)
        {
            return true;
        }

        public Boolean Modificar(Entidad parametro)
        {
            return true;
        }

        public Entidad ConsultarXId(int _id)
        {
            return null;
        }
        public List<Entidad> ConsultarTodos()
        {
            return null;
        }

        
    }
}