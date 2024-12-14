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
    public class LoaiDeAnChuongTrinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiDeAnChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiDeAnChuongTrinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiDeAnChuongTrinh>>> GetDmLoaiDeAnChuongTrinhs()
        {
            return await _context.DmLoaiDeAnChuongTrinhs.ToListAsync();
        }

        // GET: api/DmLoaiDeAnChuongTrinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiDeAnChuongTrinh>> GetDmLoaiDeAnChuongTrinh(int id)
        {
            var dmLoaiDeAnChuongTrinh = await _context.DmLoaiDeAnChuongTrinhs.FindAsync(id);

            if (dmLoaiDeAnChuongTrinh == null)
            {
                return NotFound();
            }

            return dmLoaiDeAnChuongTrinh;
        }

        private bool DmLoaiDeAnChuongTrinhExists(int id)
        {
            return _context.DmLoaiDeAnChuongTrinhs.Any(e => e.IdLoaiDeAnChuongTrinh == id);
        }
    }
}
