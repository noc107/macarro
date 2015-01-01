using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_agregarPuesto : IContratoGeneral
    {
        RadioButtonList RadioOpciones { get; }
        TextBox CampoFila { get; }
        TextBox CampoColumna { get; }
        TextBox CampoDescripcion { get; }
        TextBox CampoPrecio { get; }
        Button BtnAceptar { get; }
    }
}
