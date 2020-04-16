using System;
using ExceptionsAndReadability.Web.Infrastucture;
using ExceptionsAndReadability.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsAndReadability.Web.Controllers.V2
{
    [Route("api/v2/[controller]")]
    public class CustomerController : Controller
    {
        [Route("")]
        [HttpPost]
        public IActionResult Store([FromBody] CustomerViewModel viewModel)
        {
            var result = ValidateBirthday(viewModel.Birthday);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            result = ValidateName(viewModel.Name);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        private Result ValidateBirthday(DateTime birthday)
        {
            if (birthday == DateTime.MinValue)
            {
                return Result.Fail("Birthday must be informed");
            }

            if (birthday > DateTime.Today)
            {
                return Result.Fail("Birthday must be before today");
            }

            return Result.Ok();
        }

        private Result ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Fail("Name must be informed");
            }

            if (name.Length > 100)
            {
                return Result.Fail("Name must have a maximum of 100 characters");
            }

            return Result.Ok();
        }
    }
}
