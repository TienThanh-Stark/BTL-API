using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class vKhoaHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public vKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VKhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VKhoaHoc>>> GetVKhoaHocs()
        {
            return await _context.VKhoaHocs.ToListAsync();
        }

        // GET: api/VKhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VKhoaHoc>> GetVKhoaHoc(int id)
        {
            var VKhoaHoc = await _context.VKhoaHocs.FindAsync(id);

            if (VKhoaHoc == null)
            {
                return NotFound();
            }

            return VKhoaHoc;
        }

    }
}
