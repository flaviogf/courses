using System;

namespace CourseLibrary.Api.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset target)
        {
            return DateTime.UtcNow.Year - target.Year;
        }
    }
}
