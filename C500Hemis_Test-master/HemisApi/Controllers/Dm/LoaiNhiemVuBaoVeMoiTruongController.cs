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
    public class LoaiNhiemVuBaoVeMoiTruongController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiNhiemVuBaoVeMoiTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiNhiemVuBaoVeMoiTruong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiNhiemVuBaoVeMoiTruong>>> GetDmLoaiNhiemVuBaoVeMoiTruongs()
        {
            return await _context.DmLoaiNhiemVuBaoVeMoiTruongs.ToListAsync();
        }

        // GET: api/DmLoaiNhiemVuBaoVeMoiTruong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiNhiemVuBaoVeMoiTruong>> GetDmLoaiNhiemVuBaoVeMoiTruong(int id)
        {
            var dmLoaiNhiemVuBaoVeMoiTruong = await _context.DmLoaiNhiemVuBaoVeMoiTruongs.FindAsync(id);

            if (dmLoaiNhiemVuBaoVeMoiTruong == null)
            {
                return NotFound();
            }

            return dmLoaiNhiemVuBaoVeMoiTruong;
        }

        private bool DmLoaiNhiemVuBaoVeMoiTruongExists(int id)
        {
            return _context.DmLoaiNhiemVuBaoVeMoiTruongs.Any(e => e.IdLoaiNhiemVuBaoVeMoiTruong == id);
        }
    }
}
