using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.UsuariosInternos
{
    public interface IContrato_09_PerfilUsuario :IContratoGeneral
    {
        
        TextBox         Nombre                  { get; set; }        
        TextBox         SegundoNombre           { get; set; }        
        TextBox         Apellido                { get; set; }        
        TextBox         SegundoApellido         { get; set; }        
        TextBox         Cedula                  { get; set; }       
        TextBox         Correo                  { get; set; }       
        TextBox         NuevaContrasena         { get; set; }       
        TextBox         VerificarContrasena     { get; set; }        
        TextBox         FechaNacimiento         { get; set; }       
        DropDownList    Pais                    { get; set; }        
        TextBox         Direccion               { get; set; }        
        DropDownList    Estado                  { get; set; }        
        DropDownList    Ciudad                  { get; set; }        
        TextBox         Telefono                { get; set; }

    }
}