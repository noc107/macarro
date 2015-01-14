using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_tests_back_office
{
    [TestFixture]
    class PruebasUnitariasAcccion
    {
        public back_office.Datos.RolesSeguridad.AccionBD test;

        [SetUp]
        public void Init()
        {
            test = new back_office.Datos.RolesSeguridad.AccionBD();
        }

        [Test]
        public void consultarGeneralAccion()
        {
            Assert.AreEqual(72, test.ConsultarAccionGeneral().Count);
        }
    }
}
