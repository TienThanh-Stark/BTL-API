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
    public class vToChucHopTacQuocTeController : ControllerBase
    {
        private readonly HemisContext _context;

        public vToChucHopTacQuocTeController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VToChucHopTacQuocTe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VToChucHopTacQuocTe>>> GetVToChucHopTacQuocTes()
        {
            return await _context.VToChucHopTacQuocTes.ToListAsync();
        }

        // GET: api/VToChucHopTacQuocTe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VToChucHopTacQuocTe>> GetVToChucHopTacQuocTe(int id)
        {
            var VToChucHopTacQuocTe = await _context.VToChucHopTacQuocTes.FindAsync(id);

            if (VToChucHopTacQuocTe == null)
            {
                return NotFound();
            }

            return VToChucHopTacQuocTe;
        }

  
    }
}
