using System;
using System.Collections.Generic;
using System.Data;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
//using BackOffice.LogicaNegocio.RolesSeguridad;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_ConsultarAcciones : PresentadorGeneral
    {
        
        private IContrato_08_ConsultarAcciones _vista;
        //private ControlRolAccion _modelo; 
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaRolesSeguridad">Interfaz</param>
        public Presentador_08_ConsultarAcciones(IContrato_08_ConsultarAcciones laVistaRolesSeguridad)
            : base(laVistaRolesSeguridad)
        {
            _vista = laVistaRolesSeguridad;
            //_modelo = new ControlRolAccion();
        }

        /// <summary>
        /// Metodo para la presentacion de los datos del GridView 
        /// </summary>
        public void BindGridAcciones()
        {
            //DataTable _acciones = _modelo.llenarGridAcciones();
            //_vista.GVAcciones.DataSource = _acciones;
            //_vista.GVAcciones.DataBind();
        }
    
    }
}