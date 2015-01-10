using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.RolesSeguridad;

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
        /// 
        /// </summary>
        /// <param name="menu"></param>
        public void ConstruirMenu(Menu menu)
        {         
            
             foreach (MenuItem menuItem in menu.Items)
            {               
                MenuItem Aux = new MenuItem( menuItem.Text, menuItem.Value);
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

        


    }
}