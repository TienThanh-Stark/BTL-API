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
    public class vDoanCongTacController : ControllerBase
    {
        private readonly HemisContext _context;

        public vDoanCongTacController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VDoanCongTac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDoanCongTac>>> GetVDoanCongTacs()
        {
            return await _context.VDoanCongTacs.ToListAsync();
        }

        // GET: api/VDoanCongTac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDoanCongTac>> GetVDoanCongTac(int id)
        {
            var VDoanCongTac = await _context.VDoanCongTacs.FindAsync(id);

            if (VDoanCongTac == null)
            {
                return NotFound();
            }

            return VDoanCongTac;
        }

    }
}
