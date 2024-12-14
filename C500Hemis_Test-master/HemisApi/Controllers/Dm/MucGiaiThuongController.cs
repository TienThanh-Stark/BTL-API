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
    public class MucGiaiThuongController : ControllerBase
    {
        private readonly HemisContext _context;

        public MucGiaiThuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmMucGiaiThuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmMucGiaiThuong>>> GetDmMucGiaiThuongs()
        {
            return await _context.DmMucGiaiThuongs.ToListAsync();
        }

        // GET: api/DmMucGiaiThuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmMucGiaiThuong>> GetDmMucGiaiThuong(int id)
        {
            var dmMucGiaiThuong = await _context.DmMucGiaiThuongs.FindAsync(id);

            if (dmMucGiaiThuong == null)
            {
                return NotFound();
            }

            return dmMucGiaiThuong;
        }

        private bool DmMucGiaiThuongExists(int id)
        {
            return _context.DmMucGiaiThuongs.Any(e => e.IdMucGiaiThuong == id);
        }
    }
}
