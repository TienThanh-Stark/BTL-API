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
    public class TrinhDoTinHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrinhDoTinHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrinhDoTinHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrinhDoTinHoc>>> GetDmTrinhDoTinHocs()
        {
            return await _context.DmTrinhDoTinHocs.ToListAsync();
        }

        // GET: api/DmTrinhDoTinHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrinhDoTinHoc>> GetDmTrinhDoTinHoc(int id)
        {
            var dmTrinhDoTinHoc = await _context.DmTrinhDoTinHocs.FindAsync(id);

            if (dmTrinhDoTinHoc == null)
            {
                return NotFound();
            }

            return dmTrinhDoTinHoc;
        }

        private bool DmTrinhDoTinHocExists(int id)
        {
            return _context.DmTrinhDoTinHocs.Any(e => e.IdTrinhDoTinHoc == id);
        }
    }
}
