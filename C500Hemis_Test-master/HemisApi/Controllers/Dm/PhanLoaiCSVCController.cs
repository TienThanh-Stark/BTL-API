using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.Dm
{
    [Route("api/dm/[controller]")]
    [ApiController]
    public class PhanLoaiCsvcController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanLoaiCsvcController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiCsvc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiCsvc>>> GetDmPhanLoaiCsvcs()
        {
            return await _context.DmPhanLoaiCsvcs.ToListAsync();
        }

        // GET: api/DmPhanLoaiCsvc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiCsvc>> GetDmPhanLoaiCsvc(int id)
        {
            var dmPhanLoaiCsvc = await _context.DmPhanLoaiCsvcs.FindAsync(id);

            if (dmPhanLoaiCsvc == null)
            {
                return NotFound();
            }

            return dmPhanLoaiCsvc;
        }

        private bool DmPhanLoaiCsvcExists(int id)
        {
            return _context.DmPhanLoaiCsvcs.Any(e => e.IdPhanLoaiCsvc == id);
        }
    }
}
