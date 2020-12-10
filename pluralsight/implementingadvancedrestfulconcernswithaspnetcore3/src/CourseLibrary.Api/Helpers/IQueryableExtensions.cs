using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using CourseLibrary.Api.Services;

namespace CourseLibrary.Api.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string field, IDictionary<string, PropertyMappingValue> propertyMappingDictionary)
        {
            var ordering = string.Empty;

            foreach (var it in field.Split(','))
            {
                var orderByClause = it.Trim();

                var orderDescending = it.EndsWith(" desc");

                var propertyName = orderByClause.IndexOf(" ") == -1 ? orderByClause : orderByClause.Remove(orderByClause.IndexOf(" "));

                var propertyMappingValue = propertyMappingDictionary[propertyName];

                orderDescending = propertyMappingValue.Revert ? !orderDescending : orderDescending;

                foreach (var destinationProperty in propertyMappingValue.DestinationProperties)
                {
                    ordering += (string.IsNullOrWhiteSpace(ordering) ? string.Empty : ", ") + destinationProperty + (orderDescending ? " desc" : " asc");
                }
            }

            return source.OrderBy(ordering);
        }
    }
}
