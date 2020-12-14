using System.Linq;
using System.Reflection;

namespace CourseLibrary.Api.Services
{
    public class PropertyCheckerService : IPropertyCheckerService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            return fields.Split(',').Select(it => it.Trim()).All(it =>
            {
                var propertyInfo = typeof(T).GetProperty(it, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                return propertyInfo != null;
            });
        }
    }
}
