using System;
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
            var propertyInfos = typeof(T).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

            if (string.IsNullOrWhiteSpace(fields))
            {
                return source.Select(it => ShapeData(it, propertyInfos));
            }

            var fieldNames = fields.Split(',').Select(it => it.Trim());

            var filteredPropertyInfos = propertyInfos.Where(it => fieldNames.Contains(it.Name));

            return source.Select(it => ShapeData(it, filteredPropertyInfos));
        }

        private static ExpandoObject ShapeData(object source, IEnumerable<PropertyInfo> propertyInfos)
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
