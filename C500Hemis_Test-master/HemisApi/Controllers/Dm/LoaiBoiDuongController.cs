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
    public class LoaiBoiDuongController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiBoiDuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiBoiDuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiBoiDuong>>> GetDmLoaiBoiDuongs()
        {
            return await _context.DmLoaiBoiDuongs.ToListAsync();
        }

        // GET: api/DmLoaiBoiDuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiBoiDuong>> GetDmLoaiBoiDuong(int id)
        {
            var dmLoaiBoiDuong = await _context.DmLoaiBoiDuongs.FindAsync(id);

            if (dmLoaiBoiDuong == null)
            {
                return NotFound();
            }

            return dmLoaiBoiDuong;
        }

        private bool DmLoaiBoiDuongExists(int id)
        {
            return _context.DmLoaiBoiDuongs.Any(e => e.IdLoaiBoiDuong == id);
        }
    }
}
