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
    public class TinhTrangNhiemVuController : ControllerBase
    {
        private readonly HemisContext _context;

        public TinhTrangNhiemVuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTinhTrangNhiemVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTinhTrangNhiemVu>>> GetDmTinhTrangNhiemVus()
        {
            return await _context.DmTinhTrangNhiemVus.ToListAsync();
        }

        // GET: api/DmTinhTrangNhiemVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTinhTrangNhiemVu>> GetDmTinhTrangNhiemVu(int id)
        {
            var dmTinhTrangNhiemVu = await _context.DmTinhTrangNhiemVus.FindAsync(id);

            if (dmTinhTrangNhiemVu == null)
            {
                return NotFound();
            }

            return dmTinhTrangNhiemVu;
        }

        private bool DmTinhTrangNhiemVuExists(int id)
        {
            return _context.DmTinhTrangNhiemVus.Any(e => e.IdTinhTrangNhiemVu == id);
        }
    }
}
