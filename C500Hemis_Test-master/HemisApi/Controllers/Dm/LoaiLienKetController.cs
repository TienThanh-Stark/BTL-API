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
    public class LoaiLienKetController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiLienKetController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiLienKet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiLienKet>>> GetDmLoaiLienKets()
        {
            return await _context.DmLoaiLienKets.ToListAsync();
        }

        // GET: api/DmLoaiLienKet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiLienKet>> GetDmLoaiLienKet(int id)
        {
            var dmLoaiLienKet = await _context.DmLoaiLienKets.FindAsync(id);

            if (dmLoaiLienKet == null)
            {
                return NotFound();
            }

            return dmLoaiLienKet;
        }

        private bool DmLoaiLienKetExists(int id)
        {
            return _context.DmLoaiLienKets.Any(e => e.IdLoaiLienKet == id);
        }
    }
}
