using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Membresia
{
    public interface IDaoPago : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarPagoXIdMembresia(int Id);
        List<Entidad> ConsultarPagoXIdMembresiaYFechaPago(int Id,DateTime fPago);
        Entidad ConsultarDetallePago(int Id, int IdPago);
    }
}