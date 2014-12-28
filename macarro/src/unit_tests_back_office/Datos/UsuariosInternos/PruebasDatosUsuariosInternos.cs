using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_office.Dominio;
using NUnit.Framework;
using back_office.Datos.UsuariosInternos;
using back_office.Datos.RolesSeguridad;
using back_office.Excepciones.UsuariosInternos;

namespace unit_tests_back_office.Datos.UsuariosInternos
{
    [TestFixture]
    class PruebasDatosUsuariosInternos
    {
        [TestFixture]
        public class PruebasUsuariosInternos
        {
            private string _correo = string.Empty;
            private string _docIDentidad = string.Empty;
            private string _direccion = string.Empty;
            private Rol _rol;
            private Usuario _usuario;
            private Persona _persona;
            private Empleado _empleado;
            private List<Rol> _listaRoles;
            private EmpleadoBD _operacionesBD;
            private LugarBD _lugarBD;
            private RolBD _rolBD;

            private Lugar _lugar;
            


            [SetUp]
            public void InicializarPrueba()
            {
                _correo = "Davidjuvinao2@gmail.com";
                _docIDentidad = "20801783";
                _direccion = "La California";
                _listaRoles = new List<Rol>();
                _rol = new Rol();

                _usuario = new Usuario(_correo, "contrase", "Empleado", "Activado", Convert.ToDateTime(null), Convert.ToDateTime(null), null, null, _docIDentidad, "08/15/2014", "12/15/2014");
                _persona = new Persona(_docIDentidad, "Cedula", "David", "", "Juvinao", "Gabaldon", Convert.ToDateTime(null), 32, "11/11/1990");
                _empleado = new Empleado(_persona, _usuario);
                _operacionesBD = new EmpleadoBD();
                _lugarBD = new LugarBD();
                _rolBD = new RolBD();

            }

            [Test]
            public void PruebaAgregarUsuario()
            {
                Assert.IsTrue(_operacionesBD.AgregarEmpleadoBD(_empleado, 23, "La florida"));
            }

            [Test]
            public void PruebaModificarUsuario()
            {
                _usuario = new Usuario(_correo, "contrase", "Empleado", "Activado", Convert.ToDateTime(null), Convert.ToDateTime(null), null, null, _docIDentidad, "08/15/2014", "12/15/2014");
                _persona = new Persona(_docIDentidad, "Cedula", "David", "Aaron", "Juvinao", "Gabaldon", Convert.ToDateTime(null), 32, "11/15/1990");
                _empleado = new Empleado(_persona, _usuario);
                Assert.IsTrue(_operacionesBD.ModificarEmpleadoBD(_empleado, 23, _direccion));
            }

            [Test]
            public void PruebaAgregarRolesUsuario()
            {
                _listaRoles = _operacionesBD.ConsultarRolesEmpleadoBD(_correo);
                int cantidadRoles = _listaRoles.Count();

                _rol = (Rol)_rolBD.ConsultarRolesGeneral().ElementAt(1);

                Assert.IsTrue(_operacionesBD.AsignarRolesUsuarioBD(_correo, _rol));
            }

            [Test]
            public void PruebaConsultarRolesDisponibles()
            {
                _listaRoles = _operacionesBD.ConsultarRolesEmpleadoBD(_correo);

                foreach (Rol item in _listaRoles)
                {
                    Assert.AreNotEqual(_operacionesBD.ConsultarRolesDisponiblesBD(_correo).IndexOf(item), 0);
                }
            }

            [Test]
            public void PruebaObtenerDireccion()
            {
                _empleado = _operacionesBD.ConsultarEmpleadoUnico(_docIDentidad);
                Assert.AreEqual(_lugarBD.ObtenerDireccionBD(_empleado.Persona.FkLugar), _direccion);
            }

            [Test]
            public void PruebaObtenerDireccionCompleta()
            {
                _empleado = _operacionesBD.ConsultarEmpleadoUnico(_docIDentidad);
                Assert.AreEqual(_lugarBD.ConsultarDireccionCompletaBD(_empleado.Persona.FkLugar).Count, 3);
            }

            [Test]
            public void PruebaConsultarEmpleados()
            {
                Assert.IsNotNull(_operacionesBD.ConsultarEmpleados());
            }

