using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_configurarPlaya : IContratoGeneral
    {
        GridView GridPlayaActual { get; }
        TextBox CampoLargoPlaya { get; }
        TextBox CampoAnchoPlaya { get; }
        Button BtnAceptar { get; }
    }
}
