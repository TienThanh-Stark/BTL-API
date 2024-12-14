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
    public class vToChucHopTacDoanhNghiepController : ControllerBase
    {
        private readonly HemisContext _context;

        public vToChucHopTacDoanhNghiepController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VToChucHopTacDoanhNghiep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VToChucHopTacDoanhNghiep>>> GetVToChucHopTacDoanhNghieps()
        {
            return await _context.VToChucHopTacDoanhNghieps.ToListAsync();
        }

        // GET: api/VToChucHopTacDoanhNghiep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VToChucHopTacDoanhNghiep>> GetVToChucHopTacDoanhNghiep(int id)
        {
            var VToChucHopTacDoanhNghiep = await _context.VToChucHopTacDoanhNghieps.FindAsync(id);

            if (VToChucHopTacDoanhNghiep == null)
            {
                return NotFound();
            }

            return VToChucHopTacDoanhNghiep;
        }

       
    }
}
