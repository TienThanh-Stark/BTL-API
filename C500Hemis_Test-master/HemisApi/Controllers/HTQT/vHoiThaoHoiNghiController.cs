using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.HTQT
{
    [Route("api/htqt/[controller]")]
    [ApiController]
    public class vHoiThaoHoiNghiController : ControllerBase
    {
        private readonly HemisContext _context;

        public vHoiThaoHoiNghiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VHoiThaoHoiNghi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHoiThaoHoiNghi>>> GetVHoiThaoHoiNghis()
        {
            return await _context.VHoiThaoHoiNghis.ToListAsync();
        }

        // GET: api/VHoiThaoHoiNghi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VHoiThaoHoiNghi>> GetVHoiThaoHoiNghi(int id)
        {
            var VHoiThaoHoiNghi = await _context.VHoiThaoHoiNghis.FindAsync(id);

            if (VHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            return VHoiThaoHoiNghi;
        }

    }
}
