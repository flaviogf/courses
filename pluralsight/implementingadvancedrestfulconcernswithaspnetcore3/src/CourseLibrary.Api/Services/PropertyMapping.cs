using System.Collections.Generic;

namespace CourseLibrary.Api.Services
{
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public PropertyMapping(IDictionary<string, PropertyMappingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary;
        }

        public IDictionary<string, PropertyMappingValue> MappingDictionary { get; set; }
    }
}
