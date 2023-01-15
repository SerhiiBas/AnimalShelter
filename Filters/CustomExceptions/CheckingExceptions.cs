using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.CastomExceptions
{
    public static class CheckingExceptions
    {
        public static void CheckingAtNull<T>(T value)
        {
            if (value == null)
                throw new NullReferenceException(nameof(value) + "Can not be null");
        }
    }
}
