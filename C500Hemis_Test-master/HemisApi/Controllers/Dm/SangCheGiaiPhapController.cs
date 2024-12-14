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
    public class SangCheGiaiPhapController : ControllerBase
    {
        private readonly HemisContext _context;

        public SangCheGiaiPhapController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmSangCheGiaiPhap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmSangCheGiaiPhap>>> GetDmSangCheGiaiPhaps()
        {
            return await _context.DmSangCheGiaiPhaps.ToListAsync();
        }

        // GET: api/DmSangCheGiaiPhap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmSangCheGiaiPhap>> GetDmSangCheGiaiPhap(int id)
        {
            var dmSangCheGiaiPhap = await _context.DmSangCheGiaiPhaps.FindAsync(id);

            if (dmSangCheGiaiPhap == null)
            {
                return NotFound();
            }

            return dmSangCheGiaiPhap;
        }

        private bool DmSangCheGiaiPhapExists(int id)
        {
            return _context.DmSangCheGiaiPhaps.Any(e => e.IdSangCheGiaiPhap == id);
        }
    }
}
