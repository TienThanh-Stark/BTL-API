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
    public class LoaiKhuyetTatController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiKhuyetTatController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiKhuyetTat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiKhuyetTat>>> GetDmLoaiKhuyetTats()
        {
            return await _context.DmLoaiKhuyetTats.ToListAsync();
        }

        // GET: api/DmLoaiKhuyetTat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiKhuyetTat>> GetDmLoaiKhuyetTat(int id)
        {
            var dmLoaiKhuyetTat = await _context.DmLoaiKhuyetTats.FindAsync(id);

            if (dmLoaiKhuyetTat == null)
            {
                return NotFound();
            }

            return dmLoaiKhuyetTat;
        }

        private bool DmLoaiKhuyetTatExists(int id)
        {
            return _context.DmLoaiKhuyetTats.Any(e => e.IdLoaiKhuyetTat == id);
        }
    }
}
