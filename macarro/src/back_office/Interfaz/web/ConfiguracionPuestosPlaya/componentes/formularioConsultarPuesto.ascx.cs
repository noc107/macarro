using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Logica.ConfiguracionPuestosPlaya;
using back_office.Dominio;
using System.Data;

namespace back_office.Interfaz.web.ConfiguracionPuestosPlaya.componentes
{
    public partial class formularioConsultarPuesto : System.Web.UI.UserControl
    {
        #region atributos
        private string _fila;
        private string _columna;
        protected LogicaPuesto logica;
        private Puesto[] listapuesto;
        #endregion 
       
        
        #region propiedades
        public string Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }

        public string Columna
        {
            get { return _columna; }
            set { _columna = value; }
        }
        
        #endregion

        #region validacion
        protected void listaDeOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaDeOpciones.SelectedValue == "0")
            {
                fila.Enabled = false;
                columna.Enabled = false;

            }
            if (listaDeOpciones.SelectedValue == "1")
            {
                fila.Enabled = true;
                columna.Enabled = false;

            }
            if (listaDeOpciones.SelectedValue == "2")
            {
                fila.Enabled = false;
                columna.Enabled = true;

            }
            if (listaDeOpciones.SelectedValue == "3")
            {
                fila.Enabled = true;
                columna.Enabled = true;

            }


        }

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            fila.Enabled = false;
            columna.Enabled = false; 
             
        }
        //validacion del check de  consulta puesto 
      
        

        protected void botonBuscar_Click(object sender, EventArgs e)
        {
            _fila = fila.Text;
            _columna = columna.Text;
            cargarTablaPuesto(_fila, _columna);
          

        }

        //carga el datagridview de puesto
        public void cargarTablaPuesto(string filap, string columnap)
        {
            try
            {

                
                DataTable _miTabla = new DataTable();
                logica = new LogicaPuesto();
                listapuesto = logica.busquedaPuesto(filap, columnap);

                _miTabla.Columns.Add("Fila ", typeof(int));
                _miTabla.Columns.Add("Columna", typeof(int));
                _miTabla.Columns.Add("Descripcion", typeof(string));
                _miTabla.Columns.Add("Monto ", typeof(float));

                foreach (Puesto puestol in listapuesto)
                {
                   
                    _miTabla.Rows.Add(puestol.Fila,puestol.Columna, puestol.Descripcion, puestol.Precio);

                }
                
                GridView_ConsultarPuesto.DataSource = _miTabla;
                GridView_ConsultarPuesto.DataBind();
            }
            catch (NullReferenceException e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcion, _mensajeExcepcionNullObject, e);
            }
            
        }

    }
}