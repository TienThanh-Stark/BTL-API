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
    public class GioiTinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public GioiTinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmGioiTinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmGioiTinh>>> GetDmGioiTinhs()
        {
            return await _context.DmGioiTinhs.ToListAsync();
        }

        // GET: api/DmGioiTinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmGioiTinh>> GetDmGioiTinh(int id)
        {
            var dmGioiTinh = await _context.DmGioiTinhs.FindAsync(id);

            if (dmGioiTinh == null)
            {
                return NotFound();
            }

            return dmGioiTinh;
        }

        private bool DmGioiTinhExists(int id)
        {
            return _context.DmGioiTinhs.Any(e => e.IdGioiTinh == id);
        }
    }
}