            [Test]
            public void PruebaConsultarRoles()
            {

                Assert.IsNotNull(_operacionesBD.ConsultarRolesEmpleadoBD(_correo));
            }

            [Test]
            public void PruebaEliminarRolesUsuario()
            {
                _listaRoles = _operacionesBD.ConsultarRolesEmpleadoBD(_correo);
                int cantidadRoles = _listaRoles.Count();
                _rol = (Rol)_rolBD.ConsultarRolesGeneral().ElementAt(2);
                _operacionesBD.AsignarRolesUsuarioBD(_correo, _rol);
               Assert.IsTrue(_operacionesBD.EliminarRolesUsuarioBD(_correo, _rol));
            }
            
            [Test]
            public void PruebaEliminarEmpleadoNuevo()
            {
                _usuario = new Usuario("prueba@gmail.com", "contrase", "Empleado", "Activado", Convert.ToDateTime(null), Convert.ToDateTime(null), null, null, "prueba001", "08/15/2014", "12/15/2014");
                _persona = new Persona("prueba001", "Cedula", "David", "Aaron", "Juvinao", "Gabaldon", Convert.ToDateTime(null), 32, "11/15/1990");
                _empleado = new Empleado(_persona, _usuario);
                _operacionesBD.ModificarEmpleadoBD(_empleado, 23, _direccion);
                Assert.IsTrue(_operacionesBD.EliminarEmpleadoNuevoBD("prueba@gmail.com"));
            }

            [Test]
            public void PruebaConsultarEmpleadosSearchNombre()
            {
                Assert.IsNotNull(_operacionesBD.ConsultarEmpleadosSearch("David", "Activo"));
            }

            [Test]
            public void PruebaConsultarEmpleadosSearchApellido()
            {
                Assert.IsNotNull(_operacionesBD.ConsultarEmpleadosSearch("Juvinao", "Activo"));
            }

            [Test]
            public void PruebaConsultarEmpleadoUnico()
            {
                Assert.IsNotNull(_operacionesBD.ConsultarEmpleadoUnico(_docIDentidad));
            }

            [Test]
            public void PruebaVerificarCorreoBD()
            {
                _empleado = _operacionesBD.ConsultarEmpleadoUnico(_docIDentidad);
                Assert.AreEqual(_operacionesBD.VerificarCorreoBD(_empleado), 0);
            }

            [Test]
            public void PruebaVerificarDocIdentidadBD()
            {
                _empleado = _operacionesBD.ConsultarEmpleadoUnico(_docIDentidad);
                Assert.AreEqual(_operacionesBD.VerificarDocIdentidadBD(_empleado), 0);
            }

           
            //[Test]
            //public void PruebaLlenarCBPais()
            //{
            //    foreach (Lugar pais in _lugarBD.LlenarCBPaisesBD())
            //    {
            //        Assert.AreEqual(pais.TipoLugar, "Pais");
            //    }
            //}

            //[Test]
            //public void PruebaLlenarComboEstados()
            //{
            //     foreach (Lugar estado in _lugarBD.LlenarCBEstadoBD(_lugar.FkLugar))
            //    {
            //        Assert.AreEqual(estado.TipoLugar, "Estado");
            //    }
            //}

            //[Test]
            //public void PruebaLlenarComboCiudad()
            //{
            //    foreach (Lugar estado in _lugarBD.LlenarCBCiudadBD(_lugar.FkLugar))
            //    {
            //        Assert.AreEqual(estado.TipoLugar, "Ciudad");
            //    }
            //}

            [Test]
            [ExpectedException(typeof(ExcepcionUsuariosInternosDatos))]
            public void ProbarExcepcion()
            {
                _operacionesBD.ConsultarRolesEmpleadoBD(null);
            }

            //[Test]
            //[ExpectedException(typeof(ExcepcionUsuariosInternosDatos))]
            //public void AgregarEmpleadoExcepcion()
            //{
            //    _operacionesBD.AgregarEmpleadoBD(null, 1,"");
            //}

            [TearDown]
            public void Vaciar()
            {
                _usuario = null;
                _persona = null;
                _empleado = null;
                _operacionesBD = null;
            }

        }
    }
}
