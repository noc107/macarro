using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_Facturacion : PresentadorGeneral
    {
        private IContrato_07_Facturacion _contratoFacturacion;
        private DataTable _dt;


        public SqlConnection _cn;
        public DataSet _ds = new DataSet();
        private SqlDataReader _rdr;
        public SqlCommand cmd;

        public Presentador_07_Facturacion(IContrato_07_Facturacion _contratoFacturacion)
            : base(_contratoFacturacion)
        { 
            this._contratoFacturacion = _contratoFacturacion;
        }

        public string CargarBuscadorCorreos()
        {
            string _listaCorreos = String.Empty;
            this._cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MACARRO"].ConnectionString);
            this._cn.Open();
            cmd = new SqlCommand("Procedure_buscarCorreosClientes", this._cn);
            cmd.CommandType = CommandType.StoredProcedure;
            

            this._rdr = cmd.ExecuteReader();

            while (this._rdr.Read())
            {
                _listaCorreos += (string)this._rdr["USU_correo"];
                _listaCorreos += " ";
                
            }

            this._rdr.Close();
            this._cn.Close();

            return _listaCorreos;
        }

        public void Page_Load(String solicitudModificar)
        {
            if (solicitudModificar == null) //Se creara una nueva factura
            {

                this._contratoFacturacion.panelBloques.Visible = false;
                this._contratoFacturacion.panelBloqueNuevo.Visible = true;
                this._dt = new DataTable();
                this._contratoFacturacion.gridServicio.DataSource = this._dt;
                this._contratoFacturacion.gridServicio.DataBind();

                this._dt = new DataTable();
                this._contratoFacturacion.gridFactura.DataSource = this._dt;
                this._contratoFacturacion.gridFactura.DataBind();
                this._contratoFacturacion.labelTotal = "Total";
            }
            
        }

        public void botonCrearFactura()
        {
            //Se debe validar que el correo exista en la bd
            this._contratoFacturacion.textBoxCorreoCliente.Enabled = false;
            this._contratoFacturacion.panelBloqueNuevo.Visible = false;
            this._contratoFacturacion.panelBloques.Visible = true;
        }
        
    }
}