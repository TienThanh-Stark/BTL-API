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
    public class LoaiPhongThiNghiemController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiPhongThiNghiemController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiPhongThiNghiem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiPhongThiNghiem>>> GetDmLoaiPhongThiNghiems()
        {
            return await _context.DmLoaiPhongThiNghiems.ToListAsync();
        }

        // GET: api/DmLoaiPhongThiNghiem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiPhongThiNghiem>> GetDmLoaiPhongThiNghiem(int id)
        {
            var dmLoaiPhongThiNghiem = await _context.DmLoaiPhongThiNghiems.FindAsync(id);

            if (dmLoaiPhongThiNghiem == null)
            {
                return NotFound();
            }

            return dmLoaiPhongThiNghiem;
        }

        private bool DmLoaiPhongThiNghiemExists(int id)
        {
            return _context.DmLoaiPhongThiNghiems.Any(e => e.IdLoaiPhongThiNghiem == id);
        }
    }
}
