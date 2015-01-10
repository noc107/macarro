using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;

namespace BackOffice.FuenteDatos.IDao.UsuariosInternos
{
    public interface IDaoLugar : IDao<Entidad, bool, Entidad>
    {
        List<Entidad> LlenarCBPaisesBD();
        List<Entidad> LlenarCBEstadoBD(int parametro);
        List<Entidad> LlenarCBCiudadBD(int parametro);
        string ObtenerDireccionBD(int direccion);
        List<int> ConsultarDireccionCompleta(int parametro); 
        
    }
}