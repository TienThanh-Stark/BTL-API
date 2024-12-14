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
    public class NganhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public NganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNganhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNganhDaoTao>>> GetDmNganhDaoTaos()
        {
            return await _context.DmNganhDaoTaos.ToListAsync();
        }

        // GET: api/DmNganhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNganhDaoTao>> GetDmNganhDaoTao(int id)
        {
            var dmNganhDaoTao = await _context.DmNganhDaoTaos.FindAsync(id);

            if (dmNganhDaoTao == null)
            {
                return NotFound();
            }

            return dmNganhDaoTao;
        }

        private bool DmNganhDaoTaoExists(int id)
        {
            return _context.DmNganhDaoTaos.Any(e => e.IdNganhDaoTao == id);
        }
    }
}
