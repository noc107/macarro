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
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_gestionarProveedor : PresentadorGeneral
    {
        private IContrato_02_gestionarProveedor _vista;
        private bool gridInactivos = false;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">Contrato que contiene la vista</param>
        public Presentador_02_gestionarProveedor(IContrato_02_gestionarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;

        }
    
        public void EventoClickBotonVolver()
        {

        }
        /// <summary>
        /// Metodo que se usa para cargar la informacion en el gridview
        /// </summary>
        public void BindGridProveedor()
        {
            DataTable mytable = new DataTable();
            DataColumn tColumn;

            Comando<string, List<Entidad>> ComandoLlenarGridProveedores;
            ComandoLlenarGridProveedores = FabricaComando.ObtenerComandoCargarGVProveedores();
            try
            {
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
            catch (ExcepcionComandoCargarGVProveedores e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor("RS_08_019", "Presentador Gestionar", "Gestionar", "No se ha podido cargar los datos debido a un error en la base de datos ", e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor("RS_08_019", "Presentador Gestionar", "Gestionar", "No se han podido cargar los datos debido a que ha ocurrido un error", e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }
        /// <summary>
        /// Metodo que se usa para construir el boton de consultar
        /// </summary>
        /// <returns>Image Button que se mostrara</returns>
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
        /// <summary>
        /// Metodo que se usa para construir el boton de modificar
        /// </summary>
        /// <returns>Image Button que se mostrara</returns>
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

        /// <summary>
        /// Metodo que crea el boton eliminar
        /// </summary>
        /// <returns>Image Button que se mostrara</returns>
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
        /// <summary>
        /// MEtodo que se usa para obtener el id del proveedor seleccionado
        /// </summary>
        /// <param name="e">Evento del gridview</param>
        /// <returns>Integer con el id del proveedor</returns>
        public int ObtenerIdProveedorSeleccionado_Click(GridViewCommandEventArgs e)
        {
            GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int index = rowSelect.RowIndex;
            int idProveedor = Convert.ToInt32(_vista.GVProveedores.DataKeys[index].Value.ToString());
            return idProveedor;
        }
        /// <summary>
        /// Metodo que se utiliza para ir a la ventana modificar
        /// </summary>
        /// <param name="e">Evento del gridview</param>
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

        /// <summary>
        /// Metodo que se utiliza para eliminar un proveedor
        /// </summary>
        /// <param name="idProveedor">Integer que contiene el id del proveedor</param>
        public void EventoBotonEliminar(int idProveedor)
        {
            try
            {
                Comando<int, bool> comandoEliminarProveedor;
                comandoEliminarProveedor = FabricaComando.ObtenerComandoEliminarProveedor();
                comandoEliminarProveedor.Ejecutar(idProveedor);
                BindGridProveedor();
            }
            catch (ExcepcionComandoEliminarProveedor ex)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionGestionarProveedor Ex = new ExcepcionPresentacionGestionarProveedor("RS_08_019", "Presentador Gestionar", "Gestionar", "No se ha podido eliminar debido a que existio un error de base de datos ", ex);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionGestionarProveedor Ex = new ExcepcionPresentacionGestionarProveedor("RS_08_019", "Presentador Gestionar", "Gestionar", "No se ha podido eliminar debido a que ocurrio un error ", e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }


    }
}