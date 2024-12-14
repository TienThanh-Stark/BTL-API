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
    public class CoQuanBanHanhController : ControllerBase
    {
        private readonly HemisContext _context;

        public CoQuanBanHanhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmCoQuanBanHanh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmCoQuanBanHanh>>> GetDmCoQuanBanHanhs()
        {
            return await _context.DmCoQuanBanHanhs.ToListAsync();
        }

        // GET: api/DmCoQuanBanHanh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmCoQuanBanHanh>> GetDmCoQuanBanHanh(int id)
        {
            var dmCoQuanBanHanh = await _context.DmCoQuanBanHanhs.FindAsync(id);

            if (dmCoQuanBanHanh == null)
            {
                return NotFound();
            }

            return dmCoQuanBanHanh;
        }

        private bool DmCoQuanBanHanhExists(int id)
        {
            return _context.DmCoQuanBanHanhs.Any(e => e.IdCoQuanBanHanh == id);
        }
    }
}
