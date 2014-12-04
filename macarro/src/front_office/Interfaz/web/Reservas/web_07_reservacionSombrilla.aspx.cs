using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace front_office.Interfaz.web.Reservas
{
    public partial class web_07_reservacionSombrilla : System.Web.UI.Page
    {
        ImageButton puesto;
        TableRow tRow;
        TableCell tCell;
        // numero total de filas
        int rowCnt;
        // fila actual
        int rowCtr;
        // numero total de celdas por fila(columnas)
        int cellCtr;
        // celda actual
        int cellCnt;

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarMatriz();
        }

        private void llenarMatriz()
        {
            rowCnt = int.Parse("10") + 2;
            cellCnt = int.Parse("20") + 2;

            int contador = rowCnt;
            int num = 2;
            int x = rowCnt;
            for (rowCtr = 1; rowCtr <= rowCnt; rowCtr++)
            {
                if (!rowCtr.Equals(rowCnt - 3))
                    x--;
                // crea una nueva fila y la agrega en la tabla.
                tRow = new TableRow();
                tabla.Rows.Add(tRow);
                int y = 1;
                for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++)
                {
                    // crea una nueva celda y la agrega en la tabla.
                    tCell = new TableCell();
                    tCell.CssClass = "celda";
                    tCell.Style.Add("width", "35px");
                    tCell.Style.Add("height", "35px");
                    tCell.Style.Add("color", "#2980B9");

                    if ((rowCtr.Equals(1)) && (cellCtr.Equals(1)))
                    {
                        tCell.Text = "n°";
                    }
                    else if ((rowCtr.Equals(1) && cellCtr != 1))
                    {
                        if (!cellCtr.Equals(((cellCnt) / 2) + 1))
                        {
                            if (num == cellCtr)
                            {
                                tCell.Text = Convert.ToString(cellCtr - 1);
                                num++;
                            }
                            else if (num != cellCtr)
                            {
                                tCell.Text = Convert.ToString(cellCtr - 2);
                                num++;
                            }
                        }
                    }
                    else if ((rowCtr != 1) && (cellCtr.Equals(1)))
                    {
                        if (!rowCtr.Equals(rowCnt - 3))
                        {
                            tCell.Text = Convert.ToString(contador - 2);
                            contador--;
                        }
                    }
                    else if ((rowCtr != 1) && (cellCtr != 1))
                    {
                        if ((!cellCtr.Equals(((cellCnt) / 2) + 1)) && (!rowCtr.Equals(rowCnt - 3)))
                        {
                            puesto = new ImageButton();
                            puesto.ID = "bPuesto_" + x + "_" + y;
                            puesto.ImageUrl = "../../../comun/resources/img/cuadrados.png";
                            puesto.Height = 35;
                            puesto.Width = 35;
                            puesto.Click += new ImageClickEventHandler(this.puestoBtn_Click);
                            tCell.Controls.Add(puesto);
                            y++;
                        }
                    }
                    tRow.Cells.Add(tCell);
                }
            }
        }

        private string buscarPosicion(string id)
        {
            string[] puesto = id.Split('_','_');
            string x = puesto[1];
            string y = puesto[2];
            return x +"-"+ y;
        }


        protected void puestoBtn_Click(object sender, EventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            if (b.ImageUrl.Equals("../../../comun/resources/img/cuadrados.png"))
            {
                b.ImageUrl = "../../../comun/resources/img/cuadradosVerde.png";
                lpuesto.Text = buscarPosicion(b.ID);
            }
            else if (b.ImageUrl.Equals("../../../comun/resources/img/cuadradosVerde.png"))
            {
                b.ImageUrl = "../../../comun/resources/img/cuadrados.png";
            }
            
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_reservacionSombrilla1.aspx");
        }
    }
}