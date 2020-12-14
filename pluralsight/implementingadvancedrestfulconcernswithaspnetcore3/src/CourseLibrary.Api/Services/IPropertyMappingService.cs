using System.Collections.Generic;

namespace CourseLibrary.Api.Services
{
    public interface IPropertyMappingService
    {
        bool ValidMappingExistsFor<TSource, TDestination>(string fields);

        IDictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}
