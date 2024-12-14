using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class vBaiBaoKHDaCongBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public vBaiBaoKHDaCongBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VBaiBaoKHDaCongBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VBaiBaoKhdaCongBo>>> GetVBaiBaoKHDaCongBos()
        {
            return await _context.VBaiBaoKhdaCongBos.ToListAsync();
        }

        // GET: api/VBaiBaoKHDaCongBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VBaiBaoKhdaCongBo>> GetVBaiBaoKHDaCongBo(int id)
        {
            var VBaiBaoKHDaCongBo = await _context.VBaiBaoKhdaCongBos.FindAsync(id);

            if (VBaiBaoKHDaCongBo == null)
            {
                return NotFound();
            }

            return VBaiBaoKHDaCongBo;
        }

    }
}
