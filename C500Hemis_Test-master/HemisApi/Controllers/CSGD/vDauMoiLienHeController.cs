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
    public class vDauMoiLienHeController : ControllerBase
    {
        private readonly HemisContext _context;

        public vDauMoiLienHeController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VDauMoiLienHe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDauMoiLienHe>>> GetVDauMoiLienHes()
        {
            return await _context.VDauMoiLienHes.ToListAsync();
        }

        // GET: api/VDauMoiLienHe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDauMoiLienHe>> GetVDauMoiLienHe(int id)
        {
            var VDauMoiLienHe = await _context.VDauMoiLienHes.FindAsync(id);

            if (VDauMoiLienHe == null)
            {
                return NotFound();
            }

            return VDauMoiLienHe;
        }

       
    }
}
