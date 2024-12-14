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
    public class KhuVucController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhuVucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmKhuVuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmKhuVuc>>> GetDmKhuVucs()
        {
            return await _context.DmKhuVucs.ToListAsync();
        }

        // GET: api/DmKhuVuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmKhuVuc>> GetDmKhuVuc(int id)
        {
            var dmKhuVuc = await _context.DmKhuVucs.FindAsync(id);

            if (dmKhuVuc == null)
            {
                return NotFound();
            }

            return dmKhuVuc;
        }

        private bool DmKhuVucExists(int id)
        {
            return _context.DmKhuVucs.Any(e => e.IdKhuVuc == id);
        }
    }
}
