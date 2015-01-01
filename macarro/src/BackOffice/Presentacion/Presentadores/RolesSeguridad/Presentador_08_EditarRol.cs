using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
//using BackOffice.LogicaNegocio.RolesSeguridad;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_EditarRol : PresentadorGeneral
    {
    
        private IContrato_08_EditarRol _vista;
        //private ControlRolAccion _modelo; 
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_EditarRol(IContrato_08_EditarRol vistaEditarRol)
            : base(vistaEditarRol)
        {
            _vista = vistaEditarRol;
            //_modelo = new ControlRolAccion();
        }

        /// <summary>
        /// Metodo para llenar la informacion del rol seleccionado
        /// </summary>
        public void llenarInfo()
        {
            //_vista.TBNombre.Text = _modelo.RolActual.Nombre;
            //_vista.TBDescripcion.Text = _modelo.RolActual.Descripcion;

            //List<string> listAcc = _modelo.listaString(_modelo.listaGeneralAcciones());

            //foreach (string a in _modelo.listaString(_modelo.RolActual.Acciones))
            //{
            //    _vista.LBAccionesAsignadas.Items.Add(a);

            //    listAcc.RemoveAll(delegate(string ac)
            //    {
            //        if (ac == a)
            //            return true;
            //        else
            //            return false;
            //    });
            //}

            //foreach (string a in listAcc)
            //{
            //    _vista.LBAccionesDisponibles.Items.Add(a);
            //}
            
        }

        /// <summary>
        /// Metodo para selccionar el rol actual
        /// </summary>
        /// <param name="rol">Rol seleccionado</param>
        public void rolActual(int rol)
        {
            //_modelo.setRolActual(rol);
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
            //_modelo.modificarRol(_vista.TBNombre.Text, _vista.TBDescripcion.Text, ls);

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