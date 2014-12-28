using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*using back_office.Dominio;
using back_office.Logica.VentaCierreCaja;*/

namespace back_office.Interfaz.web.VentaCierreCaja
{
    public partial class WebForm7 : System.Web.UI.Page
    {
    /*    public static Caja caja;
        public static Caja caja2;
        public static Caja caja3;*/

        protected void Page_Load(object sender, EventArgs e)
        {
           /* LogicaCaja logica = new LogicaCaja();
            caja = logica.CalcularEntradas();
            LogicaCaja logica2 = new LogicaCaja();
            caja2 = logica2.CalcularSaldoInicial();
            LogicaCaja logica3 = new LogicaCaja();
            caja3 = logica3.CalcularSaldoActual(caja2.SaldoInicial, caja.Entrada);
            this.Entrada.Text = caja.Entrada.ToString() + " Bs.F";
            this.SaldoAnterior.Text = caja2.SaldoInicial.ToString() + " Bs.F";
            this.SaldoActual.Text = caja3.SaldoActual.ToString() + " Bs.F";
            this.Fecha.Text = DateTime.Today.ToString("d");*/
        }

        protected void BotonCerrarCaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_gestionarVenta.aspx");
        }
    }
}