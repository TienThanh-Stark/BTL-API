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
    public class vCoCauToChucController : ControllerBase
    {
        private readonly HemisContext _context;

        public vCoCauToChucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VCoCauToChuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VCoCauToChuc>>> GetVCoCauToChucs()
        {
            return await _context.VCoCauToChucs.ToListAsync();
        }

        // GET: api/VCoCauToChuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VCoCauToChuc>> GetVCoCauToChuc(int id)
        {
            var VCoCauToChuc = await _context.VCoCauToChucs.FindAsync(id);

            if (VCoCauToChuc == null)
            {
                return NotFound();
            }

            return VCoCauToChuc;
        }

       
    }
}
