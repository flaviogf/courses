using AutoMapper;
using Paladin.Web.Infra;
using Paladin.Web.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paladin.Web.Areas.Admin.Controllers
{
    public class DataExportationController : Controller
    {
        private readonly PaladinDbContext _context;

        private readonly IMapper _mapper;

        public DataExportationController(PaladinDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var applicants = _mapper.Map<List<ApplicantViewModel>>(await _context.Applicant.ToListAsync());

            return new CSVResult(applicants);
        }
    }
}