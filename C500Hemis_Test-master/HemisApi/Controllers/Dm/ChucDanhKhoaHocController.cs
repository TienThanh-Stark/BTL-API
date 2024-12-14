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
    public class ChucDanhKhoaHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChucDanhKhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucDanhKhoaHoc>>> GetDmChucDanhKhoaHocs()
        {
            return await _context.DmChucDanhKhoaHocs.ToListAsync();
        }

        // GET: api/DmChucDanhKhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucDanhKhoaHoc>> GetDmChucDanhKhoaHoc(int id)
        {
            var dmChucDanhKhoaHoc = await _context.DmChucDanhKhoaHocs.FindAsync(id);

            if (dmChucDanhKhoaHoc == null)
            {
                return NotFound();
            }

            return dmChucDanhKhoaHoc;
        }

        private bool DmChucDanhKhoaHocExists(int id)
        {
            return _context.DmChucDanhKhoaHocs.Any(e => e.IdChucDanhKhoaHoc == id);
        }
    }
}
