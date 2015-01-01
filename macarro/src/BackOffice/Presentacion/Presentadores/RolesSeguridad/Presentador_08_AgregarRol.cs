using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
//using BackOffice.LogicaNegocio.RolesSeguridad;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_AgregarRol : PresentadorGeneral
    {
        private IContrato_08_AgregarRol _vista;
        //private ControlRolAccion _modelo; 
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_AgregarRol(IContrato_08_AgregarRol vistaAgregarRol)
            : base(vistaAgregarRol)
        {
            _vista = vistaAgregarRol;
            //_modelo = new ControlRolAccion();
        }

        /// <summary>
        /// Metodo para llenar la informacion del rol seleccionado
        /// </summary>
        public void llenarInfo()
        {
            //foreach (string a in _modelo.listaString(_modelo.listaGeneralAcciones()))
            //{
            //    _vista.LBAccionesDisponibles.Items.Add(a);
            //}
        }

        /// <summary>
        /// Metodo para manejar el evento del boton agregar
        /// </summary>
        /// <param name="ListaAccionesAsignadas">lista acciones asignadas</param>
        /// <param name="ListaAccionesDisponibles">lista acciones disponibles</param>
        public void EventoAgregar_Click()
        {
            _vista.LabelMensajeError.Visible = false;
            _vista.LBAccionesAsignadas.Items.Add(_vista.LBAccionesDisponibles.SelectedItem);
            _vista.LBAccionesDisponibles.Items.RemoveAt(_vista.LBAccionesDisponibles.SelectedIndex);
            _vista.LBAccionesDisponibles.ClearSelection();
            _vista.LBAccionesAsignadas.ClearSelection();
        }


        /// <summary>
        /// Metodo para manejar el evento del boton quitar
        /// </summary>
        /// <param name="ListaAccionesAsignadas">lista acciones asignadas</param>
        /// <param name="ListaAccionesDisponibles">lista acciones disponibles</param>
        public void EventoQuitar_Click()
        {
            _vista.LabelMensajeError.Visible = false;
            _vista.LBAccionesDisponibles.Items.Add(_vista.LBAccionesAsignadas.SelectedItem);
            _vista.LBAccionesAsignadas.Items.RemoveAt(_vista.LBAccionesAsignadas.SelectedIndex);
            _vista.LBAccionesAsignadas.ClearSelection();
            _vista.LBAccionesDisponibles.ClearSelection();
        }

        /// <summary>
        /// Metodo para manejar el evento del boton aceptar
        /// </summary>
        /// <param name="nombre">nombre rol</param>
        /// <param name="descripcion">descripcion rol</param>
        /// <param name="listaAcciones">lista de acciones</param>
        public void EventoAceptar_Click() 
        {
            _vista.LabelMensajeError.Visible = false;
            List<string> ls = new List<string>();
            foreach (ListItem i in _vista.LBAccionesDisponibles.Items)
            {
                ls.Add(i.Text);
            }
            //_modelo.agregarRol(_vista.TBNombre.Text, _vista.TBDescripcion.Text, ls);

        }

        /// <summary>
        /// Metodo para verificar si el rol existe
        /// </summary>
        /// <param name="nombre">nombre rol</param>
        /// <returns></returns>
        public bool VerificarRol(string nombre) 
        {
            //return _modelo.verificarRol(nombre);
            return false; //mientras no esta la logica
        }
    
    }
}