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
    public class DaoTaoGdqpanController : ControllerBase
    {
        private readonly HemisContext _context;

        public DaoTaoGdqpanController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDaoTaoGdqpan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDaoTaoGdqpan>>> GetDmDaoTaoGdqpans()
        {
            return await _context.DmDaoTaoGdqpans.ToListAsync();
        }

        // GET: api/DmDaoTaoGdqpan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDaoTaoGdqpan>> GetDmDaoTaoGdqpan(int id)
        {
            var dmDaoTaoGdqpan = await _context.DmDaoTaoGdqpans.FindAsync(id);

            if (dmDaoTaoGdqpan == null)
            {
                return NotFound();
            }

            return dmDaoTaoGdqpan;
        }

        private bool DmDaoTaoGdqpanExists(int id)
        {
            return _context.DmDaoTaoGdqpans.Any(e => e.IdDaoTaoGdqpan == id);
        }
    }
}
