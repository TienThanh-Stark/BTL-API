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
    public class NgachController : ControllerBase
    {
        private readonly HemisContext _context;

        public NgachController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNgach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNgach>>> GetDmNgachs()
        {
            return await _context.DmNgaches.ToListAsync();
        }

        // GET: api/DmNgach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNgach>> GetDmNgach(int id)
        {
            var dmNgach = await _context.DmNgaches.FindAsync(id);

            if (dmNgach == null)
            {
                return NotFound();
            }

            return dmNgach;
        }

        private bool DmNgachExists(int id)
        {
            return _context.DmNgaches.Any(e => e.IdNgach == id);
        }
    }
}
