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
    public class ChucDanhNCKHController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhNCKHController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChucDanhNCKH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucDanhNckh>>> GetDmChucDanhNCKHs()
        {
            return await _context.DmChucDanhNckhs.ToListAsync();
        }

        // GET: api/DmChucDanhNCKH/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucDanhNckh>> GetDmChucDanhNCKH(int id)
        {
            var dmChucDanhNCKH = await _context.DmChucDanhNckhs.FindAsync(id);

            if (dmChucDanhNCKH == null)
            {
                return NotFound();
            }

            return dmChucDanhNCKH;
        }

        private bool DmChucDanhNCKHExists(int id)
        {
            return _context.DmChucDanhNckhs.Any(e => e.IdChucDanhNghienCuuKhoaHoc == id);
        }
    }
}
