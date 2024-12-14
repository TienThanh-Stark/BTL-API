using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class vHoatDongTaiChinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public vHoatDongTaiChinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VHoatDongTaiChinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHoatDongTaiChinh>>> GetVHoatDongTaiChinhs()
        {
            return await _context.VHoatDongTaiChinhs.ToListAsync();
        }

        // GET: api/VHoatDongTaiChinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VHoatDongTaiChinh>> GetVHoatDongTaiChinh(int id)
        {
            var VHoatDongTaiChinh = await _context.VHoatDongTaiChinhs.FindAsync(id);

            if (VHoatDongTaiChinh == null)
            {
                return NotFound();
            }

            return VHoatDongTaiChinh;
        }

    }
}
