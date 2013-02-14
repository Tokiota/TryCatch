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
    }

}
