using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya
{
    public interface IContrato_3_agregarServicio : IContratoGeneral
    {
        Label lNombreServicio { set; }
        TextBox NombreServicio { get; }
        Label lDescripcion { set; }
        TextBox DescripcionServicio { get; }
        Label lCategoria { set; }
        DropDownList ListaCategorias { get; }
        Label lOtraCategoria { set; }
        TextBox OtraCategoria { get; }
        Label lLugarRetiro { set; }
        TextBox LugarRetiro { get; }
        Label lCantidad { set; }
        TextBox Cantidad { get; }
        Label lCapacidad { set; }
        TextBox Capacidad { get; }
        Label lCosto { set; }
        TextBox Costo { get; }
        Label TituloHorario { set; }

        Label NotaHorario { set; }
        Label lHoraInicio { set; }

        TextBox HoraInicio { get; }
        TextBox HoraFin { get; }
        ListBox Horarios { get; }
        Label ErrorEliminarHorario { set; }
        Label HorarioRepetido { set; }
        Label LHorario { set; }



    }
}
