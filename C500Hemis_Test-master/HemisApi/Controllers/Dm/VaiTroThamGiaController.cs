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
    public class VaiTroThamGiaController : ControllerBase
    {
        private readonly HemisContext _context;

        public VaiTroThamGiaController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmVaiTroThamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmVaiTroThamGia>>> GetDmVaiTroThamGias()
        {
            return await _context.DmVaiTroThamGias.ToListAsync();
        }

        // GET: api/DmVaiTroThamGia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmVaiTroThamGia>> GetDmVaiTroThamGia(int id)
        {
            var dmVaiTroThamGia = await _context.DmVaiTroThamGias.FindAsync(id);

            if (dmVaiTroThamGia == null)
            {
                return NotFound();
            }

            return dmVaiTroThamGia;
        }

        private bool DmVaiTroThamGiaExists(int id)
        {
            return _context.DmVaiTroThamGias.Any(e => e.IdVaiTroThamGia == id);
        }
    }
}
