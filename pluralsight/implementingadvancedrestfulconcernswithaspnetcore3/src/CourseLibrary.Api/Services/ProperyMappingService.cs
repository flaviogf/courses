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

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            return fields.Split(',').Select(it => it.Trim()).All(it =>
            {
                var indexFirstWhiteSpace = it.IndexOf(" ");

                var propertyName = indexFirstWhiteSpace == -1 ? it : it.Remove(indexFirstWhiteSpace);

                return propertyMapping.ContainsKey(propertyName);
            });
        }

        public IDictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            return _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>().First().MappingDictionary;
        }
    }
}
