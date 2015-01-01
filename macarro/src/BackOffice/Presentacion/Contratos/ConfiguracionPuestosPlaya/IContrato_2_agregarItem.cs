using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_agregarItem : IContratoGeneral
    {
        DropDownList DropTipoItem { get; }
        TextBox CampoPrecio { get; }
        TextBox CampoCantidad { get; }
        Button BtnAceptar { get; }
    }
}
