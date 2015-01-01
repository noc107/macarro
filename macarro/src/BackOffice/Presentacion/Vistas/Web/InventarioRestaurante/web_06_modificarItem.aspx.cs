using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.InventarioRestaurante;
using BackOffice.Presentacion.Presentadores.InventarioRestaurante;

namespace BackOffice.Presentacion.Vistas.Web.InventarioRestaurante
{
    public partial class web_06_modificarItem : System.Web.UI.Page , IContrato_06_modificarItem
    {
        private Presentador_06_modificarItem _presentador;

        public web_06_modificarItem()
        {
            _presentador = new Presentador_06_modificarItem(this);
        }



        public TextBox Nombre
        {
            get
            {
               return  this.tbNombre;
            }
            set
            {
                this.tbNombre = value;
            }
        }

        public TextBox Cantidad
        {
            get
            {
                return this.tbCantidad;
            }
            set
            {
                this.tbCantidad = value;
            }
        }

    public TextBox Descripcion 
    {
        get
        {
            return this.tbDescripcion;
        }
        set
        {
            this.tbDescripcion = value;
        }
    }

        public TextBox Precio
        {
            get
            {
                return this.tbPrecio;
            }
            set
            {
                this.tbPrecio = value;
            }
        }

        public TextBox Precio1
        {
            get
            {
                return this.tbPrecio2;
            }
            set
            {
                this.tbPrecio2 = value;

            }
        }

        public DropDownList Proveedor
        {
            get
            {
                return this.Proveedores;
            }
            set
            {
                this.Proveedores = value;
            }
        }

        public TextBox Aumento
        {
            get
            {
                return this.TextBoxAumentarCantidad;
            }
        }

        public TextBox Disminuir

        {
            get
            {
                return this.TextBoxRestarCantidad;
            }
        }


        public Label LabelMensajeExito
        {
            get
            {
                return this.MensajeExito;
            }
            set
            {
                this.MensajeExito = value;
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                return this.MensajeFallo;
            }
            set
            {
                this.MensajeFallo = value;
            }
        }
            


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    int idItem = web_06_gestionarInventario.idItemSeleccionado;   //id del item seleccionado en la ventana gestion
            //    TextBoxAumentarCantidad.Visible = true;
            //    ProcedimientosItem _procedimiento = new ProcedimientosItem();
            //    string[] _mostrar = _procedimiento.verItem(idItem);
            //    string[] _proveedores = _procedimiento.verProveedor();

            //    this.tbNombre.Text = _mostrar[0];
            //    this.tbCantidad.Text = _mostrar[3];
            //    this.tbDescripcion.Text = _mostrar[4];
            //    this.tbPrecio.Text = _mostrar[5];
            //    this.tbPrecio2.Text = _mostrar[1];

            //    for (int _contador = 0; _contador < _proveedores.Length; _contador++)
            //    {
            //        ListItem oItem = new ListItem(_proveedores[_contador]);
            //        Proveedores.Items.Add(oItem);
            //    }
              

            //    Boton1.OnClientClick = "validacionesOk();";   //Funcion que revisa validaciones antes de confirmar            
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        //        try
        //        {
        //        int _idItem = web_06_gestionarInventario.idItemSeleccionado;
        //        float _precioVenta = float.Parse(this.tbPrecio.Text);
        //        float _precioCompra = float.Parse(this.tbPrecio2.Text);
        //        ProcedimientosItem _procedimiento = new ProcedimientosItem();
        //        string _nombre = this.tbNombre.Text;
        //        int _cantidad = int.Parse(this.tbCantidad.Text);
        //        string _descripcion = this.tbDescripcion.Text;
        //        string _proveedor = this.Proveedores.Text;

        //        if (_precioVenta < _precioCompra)
        //        {
        //            MensajeFallo.Text = "Precio venta no puede ser menor que precio compra";
        //            MensajeFallo.Visible = true;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                _procedimiento.modificarItem(_idItem, _nombre, _cantidad, _descripcion,
        //                _proveedor, _precioVenta, _precioCompra);
        //                Response.Redirect("web_06_gestionarInventario.aspx");
        //            }
        //            catch (ExcepcionModificarItem)
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg",
        //                "alert('Ha ocurrido un error de base de datos, por favor intente luego');", true);
        //                Response.Redirect("web_06_gestionarInventario.aspx");
        //            }
        //            catch (Exception)
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg",
        //                "alert('Su solicitud no pudo ser procesada');", true);
        //                Response.Redirect("web_06_gestionarInventario.aspx");
        //            }
        //        }

        //        }
        //        catch (FormatException)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg",
        //            "alert('¡Formato Incorrecto de precio!');", true);
        //        }
        }




        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_06_gestionarInventario.aspx");
        }


        protected void ButtonAceptarModalAumentar_Click(object sender, EventArgs e)
        {
            string ajaa = tbCantidad.Text.ToString();
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
            int valorAct = Convert.ToInt32(tbCantidad.Text.ToString());
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


        public TextBox nombre
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TextBox cantidad
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TextBox descripcion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TextBox precioVenta
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TextBox precioCompra
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DropDownList proveedor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TextBox aumentarCantidad
        {
            get { throw new NotImplementedException(); }
        }

        public TextBox restarCantidad
        {
            get { throw new NotImplementedException(); }
        }
    }
}