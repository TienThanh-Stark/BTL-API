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
    public class vCoSoGiaoDucController : ControllerBase
    {
        private readonly HemisContext _context;

        public vCoSoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VCoSoGiaoDuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VCoSoGiaoDuc>>> GetVCoSoGiaoDucs()
        {
            return await _context.VCoSoGiaoDucs.ToListAsync();
        }

        // GET: api/VCoSoGiaoDuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VCoSoGiaoDuc>> GetVCoSoGiaoDuc(int id)
        {
            var VCoSoGiaoDuc = await _context.VCoSoGiaoDucs.FindAsync(id);

            if (VCoSoGiaoDuc == null)
            {
                return NotFound();
            }

            return VCoSoGiaoDuc;
        }

       
    }
}
