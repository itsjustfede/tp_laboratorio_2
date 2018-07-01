using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarioEntidadesTP4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesInstanciamiento()
        {
            Correo mail = new Correo();

            //if (Object.ReferenceEquals(mail.Paquetes, null))
            //    Assert.Fail();

            Assert.IsNotNull(mail.Paquetes);
        }

        [TestMethod]
        public void MismoTrackingID()
        {
            Paquete package1 = new Paquete("Quilmes", "123-123-1233");
            Paquete package2 = new Paquete("Avellaneda", "123-123-1233");
            Correo mail = new Correo();

            mail += package1;
            mail += package2;
        }
    }
}
