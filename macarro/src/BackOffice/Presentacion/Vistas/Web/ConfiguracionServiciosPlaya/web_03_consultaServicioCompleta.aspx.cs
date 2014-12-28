using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya
{
    public partial class web_03_consultaServicioCompleta : System.Web.UI.Page
    {
        //private LogicaModificarServicio _consultaServicio;
        //Servicio _servicio;

        /// <summary>
        /// Carga de datos de un servicio particular al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //string _correoS = (string)(Session["correo"]);
            //string _docIdentidadS = (string)(Session["docIdentidad"]);
            //string _primerNombreS = (string)(Session["primerNombre"]);
            //string _primerApellidoS = (string)(Session["primerApellido"]);

            //if (!Page.IsPostBack)
            //{
            //    _servicio = new Servicio();
            //    _servicio.Nombre = Request.QueryString["Servicio"]; 

            //    this._consultaServicio = new Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio();
                
            //    _servicio = this._consultaServicio.solicitarServicio(_servicio,this.LabelMensaje);
            //    this.mostrarDatosServicio(_servicio);
            //}

        }

        /// <summary>
        /// Mostrar los datos basicos en labels del servicio solicitado
        /// </summary>
        /// <param name="_servicio">Objeto Servicio con sus respectivos valores</param>
        //private void mostrarDatosServicio(Servicio _servicio)
        //{

        //    NombreServcio.Text = _servicio.Nombre;
        //    Descripcion.Text = _servicio.Descripcion;
        //    Categoria.Text = _servicio.Categoria;
        //    LugarRetiro.Text = _servicio.LugarRetiro;
        //    Cantidad.Text = _servicio.Cantidad.ToString();
        //    Capacidad.Text = _servicio.Capacidad.ToString() + " persona(s)";
        //    Costo.Text = _servicio.Costo.ToString() + " $";

        //    if (_servicio.Estado == true)
        //    {
        //        Estado.Text = "Activo";
        //    }
        //    else
        //    {
        //        Estado.Text = "Desactivo";
        //    }

        //    mostrarHorarioServicio(_servicio);

        //}


        ///// <summary>
        ///// Mostrar la lista de horarios del servicio solicitado
        ///// </summary>
        ///// <param name="_servicio">Objeto Servicio del cual se mostraran los horarios</param>
        //public void mostrarHorarioServicio(Servicio _servicio) 
        //{
        //    string _horario = "";
        //    bool _primera = true;

        //    foreach (HorarioServicio _itemHora in _servicio.obtenerListaHorario())
        //    {
        //        string _horaInicio;
        //        string _horaFin;

        //        _horaInicio = this.obtenerHoraString(_itemHora.HoraInicio);
        //        _horaFin = this.obtenerHoraString(_itemHora.HoraFin);

        //        if (_primera == true)
        //        {
        //            _horario = _horaInicio + " a " + _horaFin;
        //            _primera = false;
        //        }
        //        else
        //        {
        //            _horario = _horario + "<br />" + _horaInicio + " a " + _horaFin;
        //        }
        //    }

        //    Horario.Text = _horario;
        
        //}


        ///// <summary>
        ///// Dado un DateTime permite conocer el string de la hora en el formato manejado
        ///// </summary>
        ///// <param name="_itemHora">El DateTime que se pasará al formato string</param>
        ///// <returns>El string con el formato de hora</returns>
        //private string obtenerHoraString(DateTime _itemHora)
        //{
        //    int _horaTempInicio = 0;            
        //    string _horaInicio;
        //    bool _esTarde = false;            
            
        //    if (_itemHora.Hour >= 12)
        //    {
        //        _horaTempInicio = _itemHora.Hour - 12;
        //        _esTarde = true;
        //    }
        //    else
        //        _horaTempInicio = _itemHora.Hour;

        //    if (_horaTempInicio <= 9)
        //        _horaInicio = "0" + _horaTempInicio.ToString();
        //    else
        //        _horaInicio = _horaTempInicio.ToString();

        //    if (_itemHora.Minute <= 9)
        //        _horaInicio = _horaInicio + ":0" + _itemHora.Minute.ToString();
        //    else
        //        _horaInicio = _horaInicio + ":" + _itemHora.Minute.ToString();

        //    if (_esTarde)
        //        _horaInicio = _horaInicio + " pm";
        //    else
        //        _horaInicio = _horaInicio + " am";

        //    return _horaInicio;
        //}

        /// <summary>
        /// Evento asociado al boton que permite volver a la consulta general
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void VolverConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_03_consultaServicio.aspx");
        }

    }
}