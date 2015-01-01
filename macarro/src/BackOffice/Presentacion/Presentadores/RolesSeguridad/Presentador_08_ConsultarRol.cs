using System;
using System.Collections.Generic;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
//using BackOffice.LogicaNegocio.RolesSeguridad;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_ConsultarRol : PresentadorGeneral
    {
    
        private IContrato_08_ConsultarRol _vista;
        //private ControlRolAccion _modelo; 
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_ConsultarRol(IContrato_08_ConsultarRol vistaConsultarRol)
            : base(vistaConsultarRol)
        {
            _vista = vistaConsultarRol;
            //_modelo = new ControlRolAccion();
        }

        /// <summary>
        /// Metodo para llenar la informacion del rol seleccionado
        /// </summary>
        public void llenarInfo()
        {
            //_vista.LNombre.Text =  _modelo.RolActual.Nombre;
            //_vista.LDescripcion.Text = _modelo.RolActual.Descripcion;

            //foreach (string a in _modelo.listaString(_modelo.RolActual.Acciones))
            //{
            //    _vista.LBAcciones.Items.Add(a);
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
    
    }
}