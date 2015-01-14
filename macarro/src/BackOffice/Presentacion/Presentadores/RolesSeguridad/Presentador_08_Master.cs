using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_Master : PresentadorGeneral
    {
        private IContrato_08_Master _vista;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaMaster">Interfaz</param>
        public Presentador_08_Master(IContrato_08_Master vistaMaster)
            : base(vistaMaster)
        {
            _vista = vistaMaster;
        }

        /// <summary>
        /// Metodo para constuir el menu de la aplicacion
        /// </summary>
        /// <param name="menu">el menu con los items</param>
        public void ConstruirMenu(Menu menu)
        {
            try
            {
                foreach (MenuItem menuItem in menu.Items)
                {
                    MenuItem Aux = new MenuItem(menuItem.Text, menuItem.Value);
                    Aux.NavigateUrl = menuItem.NavigateUrl;
                    foreach (MenuItem child in menuItem.ChildItems)
                    {
                        MenuItem AuxChild = new MenuItem(child.Text, child.Value);
                        AuxChild.NavigateUrl = child.NavigateUrl;
                        Aux.ChildItems.Add(AuxChild);

                    }

                    _vista.menuMaster.Items.Add(Aux);
                }
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Message);
            }
                   
            
        }

        


    }
}