using System;

namespace CourseLibrary.Api.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            return DateTime.UtcNow.Year - dateTime.Year;
        }
    }
}
