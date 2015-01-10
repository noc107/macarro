using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.Dao.Reservas
{
    public class DaoReservaPlaya : Dao, IDaoReservaPlaya
    {
        public Entidad ConsultarReservaPlayaXid(int _id)
        {
            Entidad _listaReservaPlaya;
            SqlCommand comando = new SqlCommand("ConsultarReserva_Playa", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_playaid", _id));


            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                _lectura.Read();
                _listaReservaPlaya = ObtenerBDReader(_lectura);

                return _listaReservaPlaya;
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return null;
        }

        private ReservaPlaya ObtenerBDReader(SqlDataReader objetoBD)
        {
            ReservaPlaya _reservaPlaya = (ReservaPlaya)FabricaEntidad.ObtenerReservaPlaya();
            try
            {
                _reservaPlaya.reservaPlaya_Fila = objetoBD.GetInt32(0);
                _reservaPlaya.reservaPlaya_Columna = objetoBD.GetInt32(1);
                _reservaPlaya.reservaPlaya_Id = objetoBD.GetInt32(2);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                string c = ex.ToString();
            }
            return _reservaPlaya;
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

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}