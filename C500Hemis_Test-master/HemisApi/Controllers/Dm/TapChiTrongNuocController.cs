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
    public class TapChiTrongNuocController : ControllerBase
    {
        private readonly HemisContext _context;

        public TapChiTrongNuocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTapChiTrongNuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTapChiTrongNuoc>>> GetDmTapChiTrongNuocs()
        {
            return await _context.DmTapChiTrongNuocs.ToListAsync();
        }

        // GET: api/DmTapChiTrongNuoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTapChiTrongNuoc>> GetDmTapChiTrongNuoc(int id)
        {
            var dmTapChiTrongNuoc = await _context.DmTapChiTrongNuocs.FindAsync(id);

            if (dmTapChiTrongNuoc == null)
            {
                return NotFound();
            }

            return dmTapChiTrongNuoc;
        }

        private bool DmTapChiTrongNuocExists(int id)
        {
            return _context.DmTapChiTrongNuocs.Any(e => e.IdTapChiTrongNuoc == id);
        }
    }
}
