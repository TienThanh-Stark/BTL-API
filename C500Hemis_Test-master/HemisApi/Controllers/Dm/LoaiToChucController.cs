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
    public class LoaiToChucController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiToChucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiToChuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiToChuc>>> GetDmLoaiToChucs()
        {
            return await _context.DmLoaiToChucs.ToListAsync();
        }

        // GET: api/DmLoaiToChuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiToChuc>> GetDmLoaiToChuc(int id)
        {
            var dmLoaiToChuc = await _context.DmLoaiToChucs.FindAsync(id);

            if (dmLoaiToChuc == null)
            {
                return NotFound();
            }

            return dmLoaiToChuc;
        }

        private bool DmLoaiToChucExists(int id)
        {
            return _context.DmLoaiToChucs.Any(e => e.IdLoaiToChuc == id);
        }
    }
}
