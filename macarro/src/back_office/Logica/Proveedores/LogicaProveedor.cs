using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;

namespace back_office.Logica.Proveedores
{
    public class LogicaProveedor
    {

        //Declaracion del constructor predeterminado de la clase proveedor
        public void constructor()
        {

        }

        //Declaracion de los metodos de la clase proveedor
        public void AgregarItemLista(Proveedor p, int codigoItem)
        {   
            //Agrego codigo del item a la lista de item
            p.Items.Add(codigoItem);
        }

        public void EliminarItemLista(Proveedor p, int codigoItem)
        {
            //Borro el codigo del item de la lista 
            p.Items.Remove(codigoItem);     
        }
    }
}