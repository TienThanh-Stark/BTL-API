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
    public class QuocTichController : ControllerBase
    {
        private readonly HemisContext _context;

        public QuocTichController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmQuocTich
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmQuocTich>>> GetDmQuocTichs()
        {
            return await _context.DmQuocTiches.ToListAsync();
        }

        // GET: api/DmQuocTich/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmQuocTich>> GetDmQuocTich(int id)
        {
            var dmQuocTich = await _context.DmQuocTiches.FindAsync(id);

            if (dmQuocTich == null)
            {
                return NotFound();
            }

            return dmQuocTich;
        }

        private bool DmQuocTichExists(int id)
        {
            return _context.DmQuocTiches.Any(e => e.IdQuocTich == id);
        }
    }
}
