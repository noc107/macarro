using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao
{
    public abstract class Dao
    {
        private static SqlConnection _conexion;

        #region IniciarConexion

        public SqlConnection IniciarConexion()
        {
            try
            {
                if (_conexion == null)
                    _conexion = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\AEDM07\\Documents\\[DS]\\macarro\\src\\App_Data\\MACARRO.mdf");
                    //_conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MACARRO"].ConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return _conexion;
        }

        #endregion

        #region CerrarConexion

        public void CerrarConexion()
        {
            try
            {
                _conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion

    }
}