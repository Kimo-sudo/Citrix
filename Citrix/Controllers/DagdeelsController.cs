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

        public DagdeelsController(ApplicationDbContext context, IDataService<Dagdeel> dataService)
        {
            _context = context;
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IEnumerable<Dagdeel>> GetAllDagmail()
        {
            return await _dataService.GetAll();
        }
        [HttpPost]

        public async void CreateDagmail(Dagdeel dagdeel)
        {
            await _dataService.Create(dagdeel);

        }
    }
}
