using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CTDT
{
    [Route("api/ctdt/[controller]")]
    [ApiController]
    public class vNamApdungChuongTrinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public vNamApdungChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VNamApdungChuongTrinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VNamApdungChuongTrinh>>> GetVNamApdungChuongTrinhs()
        {
            return await _context.VNamApdungChuongTrinhs.ToListAsync();
        }

        // GET: api/VNamApdungChuongTrinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VNamApdungChuongTrinh>> GetVNamApdungChuongTrinh(int id)
        {
            var VNamApdungChuongTrinh = await _context.VNamApdungChuongTrinhs.FindAsync(id);

            if (VNamApdungChuongTrinh == null)
            {
                return NotFound();
            }

            return VNamApdungChuongTrinh;
        }

        
    }
}
