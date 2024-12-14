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
    public class DoiTuongChinhSachController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoiTuongChinhSachController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDoiTuongChinhSach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDoiTuongChinhSach>>> GetDmDoiTuongChinhSachs()
        {
            return await _context.DmDoiTuongChinhSaches.ToListAsync();
        }

        // GET: api/DmDoiTuongChinhSach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDoiTuongChinhSach>> GetDmDoiTuongChinhSach(int id)
        {
            var dmDoiTuongChinhSach = await _context.DmDoiTuongChinhSaches.FindAsync(id);

            if (dmDoiTuongChinhSach == null)
            {
                return NotFound();
            }

            return dmDoiTuongChinhSach;
        }

        private bool DmDoiTuongChinhSachExists(int id)
        {
            return _context.DmDoiTuongChinhSaches.Any(e => e.IdDoiTuongChinhSach == id);
        }
    }
}
