using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidaQuePaqueteDeCorreoEsteInstanciado()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }


        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void ValidaQueNoSeCarguenTrackingRepetidos()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("calleFalsa123", "111111");
            Paquete p2 = new Paquete("bouchard559", "111111");
            c += p1;
            c += p2;
        }
    }
}
