using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 

namespace back_office.Dominio
{
	public class Plato
	{
		private int     _codigo; 
		private string  _nombre;
		private float   _precio; 
		private string  _descripcion;
		private bool    _estado; 
		
		
		public int Codigo
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		public float Precio
		{
			get { return _precio; }
			set { _precio = value; }
		}
		
		public string Descripcion
		{
			get	{ return _descripcion; }
			set { _descripcion = value; }
		}
		
		public bool Estado 
		{
			get { return _estado; }
			set { _estado = value; }
		}
			
	}
}