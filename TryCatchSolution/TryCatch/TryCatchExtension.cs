using System;

namespace TryCatch
{
    public static class TryCatchExtension
    {
        public static void TryCatch<TException>(this Action tryAction, Action<TException> onException) where TException : Exception
        {
            try
            {
                tryAction.Invoke();
            }
            catch(TException exception)
            {
                onException(exception);
            }
        }

        public static void TryCatch<TException1, TException2>(this Action tryAction, Action<TException1> onException1, Action<TException2> onException2)
            where TException1 : Exception
            where TException2 : Exception
        {
            try
            {
                tryAction.TryCatch(onException1);
            }
            catch (TException2 exception)
            {
                onException2.Invoke(exception);
            }
        }
    }
}
