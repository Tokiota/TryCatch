using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TryCatch.Test
{
    [TestClass]
    public class TryCatchFixture
    {
        [TestMethod]
        public void CuandoHayUnaException()
        {
            Action generarExcepcion = () =>
                {
                    int divisor = 0;
                    var result = 10 / divisor;
                };
            Action<DivideByZeroException> whenError = exception => Assert.IsInstanceOfType(exception, typeof(DivideByZeroException));

            generarExcepcion.TryCatch(whenError);
        }

        [TestMethod]
        public void CuandoNoHayUnaException()
        {
            var ejecutoCatch = false;

            Action noGeneraExcepcion = () =>
                {
                    int divisor = 2;
                    var result = 10 / divisor;
                };
            Action<DivideByZeroException> whenError = exception =>
                {
                    ejecutoCatch = true;
                    Assert.IsInstanceOfType(exception, typeof(DivideByZeroException));
                };

            noGeneraExcepcion.TryCatch(whenError);

            Assert.IsFalse(ejecutoCatch);
        }

        [TestMethod]
        public void CuandoHayUnaExceptionGenerica()
        {
            bool ejecutoCatch = false;
            Action generaExcepcionGenerica = () =>
                {
                    throw new Exception("Mensaje");
                };
            Action<DivideByZeroException> whenError = exception =>
                {
                    ejecutoCatch = true;
                };
            Action<Exception> whenGenerico = exception => Assert.IsInstanceOfType(exception, typeof(Exception));

            generaExcepcionGenerica.TryCatch(whenError, whenGenerico);

            Assert.IsFalse(ejecutoCatch);
        }

    }
}
