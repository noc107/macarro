using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace back_office.Datos
{
    public class OperacionesBD
    {
        public SqlConnection _cn;
        public DataSet _ds = new DataSet();
        public SqlDataAdapter _da;
        public SqlCommand _comando;
        public string stringConexion = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\\MACARRO.mdf;Integrated Security=True";
   
        private void ConectarBD()
        {
            this._cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MACARRO"].ConnectionString);        
        }

	    public OperacionesBD()
	    {
           this.ConectarBD();
	    }

        public void DesconectarBD()
        {
           this._cn.Close();
        }

    }
}