﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_eliminarProveedor : System.Web.UI.Page
    {
        //ProveedorBD auxBD = new ProveedorBD();
      
        private string auxString = "";

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargase la pagina
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        /// <exception> Exception , Param = ex </exception>

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    String s = Request.QueryString["p"];
            //    auxString = s;
            //    LogicaProveedor.ProveedorActual = s;
            //    Proveedor p = auxBD.consultarProveedorBD(s);
            //    List<Item> i = auxBD.consultarItemsProveedorBD(s);
            //    CargarProveedor(p);
            //    CargarItems(i);
            //}

        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, Dispara los mensajes de éxito o fallo al eliminar.
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        /// 
        protected void Button1_Click(object sender, EventArgs e)
        {
        //    LogicaProveedor logica = new LogicaProveedor();
        //    bool confirmacion = auxBD.eliminarProveedor(LogicaProveedor.ProveedorActual);
        //    if(confirmacion)
        //    {
        //        logica.MensajeExitoEliminar(Mensaje);
        //    }
        //    else
        //    {
        //        logica.MensajeFalloEliminar(Mensaje,0);
        //    }
        }

        ///// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        ///// <summary>
        ///// Evento, redirecciona la pagina, vuelve al menu
        ///// </summary>
        ///// <param name= sender> Objeto </param>
        ///// <param name= e> Argumento </param>
        ///// 
        protected void Button2_Click(object sender, EventArgs e)
        {
        //    Response.Redirect("web_02_gestionarProveedores.aspx");
        }

        ///// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        ///// <summary>
        ///// Metodo que carga la informacion del proveedor dentro de la pagina
        ///// </summary>
        ///// <param name= p> Objeto de tipo proveedor, contiene todos los campos que existen para un proveedor</param>
        ///// <exception> ExcepcionEliminarProveedor </exception>
        ///// <exception> Exception , Param = e </exception>

        //private void CargarProveedor(Proveedor p)
        //{
        //    List<string> lugar = auxBD.ConsultarDireccionProveedorBD(p.Lugar);

        //    try
        //    {
        //        this.Rif.Text = p.Rif;
        //        this.RazonSocial.Text = p.RazonSocial;
        //        this.Correo.Text = p.Correo;
        //        this.PaginaWeb.Text = p.PaginaWeb;
        //        this.Telefono.Text = p.Telefono;
        //        this.FechaContrato.Text = p.FechaContrato.ToString();
        //        this.Pais.Text = lugar[0];
        //        this.Estado.Text = lugar[1];
        //        this.Ciudad.Text = lugar[2];
        //        this.Direccion.Text = lugar[3];
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        ///// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        ///// <summary>
        ///// Metodo que carga la informacion de la lista de items dentro de la pagina
        ///// </summary>
        ///// <param name= Items> Lista de tipo ITEM con el nombre y id de cada uno</param>
        ///// <exception> Exception , Param = e </exception>
        ///// <exception> ExcepcionConsultarProveedor, Param = ex </exception>

        //private void CargarItems(List<Item> Items)
        //{

        //    //Llenar gridview con los items
        //    GridItems.DataSource = Items;
        //    GridItems.DataBind();
        //}

        
    }
}