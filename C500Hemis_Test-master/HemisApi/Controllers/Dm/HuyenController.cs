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
    public class HuyenController : ControllerBase
    {
        private readonly HemisContext _context;

        public HuyenController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHuyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHuyen>>> GetDmHuyens()
        {
            return await _context.DmHuyens.ToListAsync();
        }

        // GET: api/DmHuyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHuyen>> GetDmHuyen(int id)
        {
            var DmHuyen = await _context.DmHuyens.FindAsync(id);

            if (DmHuyen == null)
            {
                return NotFound();
            }

            return DmHuyen;
        }

        private bool DmHuyenExists(int id)
        {
            return _context.DmHuyens.Any(e => e.IdHuyen == id);
        }
    }
}
