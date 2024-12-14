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
    public class ChucDanhHoiDongController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhHoiDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChucDanhHoiDong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucDanhHoiDong>>> GetDmChucDanhHoiDongs()
        {
            return await _context.DmChucDanhHoiDongs.ToListAsync();
        }

        // GET: api/DmChucDanhHoiDong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucDanhHoiDong>> GetDmChucDanhHoiDong(int id)
        {
            var dmChucDanhHoiDong = await _context.DmChucDanhHoiDongs.FindAsync(id);

            if (dmChucDanhHoiDong == null)
            {
                return NotFound();
            }

            return dmChucDanhHoiDong;
        }

        private bool DmChucDanhHoiDongExists(int id)
        {
            return _context.DmChucDanhHoiDongs.Any(e => e.IdChucDanhHoiDong == id);
        }
    }
}
