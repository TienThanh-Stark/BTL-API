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
    public class TuyChonController : ControllerBase
    {
        private readonly HemisContext _context;

        public TuyChonController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTuyChon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTuyChon>>> GetDmTuyChons()
        {
            return await _context.DmTuyChons.ToListAsync();
        }

        // GET: api/DmTuyChon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTuyChon>> GetDmTuyChon(int id)
        {
            var dmTuyChon = await _context.DmTuyChons.FindAsync(id);

            if (dmTuyChon == null)
            {
                return NotFound();
            }

            return dmTuyChon;
        }

        private bool DmTuyChonExists(int id)
        {
            return _context.DmTuyChons.Any(e => e.IdTuyChon == id);
        }
    }
}
