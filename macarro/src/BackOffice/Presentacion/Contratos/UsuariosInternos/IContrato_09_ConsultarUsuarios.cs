using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.UsuariosInternos
{
   public interface IContrato_09_ConsultarUsuarios : IContratoGeneral
    {
        Label   Nombre           {get; set;}
        Label   SegundoNombre    {get; set;}
        Label   Apellido         {get; set;}
        Label   SegundoApellido  {get; set;}
        Label   TipoDocumento    {get; set;}
        Label   Cedula           {get; set;}
        Label   FechaNacimiento  {get; set;}
        Label   Estatus          {get; set;}
        Label   Telefono         {get; set;}
        Label   Correo           {get; set;}
        Label   FechaIngreso     {get; set;}
        Label   FechaEgreso      {get; set;}
        Label   Direccion        {get; set;}
        ListBox ListaCargos      {get; set;}
        

    }
}