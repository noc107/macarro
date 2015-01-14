using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.Dao.ConfiguracionEstacionamientos
{
    public class DaoEstacionamiento : Dao, IDaoEstacionamiento
    {
        private Entidad _estacionamiento = FabricaEntidad.ObtenerEstacionamiento();

        public Dominio.Entidad ConsultarXId(int id)
        {
            SqlCommand comando = new SqlCommand(Recurso.RecursoDaoConfiguracionEstacionamiento.ProcedimientoConsultarEstacionamiento, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroIdEstacionamiento, id));

            SqlDataReader _lectura;
         

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                
                while (_lectura.Read())
                {
                    _estacionamiento = ObtenerBDReader(_lectura);
                    if (_estacionamiento != null)
                    {
                        return _estacionamiento;
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

        private Entidad ObtenerBDReader(SqlDataReader objetoBD)
        {
         
         Entidad estacionamiento = FabricaEntidad.ObtenerEstacionamiento(objetoBD.GetInt32(0), objetoBD.GetString(1).ToString(), objetoBD.GetInt32(2), (float)(objetoBD.GetDouble(3)), (float)objetoBD.GetDouble(4), objetoBD.GetInt32(5), objetoBD.GetInt32(6),objetoBD.GetString(7));

               
            return estacionamiento;
        }

        public Dominio.Entidad Agregar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad Modificar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

    }
   
}