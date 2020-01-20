using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models;
using Citrix.Data.Services;

namespace Citrix.Controllers
{
    [Route("api/Dagdeel")]
    [ApiController]
    public class DagdeelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService<Dagdeel> _dataService;
        private readonly ApplicationDbContextFactory _contextFactory;

        public DagdeelsController(ApplicationDbContext context, IDataService<Dagdeel> dataService, ApplicationDbContextFactory contextFactory)
        {
            _context = context;
            _dataService = dataService;
            _contextFactory = contextFactory;

        }

        [HttpGet]
        public async Task<IEnumerable<Dagdeel>> GetAllDagmail()
        {
            return await _dataService.GetAll();
        }
        [Route("Create")]
        [HttpPost]
        public async void CreateDagmail(Dagdeel dagdeel)
        {
            await _dataService.Create(dagdeel);
        }
        [Route("Today")]
        [HttpGet]
        public async Task<Dagdeel> GetToday()
        {
            var x = await _context.Dagdeel.FirstOrDefaultAsync(e => e.DateAdded.Date == DateTime.Now.Date);
            return x;
        }

    }
}
