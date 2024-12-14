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
    public class PhuongThucKhenThuongController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhuongThucKhenThuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhuongThucKhenThuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhuongThucKhenThuong>>> GetDmPhuongThucKhenThuongs()
        {
            return await _context.DmPhuongThucKhenThuongs.ToListAsync();
        }

        // GET: api/DmPhuongThucKhenThuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhuongThucKhenThuong>> GetDmPhuongThucKhenThuong(int id)
        {
            var dmPhuongThucKhenThuong = await _context.DmPhuongThucKhenThuongs.FindAsync(id);

            if (dmPhuongThucKhenThuong == null)
            {
                return NotFound();
            }

            return dmPhuongThucKhenThuong;
        }

        private bool DmPhuongThucKhenThuongExists(int id)
        {
            return _context.DmPhuongThucKhenThuongs.Any(e => e.IdPhuongThucKhenThuong == id);
        }
    }
}
