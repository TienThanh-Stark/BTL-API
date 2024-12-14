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
    public class HocCheDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public HocCheDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHocCheDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHocCheDaoTao>>> GetDmHocCheDaoTaos()
        {
            return await _context.DmHocCheDaoTaos.ToListAsync();
        }

        // GET: api/DmHocCheDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHocCheDaoTao>> GetDmHocCheDaoTao(int id)
        {
            var dmHocCheDaoTao = await _context.DmHocCheDaoTaos.FindAsync(id);

            if (dmHocCheDaoTao == null)
            {
                return NotFound();
            }

            return dmHocCheDaoTao;
        }

        private bool DmHocCheDaoTaoExists(int id)
        {
            return _context.DmHocCheDaoTaos.Any(e => e.IdHocCheDaoTao == id);
        }
    }
}
