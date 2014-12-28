using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_reservacionSombrilla : System.Web.UI.Page
    {
        //float _total = 0f;
        //ImageButton _puesto;
        //TableRow tRow;
        //TableCell tCell;
        //ListaPuesto _listaOcupados;
        //List<Puesto> _lista = new List<Puesto>();
        //ListaPuesto _listaReserva = new ListaPuesto();
        //LogicaReservaSombrilla _log = new LogicaReservaSombrilla();
        
        //// numero total de filas
        //int rowCnt;
        //// fila actual
        //int rowCtr;
        //// numero total de celdas por fila(columnas)
        //int cellCtr;
        //// celda actual
        //int cellCnt;

        protected void Page_Load(object sender, EventArgs e)
        {
            //llenarMatriz();
        }

        private void llenarMatriz()
        {
            //_listaOcupados = _log.buscarPuestosOcupados();
            //Puesto _playa = new Puesto();
            //_playa = _log.traerTamanoPlaya();

            //rowCnt = _playa.Fila + 2;
            //cellCnt = _playa.Columna + 2;

            //int contador = rowCnt;
            //int num = 2;
            //int x = rowCnt;
            //for (rowCtr = 1; rowCtr <= rowCnt; rowCtr++)
            //{
            //    if (!rowCtr.Equals(rowCnt - 3))
            //        x--;
            //    // crea una nueva fila y la agrega en la tabla.
            //    tRow = new TableRow();
            //    tabla.Rows.Add(tRow);
            //    int y = 1;
            //    for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++)
            //    {
            //        // crea una nueva celda y la agrega en la tabla.
            //        tCell = new TableCell();
            //        tCell.CssClass = "celda";
            //        tCell.Style.Add("width", "35px");
            //        tCell.Style.Add("height", "35px");
            //        tCell.Style.Add("color", "#2980B9");

            //        if ((rowCtr.Equals(1)) && (cellCtr.Equals(1)))
            //        {
            //            tCell.Text = "n°";
            //        }
            //        else if ((rowCtr.Equals(1) && cellCtr != 1))
            //        {
            //            if (!cellCtr.Equals(((cellCnt) / 2) + 1))
            //            {
            //                if (num == cellCtr)
            //                {
            //                    tCell.Text = Convert.ToString(cellCtr - 1);
            //                    num++;
            //                }
            //                else if (num != cellCtr)
            //                {
            //                    tCell.Text = Convert.ToString(cellCtr - 2);
            //                    num++;
            //                }
            //            }
            //        }
            //        else if ((rowCtr != 1) && (cellCtr.Equals(1)))
            //        {
            //            if (!rowCtr.Equals(rowCnt - 3))
            //            {
            //                tCell.Text = Convert.ToString(contador - 2);
            //                contador--;
            //            }
            //        }
            //        else if ((rowCtr != 1) && (cellCtr != 1))
            //        {
            //            if ((!cellCtr.Equals(((cellCnt) / 2) + 1)) && (!rowCtr.Equals(rowCnt - 3)))
            //            {
            //                Puesto _pues = new Puesto(x,y);

            //                if (!_listaOcupados.buscarPuesto(_pues))
            //                {
            //                    _puesto = new ImageButton();
            //                    _puesto.ID = "bPuesto_" + x + "_" + y;
            //                    _puesto.ImageUrl = "../../../comun/resources/img/cuadrados.png";
            //                    _puesto.Height = 35;
            //                    _puesto.Width = 35;
            //                    _puesto.Click += new ImageClickEventHandler(this.puestoBtn_Click);
            //                    tCell.Controls.Add(_puesto);
            //                }
            //                else if (_listaOcupados.buscarPuesto(_pues))
            //                {
            //                    _puesto = new ImageButton();
            //                    _puesto.ID = "bPuesto_" + x + "_" + y;
            //                    _puesto.ImageUrl = "../../../comun/resources/img/cuadradosPlayaRojo.png";
            //                    _puesto.Height = 35;
            //                    _puesto.Width = 35;
            //                    _puesto.Enabled = false;
            //                    tCell.Controls.Add(_puesto);
            //                }
            //                y++;
            //            }
            //        }
            //        tRow.Cells.Add(tCell);
            //    }
            //}
        }

        //public float buscarPosicion(string id, string hacer)
        //{
            //Puesto _pues = new Puesto();
            //string[] _puesto = id.Split('_','_');
            //string x = _puesto[1];
            //string y = _puesto[2];
            //_pues = _log.traerPrecioPuesto(Convert.ToInt32(x), Convert.ToInt32(y));
            //_pues.Fila = Convert.ToInt32(x);
            //_pues.Columna = Convert.ToInt32(y);
            //string precio = x + " - " + y + "........." + _pues.Precio;
            //if (hacer.Equals("agregar"))
            //{
            //    _listaReserva.agregarPuesto(_pues);
            //    this.l_puesto.Items.Add(precio);
            //}
            //else if (hacer.Equals("quitar"))
            //{
            //    _listaReserva.eliminarPuesto(_pues);
            //    this.l_puesto.Items.Remove(precio);
            //}
            //return _pues.Precio;
       // }


        protected void puestoBtn_Click(object sender, EventArgs e)
        {
            //ImageButton _b = (ImageButton)sender;
            //if (_b.ImageUrl.Equals("../../../comun/resources/img/cuadrados.png"))
            //{
            //    _b.ImageUrl = "../../../comun/resources/img/cuadradosVerde.png";
            //    float total = buscarPosicion(_b.ID, "agregar");
            //    _total = float.Parse(l_total.Text) + total;
            //    this.l_total.Text = _total.ToString();
            //}
            //else if (_b.ImageUrl.Equals("../../../comun/resources/img/cuadradosVerde.png"))
            //{
            //    _b.ImageUrl = "../../../comun/resources/img/cuadrados.png";
            //    float total = buscarPosicion(_b.ID, "quitar");
            //    _total = float.Parse(l_total.Text) - total;
            //    this.l_total.Text = _total.ToString();
            //}
            
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            //Puesto _puesto = new Puesto();
            //int n = 0;
            //string _horai = Session["horaI"].ToString();
            //string _horaf = Session["horaF"].ToString();
            //while (n < _listaReserva.cantidadPuesto())
            //{
            //    _puesto = _listaReserva.getPuestoAt(n);
            //    if (_log.agregarPuesto(_horai, _horaf, _puesto.Fila, _puesto.Columna))
            //    {
            //        Response.Redirect("../inicio.aspx");
            //    }
            //}

        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }
    }
}