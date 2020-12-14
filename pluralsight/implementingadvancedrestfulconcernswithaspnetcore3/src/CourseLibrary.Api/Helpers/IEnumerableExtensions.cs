using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace CourseLibrary.Api.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<T>(this IEnumerable<T> source, string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(T).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                return source.Select(it => it.ShapeData(propertyInfos));
            }

            var filteredPropertyInfos = fields.Split(',').Select(it => typeof(T).GetProperty(it.Trim(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public));

            return source.Select(it => it.ShapeData(filteredPropertyInfos));
        }
    }
}
