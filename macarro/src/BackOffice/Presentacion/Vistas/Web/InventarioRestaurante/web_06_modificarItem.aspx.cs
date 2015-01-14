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
               return  this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public TextBox Cantidad
        {
            get
            {
                return this._cantidad;
            }
            set
            {
                this._cantidad = value;
            }
        }

    public TextBox Descripcion 
    {
        get
        {
            return this._descripcion;
        }
        set
        {
            this._descripcion = value;
        }
    }

        public TextBox PrecioVenta
        {
            get
            {
                return this._precioVenta;
            }
            set
            {
                this._precioVenta = value;
            }
        }

        public TextBox PrecioCompra
        {
            get
            {
                return this._precioCompra;
            }
            set
            {
                this._precioCompra = value;

            }
        }

        public DropDownList Proveedor
        {
            get
            {
                return this._proveedor;
            }
            set
            {
                this._proveedor = value;
            }
        }

        public TextBox AumentarCantidad
        {
            get
            {
                return this._aumentarCantidad;
            }
        }

        public TextBox RestarCantidad

        {
            get
            {
                return this._restarCantidad;
            }
        }


        public Label LabelMensajeExito
        {
            get
            {
                return this._mensajeExito;
            }
            set
            {
                this._mensajeExito = value;
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                return this._mensajeError;
            }
            set
            {
                this._mensajeError = value;
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
            string ajaa = _cantidad.Text.ToString();
            int valorAct = valorActual();
            int y = 0;
            if (string.IsNullOrWhiteSpace(_aumentarCantidad.Text.ToString()))   //No suma null
                y = 0;
                try
                {
                    y = Convert.ToInt32(_aumentarCantidad.Text.ToString()); //Intenta convertir (no letras)
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
                    _cantidad.Text = valorAct.ToString();
                    _aumentarCantidad.Text = "";     //Setea el textbox en vacio
                }
        }


        protected void ButtonCancelarModalAumentar_Click(object sender, EventArgs e)
        {
            _aumentarCantidad.Text = "";     //Setea el textbox en vacio                
        }

        protected void ButtonAceptarModalRestar_Click(object sender, EventArgs e)
        {
            int valorAct = Convert.ToInt32(_cantidad.Text.ToString());
            int y = 0;
            if (string.IsNullOrWhiteSpace(_restarCantidad.Text.ToString()))   //No resta null
                y = 0;
            try
            {
                y = Convert.ToInt32(_restarCantidad.Text.ToString()); //Intenta convertir (no letras)
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
                    _cantidad.Text = "0";
                    _restarCantidad.Text = "";
                }
                else
                {
                    valorAct = valorAct - y;
                    _cantidad.Text = valorAct.ToString();
                    _restarCantidad.Text = "";     //Setea el textbox en vacio
                }
            }
        }

        protected void ButtonCancelarModalRestar_Click(object sender, EventArgs e)
        {
            _restarCantidad.Text = "";     //Setea el textbox en vacio                
        }

        protected int valorActual() //Verifica si el textbox cantidad posee caracteres validos
        {
            if (string.IsNullOrWhiteSpace(_cantidad.Text.ToString()))   //No resta null
                return (0);
            try
            {
                int valor = Convert.ToInt32(_cantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    return (0);
                else
                    return (valor);
            }
            catch (FormatException)
            {
                _cantidad.Text = "";
                return (0);
            }
        }


        protected void ButtonMasoMenos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_cantidad.Text.ToString()))   //No resta null
                _cantidad.Text = "0";
            try
            {
                int valor = Convert.ToInt32(_cantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    _cantidad.Text = "0";
            }
            catch (FormatException)
            {
                _cantidad.Text = "0";
            }          
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_cantidad.Text.ToString()))   //No resta null
                _cantidad.Text = "0";
            try
            {
                int valor = Convert.ToInt32(_cantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    _cantidad.Text = "0";
            }
            catch (FormatException)
            {
                _cantidad.Text = "0";
            }
        }

        protected bool setTBto0()
        {
            if (string.IsNullOrWhiteSpace(_cantidad.Text.ToString()))   //No resta null
                _cantidad.Text = "0";
            try
            {
                int valor = Convert.ToInt32(_cantidad.Text.ToString()); //Intenta convertir (no letras)
                if (valor < 0)
                    _cantidad.Text = "0";
                return false;
            }
            catch (FormatException)
            {
                _cantidad.Text = "0";
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