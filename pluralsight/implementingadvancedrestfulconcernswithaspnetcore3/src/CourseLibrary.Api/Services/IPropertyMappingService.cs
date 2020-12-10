using System.Collections.Generic;

namespace CourseLibrary.Api.Services
{
    public interface IPropertyMappingService
    {
        IDictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}
