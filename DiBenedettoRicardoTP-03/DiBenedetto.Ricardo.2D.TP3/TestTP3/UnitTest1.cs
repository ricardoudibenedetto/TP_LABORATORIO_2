using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesExcepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidException))]
        public void DniInvalido()
        {
            Alumno a = new Alumno(1, "gregor", "Mc", "a2222", Persona.ENacionalidad.Extranjero,Universidad.EClases.SPD);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a = new Alumno(1, "pepe", "grillo", "1", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
        }
        [TestMethod]
        public void NumericValidation()
        {
            Alumno a = new Alumno(1, "carlitos", "gepeto", "1414421", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsInstanceOfType(a.DNI, typeof(int));
        }

        [TestMethod]
        public void NoNull()
        {
            Alumno a = new Alumno(1, "tony", "stark", "1818232", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsNotNull(a.Apellido);

        }
    }
}
