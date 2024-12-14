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
    public class CoQuanChuQuanController : ControllerBase
    {
        private readonly HemisContext _context;

        public CoQuanChuQuanController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmCoQuanChuQuan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmCoQuanChuQuan>>> GetDmCoQuanChuQuans()
        {
            return await _context.DmCoQuanChuQuans.ToListAsync();
        }

        // GET: api/DmCoQuanChuQuan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmCoQuanChuQuan>> GetDmCoQuanChuQuan(int id)
        {
            var dmCoQuanChuQuan = await _context.DmCoQuanChuQuans.FindAsync(id);

            if (dmCoQuanChuQuan == null)
            {
                return NotFound();
            }

            return dmCoQuanChuQuan;
        }

        private bool DmCoQuanChuQuanExists(int id)
        {
            return _context.DmCoQuanChuQuans.Any(e => e.IdCoQuanChuQuan == id);
        }
    }
}
