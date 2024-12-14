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
    public class vToChucKiemDinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public vToChucKiemDinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VToChucKiemDinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VToChucKiemDinh>>> GetVToChucKiemDinhs()
        {
            return await _context.VToChucKiemDinhs.ToListAsync();
        }

        // GET: api/VToChucKiemDinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VToChucKiemDinh>> GetVToChucKiemDinh(int id)
        {
            var VToChucKiemDinh = await _context.VToChucKiemDinhs.FindAsync(id);

            if (VToChucKiemDinh == null)
            {
                return NotFound();
            }

            return VToChucKiemDinh;
        }

    }
}
