using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_modificarPuesto : IContratoGeneral
    {
        TextBox CampoFila { get; set; }
        TextBox CampoColumna { get; set; }
        TextBox CampoDescripcion { get; set; }
        TextBox CampoPrecio { get; set; }
        Button BtnAceptar { get; }
        Button BtnCancelar { get; }
    }
}
