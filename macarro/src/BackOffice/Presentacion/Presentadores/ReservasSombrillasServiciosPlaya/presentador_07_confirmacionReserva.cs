using BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya;
using BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Presentadores.ReservasSombrillasServiciosPlaya
{
    public class presentador_07_confirmacionReserva : PresentadorGeneral
    {
        private IContrato_07_confirmacionReserva _vista;
        //private logica_13_consultar _consultar;


        public presentador_07_confirmacionReserva ( IContrato_07_confirmacionReserva _view )
            : base ( _view )
        {
            _vista = _view;
            //_consultar = new logica_13_consultar ();
        }

        public void consultarReserva ( )
        {
            DataTable _dt = new DataTable ();
            //_dt = _consultar.GetReservasPuesto ( _vista._idReserva );
            if ( _dt != null )
            {
                _vista._tablePuesto.DataSource = _dt;
                _vista._tablePuesto.DataBind ();
            }
            else
            {
                //_dt = _consultar.GetReservasServicio ( _vista._idReserva );
                _vista._tableServicio.DataSource = _dt;
                _vista._tableServicio.DataBind ();
            }
        }

        public void consultar ( )
        {
            string _aux = "";
            DateTime _fecha = System.DateTime.Now;
            DataTable _dt = new DataTable ();
            //_dt = _consultar.GetReserva ( _vista._idReserva );
            foreach ( DataRow dtRow in _dt.Rows )
            {

                foreach ( DataColumn dc in _dt.Columns )
                {
                    _aux = dtRow [ dc ].ToString ();
                }
            }
            _vista._combo.Text = _aux;
            if ( _aux.CompareTo ( "En espera" ) == 0 )
            {
               // _dt = _consultar.GetReservaFecha ( _vista._idReserva );
                foreach ( DataRow dtRow in _dt.Rows )
                {

                    foreach ( DataColumn dc in _dt.Columns )
                    {
                        _aux = dtRow [ dc ].ToString ();
                        _fecha = Convert.ToDateTime ( _aux );
                    }
                }
                if ( _fecha > System.DateTime.Now )
                {
                    _vista._combo.Items.Add ( "En espera" );
                    _vista._combo.Items.Add ( "Cancelado" );
                    _vista._combo.Items.Add ( "Confirmado" );

                }
                else
                {
                    _vista._combo.Items.Add ( "En espera" );
                    _vista._combo.Items.Add ( "Cancelado" );

                }
            }
            else
            {
                _vista._combo.Items.Add ( _aux );
            }
        }

        public void actualizarEstado ( )
        {
            string _aux = _vista._combo.Text;
            //_consultar.EstadoReserva ( _vista._idReserva, _aux );

        
        }

        public void grid_PageIndexChanging ( object sender, GridViewPageEventArgs e )
        {
            DataTable _dt = new DataTable ();
            //_dt = _consultar.GetReservas ();

            _vista._tablePuesto.PageIndex = e.NewPageIndex;
            _vista._tablePuesto.DataSource = _dt;
        }

        public void grid_RowCommand ( object sender, GridViewCommandEventArgs e )
        {
            Int16 _Index;
            DataTable _dt = new DataTable ();
           // _dt = _consultar.GetReservas ();

            _Index = Convert.ToInt16 ( e.CommandArgument );
            _vista._idReserva = _vista._tablePuesto.Rows [ _Index ].Cells [ 0 ].Text;

        }
    }
}