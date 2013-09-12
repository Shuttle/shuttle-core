using System;

namespace Shuttle.Core.Data
{
    public static class ExceptionExtensions
    {
        public static bool IsDuplicate(this Exception exception)
        {
            return exception.Message.ToLower().Contains("cannot insert duplicate key row in object");
        }

        public static bool IsDuplicate(this Exception exception, string contains)
        {
            return IsDuplicate(exception) && exception.Message.ToLower().Contains(contains);
        }
    }
}
