using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_consultarPuesto : IContratoGeneral
    {
        RadioButtonList RadioOpciones { get; }
        TextBox CampoFila { get; }
        TextBox CampoColumna { get; }
        Button BtnBuscar { get; }
        GridView GridPuestos { get; }
        Button BtnModificar { get; }
        Button BtnEliminar { get; }
    }
}
