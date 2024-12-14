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
    public class DanTocController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanTocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDanToc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDanToc>>> GetDmDanTocs()
        {
            return await _context.DmDanTocs.ToListAsync();
        }

        // GET: api/DmDanToc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDanToc>> GetDmDanToc(int id)
        {
            var dmDanToc = await _context.DmDanTocs.FindAsync(id);

            if (dmDanToc == null)
            {
                return NotFound();
            }

            return dmDanToc;
        }

        private bool DmDanTocExists(int id)
        {
            return _context.DmDanTocs.Any(e => e.IdDanToc == id);
        }
    }
}
