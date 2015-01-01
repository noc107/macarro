using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
//using BackOffice.LogicaNegocio.RolesSeguridad;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{

    public class Presentador_08_GestionarRoles : PresentadorGeneral
    {

        private IContrato_08_GestionarRoles _vista;
        //private ControlRolAccion _modelo;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_GestionarRoles(IContrato_08_GestionarRoles laVistaRolesSeguridad)
            : base(laVistaRolesSeguridad)
        {
            _vista = laVistaRolesSeguridad;
            //_modelo = new ControlRolAccion();
        }

        /// <summary>
        /// Metodo para la presentacion de los datos del GridView 
        /// </summary>
        public void BindGridRoles()
        {
            //DataTable _datosRoles = _modelo.llenarGridRoles();
            //_vista.GVRoles.DataSource = _datosRoles;
            //_vista.GVRoles.DataBind();
        }

        /// <summary>
        /// Metodo para la creacion del botton de consultar
        /// </summary>
        /// <returns>Botton correspondiente</returns>
        public ImageButton Consultar () 
        {

            ImageButton consultar = new ImageButton();
            consultar.ID = "bConsultar";
            consultar.ImageUrl = "../../../../comun/resources/img/View-128.png";
            consultar.Height = 60;
            consultar.Width = 60;
            return consultar;
               
        }

        /// <summary>
        /// Metodo para la creacion del botton de editar
        /// </summary>
        /// <returns>Botton correspondiente</returns>
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
        /// Metodo para la creacion del botton de eliminar
        /// </summary>
        /// <returns>Botton correspondiente</returns>
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
        public int EventoConsultarBtn_Click (object sender)
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
            //_modelo.setRolActual(EventoConsultarBtn_Click(sender));
            //_modelo.eliminarRol();
            //BindGridRoles();
        }

    }
}