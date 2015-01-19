using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;
using System.Data;
using System.Web.UI.WebControls;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.LogicaNegocio.Comandos.Proveedores;
using BackOffice.Dominio.Entidades;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_gestionarProveedor : PresentadorGeneral
    {
        private IContrato_02_gestionarProveedor _vista;
        private bool gridInactivos = false;


        public Presentador_02_gestionarProveedor(IContrato_02_gestionarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;

        }
    
        public void EventoClickBotonVolver()
        {

        }

        public void BindGridProveedor()
        {
            DataTable mytable = new DataTable();
            DataColumn tColumn;

            Comando<string, List<Entidad>> ComandoLlenarGridProveedores;
            ComandoLlenarGridProveedores = FabricaComando.ObtenerComandoCargarGVProveedores();
            List<Entidad> listaProveedores = ComandoLlenarGridProveedores.Ejecutar(_vista.textboxBuscar.Text);

            tColumn = new System.Data.DataColumn("Id", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Rif", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Nombre", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Estado", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Acciones", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);

            foreach (Proveedor r in listaProveedores)
            {
                if (_vista.comboEstado.SelectedValue == "Activado")
                {
                    if (r.Status == "Activado")
                    {
                        mytable.Rows.Add(r.Id, r.Rif, r.RazonSocial, r.Status);
                        gridInactivos = false;
                    }
                }
                else
                {
                    if (r.Status == "Desactivado")
                    {
                        mytable.Rows.Add(r.Id, r.Rif, r.RazonSocial, r.Status);
                        gridInactivos = true;
                    }
                }
            }

            _vista.GVProveedores.DataSource = mytable;
            _vista.GVProveedores.DataBind();
        }

        public ImageButton Consultar()
        {
            ImageButton consultar = new ImageButton();
            consultar.ID = "bConsultar";
            consultar.ImageUrl = "../../../../comun/resources/img/View-128.png";
            consultar.Height = 60;
            consultar.Width = 60;
            consultar.CommandName = "Consultar";
            return consultar;
        }

        public ImageButton Editar()
        {
            ImageButton editar = new ImageButton();
            editar.ID = "bEditar";
            editar.ImageUrl = "../../../../comun/resources/img/Data-Edit-128.png";
            editar.Height = 60;
            editar.Width = 60;
            editar.CommandName = "Modificar";
            return editar;
        }


        public ImageButton Eliminar()
        {
            ImageButton eliminar = new ImageButton();
            eliminar.ID = "bEliminar";
            eliminar.ImageUrl = "../../../../comun/resources/img/Garbage-Closed-128.png";
            eliminar.Height = 60;
            eliminar.Width = 60;
            eliminar.CommandName = "Eliminar";
            if (!gridInactivos)
            eliminar.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema. ¿Desea continuar?')";
            else
                eliminar.OnClientClick = "return alert('El proveedor se encuentra desactivado. Puede cambiar su estado en la opcion modificar')";
            return eliminar;
        }

        public int ObtenerIdProveedorSeleccionado_Click(GridViewCommandEventArgs e)
        {
            GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int index = rowSelect.RowIndex;
            int idProveedor = Convert.ToInt32(_vista.GVProveedores.DataKeys[index].Value.ToString());
            return idProveedor;
        }

        public void EventoModificarBtn_Click(GridViewCommandEventArgs e)
        {
            GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int index = rowSelect.RowIndex;
            int idProveedor = Convert.ToInt32(_vista.GVProveedores.DataKeys[index].Value.ToString());
        }

        //public int EventoConsultarBtn_Click(object sender)
        //{
        //    ImageButton b = (ImageButton)sender;
        //    GridViewRow row = (GridViewRow)b.Parent.Parent;
        //    return row.DataItemIndex;
        //}

        //public void EventoEliminarBtn_Click(object sender)
        //{
        //    Comando<int, bool> ComandoEliminarRol;
        //    ComandoEliminarRol = FabricaComando.ObtenerComandoEliminarRol();
        //   // ComandoEliminarRol.Ejecutar(EventoConsultarBtn_Click(sender));
        //    BindGridProveedor();
        //}


        public void EventoBotonEliminar(int idProveedor)
        {
            try
            {
                Comando<int, bool> comandoEliminarProveedor;
                comandoEliminarProveedor = FabricaComando.ObtenerComandoEliminarProveedor();
                comandoEliminarProveedor.Ejecutar(idProveedor);
                BindGridProveedor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}