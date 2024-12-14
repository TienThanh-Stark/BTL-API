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
    public class ToChucKiemDinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public ToChucKiemDinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmToChucKiemDinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmToChucKiemDinh>>> GetDmToChucKiemDinhs()
        {
            return await _context.DmToChucKiemDinhs.ToListAsync();
        }

        // GET: api/DmToChucKiemDinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmToChucKiemDinh>> GetDmToChucKiemDinh(int id)
        {
            var dmToChucKiemDinh = await _context.DmToChucKiemDinhs.FindAsync(id);

            if (dmToChucKiemDinh == null)
            {
                return NotFound();
            }

            return dmToChucKiemDinh;
        }

        private bool DmToChucKiemDinhExists(int id)
        {
            return _context.DmToChucKiemDinhs.Any(e => e.IdToChucKiemDinh == id);
        }
    }
}
