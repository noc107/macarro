using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.MenuRestaurante;

namespace BackOffice.Presentacion.Presentadores.MenuRestaurante
{
    public class Presentador_05_GestionarProducto : PresentadorGeneral
    {
        private IContrato_05_GestionarPlato _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaGestionMenu">Interfaz</param>
        public Presentador_05_GestionarProducto(IContrato_05_GestionarPlato vistaGestionMenu)
            : base(vistaGestionMenu)
        {
            _vista = vistaGestionMenu;
        }

        /// <summary>
        /// Metodo para mostrar los platos en el GridView
        /// </summary>
        public void GridViewPlatos()
        {
            DataTable mytable = new DataTable();
            DataColumn tColumn;

            try
            {
                _vista.LabelMensajeError.Visible = false;

                Comando<bool, List<Entidad>> ComandoLlenarGridPlatos;
                ComandoLlenarGridPlatos = FabricaComando.ObtenerComandoLlenarGridPlatos();
                List<Entidad> listaPlatos = ComandoLlenarGridPlatos.Ejecutar(true);

                tColumn = new System.Data.DataColumn("Plato", System.Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);
                tColumn = new System.Data.DataColumn("Precio", System.Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);
                tColumn = new System.Data.DataColumn("Descripción", System.Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);
                tColumn = new System.Data.DataColumn("Sección", System.Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);
                tColumn = new System.Data.DataColumn("Ver Editar Eliminar", System.Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);

                foreach (Plato p in listaPlatos)
                {
                    mytable.Rows.Add(p.Nombre, p.Precio, p.Descripcion, p.Seccion);
                }

                _vista.GVPlatos.DataSource = mytable;
                _vista.GVPlatos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para la creacion del boton de consultar
        /// </summary>
        /// <returns></returns>
        public ImageButton Consultar()
        {
            ImageButton consultar = new ImageButton();
            consultar.ID = "bConsultar";
            consultar.ImageUrl = "../../../../comun/resources/img/View-128.png";
            consultar.Height = 60;
            consultar.Width = 60;
            return consultar;
        }

        /// <summary>
        /// Metodo para la creacion del boton de editar
        /// </summary>
        /// <returns></returns>
        public ImageButton Editar()
        {
            ImageButton editar = new ImageButton();
            editar.ID = "bEditar";
            editar.ImageUrl = "../../../../comun/resources/img/Data-Edit-128.png";
            editar.Height = 60;
            editar.Width = 60;
            return editar;
        }

        /// <summary>
        /// Metodo para la creacion del boton eliminar
        /// </summary>
        /// <returns></returns>
        public ImageButton Eliminar()
        {
            ImageButton eliminar = new ImageButton();
            eliminar.ID = "bEliminar";
            eliminar.ImageUrl = "../../../../comun/resources/img/Garbage-Closed-128.png";
            eliminar.Height = 60;
            eliminar.Width = 60;
            eliminar.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";
            return eliminar;
        }

        /// <summary>
        /// Metodo para manejar elvento del boton consultar
        /// </summary>
        public int EventoConsultarBtn_Click(object sender)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.Parent.Parent;
            return row.DataItemIndex;
        }

        /// <summary>
        /// Metodo para manejar elvento del boton eliminar
        /// </summary>
        public void EventoEliminarBtn_Click(object sender)
        {
            Comando<int, bool> ComandoEliminarRol;
            ComandoEliminarRol = FabricaComando.ObtenerComandoEliminarRol();
            ComandoEliminarRol.Ejecutar(EventoConsultarBtn_Click(sender));
            GridViewPlatos();
        }
    }
}