using Bytebank.Api.Models;
using Bytebank.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bytebank.Api.Controllers
{
    [ApiController]
    [Route("/transaction")]
    public class TransactionController : Controller
    {
        private readonly ApplicationContext _context;

        public TransactionController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Store([FromBody]StoreTransactionViewModel viewModel)
        {
            var id = viewModel.Id ?? Guid.NewGuid();

            var contact = new Contact
            {
                Name = viewModel.ContactName,
                Account = viewModel.ContactAccount
            };

            var transaction = new Transaction
            {
                Id = id,
                Contact = contact,
                Value = viewModel.Value,
                Date = viewModel.Date
            };

            await _context.Transactions.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return Created("", transaction);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transactions.ToListAsync();

            return Ok(transactions);
        }
    }
}
