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
    public class NhomNganhController : ControllerBase
    {
        private readonly HemisContext _context;

        public NhomNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNhomNganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNhomNganh>>> GetDmNhomNganhs()
        {
            return await _context.DmNhomNganhs.ToListAsync();
        }

        // GET: api/DmNhomNganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNhomNganh>> GetDmNhomNganh(int id)
        {
            var dmNhomNganh = await _context.DmNhomNganhs.FindAsync(id);

            if (dmNhomNganh == null)
            {
                return NotFound();
            }

            return dmNhomNganh;
        }

        private bool DmNhomNganhExists(int id)
        {
            return _context.DmNhomNganhs.Any(e => e.IdNhomNganh == id);
        }
    }
}
