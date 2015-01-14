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
    public class DaoTicket : Dao , IDaoTicket
    {
        private Entidad _Ticket = FabricaEntidad.ObtenerTicket();

        public Boolean Agregar(Dominio.Entidad parametros)
        {
            Boolean respuesta = false;
           
            Ticket _ticket = parametros as Ticket;

            try
            {
                
                SqlCommand _comando = new SqlCommand(Recurso.RecursoDaoConfiguracionEstacionamiento.ProcedimientoInsertarTicket, IniciarConexion());
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroPlaca, SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstacionamiento,SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstadoTicket, SqlDbType.Int));
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroPlaca].Value = _ticket.Placa;
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstacionamiento].Value = _ticket.FkEstacionamiento;
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstadoTicket].Value = _ticket.FkEstado;
                _comando.CommandType = CommandType.StoredProcedure;
                IniciarConexion().Open();
                _comando.ExecuteNonQuery();
                
                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;
        }

        public Entidad VerificarXplaca(string placa) 
        {
            SqlCommand comando = new SqlCommand(Recurso.RecursoDaoConfiguracionEstacionamiento.ProcedimientoVerificarPorPlaca, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroPlaca, placa));

            SqlDataReader _lectura;
         

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                
                while (_lectura.Read())
                {
                    _Ticket = ObtenerBDTicket(_lectura);
                    if (_Ticket!= null)
                    {
                        return _Ticket;
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

        public Entidad ObtenerBDTicket(SqlDataReader objetoTicket) 
        {
            
            
            Entidad ticket = FabricaEntidad.ObtenerTicket(objetoTicket.GetInt32(0), (DateTime)objetoTicket.GetDateTime(1), objetoTicket.GetString(2), objetoTicket.GetInt32(3),objetoTicket.GetString(4));
            return ticket;
        }

        public Boolean Modificar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(int _id)
        {
            return null;
        }

        public Boolean ModificarXplaca(Entidad ticket) 
        {
            Boolean respuesta = false;

            Ticket _ticket = ticket as Ticket;

            
                SqlCommand _comando = new SqlCommand(Recurso.RecursoDaoConfiguracionEstacionamiento.ProcedimientoModificarTicketPorPlaca, IniciarConexion());
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroPlaca, SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstadoTicket, SqlDbType.Int));
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroPlaca].Value = _ticket.Placa;
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstadoTicket].Value = _ticket.FkEstado;
                _comando.CommandType = CommandType.StoredProcedure;
                int _lectura;
                try
                {

                IniciarConexion().Open();
               _lectura = _comando.ExecuteNonQuery();
               if (_lectura != 0)
               {
                   respuesta = true;
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
            return respuesta;
        }

        public Boolean ModificarXticket(Entidad ticket) 
        {
        Boolean respuesta = false;

            Ticket _ticket = ticket as Ticket;

            
                SqlCommand _comando = new SqlCommand(Recurso.RecursoDaoConfiguracionEstacionamiento.ProcedimietnoModificarTicket, IniciarConexion());
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroIdTicket, SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter(Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstadoTicket, SqlDbType.Int));
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroIdTicket].Value = _ticket.Placa;
                _comando.Parameters[Recurso.RecursoDaoConfiguracionEstacionamiento.ParametroFkEstadoTicket].Value = _ticket.FkEstado;
                _comando.CommandType = CommandType.StoredProcedure;
                int _lectura;
                try
                {

                IniciarConexion().Open();
               _lectura = _comando.ExecuteNonQuery();
               if (_lectura != 0)
               {
                   respuesta = true;
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
            return respuesta;
        }
        
    }
}