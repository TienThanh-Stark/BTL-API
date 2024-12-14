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
    public class TuChuMoNganhController : ControllerBase
    {
        private readonly HemisContext _context;

        public TuChuMoNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTuChuMoNganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTuChuMoNganh>>> GetDmTuChuMoNganhs()
        {
            return await _context.DmTuChuMoNganhs.ToListAsync();
        }

        // GET: api/DmTuChuMoNganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTuChuMoNganh>> GetDmTuChuMoNganh(int id)
        {
            var dmTuChuMoNganh = await _context.DmTuChuMoNganhs.FindAsync(id);

            if (dmTuChuMoNganh == null)
            {
                return NotFound();
            }

            return dmTuChuMoNganh;
        }

        private bool DmTuChuMoNganhExists(int id)
        {
            return _context.DmTuChuMoNganhs.Any(e => e.IdTuChuMoNganh == id);
        }
    }
}
