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
    public class ThiDuaGiaiThuongKhenThuongController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThiDuaGiaiThuongKhenThuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmThiDuaGiaiThuongKhenThuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmThiDuaGiaiThuongKhenThuong>>> GetDmThiDuaGiaiThuongKhenThuongs()
        {
            return await _context.DmThiDuaGiaiThuongKhenThuongs.ToListAsync();
        }

        // GET: api/DmThiDuaGiaiThuongKhenThuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmThiDuaGiaiThuongKhenThuong>> GetDmThiDuaGiaiThuongKhenThuong(int id)
        {
            var dmThiDuaGiaiThuongKhenThuong = await _context.DmThiDuaGiaiThuongKhenThuongs.FindAsync(id);

            if (dmThiDuaGiaiThuongKhenThuong == null)
            {
                return NotFound();
            }

            return dmThiDuaGiaiThuongKhenThuong;
        }

        private bool DmThiDuaGiaiThuongKhenThuongExists(int id)
        {
            return _context.DmThiDuaGiaiThuongKhenThuongs.Any(e => e.IdThiDuaGiaiThuongKhenThuong == id);
        }
    }
}
