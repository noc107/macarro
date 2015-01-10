using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
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
       
        public Boolean Agregar(Dominio.Entidad parametros)
        {
            Boolean respuesta = false;
           
            Ticket _ticket = parametros as Ticket;

            try
            {
                
                SqlCommand _comando = new SqlCommand("[dbo].Procedure_InsertarTicketNuevo", IniciarConexion());
                _comando.Parameters.Add(new SqlParameter("@_TIC_placa", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_FK_estacionamiento",SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter("@_FK_estado", SqlDbType.Int));
                _comando.Parameters["@_TIC_placa"].Value = _ticket.Placa;
                _comando.Parameters["@_FK_estacionamiento"].Value = _ticket.FkEstacionamiento;
               _comando.Parameters["@_FK_estado"].Value = _ticket.FkEstado;
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
        


        
    }
}