﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Logica.InventarioRestaurante;

namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_modificarItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxAumentarCantidad.Visible= true;

            ProcedimientosItem _procedimiento = new ProcedimientosItem();
            string[] _mostrar = _procedimiento.verItem(10);
            string[] _proveedores = _procedimiento.verProveedor();

            tbNombre.Text = _mostrar[0];
            tbCantidad.Text = _mostrar[3];
            tbDescripcion.Text = _mostrar[4];
            tbPrecio.Text = _mostrar[5];
            tbPrecio2.Text = _mostrar[1];

            for (int _contador = 0; _contador < _proveedores.Length; _contador++)
            {
                ListItem oItem = new ListItem(_proveedores[_contador]);
                Proveedores.Items.Add(oItem);
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            float _precioVenta = int.Parse(tbPrecio.Text);
            float _precioCompra = int.Parse(tbPrecio2.Text);

            if (_precioVenta < _precioCompra) 
            {
                MensajeFallo.Text = "Precio venta no puede ser menor que precio compra";
                MensajeFallo.Visible = true;
            }
            

            Response.Redirect("web_06_gestionarInventario.aspx");
        
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_06_gestionarInventario.aspx");
        }


        protected void ButtonAceptarModalAumentar_Click(object sender, EventArgs e)
        {
            int valorAct = valorActual();
            int y = 0;
            if (string.IsNullOrWhiteSpace(TextBoxAumentarCantidad.Text.ToString()))   //No suma null
                y = 0;
                try
                {
                    y = Convert.ToInt32(TextBoxAumentarCantidad.Text.ToString()); //Intenta convertir (no letras)
                }
                catch (FormatException)
                {
                    y = 0;
                }
                finally
                {
                    if (y < 0) //No opera numeros negativos
                        y = 0;
                    valorAct = valorAct + y;
                    if (valorAct > 9999)
                        valorAct = 9999;   //Para que no sobrepase el rango permitido
                    tbCantidad.Text = valorAct.ToString();
                    TextBoxAumentarCantidad.Text = "";     //Setea el textbox en vacio
                }
        }


        protected void ButtonCancelarModalAumentar_Click(object sender, EventArgs e)
        {
            TextBoxAumentarCantidad.Text = "";     //Setea el textbox en vacio                
        }

        protected void ButtonAceptarModalRestar_Click(object sender, EventArgs e)
        {
            int valorAct = valorActual();
            int y = 0;
            if (string.IsNullOrWhiteSpace(TextBoxRestarCantidad.Text.ToString()))   //No resta null
                y = 0;
            try
            {
                y = Convert.ToInt32(TextBoxRestarCantidad.Text.ToString()); //Intenta convertir (no letras)
            }
            catch (FormatException)
            {
                y = 0;
            }
            finally
            {
                if (y < 0) //No opera numeros negativos
                    y = 0;
                if (y > valorAct)
                {
                    tbCantidad.Text = "0";
                    TextBoxRestarCantidad.Text = "";
                }
                else
                {
                    valorAct = valorAct - y;
                    tbCantidad.Text = valorAct.ToString();
                    TextBoxRestarCantidad.Text = "";     //Setea el textbox en vacio
                }
            }
        }

        protected void ButtonCancelarModalRestar_Click(object sender, EventArgs e)
        {
            TextBoxRestarCantidad.Text = "";     //Setea el textbox en vacio                
        }

        protected int valorActual() //Verifica si el textbox cantidad posee caracteres validos
        {
            if (string.IsNullOrWhiteSpace(tbCantidad.Text.ToString()))   //No resta null
                return (0);
            try
            {
                int valor = Convert.ToInt32(tbCantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    return (0);
                else
                    return (valor);
            }
            catch (FormatException)
            {
                tbCantidad.Text = "";
                return (0);
            }
        }


        protected void ButtonMasoMenos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCantidad.Text.ToString()))   //No resta null
                tbCantidad.Text = "0";
            try
            {
                int valor = Convert.ToInt32(tbCantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    tbCantidad.Text = "0";
            }
            catch (FormatException)
            {
                tbCantidad.Text = "0";
            }          
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCantidad.Text.ToString()))   //No resta null
                tbCantidad.Text = "0";
            try
            {
                int valor = Convert.ToInt32(tbCantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    tbCantidad.Text = "0";
            }
            catch (FormatException)
            {
                tbCantidad.Text = "0";
            }
        }

        protected bool setTBto0()
        {
            if (string.IsNullOrWhiteSpace(tbCantidad.Text.ToString()))   //No resta null
                tbCantidad.Text = "0";
            try
            {
                int valor = Convert.ToInt32(tbCantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    tbCantidad.Text = "0";
                return false;
            }
            catch (FormatException)
            {
                tbCantidad.Text = "0";
                return false;
            }
        }

    }
}