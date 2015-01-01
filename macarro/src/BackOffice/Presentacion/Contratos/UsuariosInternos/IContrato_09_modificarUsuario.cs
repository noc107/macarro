using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.UsuariosInternos
{
   public interface IContrato_09_modificarUsuario : IContratoGeneral
    {
        TextBox      Nombre              { get; set; }
        TextBox      SegundoNombre       { get; set; }
        TextBox      Apellido            { get; set; }
        TextBox      SegundoApellido     { get; set; }
        DropDownList TipoDocumento       { get; set; }
        TextBox      Cedula              { get; set; }
        TextBox      FechaNacimiento     { get; set; }
        TextBox      Correo              { get; set; }
        TextBox      Contrasena          { get; set; }
        TextBox      VerificarContrasena { get; set; }
        DropDownList Estatus             { get; set; }
        TextBox      Telefono            { get; set; }
        DropDownList Pais                { get; set; }
        DropDownList Estado              { get; set; }
        DropDownList Ciudad              { get; set; }
        TextBox      Direccion           { get; set; }

    }
}
