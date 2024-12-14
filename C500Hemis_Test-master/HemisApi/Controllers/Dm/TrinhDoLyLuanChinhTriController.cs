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
    public class TrinhDoLyLuanChinhTriController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrinhDoLyLuanChinhTriController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrinhDoLyLuanChinhTri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrinhDoLyLuanChinhTri>>> GetDmTrinhDoLyLuanChinhTris()
        {
            return await _context.DmTrinhDoLyLuanChinhTris.ToListAsync();
        }

        // GET: api/DmTrinhDoLyLuanChinhTri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrinhDoLyLuanChinhTri>> GetDmTrinhDoLyLuanChinhTri(int id)
        {
            var dmTrinhDoLyLuanChinhTri = await _context.DmTrinhDoLyLuanChinhTris.FindAsync(id);

            if (dmTrinhDoLyLuanChinhTri == null)
            {
                return NotFound();
            }

            return dmTrinhDoLyLuanChinhTri;
        }

        private bool DmTrinhDoLyLuanChinhTriExists(int id)
        {
            return _context.DmTrinhDoLyLuanChinhTris.Any(e => e.IdTrinhDoLyLuanChinhTri == id);
        }
    }
}
