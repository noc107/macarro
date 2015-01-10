using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;

namespace BackOffice.FuenteDatos.Dao.RolesSeguridad
{
    public class DaoMenu : Dao, IDaoMenu
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Menu ConsultarMenuMaster(string usuario)
        {

            Menu menuBar = new Menu();

            DataTable table = new DataTable();

            try
            {
                

                string sql = "select * from MENU_MASTER WHERE MEN_MAS_id_padre IS NULL or MEN_MAS_id_accion in (" +
                    ListaIdsAccionesUsuario(usuario) + ")";

                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand(sql, _cn);
                SqlDataAdapter _da = new SqlDataAdapter(_comando);
                _da.Fill(table);

                DataView view = new DataView(table);


                view.RowFilter = "MEN_MAS_id_padre is NULL";
                foreach (DataRowView row in view)
                {
                    MenuItem menuItem = new MenuItem(row["MEN_MAS_texto"].ToString(),
                    row["MEN_MAS_id"].ToString());
                    menuItem.NavigateUrl = row["MEN_MAS_url"].ToString();
                    menuItem.ImageUrl = "~/comun/resources/img/dropdown.png";
                    menuBar.Items.Add(menuItem);
                    AddChildItems(table, menuItem);
                }

                       
                

                return menuBar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="menuItem"></param>
        private void AddChildItems(DataTable table, MenuItem menuItem)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "MEN_MAS_id_padre=" + menuItem.Value;
            foreach (DataRowView childView in viewItem)
            {
                MenuItem childItem = new MenuItem(childView["MEN_MAS_texto"].ToString(),
                childView["MEN_MAS_id"].ToString());
                childItem.NavigateUrl = childView["MEN_MAS_url"].ToString();
                menuItem.ChildItems.Add(childItem);
                AddChildItems(table, childItem);
            }
        }

               
        
        /// <summary>
        /// Metodo para obtener los ids de menu de las acciones segun cada rol de un usuario
        /// para ser utilizado en la consulta SQL que trae los items del menu que el usuario
        /// puede utilizar
        /// </summary>
        /// <param name="usuario">Usuario para obtener las acciones</param>
        /// <returns>La lista de ids de menu de acciones del usuario</returns>
        public string ListaIdsAccionesUsuario(string usuario)
        {
            SqlDataReader reader;
            List<Rol> roles = new List<Rol>();
            string ids = "";
            bool primera = true;
            List<string> listIds = new List<string>();
            List<string> listIdsTemp = new List<string>();

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_consultarRolesEmpleadoAccion", _cn);
                _comando.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar));
                _comando.Parameters["@usuario"].Value = usuario;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((Rol)FabricaEntidad.ObtenerRol((int)reader[0], (string)reader[1], (string)reader[2], null));
                }

                for (int i = 0; i < roles.Count; i++)
                {
                    reader.Close();
                    _comando = new SqlCommand("Procedure_AccionIdMenu", _cn);
                    _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                    _comando.Parameters["@_rolID"].Value = roles[i].Id;
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = _comando.ExecuteReader();

                    while (reader.Read())
                    {
                        listIdsTemp.Add(reader.GetInt32(0).ToString());
                    }

                    listIds = listIdsTemp.Distinct().ToList();

                    foreach (string s in listIds)
                    {
                        if (!primera)
                        {
                            ids = ids + "," + s;
                        }
                        else
                        {
                            ids = s;
                            primera = false;
                        }
                    }
                }

                return ids;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para obtener los URLs de menu de las acciones segun cada rol de un usuario
        /// </summary>
        /// <param name="usuario">Usuario para obtener las acciones</param>
        /// <returns>La lista de URLs de menu de acciones del usuario</returns>
        public List<string> ListaUrlAccionesUsuario(string usuario)
        {
            SqlDataReader reader;
            List<Rol> roles = new List<Rol>();
            List<string> listaUrl = new List<string>();
            List<string> listaUrlTemp = new List<string>();

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_consultarRolesEmpleadoAccion", _cn);
                _comando.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar));
                _comando.Parameters["@usuario"].Value = usuario;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((Rol)FabricaEntidad.ObtenerRol((int)reader[0], (string)reader[1], (string)reader[2], null));
                }

                for (int i = 0; i < roles.Count; i++)
                {
                    reader.Close();
                    _comando = new SqlCommand("Procedure_AccionURL", _cn);
                    _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                    _comando.Parameters["@_rolID"].Value = roles[i].Id;
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = _comando.ExecuteReader();

                    while (reader.Read())
                    {
                        listaUrlTemp.Add(reader.GetString(0));
                    }
                }

                listaUrl = listaUrlTemp.Distinct().ToList();

                if (listaUrl.Contains("/Presentacion/Vistas/Web/UsuariosInternos/web_09_agregarUsuario.aspx") || listaUrl.Contains("/Presentacion/Vistas/Web/UsuariosInternos/web_09_modificarUsuario.aspx"))
                {
                    listaUrl.Add("/Presentacion/Vistas/Web/UsuariosInternos/web_09_asignarRoles.aspx");
                }

                listaUrl.Add("/Presentacion/Vistas/Web/inicio.aspx");

                return listaUrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para obtener las acciones segun cada rol de un usuario
        /// </summary>
        /// <param name="usuario">Usuario para obtener las acciones</param>
        /// <returns>La lista de URLs de menu de acciones del usuario</returns>
        public List<string> ListaAccionesUsuario(string usuario)
        {
            SqlDataReader reader;
            List<Rol> roles = new List<Rol>();
            List<string> listaAccionString = new List<string>();
            List<Accion> listaAccion = new List<Accion>();
            List<Entidad> listaAccionTemp = new List<Entidad>();

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_consultarRolesEmpleadoAccion", _cn);
                _comando.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar));
                _comando.Parameters["@usuario"].Value = usuario;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((Rol)FabricaEntidad.ObtenerRol((int)reader[0], (string)reader[1], (string)reader[2], null));
                }
                CerrarConexion();

                for (int i = 0; i < roles.Count; i++)
                {
                    reader.Close();
                    IDaoRol _daoRol;
                    _daoRol = FabricaDao.ObtenerDaoRol();
                    listaAccionTemp = _daoRol.ConsultarRol(roles[i]);

                    foreach (Accion a in listaAccionTemp)
                    {
                        listaAccion.Add(a);
                    }
                }

                foreach (Accion a in listaAccion)
                {
                    listaAccionString.Add(a.Nombre);
                }

                _cn = IniciarConexion();
                _cn.Open();

                return listaAccionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<bool> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public Menu Agregar(string menu)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public Menu Modificar(string menu)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar menu por id. No implementado
        /// </summary>
        /// <param name="id">id de la menu</param>
        /// <returns>menu consultado</returns>
        public bool ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }
    
    }
}