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
    public class TiengDanToc : ControllerBase
    {
        private readonly HemisContext _context;

        public TiengDanToc(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTiengDanToc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTiengDanToc>>> GetDmTiengDanTocs()
        {
            return await _context.DmTiengDanTocs.ToListAsync();
        }

        // GET: api/DmTiengDanToc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTiengDanToc>> GetDmTiengDanToc(int id)
        {
            var dmTiengDanToc = await _context.DmTiengDanTocs.FindAsync(id);

            if (dmTiengDanToc == null)
            {
                return NotFound();
            }

            return dmTiengDanToc;
        }

        private bool DmTiengDanTocExists(int id)
        {
            return _context.DmTiengDanTocs.Any(e => e.IdTiengDanToc == id);
        }
    }
}
