using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Models;

namespace CourseLibrary.Api.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<AuthorDto, Author>(new Dictionary<string, PropertyMappingValue>
            {
                ["Id"] = new PropertyMappingValue(new string[] { "Id" }),
                ["MainCategory"] = new PropertyMappingValue(new string[] { "MainCategory" }),
                ["Age"] = new PropertyMappingValue(new string[] { "DateOfBirth" }, revert: true),
                ["Name"] = new PropertyMappingValue(new string[] { "FirstName", "LastName" }),
            }));
        }

        public IDictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            return _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>().First().MappingDictionary;
        }
    }
}
