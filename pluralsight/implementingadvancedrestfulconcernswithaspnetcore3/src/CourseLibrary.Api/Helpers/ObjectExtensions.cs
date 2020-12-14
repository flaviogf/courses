using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace CourseLibrary.Api.Helpers
{
    public static class ObjectExtensions
    {
        public static ExpandoObject ShapeData<T>(this T source, string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(T).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                return source.ShapeData(propertyInfos);
            }

            var filteredPropertyInfos = fields.Split(',').Select(it => typeof(T).GetProperty(it.Trim(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public));

            return source.ShapeData(filteredPropertyInfos);
        }

        public static ExpandoObject ShapeData(this object source, IEnumerable<PropertyInfo> propertyInfos)
        {
            var result = new ExpandoObject();

            foreach (var propertyInfo in propertyInfos)
            {
                ((IDictionary<string, object>)result).Add(propertyInfo.Name, propertyInfo.GetValue(source));
            }

            return result;
        }
    }
}
