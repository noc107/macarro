using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_modificarPuesto : IContratoGeneral
    {
        TextBox CampoFila { get; }
        TextBox CampoColumna { get; }
        TextBox CampoDescripcion { get; }
        TextBox CampoPrecio { get; }
        Button BtnAceptar { get; }
        Button BtnCancelar { get; }
    }
}
