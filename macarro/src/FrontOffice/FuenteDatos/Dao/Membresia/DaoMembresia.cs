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
    public class DaoMembresia : Dao, IDaoMembresia
    {

        public Entidad ConsultarMembresiaXIdUsuario(int Id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("Procedure_consultarMembresiasXIdUsuario", IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@_id", Id));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    return this.asignarMembresia(lector,Id);
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

            return null;
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

        private Entidad asignarMembresia(SqlDataReader _objeto,int Id)
        {
            Entidad w;
            Persona x;

            x =(Persona) FabricaEntidad.ObtenerPersona();
            x.Id=Id;
            x.nombre=_objeto.GetString(0);
            x.apellido=_objeto.GetString(1);
            x.Cedula=_objeto.GetString(6);
            x.TipoDocumento = _objeto.GetString(5);
            w= FabricaEntidad.ObtenerMembresia((Persona)x,_objeto.GetInt32(8),_objeto.GetDateTime(2),_objeto.GetDateTime(3),_objeto.GetString(4),123,0,_objeto.GetString(7),true);

            return w;
        }
    }
}