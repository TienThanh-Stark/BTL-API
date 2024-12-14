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
    public class LoaiNhiemVuController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiNhiemVuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiNhiemVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiNhiemVu>>> GetDmLoaiNhiemVus()
        {
            return await _context.DmLoaiNhiemVus.ToListAsync();
        }

        // GET: api/DmLoaiNhiemVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiNhiemVu>> GetDmLoaiNhiemVu(int id)
        {
            var dmLoaiNhiemVu = await _context.DmLoaiNhiemVus.FindAsync(id);

            if (dmLoaiNhiemVu == null)
            {
                return NotFound();
            }

            return dmLoaiNhiemVu;
        }

        private bool DmLoaiNhiemVuExists(int id)
        {
            return _context.DmLoaiNhiemVus.Any(e => e.IdLoaiNhiemVu == id);
        }
    }
}
