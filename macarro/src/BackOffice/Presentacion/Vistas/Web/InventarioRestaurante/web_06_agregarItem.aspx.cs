using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Presentadores.InventarioRestaurante;
using BackOffice.Presentacion.Contratos.InventarioRestaurante;

namespace BackOffice.Presentacion.Vistas.Web.InventarioRestaurante
{
    public partial class web_06_agregarItem : System.Web.UI.Page, IContrato_06_agregarItem
    {
        private Presentador_06_agregarItem _presentador;

        public web_06_agregarItem() 
        {
            this._presentador = new Presentador_06_agregarItem(this);
        }

        public TextBox CantidadMinima 
        {
            get
            {
                return this.tbCantidadMinima;
            }
        
        }

        public TextBox TbNombre
        {
            get
            {
                return this.Nombre; 
            }
        }

        public TextBox TbCantidad
        {
            get
            {
                return this.Cantidad;
            }
        }

        public TextBox Descripcion
        {
            get
            {
                return this.tbDescripcion;
            }
        }

        public TextBox Precio
        {
            get
            {
                return this.tbPrecio;
            }
        }

        public TextBox Precio2
        {
            get
            {
                return this.tbPrecio2;

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
            //ProcedimientosItem _procedimiento = new ProcedimientosItem();
            //try
            //{
            //    string[] _proveedores = _procedimiento.verProveedor();
            //    for (int _contador = 0; _contador < _proveedores.Length; _contador++)
            //    {
            //        ListItem oItem = new ListItem(_proveedores[_contador]);
            //        Proveedores.Items.Add(oItem);
            //    }
            //}
            //catch (ExcepcionVerItem)
            //{
            //    MensajeFallo.Text = "Ha ocurrido un error de base de datos, por favor intente mas tarde";
            //    MensajeFallo.Visible = true;

            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        ProcedimientosItem _procedimiento = new ProcedimientosItem();
        //        float _precioCompra = float.Parse(tbPrecio2.Text);
        //        float _precioVenta = float.Parse(tbPrecio.Text);
        //        int _cantidad = int.Parse(Cantidad.Text);
        //        int _cantidadMinima = int.Parse(tbCantidadMinima.Text);
        //        if (_precioVenta < _precioCompra)
        //        {
        //            MensajeFallo.Text = "El precio de venta no puede ser menor al precio de compra";
        //            MensajeFallo.Visible = true;
        //        }
        //        else if (_cantidad < _cantidadMinima)
        //        {
        //            MensajeFallo.Text = "La cantidad no puede ser menor a la cantidad minima";
        //            MensajeFallo.Visible = true;
        //        }
        //        else
        //        {
        //            try
        //            {

        //                bool _exito = _procedimiento.guardarItem(Nombre.Text, Convert.ToInt32(Cantidad.Text),
        //                            float.Parse(tbPrecio2.Text), float.Parse(tbPrecio.Text), tbDescripcion.Text, Proveedores.Text,
        //                            Convert.ToInt32(tbCantidadMinima.Text));

        //                if (_exito)
        //                {

        //                    MensajeFallo.Visible = false;
        //                    MensajeExito.Visible = true;
        //                    Nombre.Text = "";
        //                    tbCantidadMinima.Text = "";
        //                    tbDescripcion.Text = "";
        //                    tbPrecio.Text = "";
        //                    tbPrecio2.Text = "";
        //                    Cantidad.Text = "";
        //                }
        //                else
        //                {
        //                    MensajeFallo.Visible = true;
        //                }
        //            }
        //            catch (ExcepcionAgregarItem)
        //            {
        //                MensajeFallo.Text = "El ítem no ha podido ser creado debido a que existe un conflicto con la conexión a la base de datos.";
        //                MensajeFallo.Visible = true;
        //            }
        //            catch (Exception)
        //            {
        //                MensajeFallo.Text = "Su operacion no pudo ser procesada, por favor contacte con el administrador";
        //                MensajeFallo.Visible = true;
        //            }
        //        }
        //    }
        //    catch (FormatException)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg",
        //        "alert('¡Formato Incorrecto de precio!');", true);
        //    }
        }



        public TextBox cantidadMinima
        {
            get { throw new NotImplementedException(); }
        }

        public TextBox nombre
        {
            get { throw new NotImplementedException(); }
        }

        public TextBox cantidad
        {
            get { throw new NotImplementedException(); }
        }

        public TextBox descripcion
        {
            get { throw new NotImplementedException(); }
        }

        public TextBox precioVenta
        {
            get { throw new NotImplementedException(); }
        }

        public TextBox precioCompra
        {
            get { throw new NotImplementedException(); }
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
    }
}