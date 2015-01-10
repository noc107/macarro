using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.VentaCierreCaja
{
    public interface IDaoFacturacion : IDao<Entidad, bool, Entidad>
    {
        string ConsultarCorreos();
        Entidad VerificarCorreo(string _correoUsuario);
        List<Entidad> ConsultarDetalleServicio(string _correoUsuario);
    }
}
