using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 

namespace back_office.Dominio
{
	public class Seccion
	{
		private string _nombre; 
		private string _descripcion;
		private bool _estado; 
		private List<Plato> _arregloPlatos;

       
	
		public string Nombre
		{	
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		public string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		public bool Estado 
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		public List <Plato> ArregloPlatos
		{
			get { return _arregloPlatos; }
			set { _arregloPlatos = value; }
		}
		
	}









}