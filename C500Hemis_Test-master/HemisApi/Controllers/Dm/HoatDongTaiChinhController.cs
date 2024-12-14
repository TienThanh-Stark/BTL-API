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
    public class HoatDongTaiChinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public HoatDongTaiChinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHoatDongTaiChinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHoatDongTaiChinh>>> GetDmHoatDongTaiChinhs()
        {
            return await _context.DmHoatDongTaiChinhs.ToListAsync();
        }

        // GET: api/DmHoatDongTaiChinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHoatDongTaiChinh>> GetDmHoatDongTaiChinh(int id)
        {
            var dmHoatDongTaiChinh = await _context.DmHoatDongTaiChinhs.FindAsync(id);

            if (dmHoatDongTaiChinh == null)
            {
                return NotFound();
            }

            return dmHoatDongTaiChinh;
        }

        private bool DmHoatDongTaiChinhExists(int id)
        {
            return _context.DmHoatDongTaiChinhs.Any(e => e.IdHoatDongTaiChinh == id);
        }
    }
}
