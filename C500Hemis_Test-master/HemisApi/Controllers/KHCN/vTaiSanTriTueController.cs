using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class vTaiSanTriTueController : ControllerBase
    {
        private readonly HemisContext _context;

        public vTaiSanTriTueController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VTaiSanTriTue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VTaiSanTriTue>>> GetVTaiSanTriTues()
        {
            return await _context.VTaiSanTriTues.ToListAsync();
        }

        // GET: api/VTaiSanTriTue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VTaiSanTriTue>> GetVTaiSanTriTue(int id)
        {
            var VTaiSanTriTue = await _context.VTaiSanTriTues.FindAsync(id);

            if (VTaiSanTriTue == null)
            {
                return NotFound();
            }

            return VTaiSanTriTue;
        }

    }
}
