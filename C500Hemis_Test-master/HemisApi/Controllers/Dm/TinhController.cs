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
    public class TinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public TinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTinh>>> GetDmTinhs()
        {
            return await _context.DmTinhs.ToListAsync();
        }

        // GET: api/DmTinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTinh>> GetDmTinh(int id)
        {
            var dmTinh = await _context.DmTinhs.FindAsync(id);

            if (dmTinh == null)
            {
                return NotFound();
            }

            return dmTinh;
        }

        private bool DmTinhExists(int id)
        {
            return _context.DmTinhs.Any(e => e.IdTinh == id);
        }
    }
}
