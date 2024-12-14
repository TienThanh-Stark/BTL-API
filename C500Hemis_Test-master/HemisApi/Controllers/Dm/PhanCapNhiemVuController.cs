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
    public class PhanCapNhiemVuController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanCapNhiemVuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanCapNhiemVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanCapNhiemVu>>> GetDmPhanCapNhiemVus()
        {
            return await _context.DmPhanCapNhiemVus.ToListAsync();
        }

        // GET: api/DmPhanCapNhiemVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanCapNhiemVu>> GetDmPhanCapNhiemVu(int id)
        {
            var dmPhanCapNhiemVu = await _context.DmPhanCapNhiemVus.FindAsync(id);

            if (dmPhanCapNhiemVu == null)
            {
                return NotFound();
            }

            return dmPhanCapNhiemVu;
        }

        private bool DmPhanCapNhiemVuExists(int id)
        {
            return _context.DmPhanCapNhiemVus.Any(e => e.IdPhanCapNhiemVu == id);
        }
    }
}
