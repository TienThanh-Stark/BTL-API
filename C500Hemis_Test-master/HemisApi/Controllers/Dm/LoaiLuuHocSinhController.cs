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
    public class LoaiLuuHocSinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiLuuHocSinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiLuuHocSinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiLuuHocSinh>>> GetDmLoaiLuuHocSinhs()
        {
            return await _context.DmLoaiLuuHocSinhs.ToListAsync();
        }

        // GET: api/DmLoaiLuuHocSinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiLuuHocSinh>> GetDmLoaiLuuHocSinh(int id)
        {
            var dmLoaiLuuHocSinh = await _context.DmLoaiLuuHocSinhs.FindAsync(id);

            if (dmLoaiLuuHocSinh == null)
            {
                return NotFound();
            }

            return dmLoaiLuuHocSinh;
        }

        private bool DmLoaiLuuHocSinhExists(int id)
        {
            return _context.DmLoaiLuuHocSinhs.Any(e => e.IdLoaiLuuHocSinh == id);
        }
    }
}
