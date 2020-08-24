using System;

namespace InfoTecsIntro
{
    public static class ObjectExtension
    {
        public static void ThrowIfNull(this object obj, string exceptionMessage)
        {
            if (obj == null)
                throw new ArgumentException(exceptionMessage);
        }
    }
}