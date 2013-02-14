using System;

namespace TryCatch
{
    public static class TryCatchExtension
    {
        public static void TryCatch<TException>(this Action tryAction, Action<TException> onException) where TException : Exception
        {

        }
    }
}
