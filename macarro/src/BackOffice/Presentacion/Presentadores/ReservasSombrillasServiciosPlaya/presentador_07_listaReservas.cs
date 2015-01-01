using BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Presentadores.ReservasSombrillasServiciosPlaya
{
    public class presentador_07_listaReservas : PresentadorGeneral
    {
        private IContrato_07_listaReserva _vista;
        //private logica_13_consultar _consultar;

        public presentador_07_listaReservas ( IContrato_07_listaReserva _view ) : base ( _view )
        {
            _vista = _view;
            //_consultar = new logica_13_consultar ();
            
        }

        public void  Cargar_Reservas ()
        {
            DataTable _dt = new DataTable ();
            //_dt = _consultar.GetReservas ();
            
            _vista._table.DataSource = _dt;
            _vista._table.DataBind ();
        
        }

        public void grid_PageIndexChanging ( object sender, GridViewPageEventArgs e )
        {
            DataTable _dt = new DataTable ();
            //_dt = _consultar.GetReservas ();
            
            _vista._table.PageIndex = e.NewPageIndex;
            _vista._table.DataSource = _dt;
        }

        public void grid_RowCommand ( object sender, GridViewCommandEventArgs e)
        {
            Int16 _Index;
            DataTable _dt = new DataTable ();
            //_dt = _consultar.GetReservas ();

            _Index = Convert.ToInt16 ( e.CommandArgument );
            _vista._idReserva = _vista._table.Rows [ _Index ].Cells [ 0 ].Text;
            
        }

        public void grid_RowEditing ()
        {
           
        }


    }
}