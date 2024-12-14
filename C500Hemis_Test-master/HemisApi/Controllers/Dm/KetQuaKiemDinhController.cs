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
    public class KetQuaKiemDinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public KetQuaKiemDinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmKetQuaKiemDinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmKetQuaKiemDinh>>> GetDmKetQuaKiemDinhs()
        {
            return await _context.DmKetQuaKiemDinhs.ToListAsync();
        }

        // GET: api/DmKetQuaKiemDinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmKetQuaKiemDinh>> GetDmKetQuaKiemDinh(int id)
        {
            var dmKetQuaKiemDinh = await _context.DmKetQuaKiemDinhs.FindAsync(id);

            if (dmKetQuaKiemDinh == null)
            {
                return NotFound();
            }

            return dmKetQuaKiemDinh;
        }

        private bool DmKetQuaKiemDinhExists(int id)
        {
            return _context.DmKetQuaKiemDinhs.Any(e => e.IdKetQuaKiemDinh == id);
        }
    }
}
