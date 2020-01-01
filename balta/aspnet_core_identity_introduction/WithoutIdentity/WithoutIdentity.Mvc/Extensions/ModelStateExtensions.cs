using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace WithoutIdentity.Mvc.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddErrors(this ModelStateDictionary target, IEnumerable<object> errors)
        {
            foreach(var error in errors)
            {
                target.AddModelError(string.Empty, error.ToString());
            }
        }
    }
}
