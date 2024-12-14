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
    public class LoaiKyLuatController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiKyLuatController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiKyLuat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiKyLuat>>> GetDmLoaiKyLuats()
        {
            return await _context.DmLoaiKyLuats.ToListAsync();
        }

        // GET: api/DmLoaiKyLuat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiKyLuat>> GetDmLoaiKyLuat(int id)
        {
            var dmLoaiKyLuat = await _context.DmLoaiKyLuats.FindAsync(id);

            if (dmLoaiKyLuat == null)
            {
                return NotFound();
            }

            return dmLoaiKyLuat;
        }

        private bool DmLoaiKyLuatExists(int id)
        {
            return _context.DmLoaiKyLuats.Any(e => e.IdLoaiKyLuat == id);
        }
    }
}
