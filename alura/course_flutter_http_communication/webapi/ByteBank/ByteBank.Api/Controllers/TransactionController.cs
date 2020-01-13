using ByteBank.Api.Models;
using ByteBank.Api.ViewModels.Transaction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ByteBank.Api.Controllers
{
    [ApiController]
    [Route("/api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TransactionController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Store(StoreTransactionViewModel viewModel)
        {
            var contact = new Contact
            {
                Name = viewModel.ContactName,
                Account = viewModel.ContactAccount
            };

            var transaction = new Transaction
            {
                Value = viewModel.Value,
                Contact = contact
            };

            await _context.Transactions.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return Ok();
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
