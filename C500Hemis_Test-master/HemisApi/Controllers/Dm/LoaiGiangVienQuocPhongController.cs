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
    public class LoaiGiangVienQuocPhongController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiGiangVienQuocPhongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiGiangVienQuocPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiGiangVienQuocPhong>>> GetDmLoaiGiangVienQuocPhongs()
        {
            return await _context.DmLoaiGiangVienQuocPhongs.ToListAsync();
        }

        // GET: api/DmLoaiGiangVienQuocPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiGiangVienQuocPhong>> GetDmLoaiGiangVienQuocPhong(int id)
        {
            var dmLoaiGiangVienQuocPhong = await _context.DmLoaiGiangVienQuocPhongs.FindAsync(id);

            if (dmLoaiGiangVienQuocPhong == null)
            {
                return NotFound();
            }

            return dmLoaiGiangVienQuocPhong;
        }

        private bool DmLoaiGiangVienQuocPhongExists(int id)
        {
            return _context.DmLoaiGiangVienQuocPhongs.Any(e => e.IdLoaiGiangVienQuocPhong == id);
        }
    }
}
