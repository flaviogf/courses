using System;
using ExceptionsAndReadability.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsAndReadability.Web.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class CustomerController : Controller
    {
        [Route("")]
        [HttpPost]
        public IActionResult Store([FromBody] CustomerViewModel viewModel)
        {
            try
            {
                ValidateBirthday(viewModel.Birthday);
                ValidateName(viewModel.Name);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void ValidateBirthday(DateTime birthday)
        {
            if (birthday == DateTime.MinValue)
            {
                throw new ArgumentException("Birthday must be informed", nameof(birthday));
            }

            if (birthday > DateTime.Today)
            {
                throw new ArgumentException("Birthday must be before today", nameof(birthday));
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must be informed", nameof(name));
            }

            if (name.Length > 100)
            {
                throw new ArgumentException("Name must have a maximum of 100 characters", nameof(name));
            }
        }
    }
}
