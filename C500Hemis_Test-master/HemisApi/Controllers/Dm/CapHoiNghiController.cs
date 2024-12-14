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
    public class CapHoiNghiController : ControllerBase
    {
        private readonly HemisContext _context;

        public CapHoiNghiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmCapHoiNghi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmCapHoiNghi>>> GetDmCapHoiNghis()
        {
            return await _context.DmCapHoiNghis.ToListAsync();
        }

        // GET: api/DmCapHoiNghi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmCapHoiNghi>> GetDmCapHoiNghi(int id)
        {
            var dmCapHoiNghi = await _context.DmCapHoiNghis.FindAsync(id);

            if (dmCapHoiNghi == null)
            {
                return NotFound();
            }

            return dmCapHoiNghi;
        }

        private bool DmCapHoiNghiExists(int id)
        {
            return _context.DmCapHoiNghis.Any(e => e.IdCapHoiNghi == id);
        }
    }
}
