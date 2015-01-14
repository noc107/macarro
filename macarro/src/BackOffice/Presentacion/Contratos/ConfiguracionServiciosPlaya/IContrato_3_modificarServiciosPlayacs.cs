using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya
{
    public interface IContrato_3_modificarServiciosPlaya : IContratoGeneral
    {
        Label lNombreServicio { set; }//labelNombreServicio
        TextBox NombreServicio { get; }//inputNombreServcio
        Label lDescripcion { set; }//labelDescripcion
        TextBox Descripcion { get; }//inputDescripcion
        Label lCategoria { set; }//labelCategoria
        DropDownList ListaCategoria { get; }//dropdownlistCategoria
        Label lOtraCategoria { set; }//LabelCategoriaOtro
        TextBox OtraCategoria { get; } //inputCategoriaOtro
        Label lLugarRetiro { set; }//labelLugarRetiro
        TextBox LugarRetiro { get; }//inputLugarRetiro
        Label lCantidad { set; }//labelCantidad
        TextBox Cantidad { get; }//inputCantidad
        Label lCapacidad { set; }//labelCapacidad
        TextBox Capacidad { get; }//inputCapacidad
        Label lCosto { set; }//labelCosto
        TextBox Costo { get; }//inputCosto
        Label TituloHorario { set; }//ltituloHorario
        Label NotaHorario { set; }//notaHorario
        Label lHoraInicio { set; }//labelHoraInicio
        TextBox HoraInicio { get; }//timePickerInicio
        Label ErrorAgregarHorario { set; }//mensajeErrorAgregarHorario
        Label lHoraFin { set; }//labelHoraFin
        TextBox HoraFin { get; } //timePickerFin
        Label ErrorEliminarHorario { set; }//mensajeErrorEliminarHorario
        Label HorarioRepetido { set; }//mensajeHorarioRepetido
        Label HorarioOcupado { set; }//mensajeHorarioOcupado
        Label lHorario { set; }//labelHorario

        ListBox ListaHorario { get; }//listboxHorario

        Label lEstado { set; }//labelEstado
        DropDownList ListaEstado { get; }//dropdownlistEstado
        Label lNombreOriginal { set; } //nombreOriginal
        Label lCategoriaNueva { set; }//categoriaNueva
    }
}
