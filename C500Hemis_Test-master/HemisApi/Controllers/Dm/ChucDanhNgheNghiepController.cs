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
    public class ChucDanhNgheNghiepController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhNgheNghiepController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChucDanhNgheNghiep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucDanhNgheNghiep>>> GetDmChucDanhNgheNghieps()
        {
            return await _context.DmChucDanhNgheNghieps.ToListAsync();
        }

        // GET: api/DmChucDanhNgheNghiep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucDanhNgheNghiep>> GetDmChucDanhNgheNghiep(int id)
        {
            var dmChucDanhNgheNghiep = await _context.DmChucDanhNgheNghieps.FindAsync(id);

            if (dmChucDanhNgheNghiep == null)
            {
                return NotFound();
            }

            return dmChucDanhNgheNghiep;
        }

        private bool DmChucDanhNgheNghiepExists(int id)
        {
            return _context.DmChucDanhNgheNghieps.Any(e => e.IdChucDanhNgheNghiep == id);
        }
    }
}
