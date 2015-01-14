using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Dominio;
using back_office.Logica.UsuariosInternos;
using NUnit.Framework;
using back_office.Excepciones.UsuariosInternos;
using back_office.Datos.RolesSeguridad;

namespace unit_tests_back_office.Logica.UsuariosInternos
{
    [TestFixture]
    class PruebasLogicaUsuariosInternos
    {
        private string _correo = string.Empty;
        private string _docIDentidad = string.Empty;
        private string _direccion = string.Empty;
        private Rol _rol;
        private Usuario _usuario;
        private Persona _persona;
        private Empleado _empleado;
        private List<Rol> _listaRoles;
        private UsuariosInternosLogica _usuariosLogica;
        private RolBD _rolBD;
        private Lugar _lugar;


        [SetUp]
        public void InicializarPrueba()
        {
            _correo = "rosario@gmail.com";
            _docIDentidad = "19181716";
            _direccion = "La California";
            _listaRoles = new List<Rol>();
            _rol = new Rol();

            _usuario = new Usuario(_correo, "contrase", "Empleado", "Activado", Convert.ToDateTime(null), Convert.ToDateTime(null), null, null, _docIDentidad, "08/15/2014", "12/15/2014");
            _persona = new Persona(_docIDentidad, "Cedula", "Rosario", "", "Vivas", "Silva", Convert.ToDateTime(null), 32, "11/11/1990");
            _empleado = new Empleado(_persona, _usuario);
            _usuariosLogica = new UsuariosInternosLogica();
            _rolBD = new RolBD();

        }

        [Test]
        public void PruebaAgregarUsuarioLogica()
        {
            Assert.IsTrue(_usuariosLogica.AgregarEmpleado(_empleado, 23, "La florida"));
        }

        [Test]
        [ExpectedException(typeof(ExcepcionUsuariosInternosLogica))]
        public void PruebaAgregarUsuarioLogicaExcepcion()
        {
            _usuariosLogica.AgregarEmpleado(null, 23, "La florida");
        }

        [Test]
        public void PruebaModificarUsuarioLogica()
        {
            _usuario = new Usuario(_correo, "contrase", "Empleado", "Activado", Convert.ToDateTime(null), Convert.ToDateTime(null), null, null, _docIDentidad, "08/15/2014", "12/15/2014");
            _persona = new Persona(_docIDentidad, "Cedula", "Zuleyma", "Milagros", "Bustamante", "La Rosa", Convert.ToDateTime(null), 32, "11/15/1990");
            _empleado = new Empleado(_persona, _usuario);
            Assert.IsTrue(_usuariosLogica.ModificarEmpleado(_empleado, 23, _direccion));
        }

        [Test]
        public void PruebaAgregarRolesUsuarioLogica()
        {
            _empleado = _usuariosLogica.EmpleadoUnico(_docIDentidad);
            _listaRoles = _usuariosLogica.ConsultarRolesEmpleado(_empleado);
            int cantidadRoles = _listaRoles.Count();
            List<Rol> _listaRolesEmpleado = new List<Rol>();
            _listaRolesEmpleado.Add(_rolBD.ConsultarRolesGeneral().ElementAt(2));

            Assert.IsTrue(_usuariosLogica.AgregarListaRolesEmpleado(_correo, _listaRolesEmpleado));
        }

        [Test]
        public void PruebaConsultarRolesDisponiblesLogica()
        {
            _empleado = _usuariosLogica.EmpleadoUnico(_docIDentidad);
            _listaRoles = _usuariosLogica.ConsultarRolesEmpleado(_empleado);

            foreach (Rol item in _listaRoles)
            {
                Assert.AreNotEqual(_usuariosLogica.ConsultarRolesDisponibles(_correo).IndexOf(item), 0);
            }
        }

        [Test]
        public void PruebaObtenerDireccionlogica()
        {
            _empleado = _usuariosLogica.EmpleadoUnico(_docIDentidad);
            Assert.AreEqual(_usuariosLogica.ObtenerDireccion(_empleado.Persona.FkLugar), _direccion);
        }

        [Test]
        public void PruebaObtenerDireccionCompletaLogica()
        {
            _empleado = _usuariosLogica.EmpleadoUnico(_docIDentidad);
            Assert.AreEqual(_usuariosLogica.ConsultarDireccionCompleta(_empleado.Persona.FkLugar).Count, 3);
        }

        [Test]
        public void PruebaObetenerDireccionConcadenadaLogica()
        {
            string[] arreglo = null;
            _empleado = _usuariosLogica.EmpleadoUnico(_docIDentidad);
            arreglo = _usuariosLogica.ObtenerDireccionConcatenada(_empleado.Persona.FkLugar).Split('-');
            Assert.AreEqual(arreglo.Count(), 4);
        }

        [Test]
        public void PruebaConsultarEmpleadosLogica()
        {
            Assert.IsNotNull(_usuariosLogica.ListaEmpleados());
        }

        [Test]
        public void PruebaConsultarRoles()
        {
            Assert.IsNotNull(_usuariosLogica.ConsultarRolesDisponibles(_correo));
        }

        //[Test]
        //public void PruebaEliminarRolesUsuario()
        //{
        //    Assert.IsTrue(_logica.EliminarRolesEmpleado(_correo,_rol));
        //}

        //[Test]
        //public void PruebaLlenarComboPaises()
        //{
        //    Assert.IsNotEmpty(_logica.LlenarCBPaises());
        //}

        //[Test]
        //public void PruebaLlenarComboEstados()
        //{
        //    Assert.IsNotEmpty(_logica.LlenarCBEstado(1));
        //}

        [Test]
        public void PruebaEliminarUsuarioNuevo()
        {
            Assert.IsTrue(_usuariosLogica.EliminarEmpleadoNuevo(_correo));
        }

        [Test]
        [ExpectedException (typeof(ExcepcionUsuariosInternosLogica) )]
        public void ExcepcionConsultarRolesDisponibles()
        {
            _usuariosLogica.ConsultarRolesDisponibles(null);
         }

    }
}