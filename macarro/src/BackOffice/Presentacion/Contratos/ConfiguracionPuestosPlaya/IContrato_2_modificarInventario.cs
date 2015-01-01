using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_modificarInventario : IContratoGeneral
    {
        TextBox CampoPrecio { get; }
        DropDownList DropEstado { get; }
        TextBox CampoDescripcion { get; }
        Button BtnAceptar { get; }
        Button BtnCancelar { get; }
    }
}
