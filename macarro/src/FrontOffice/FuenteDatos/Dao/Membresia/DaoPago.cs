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
    public class DaoPago : Dao, IDaoPago
    {

        public List<Entidad> ConsultarPagoXIdMembresia(int Id)
        {
            List<Entidad> Resultado;
            Resultado = FabricaEntidad.ObtenerListaEntidad();

            try
            {
                
                SqlCommand comando = new SqlCommand("Procedure_membresiaPagosxIdMembresia", IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@_memId", Id));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Tarjeta Tarjetax;
                    Entidad Pago;

                    Tarjetax = FabricaEntidad.ObtenerTarjetaMembresia(lector.GetInt32(0));
                    float num=float.Parse(lector.GetValue(2).ToString());
                    Pago = FabricaEntidad.ObtenerPagoMembresia(Tarjetax, lector.GetDateTime(1), num,lector.GetInt32(3));
                    Resultado.Add(Pago);
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

        public List<Entidad> ConsultarPagoXIdMembresiaYFechaPago(int Id, DateTime fPago)
        {
            List<Entidad> Resultado;
            Resultado = FabricaEntidad.ObtenerListaEntidad();

            try
            {

                SqlCommand comando = new SqlCommand("Procedure_membresiaPagosxIdMembresiaYFecha", IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@_memId", Id));
                comando.Parameters.Add(new SqlParameter("@_fecha", fPago.Year.ToString()+"-"+fPago.Month.ToString()+"-"+fPago.Day.ToString()));
                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Tarjeta Tarjetax;
                    Entidad Pago;

                    Tarjetax = FabricaEntidad.ObtenerTarjetaMembresia(lector.GetInt32(0));
                    float num = float.Parse(lector.GetValue(2).ToString());
                    Pago = FabricaEntidad.ObtenerPagoMembresia(Tarjetax, lector.GetDateTime(1), num, lector.GetInt32(3));
                    Resultado.Add(Pago);
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

        public Entidad ConsultarDetallePago(int Id, int IdPago)
        {

            try
            {

                SqlCommand comando = new SqlCommand("Procedure_membresiaDetallePago", IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@_memId", Id));
                comando.Parameters.Add(new SqlParameter("@_pagoId", IdPago));
                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Tarjeta Tarjetax;
                    Entidad Pago;

                    Tarjetax = FabricaEntidad.ObtenerTarjetaMembresia(lector.GetInt32(0),lector.GetString(4));
                    float num = float.Parse(lector.GetValue(2).ToString());
                    Pago = FabricaEntidad.ObtenerPagoMembresia(Tarjetax, lector.GetDateTime(1), num, lector.GetInt32(3));
                    return Pago;
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

        
    }
}